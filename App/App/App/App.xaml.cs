using App.ViewModels;
using App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    public partial class App : Application
    {
        public readonly string DBpath;
        public App(string dbPath)
        {
            InitializeComponent();
            var repo = new UserRepo(dbPath);
         
            DBpath = dbPath;
            MainPage = new NavigationPage(new RegistrationPage(DBpath) {
                BindingContext = new UserViewModel(repo)
            });
            
       

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
