
using System;
using System.Threading.Tasks;
using AdorableData.Services;
using AdorableData.ViewModels;
using Adoravatars.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdorableTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestAvatrnameNull()
        {
            var avatarKit = new AvatarKitViewModel(new AdorableService(new ApiService(), new StorageService()), null);

            await avatarKit.Load();

            Assert.AreEqual(avatarKit.DownloadState, DownloadState.Error);
        }

        [TestMethod]
        public async Task TestAvatrnameIsOk()
        {
            var avatarKit = new AvatarKitViewModel(new AdorableService(new ApiService(), new StorageService()), "Nick");

            await avatarKit.Load();

            Assert.AreEqual(avatarKit.DownloadState, DownloadState.Completed);
        }
    }
}
