using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Expressions.Test.FleeLanguage.ExpressionTests
{
    [TestFixture]
    internal class VoidMethods : TestBase
    {
        [Test]
        public void VoidMethodsAreInvisible()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
            {
                Resolve(
                    new ExpressionContext(null, new Owner()),
                    "VoidMethod()"
                );
            });
        }

        public class Owner
        {
            public void VoidMethod()
            {
            }
        }
    }
}
