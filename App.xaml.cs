using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using foodsharing.Services;
using foodsharing.Views;

namespace foodsharing
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<PostService>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

