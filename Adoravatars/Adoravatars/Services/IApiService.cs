using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace Adoravatars.Services
{
    public interface IApiService
    {
        DownloadOperation GetFile(Uri uri, StorageFile file);
    }
}
