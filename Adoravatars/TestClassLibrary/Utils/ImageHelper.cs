using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;
using AdorableData.Services;

namespace AdorableData.Utils
{
    public static  class ImageHelper
    {
        public static async Task<BitmapImage> ConvertStorageFileToImage(ImageDescriptor descriptor)
        {
            try
            {

                using (var stream = (FileRandomAccessStream) await descriptor.File.OpenAsync(FileAccessMode.Read))
                {
                    try
                    {
                        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                            () =>
                            {
                                var bitmapImage = new BitmapImage();
                                bitmapImage.SetSource(stream);
                                descriptor.Image = bitmapImage;
                            });
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }

            return descriptor.Image;
        }
    }
}
