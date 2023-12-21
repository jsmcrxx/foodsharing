using Xamarin.Forms;
using foodsharing.ViewModels;

namespace foodsharing.Views
{
    public partial class PostsPage : ContentPage
    {
        PostViewModel _viewModel;

        public PostsPage()
        {
            
            InitializeComponent();
            // Команда соединяет страницу с соответсвующей ViewModel
            BindingContext = _viewModel = new PostViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}

