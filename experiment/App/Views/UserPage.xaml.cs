using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;
using App.Views;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage(UserViewModel userViewModel)
        {
            BindingContext = userViewModel;
            InitializeComponent();
            
        }
        private async void ToRegistrationPage(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}