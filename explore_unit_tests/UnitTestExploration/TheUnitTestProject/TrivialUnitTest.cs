using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibToTest;

namespace TheUnitTestProject
{
    [TestClass]
    public class TrivialUnitTest
    {
        [TestMethod]
        public void TrivialTestMethod()
        {
            Assert.AreEqual(3, new AdderObject().add(1,2));
        }
    }
}
