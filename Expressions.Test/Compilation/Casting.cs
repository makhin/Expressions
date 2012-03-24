﻿using System;
using System.Collections.Generic;
using System.Text;
using Expressions.Expressions;
using NUnit.Framework;

namespace Expressions.Test.Compilation
{
    [TestFixture]
    internal class Casting : TestBase
    {
        [Test]
        public void CastWithBuiltInFloat()
        {
            Resolve("cast(7, float)", 7.0f);
        }

        [Test]
        public void CastWithExpression()
        {
            Resolve("cast(1 + 2, float)", 3f);
        }

        [Test]
        public void CastingWithBuiltInStringArray()
        {
            Resolve("cast(null, string[])", null);
        }

        [Test]
        public void CastingWithBuiltInStringArrayRank2()
        {
            Resolve("cast(null, string[,])", null);
        }

        [Test]
        public void CastingWithBuiltInStringArrayRank3()
        {
            Resolve("cast(null, string[,,])", null);
        }

        [Test]
        public void CastingWithFullStringArray()
        {
            Resolve("cast(null, System.String[])", null);
        }

        [Test]
        public void CastingWithFullStringArrayRank2()
        {
            Resolve("cast(null, System.String[,])", null);
        }

        [Test]
        public void CastingWithFullStringArrayRank3()
        {
            Resolve("cast(null, System.String[,,])", null);
        }

        [Test]
        [ExpectedException]
        public void CastWithBuiltInString()
        {
            Resolve("cast(7, string)");
        }

        [Test]
        public void ImplicitOperator()
        {
            var context = new ExpressionContext();

            context.Variables.Add(new Variable("Owner") { Value = new Owner() });

            Resolve(
                context,
                "Owner",
                1.0,
                new BoundExpressionOptions
                {
                    ResultType = typeof(double)
                }
            );
        }

        public class Owner
        {
            public static implicit operator double(Owner value)
            {
                return 1.0;
            }
        }
    }
}
