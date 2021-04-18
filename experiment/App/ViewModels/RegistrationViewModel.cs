using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using App.Services;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepository;
        private readonly CheckInputService _checkInputService;
        private readonly NavigationService _navigationService;

        public RegistrationViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _checkInputService = new CheckInputService();
            _navigationService = new NavigationService();
        }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserNickname { get; set; }
        public User UserModel;
        public ICommand SignUpCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var user = new User
                    {
                        Email = UserEmail,
                        Password = UserPassword,
                        Nickname = UserNickname,
                        Projects = new List<Project>()

                    };
                    var nicknameIsUnique = await _checkInputService.CheckIfNicknameIsUnique(this);
                    var inputIsNotEmpty = _checkInputService.CheckIfInputIsNotEmpty(this);
                    if (!inputIsNotEmpty)
                    {
                        await App.Current.MainPage.DisplayAlert(" ", "Fields can't be empty", "Ok");

                    }
                    else if (!nicknameIsUnique)
                    {
                        string message = "Username " + UserNickname + " is already taken";
                        await App.Current.MainPage.DisplayAlert("Nickname", message, "Ok");
                    }
                    else if (UserPassword.Length<6)
                    {
                        await App.Current.MainPage.DisplayAlert("Password", "The password is too short", "Ok");
                    }
                    else
                    {
                        await _userRepository.AddUserAsync(user);
                        UserModel = user;
                        _navigationService.SignUpNavigation(this);
                    }

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
