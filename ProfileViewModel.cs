using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using foodsharing.Views;

// ViewModel для страницы профиля "ProfilePage"

namespace foodsharing.ViewModels
{
	public class ProfileViewModel : BaseViewModel
	{
        // Объявляются команды
        public Command GoToMyPostsCommand { get; }
        public Command ExitAccountCommand { get; }

		public ProfileViewModel()
		{
            // Присваиваются значения командам
            GoToMyPostsCommand = new Command(GoToMyPostsClicked);
            ExitAccountCommand = new Command(ExitAccountClicked);

        }

        // Функция для команды "GoToMyPosts", которая отслылает пользователя на страницу "Мои объявления"
        private async void GoToMyPostsClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(MyPostsPage)}");
        }

        // Функция для команды "ExitAccount", которая выполняет выход из аккаунта и отсылает пользователя на страницу входа 
        private async void ExitAccountClicked(object obj)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        // Далее написана команда для установки фото в профиле
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
                if (value != null)
                {
                    _mediaPath = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

