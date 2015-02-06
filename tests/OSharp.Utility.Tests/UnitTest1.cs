using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OSharp.Utility.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Type type = typeof(String);
            Assert.IsTrue(!type.IsValueType);
        }
    }
}
