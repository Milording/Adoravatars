
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdorableTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sum = Add(2, 2);
        }

        private int Add(int x, int y)
            => x + y;
    }
}
