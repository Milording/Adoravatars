using Windows.UI.Xaml.Media.Imaging;
using Caliburn.Micro;

namespace AdorableData.Models
{
    public class Avatar: PropertyChangedBase
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
}
