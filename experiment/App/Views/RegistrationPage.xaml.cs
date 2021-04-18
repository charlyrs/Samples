using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
      
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private async void ToMyPage(object sender, EventArgs e)
        {
            var registrationViewModel = (RegistrationViewModel)BindingContext;
            var userViewModel = new UserViewModel(new UserRepository(App.DBpath))
            {
                UserPassword = registrationViewModel.UserPassword,
                UserNickname = registrationViewModel.UserNickname,
                UserEmail = registrationViewModel.UserEmail,
                UserModel = registrationViewModel.UserModel
            };
            await Navigation.PushModalAsync(new MyPage(userViewModel));
        }
        private async void ToLogInPage(object sender, EventArgs e)
        {
            var logInPage= new LogInPage(new UserViewModel(new UserRepository(App.DBpath)));
            await Navigation.PushAsync(logInPage);

        }
    }
}