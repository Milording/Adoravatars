
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestClassLibrary;
using TestClassLibrary.Services;

namespace AdorableTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            StorageService ss = new StorageService();
            var file = await ss.CreateFile("test.png");
            
            Assert.IsNotNull(file);
        }

        private int Add(int x, int y)
            => x + y;
    }
}
