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
            var userVm = (UserViewModel)BindingContext;
            await Navigation.PushModalAsync(new MyPage(userVm));
        }
        private async void ToLogInPage(object sender, EventArgs e)
        {
           // var userVm = (UserViewModel)BindingContext;
           var page= new LogInPage(new UserViewModel(new UserRepo(App.DBpath)));
            await Navigation.PushAsync(page);

        }
    }
}