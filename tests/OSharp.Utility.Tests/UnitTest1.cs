using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OSharp.Utility.IO;


namespace OSharp.Utility.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = @"D:\~1";
            DirectoryHelper.SetAttributes(path, FileAttributes.System, true);
            DirectoryHelper.SetAttributes(path, FileAttributes.Hidden, true);
        }
    }
}
