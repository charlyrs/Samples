using System;
using System.Collections.Generic;
using System.Text;
using App.ViewModels;
using App.Views;
using Xamarin.Forms;

namespace App.Services
{
    public class NavigationService
    {
        public async void SignUpNavigation(RegistrationViewModel registrationViewModel)
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
    }
}
