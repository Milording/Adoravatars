using System;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace AdorableData.Services
{
    public interface IApiService
    {
        DownloadOperation GetFile(Uri uri, StorageFile file);
    }
}
