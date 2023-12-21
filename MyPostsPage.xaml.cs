using Xamarin.Forms;
using foodsharing.ViewModels;

namespace foodsharing.Views
{
    public partial class MyPostsPage : ContentPage
    {
        MyPostsViewModel _viewModel;

        public MyPostsPage()
        {

            InitializeComponent();

            // Команда соединяет страницу с соответсвующей ViewModel
            BindingContext = _viewModel = new MyPostsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}

