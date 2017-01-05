using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Expressions.Test.FleeLanguage.Compilation
{
    [TestFixture]
    internal class CompilationFailures : TestBase
    {
        [Test]
        public void InfiniteLoop()
        {
            Assert.Throws(typeof(ExpressionsException), delegate
                {
                    Resolve("true && false");
                }
            );
        }
    }
}
