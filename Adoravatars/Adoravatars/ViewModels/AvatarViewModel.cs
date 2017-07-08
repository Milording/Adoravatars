using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Adoravatars.Models;
using Adoravatars.Services;
using Adoravatars.Utils;
using Caliburn.Micro;

namespace Adoravatars.ViewModels
{
    public class AvatarViewModel : Screen
    {
        private readonly IAdorableService _adorableService;
        public string Test => "It's ok";

        private ObservableCollection<Avatar> _avatarCollection;

        public ObservableCollection<Avatar> AvatarCollection
        {
            get { return _avatarCollection; }
            set
            {
                _avatarCollection = value;
                NotifyOfPropertyChange(nameof(AvatarCollection));
            }
        }

        public AvatarViewModel(IAdorableService adorableService)
        {
            _adorableService = adorableService;
        }

        protected override void OnInitialize()
        {
            AvatarCollection = new ObservableCollection<Avatar>();
        }

        protected override async void OnActivate()
        {
            var avatarNames = _adorableService.GetAvatarNames();
            foreach (var avatarName in avatarNames)
            {
                var avatar = await _adorableService.GetAvatar(avatarName);

                avatar.DownloadOperation.StartAsync().AsTask()
                    .ContinueWith(p => OnCompleted(p, avatar));
                

                AvatarCollection.Add(avatar);
            }
        }

        private void OnCompleted(Task<DownloadOperation> task, Avatar avatar)
        {
            var resultFile = task.Result.ResultFile;

            if (resultFile == null) return;

            avatar.DownloadState = DownloadState.Completed;

            avatar.File = (StorageFile)resultFile;

            ImageHelper.ConvertStorageFileToImage(avatar);
        }
    }
}
