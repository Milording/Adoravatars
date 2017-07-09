using System.Threading.Tasks;
using Windows.Storage;

namespace AdorableData.Services
{
    public interface IStorageService
    {
        Task<StorageFile> CreateFile(string filename);
    }
}
