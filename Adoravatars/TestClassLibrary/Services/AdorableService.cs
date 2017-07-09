using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using TestClassLibrary.Utils;

namespace TestClassLibrary.Services
{
    public class AdorableService:IAdorableService
    {
        private readonly IApiService _apiService;
        private readonly IStorageService _storageService;

        private string _apiAddress = "https://api.adorable.io/avatars/285/";
        private string _extension = ".png";

        private List<string> _avatarNames = new List<string> {
            "Luke Skywalker", "C-3PO", "R2-D2", "Darth Vader", "Leia Organa", "Owen Lars", "Beru Whitesun lars", "R5-D4", "Biggs Darklighter", "Obi-Wan Kenobi", "Anakin Skywalker", "Wilhuff Tarkin", "Chewbacca", "Han Solo", "Greedo", "Jabba Desilijic Tiure", "Wedge Antilles", "Jek Tono Porkins", "Yoda", "Palpatine", "Boba Fett", "IG-88", "Bossk", "Lando Calrissian", "Lobot", "Ackbar", "Mon Mothma", "Arvel Crynyd", "Wicket Systri Warrick", "Nien Nunb", "Qui-Gon Jinn", "Nute Gunray", "Finis Valorum", "Jar Jar Binks", "Roos Tarpals", "Rugor Nass", "Ric Olié", "Watto", "Sebulba", "Quarsh Panaka", "Shmi Skywalker", "Darth Maul", "Bib Fortuna", "Ayla Secura", "Dud Bolt", "Gasgano", "Ben Quadinaros", "Mace Windu", "Ki-Adi-Mundi", "Kit Fisto", "Eeth Koth", "Adi Gallia", "Saesee Tiin", "Yarael Poof", "Plo Koon", "Mas Amedda", "Gregar Typho", "Cordé", "Cliegg Lars", "Poggle the Lesser", "Luminara Unduli", "Barriss Offee", "Dormé", "Dooku", "Bail Prestor Organa", "Jango Fett", "Zam Wesell", "Dexter Jettster", "Lama Su", "Taun We", "Jocasta Nu", "Ratts Tyerell", "R4-P17", "Wat Tambor", "San Hill", "Shaak Ti", "Grievous", "Tarfful", "Raymus Antilles", "Sly Moore", "Tion Medon", "Finn", "Rey", "Poe Dameron", "BB8", "Captain Phasma", "Padmé Amidala" };
        
        public AdorableService(IApiService apiService, IStorageService storageService)
        {
            _apiService = apiService;
            _storageService = storageService;
        }

        public async Task<BitmapImage> GetAvatar(string avatarName)
        {
            var file = await _storageService.CreateFile(avatarName + _extension);
            
            var downloadOperation = _apiService.GetFile(new Uri(_apiAddress + avatarName + _extension), file);

            var descriptor = new ImageDescriptor
            {
                File = file
            };

            downloadOperation.StartAsync().AsTask()
                .ContinueWith(p => OnCompleted(p, descriptor));

            return descriptor.Image;
        }

        private void OnCompleted(Task<DownloadOperation> task, ImageDescriptor descriptor)
        {
            var resultFile = task.Result.ResultFile;

            if (resultFile == null) return;
            
            ImageHelper.ConvertStorageFileToImage(descriptor);
        }

        public List<string> GetAvatarNames()
        {
            return _avatarNames;
        }
    }

    public class ImageDescriptor
    {
        public StorageFile File { get; set; }

        public BitmapImage Image { get; set; }  
    }
}