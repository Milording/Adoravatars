using Windows.UI.Xaml.Media.Imaging;

namespace TestClassLibrary.Models
{
    public class Avatar
    {
        public string Name;

        public BitmapImage Image;
    }

    public enum DownloadState
    {
        Started,
        Completed,
        Error
    }
}
