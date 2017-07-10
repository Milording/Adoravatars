using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AdorableData.Models;
using AdorableData.Services;
using Caliburn.Micro;

namespace AdorableData.ViewModels
{
    public class AvatarKitViewModel : PropertyChangedBase
    {
        #region Private fields

        private readonly IAdorableService _adorableService;

        #endregion

        #region Bindable properties

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

        #endregion

        public AvatarKitViewModel(IAdorableService adorableService, string avatarName)
        {
            _adorableService = adorableService;

            Avatar = new Avatar
            {
                Name = avatarName
            };
        }

        #region Public methods

        public async Task Load()
        {
            DownloadState = DownloadState.Started;

            try
            {
                var image = await _adorableService.GetAvatar(Avatar.Name);
                Avatar.Image = image;

                DownloadState = DownloadState.Completed;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                DownloadState = DownloadState.Error;
            }
        }

        #endregion
    }

    public enum DownloadState
    {
        Started,
        Completed,
        Error
    }
}
