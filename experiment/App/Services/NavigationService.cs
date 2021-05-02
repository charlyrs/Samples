using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Database.DataBase;
using App.ViewModels;
using App.Views;
using Xamarin.Forms;

namespace App.Services
{
    public class NavigationService
    {
        public async Task SignUpNavigation(RegistrationViewModel registrationViewModel)
        {
            var userViewModel = new UserViewModel(new UserRepository(App.DBpath))
            {
                UserPassword = registrationViewModel.UserPassword,
                UserNickname = registrationViewModel.UserNickname,
                UserEmail = registrationViewModel.UserEmail,
                UserModel = registrationViewModel.UserModel
            };
            await Application.Current.MainPage.Navigation.PushModalAsync(new MyPage(userViewModel));

        }
        
        public async Task ToLoginPage()
        {
            var logInPage = new LogInPage(new UserViewModel(new UserRepository(App.DBpath)));
            await Application.Current.MainPage.Navigation.PushAsync(logInPage);
        }
        public async Task NavigateBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
