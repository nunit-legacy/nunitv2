// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework.Constraints;

#if CLR_2_0 || CLR_4_0
using System.Collections.Generic;
#endif

namespace NUnit.Framework.Syntax
{
    [TestFixture]
    public class ArbitraryConstraintMatching
    {
        Constraint custom = new CustomConstraint();
        Constraint another = new AnotherConstraint();

        [Test]
        public void CanMatchCustomConstraint()
        {
            IResolveConstraint constraint = new ConstraintExpression().Matches(custom);
            Assert.That(constraint.Resolve().ToString(), Is.EqualTo("<custom>"));
        }

        [Test]
        public void CanMatchCustomConstraintAfterPrefix()
        {
            IResolveConstraint constraint = Is.All.Matches(custom);
            Assert.That(constraint.Resolve().ToString(), Is.EqualTo("<all <custom>>"));
        }

        [Test]
        public void CanMatchCustomConstraintsUnderAndOperator()
        {
            IResolveConstraint constraint = Is.All.Matches(custom).And.Matches(another);
            Assert.That(constraint.Resolve().ToString(), Is.EqualTo("<all <and <custom> <another>>>"));
        }

#if CLR_2_0 || CLR_4_0
        [Test]
        public void CanMatchPredicate()
        {
            IResolveConstraint constraint = new ConstraintExpression().Matches(new Predicate<int>(IsEven));
            Assert.That(constraint.Resolve().ToString(), Is.EqualTo("<predicate>"));
            Assert.That(42, constraint);
        }

        bool IsEven(int num)
        {
            return (num & 1) == 0;
        }

#if CS_3_0 || CS_4_0 || CS_5_0
        [Test]
        public void CanMatchLambda()
        {
            IResolveConstraint constraint = new ConstraintExpression().Matches<int>( (x) => (x & 1) == 0);
            Assert.That(constraint.Resolve().ToString(), Is.EqualTo("<predicate>"));
            Assert.That(42, constraint);
        }
#endif
#endif

        class CustomConstraint : Constraint
        {
            public override bool Matches(object actual)
            {
                throw new NotImplementedException();
            }

            public override void WriteDescriptionTo(MessageWriter writer)
            {
                throw new NotImplementedException();
            }
        }

        class AnotherConstraint : CustomConstraint
        {
        }

#if CLR_2_0 || CLR_4_0
        [Test]
        public void ApplyMatchesToProperty()
        {
            var unit = new Unit();

            // All forms should pass
            Assert.That(unit, Has.Property("Items").With.Property("Count").EqualTo(5));
            Assert.That(unit, Has.Property("Items").With.Count.EqualTo(5));
            Assert.That(unit, Has.Property("Items").Property("Count").EqualTo(5));
            Assert.That(unit, Has.Property("Items").Count.EqualTo(5));

            // This is the one the bug refers to
            Assert.That(unit, Has.Property("Items").Matches(Has.Count.EqualTo(5)));
        }

        private class Unit
        {
            public List<int> Items { get; private set; }
            public Unit()
            {
                Items = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            }
        }
#endif
    }
}
