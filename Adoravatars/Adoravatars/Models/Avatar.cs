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
    public class Avatar : PropertyChangedBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        private StorageFile _file;

        public StorageFile File
        {
            get => _file;
            set
            {
                _file = value;
                NotifyOfPropertyChange(nameof(File));
            }
        }

        private DownloadOperation _downloadOperation;

        public DownloadOperation DownloadOperation
        {
            get => _downloadOperation;
            set
            {
                _downloadOperation = value;
                NotifyOfPropertyChange(nameof(DownloadOperation));
            }

        }

        private DownloadState _downloadState;

        public DownloadState DownloadState
        {
            get => _downloadState;
            set
            {
                _downloadState = value;
                NotifyOfPropertyChange(nameof(DownloadState));
            }

        }

        private BitmapImage _image;

        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
                NotifyOfPropertyChange(nameof(Image));
            }

        }
    }

    public enum DownloadState
    {
        Started,
        Completed,
        Error
    }
}
