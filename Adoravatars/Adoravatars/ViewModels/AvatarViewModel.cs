using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adoravatars.Services;
using Caliburn.Micro;

namespace Adoravatars.ViewModels
{
    public class AvatarViewModel:Screen
    {
        private readonly IAdorableService _adorableService;
        public string Test => "It's ok";

        public AvatarViewModel(IAdorableService adorableService)
        {
            _adorableService = adorableService;
        }
    }
}
