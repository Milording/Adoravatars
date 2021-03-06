﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using AdorableData.Services;
using Adoravatars.Utils;
using Caliburn.Micro;
using AdorableData.ViewModels;

namespace Adoravatars.ViewModels
{
    public class AvatarViewModel : Screen
    {
        #region Services

        private readonly IAdorableService _adorableService;

        #endregion

        #region Bindable properties

        private ObservableCollection<AvatarKitViewModel> _avatarCollection;

        public ObservableCollection<AvatarKitViewModel> AvatarCollection
        {
            get => _avatarCollection;
            set
            {
                _avatarCollection = value;
                NotifyOfPropertyChange(nameof(AvatarCollection));
            }
        }

        #endregion

        public AvatarViewModel(IAdorableService adorableService)
        {
            _adorableService = adorableService;

            AvatarCollection = new ObservableCollection<AvatarKitViewModel>();
        }


        #region Overrided methods

        protected override async void OnActivate()
        {
            var avatarNames = _adorableService.GetAvatarNames();
            foreach (var avatarName in avatarNames)
            {
                var avatar = new AvatarKitViewModel(_adorableService, avatarName);

                avatar.Load();

                AvatarCollection.Add(avatar);
            }
        }

        #endregion
    }
}