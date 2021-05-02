using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database.DataBase;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage(UserViewModel userViewModel)
        {
            var logInViewModel = new LogInViewModel(new UserRepository(App.DBpath))
            {
                UserPassword = userViewModel.UserPassword,
                UserNickname = userViewModel.UserNickname
            };
            BindingContext = logInViewModel;
            InitializeComponent();
        }
    }
}