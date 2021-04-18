using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using App.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepository;

        public string UserNickname { get; set; }
        public string UserPassword { get; set; }

        public ICommand LogInCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var user = await _userRepository.GetUserByNickname(UserNickname);
                    if (user == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("LogIn", "Invalid username or password", "Try again");
                    }
                    else if (user.Password != UserPassword)
                    {
                        await Application.Current.MainPage.DisplayAlert("LogIn", "Invalid username or password", "Try again");
                    }
                    else
                    {
                        var userViewModel = new UserViewModel(_userRepository)
                        {
                            UserNickname = user.Nickname,
                            UserPassword = user.Password,
                            UserEmail = user.Email,
                            UserModel = user,
                            UserProjects = await _userRepository.GetProjects(user)
                        };
                        await Application.Current.NavigationProxy.PushModalAsync(new MyPage(userViewModel){BarBackgroundColor = Color.Teal});
                    }

                });
            }
        }
        public LogInViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
