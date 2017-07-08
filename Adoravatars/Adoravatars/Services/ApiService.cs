using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace Adoravatars.Services
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
