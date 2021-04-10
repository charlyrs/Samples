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
        private UserRepo _userRepo;
        //public User UserModel;

        public string UserNickname { get; set; }
        public string UserPassword { get; set; }

        public ICommand LogInCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var user = await _userRepo.GetUserByNickname(UserNickname);
                    if (user == null)
                    {
                        await App.Current.MainPage.DisplayAlert("LogIn", "Invalid username or password", "Try again");
                    }
                    else if (user.Password != UserPassword)
                    {
                        await App.Current.MainPage.DisplayAlert("LogIn", "Invalid username or password", "Try again");
                    }
                    else
                    {
                        var userVm = new UserViewModel(_userRepo)
                        {
                            UserNickname = user.Nickname,
                            UserPassword = user.Password,
                            UserEmail = user.Email,
                            UserModel = user,
                            UserProjects = await _userRepo.GetProjects(user)
                        };
                        await Application.Current.NavigationProxy.PushModalAsync(new MyPage(userVm){BarBackgroundColor = Color.Teal});
                    }




                });
            }
        }
        public LogInViewModel(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
