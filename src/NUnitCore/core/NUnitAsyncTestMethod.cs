using System;
using System.Reflection;
using NUnit.Framework;

namespace NUnit.Core
{
    public class NUnitAsyncTestMethod : NUnitTestMethod
    {
	    public NUnitAsyncTestMethod(MethodInfo method) : base(method)
        {
            if (method.ReturnType == typeof(void))
                Compatibility.Error(method.ReflectedType + "." + method.Name, "Async void test methods are no longer supported. Use async Task instead.");
        }

        protected override object RunTestMethod()
        {
			using (AsyncInvocationRegion region = AsyncInvocationRegion.Create(method))
			{
				object result = base.RunTestMethod();

				try
				{
					return region.WaitForPendingOperationsToComplete(result);
				}
				catch (Exception e)
				{
					throw new NUnitException("Rethrown", e);
				}
			}
        }
    }
}