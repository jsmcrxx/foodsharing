using System;
using Xamarin.Forms;
using SQLite;
using System.IO;
using foodsharing.Tables;

// Страница входа

namespace foodsharing.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();           
        }

        /* Данная функция отвечает за нажатие на кнопку "Зарегистрируйтесь". 
        После нажатия кнопки пользователя отсылает на страницу регистрации */
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///RegistrationPage");
        }

        /* Данная функция отвечает за нажатие на кнопку "Войти". 
        После нажатия кнопки данные введенные в Entry сопоставляются с данными в базе данных SQLite,
        в случае успеха пользователя отсылает на главную страницу приложения. В случае если данные не совпали,
        появляется сообщение об этом */
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if(myquery!=null)
            {
                await Shell.Current.GoToAsync("///PostsPage");

                EntryUser.Text = "";
                EntryPassword.Text = "";
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");

                    EntryUser.Text = "";
                    EntryPassword.Text = "";
                });
            }
        }
    }
}

