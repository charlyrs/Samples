using App.ViewModels;
using App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App
{
    public partial class App : Application
    {
        public static string DBpath;
        
        public App(string dbPath)
        {
            DBpath = dbPath;
            InitializeComponent();
            var repo = new UserRepo(dbPath);
            var pr = new ProjectRepo(dbPath);
            
            MainPage = new NavigationPage(new RegistrationPage()
            {
                BindingContext = new UserViewModel(repo)
            }) ;

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
