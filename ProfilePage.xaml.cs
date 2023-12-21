using foodsharing.ViewModels;
using Xamarin.Forms;

namespace foodsharing.Views
{	
	public partial class ProfilePage : ContentPage
	{	
		public ProfilePage ()
		{
			InitializeComponent ();

            // Команда соединяет страницу с соответсвующей ViewModel
            BindingContext = new ProfileViewModel();
		}
	}
}

