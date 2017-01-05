using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Expressions.Test.FleeLanguage.Parsing
{
    [TestFixture]
    internal class Parsing
    {
        [Test]
        public void ValidSyntaxCheck()
        {
            DynamicExpression.CheckSyntax(
                "1", ExpressionLanguage.Flee
            );
        }

        [Test]
        public void InvalidSyntaxCheck()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
            {
                DynamicExpression.CheckSyntax(
                    "?", ExpressionLanguage.Flee
                );
            });
        }
    }
}
