using foodsharing.ViewModels;
using Xamarin.Forms;

namespace foodsharing.Views
{	
	public partial class PostDetail : ContentPage
	{

		public PostDetail ()
		{
			InitializeComponent ();

            // Команда соединяет страницу с соответсвующей ViewModel
            BindingContext = new PostDetailViewModel();
        }
    }
}

