using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage(UserViewModel uModel)
        {
            var loginModel = new LogInViewModel(new UserRepo(App.DBpath))
            {
                UserPassword = uModel.UserPassword,
                UserNickname = uModel.UserNickname
            };
            BindingContext = loginModel;
            InitializeComponent();
        }
    }
}