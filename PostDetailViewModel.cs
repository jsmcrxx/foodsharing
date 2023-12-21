using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Essentials;

// ViewModel для страницы описания объявления "PostsDetail"

namespace foodsharing.ViewModels
{
    [QueryProperty(nameof(PostId), nameof(PostId))]
    public class PostDetailViewModel : BaseViewModel
    {
        public PostDetailViewModel()
        {
            // Здесь присваивается значение команды звонка
            DialCommand = new Command(OnDialClicked);
        }

        // Далее написана команда для совершения звонка
        public Command DialCommand { get; }
        private void OnDialClicked(object obj)
        {
            PhoneDialer.Open(PhoneNumber);
        }

        // Объявление строк.
        private string postId;
        private string postname;
        private string phonenumder;
        private string username;
        private string adress;
        private string description;
        private string imageurl;
        public string Id { get; set; }


        // В данной части кода присваиваются значения соответсвующим строкам.
        public string ImageUrl
        {
            get => imageurl;
            set => SetProperty(ref imageurl, value);
        }

        public string PostName
        {
            get => postname;
            set => SetProperty(ref postname, value);
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

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PostId
        {
            get
            {
                return postId;
            }
            set
            {
                postId = value;
                LoadPostId(value);
            }
        }

        // Команда для вызова определенного объявления из коллекции.
        public async void LoadPostId(string postId)
        {
            try
            {
                var post = await DataStore.GetPostAsync(postId);
                Id = post.Id;
                PostName = post.PostName;
                Description = post.Description;
                ImageUrl = post.ImageUrl;
                Adress = post.Adress;
                UserName = post.UserName;
                PhoneNumber = post.PhoneNumder;
            }
            catch (Exception)
            {
                Debug.WriteLine("Не удалось загрузить объявление");
            }
        }
    }
}



