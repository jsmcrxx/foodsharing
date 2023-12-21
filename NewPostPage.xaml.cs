using foodsharing.Models;
using foodsharing.ViewModels;
using Xamarin.Forms;

namespace foodsharing.Views
{	
	public partial class NewPostPage : ContentPage
	{
        public Post Post { get; set; }

        public NewPostPage()
        {
            InitializeComponent();

            // Команда соединяет страницу с соответсвующей ViewModel
            BindingContext = new NewPostViewModel();
        }
    }
}

