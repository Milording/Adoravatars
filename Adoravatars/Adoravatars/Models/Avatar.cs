using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Caliburn.Micro;

namespace Adoravatars.Models
{
    public class Avatar:PropertyChangedBase
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        private StorageFile _file;
        public StorageFile File
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
                NotifyOfPropertyChange(nameof(File));
            }
        }

        private DownloadOperation _downloadOperation;
        public DownloadOperation DownloadOperation
        {
            get
            {
                return _downloadOperation;
            }
            set
            {
                _downloadOperation = value;
                NotifyOfPropertyChange(nameof(DownloadOperation));
            }

        }


        private BitmapImage _image;
        public BitmapImage Image {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                NotifyOfPropertyChange(nameof(Windows.UI.Xaml.Controls.Image));
            }

        }
    }
}
