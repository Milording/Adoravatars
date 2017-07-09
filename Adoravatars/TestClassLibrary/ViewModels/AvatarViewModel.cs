using TestClassLibrary.Models;
using TestClassLibrary.Services;

namespace TestClassLibrary.ViewModels
{
    class AvatarViewModel
    {
        private readonly IAdorableService _adorableService;
        private readonly string _avatarName;
        public Avatar Avatar { get; set; }

        public DownloadState DownloadState;

        public AvatarViewModel(IAdorableService adorableService, string avatarName)
        {
            _adorableService = adorableService;
            _avatarName = avatarName;

            Avatar = new Avatar
            {
                Name = avatarName
            };
        }

        public async void Load()
        {
            DownloadState = DownloadState.Started;
            var image = await _adorableService.GetAvatar(_avatarName);
            Avatar.Image = image;

            DownloadState = DownloadState.Completed;
        }
    }
}
