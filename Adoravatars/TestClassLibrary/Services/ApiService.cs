using System;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace AdorableData.Services
{
    public class ApiService:IApiService
    {
        public DownloadOperation GetFile(Uri uri, StorageFile file)
        {
            var downloader = new BackgroundDownloader();

            return  downloader.CreateDownload(uri, file);
        }
    }
}