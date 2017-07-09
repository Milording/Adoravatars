using System.Threading.Tasks;
using AdorableData.Models;
using AdorableData.Services;
using Caliburn.Micro;

namespace AdorableData.ViewModels
{
    public class AvatarKitViewModel:PropertyChangedBase
    {
        private readonly IAdorableService _adorableService;
        
        private Avatar _avatar;
        public Avatar Avatar
        {
            get => _avatar;
            set
            {
                _avatar = value;
                NotifyOfPropertyChange(nameof(Avatar));
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

        public AvatarKitViewModel(IAdorableService adorableService, string avatarName)
        {
            _adorableService = adorableService;
            
            Avatar = new Avatar
            {
                Name = avatarName
            };
        }

        public async Task Load()
        {
            DownloadState = DownloadState.Started;

            var image = await _adorableService.GetAvatar(Avatar.Name);
            Avatar.Image = image;

            DownloadState = DownloadState.Completed;
        }
    }
}
