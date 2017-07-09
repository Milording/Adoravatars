using System;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace TestClassLibrary.Services
{
    public interface IApiService
    {
        DownloadOperation GetFile(Uri uri, StorageFile file);
    }
}
