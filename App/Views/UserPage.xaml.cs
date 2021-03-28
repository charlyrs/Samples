using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage(UserRepo repo)
        {
            var user = repo.GetLastUser();
            BindingContext = new UserViewModel(repo) { UserEmail = user.Email, 
                UserNickname = user.Nickname, 
                UserPassword = user.Password 
            };
            
            InitializeComponent();
            
        }
    }
}