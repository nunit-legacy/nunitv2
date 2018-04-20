// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using System.Reflection;

namespace NUnit.Core.Builders
{
    class ProviderReference
    {
        public ProviderReference(Type providerType, string providerName, string category)
        {
            if (providerType == null)
                throw new ArgumentNullException("providerType");
            if (providerName == null && providerType.GetInterface("System.Collections.IEnumerable") == null)
                throw new ArgumentNullException("providerName");

            ProviderType = providerType;
            ProviderName = providerName;
            ProviderLocation = providerType.FullName + "." + providerName;
            ProviderCategory = category;
        }

        public ProviderReference(Type providerType, object[] args, string providerName, string category)
            : this(providerType, providerName, category)
        {
            ProviderArgs = args;
        }

        public Type ProviderType { get; private set; }

        public string ProviderName { get; private set; }

        public object[] ProviderArgs { get; private set; }

        public string ProviderLocation { get; private set; }

        public string ProviderCategory { get; private set; }

        public IEnumerable GetInstance()
        {
            if (ProviderName != null)
            {
                MemberInfo[] members = ProviderType.GetMember(
                    ProviderName,
                    MemberTypes.Field | MemberTypes.Method | MemberTypes.Property,
                    BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (members.Length == 0)
                    throw new Exception(string.Format(
                        "Unable to locate {0}.{1}", ProviderType.FullName, ProviderName));

                return (IEnumerable)GetProviderObjectFromMember(members[0]);
            }
            else
                return Reflect.Construct(ProviderType) as IEnumerable;
        }

        private object GetProviderObjectFromMember(MemberInfo member)
        {
            object providerObject = null;
            object instance = null;

            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    PropertyInfo providerProperty = member as PropertyInfo;
                    MethodInfo getMethod = providerProperty.GetGetMethod(true);
                    if (!getMethod.IsStatic)
                        //instance = ProviderCache.GetInstanceOf(providerType);
                        instance = Reflect.Construct(ProviderType, ProviderArgs);
                    providerObject = providerProperty.GetValue(instance, null);
                    break;

                case MemberTypes.Method:
                    MethodInfo providerMethod = member as MethodInfo;
                    if (!providerMethod.IsStatic)
                        //instance = ProviderCache.GetInstanceOf(providerType);
                        instance = Reflect.Construct(ProviderType, ProviderArgs);
                    providerObject = providerMethod.Invoke(instance, null);
                    break;

                case MemberTypes.Field:
                    FieldInfo providerField = member as FieldInfo;
                    if (!providerField.IsStatic)
                        //instance = ProviderCache.GetInstanceOf(providerType);
                        instance = Reflect.Construct(ProviderType, ProviderArgs);
                    providerObject = providerField.GetValue(instance);
                    break;
            }

            return providerObject;
        }
    }
}
