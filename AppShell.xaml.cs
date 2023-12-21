using System;
using System.Collections.Generic;
using foodsharing.ViewModels;
using foodsharing.Views;
using Xamarin.Forms;

namespace foodsharing
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(PostDetail), typeof(PostDetail));
            Routing.RegisterRoute(nameof(NewPostPage), typeof(NewPostPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(MyPostsPage), typeof(MyPostsPage));
        }

    }
}

