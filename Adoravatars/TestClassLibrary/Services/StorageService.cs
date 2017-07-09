using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace TestClassLibrary.Services
{
    public class StorageService:IStorageService
    {
        private StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public Task<StorageFile> CreateFile(string filename)
            => _localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).AsTask();
    }
}
