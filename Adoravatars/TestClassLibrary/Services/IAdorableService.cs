﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AdorableData.Services
{
    public interface IAdorableService
    {
        Task<BitmapImage> GetAvatar(string avatarName);
        List<string> GetAvatarNames();
    }
}
