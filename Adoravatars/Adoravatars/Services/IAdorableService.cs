using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adoravatars.Models;

namespace Adoravatars.Services
{
    public interface IAdorableService
    {
        Task<Avatar> GetAvatar(string avatarName);
        List<string> GetAvatarNames();
    }

    
}
