using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;
using Adoravatars.Models;

namespace Adoravatars.Utils
{
    public static  class ImageHelper
    {
        public static async void ConvertStorageFileToImage(Avatar avatar)
        {
            using (var stream = (FileRandomAccessStream) await avatar.File.OpenAsync(FileAccessMode.Read))
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(stream);
                    avatar.Image = bitmapImage;
                });

            }
        }
    }
}
