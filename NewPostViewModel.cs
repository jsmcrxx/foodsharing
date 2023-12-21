using System;
using foodsharing.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.IO;

// ViewModel для страницы добавления нового объявления "NewPostPage".

namespace foodsharing.ViewModels
{
    public class NewPostViewModel : BaseViewModel
    {
        // Объявляем строки.
        private string postname;
        private string phonenumder;
        private string username;
        private string adress;
        private string description;
        private string imageurl;

        public NewPostViewModel()
        {
            // Присваиваем значение команде сохранения объявления "SaveCommand".
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        // Функция для команды сохранения, не позволяющая сохранить объявление, не заполнив соотвествующие строки. 
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(postname)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(username)
                && !String.IsNullOrWhiteSpace(adress)
                && !String.IsNullOrWhiteSpace(phonenumder);
        }

        // В данной части кода присваиваются значения соответсвующим строкам.
        public string PostName
        {
            get => postname;
            set => SetProperty(ref postname, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PhoneNumber
        {
            get => phonenumder;
            set => SetProperty(ref phonenumder, value);
        }

        public string UserName
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Adress
        {
            get => adress;
            set => SetProperty(ref adress, value);
        }

        public string ImageUrl
        {
            get => imageurl;
            set => SetProperty(ref imageurl, value);
        }


        // В данной части написана команда для прикрепления фото к новому объявлению
        public Command PickImage
        {
            get
            {
                return new Command(async (e) =>
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    var stream = await LoadPhotoAsync(photo);
                });
            }
        }

        async Task<Stream> LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                return null;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            var stream = await photo.OpenReadAsync();
            MediaPath = photo.FullPath;
            return stream;
        }

        string _mediaPath;
        public string MediaPath
        {
            get { return _mediaPath; }
            set
            {
                if (value !=null)
                {
                    _mediaPath = value;
                    OnPropertyChanged();
                }
            }
        }

        // В данной части напиасана команда добавления объявления.
        public Command SaveCommand { get; }

        private async void OnSave()
        {
            Post newPost = new Post()
            {
                Id = Guid.NewGuid().ToString(),
                PostName = PostName,
                Description = Description,
                ImageUrl = MediaPath,
                Adress = Adress,
                UserName = UserName,
                PhoneNumder = PhoneNumber
            
            };

            await DataStore.AddPostAsync(newPost);

            await Shell.Current.GoToAsync("///PostsPage");

            PostName = "";
            Description = "";
            ImageUrl = "";
            Adress = "";
            UserName = "";
            PhoneNumber = "";
            MediaPath="";

        }
    }
}