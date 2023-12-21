using System;
using foodsharing.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using foodsharing.Views;

// ViewModel для страницы моих объявлений "MyPostsPage.

// На данной странице воссоздается код для главной старницы, чтобы тестово заполнить страницу моих объялений.

namespace foodsharing.ViewModels
{
    public class MyPostsViewModel : BaseViewModel
    {
        private Post _selectedPost;

        public ObservableCollection<Post> Posts { get; }
        public Command LoadPostsCommand { get; }
        public Command<Post> PostTapped { get; }

        public MyPostsViewModel()
        {
            Posts = new ObservableCollection<Post>();
            LoadPostsCommand = new Command(async () => await ExecuteLoadPostsCommand());
            PostTapped = new Command<Post>(OnPostSelected);
        }

        async Task ExecuteLoadPostsCommand()
        {
            IsBusy = true;

            try
            {
                Posts.Clear();
                var posts = await DataStore.GetPostsAsync(true);
                foreach (var post in posts)
                {
                    Posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPost = null;
        }

        public Post SelectedPost
        {
            get => _selectedPost;
            set
            {
                SetProperty(ref _selectedPost, value);
                OnPostSelected(value);
            }
        }

        private async void OnAddPost(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPostPage));
        }

        async void OnPostSelected(Post post)
        {
            if (post == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PostDetail)}?{nameof(PostDetailViewModel.PostId)}={post.Id}");
        }
    }
}