using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace Adoravatars.Services
{
    public class StorageService:IStorageService
    {
        private StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public Task<StorageFile> CreateFile(string filename)
            => _localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).AsTask();
    }
}
