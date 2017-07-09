using System.Threading.Tasks;
using Windows.Storage;

namespace TestClassLibrary.Services
{
    public interface IStorageService
    {
        Task<StorageFile> CreateFile(string filename);
    }
}
