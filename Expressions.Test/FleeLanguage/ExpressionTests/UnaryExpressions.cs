using System;
using System.Collections.Generic;
using System.Text;
using Expressions.Expressions;
using NUnit.Framework;

namespace Expressions.Test.FleeLanguage.ExpressionTests
{
    [TestFixture]
    internal class UnaryExpressions : TestBase
    {
        [Test]
        public void UnaryPlus()
        {
            Resolve(
                "+1",
                new UnaryExpression(
                    new Constant(1),
                    typeof(int),
                    ExpressionType.Plus
                )
            );
        }

        [Test]
        public void UnaryMinus()
        {
            Resolve(
                "-1",
                new Constant(-1)
            );
        }

        [Test]
        public void IllegalUnaryPlus()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
            {
                Resolve(
                    "+\"\""
                );
            });
        }

        [Test]
        public void IllegalUnaryMinus()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
            {
                Resolve(
                    "-\"\""
                );
            });
        }

        [Test]
        public void UnaryNot()
        {
            Resolve(
                "not true",
                new UnaryExpression(
                    new Constant(true),
                    typeof(bool),
                    ExpressionType.Not
                )
            );
        }

        [Test]
        public void IllegalUnaryNot()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
            {
                Resolve(
                    "not \"\""
                );
            });
        }
    }
}
