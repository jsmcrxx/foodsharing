using System;
using System.IO;
using SQLite;
using foodsharing.Tables;
using Xamarin.Forms;

// Страница регистрации пользователя
namespace foodsharing.Views
{
  
    public partial class RegistrationPage : ContentPage
	{	
		public RegistrationPage ()
		{
			InitializeComponent ();
        }

        /* Данная функция отвечает за нажатие на кнопку "Зарегистрироваться".
        После нажатия кнопки в базу данных SQLite записываются данные, введенные в Entry,
        после этого появляется уведомление об успешной регистрации, пользователя пересылает на страницу входа,
        а поля Entry очищаются */
        void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                await this.DisplayAlert("Поздравляем!", "Регистрация прошла успешно!", "Далее");
                await Shell.Current.GoToAsync("///LoginPage");

                EntryUserName.Text = "";
                EntryUserPassword.Text = "";
                EntryUserEmail.Text = "";
                EntryUserPhoneNumber.Text = "";
            });
        }
        /* Данная функция отвечает за нажатие на кнопку "Отмена"
        После нажатия на кнопку пользователя отсылает на страницу входа, а поля Entry очищаются */
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///LoginPage");

            EntryUserName.Text = "";
            EntryUserPassword.Text = "";
            EntryUserEmail.Text = "";
            EntryUserPhoneNumber.Text = "";
        }
    }
}

