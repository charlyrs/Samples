using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    public partial class App : Application
    {
        public static IUserRepo _userRepo;
        public App(IUserRepo repo)
        {
            InitializeComponent();
            _userRepo = repo;
            var reg = new RegistrationPage()
            {
                BindingContext = new UserViewModel(_userRepo)
            };

            MainPage = new NavigationPage(reg);
            

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
