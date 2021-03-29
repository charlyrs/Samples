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
        private readonly string DBpath;
        public string name;
        public RegistrationPage(string path)

        {
            DBpath = path;
           /* var model = new UserViewModel(App.UserRepository);
            string name1;*/
            
            InitializeComponent();
        }
        private async void ToMyPage(object sender, EventArgs e)
        {
            var u = (UserViewModel)BindingContext;
            var user = App.UserRepository.GetLastUser();
            var repo = App.UserRepository;
            /*var model = new UserViewModel(repo) { 
            UserEmail = u.Email,
            UserPassword = u.Password,
            UserNickname = u.Nickname

            };*/
            await Navigation.PushModalAsync(new MyPage(u));
        }
    }
}