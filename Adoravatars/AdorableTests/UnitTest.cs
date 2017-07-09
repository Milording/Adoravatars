
using System;
using System.Threading.Tasks;
using AdorableData.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
