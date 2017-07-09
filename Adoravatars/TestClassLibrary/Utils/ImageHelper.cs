using System;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;
using TestClassLibrary.Services;

namespace TestClassLibrary.Utils
{
    public static  class ImageHelper
    {
        public static async void ConvertStorageFileToImage(ImageDescriptor descriptor)
        {
            using (var stream = (FileRandomAccessStream) await descriptor.File.OpenAsync(FileAccessMode.Read))
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(stream);
                    descriptor.Image = bitmapImage;
                });

            }
        }
    }
}
