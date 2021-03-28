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
        public RegistrationPage(string path)

        {
            DBpath = path;
            InitializeComponent();
        }
        private async void ToMyPage(object sender, EventArgs e)
        {
            
            await Navigation.PushModalAsync(new MyPage(DBpath));
        }
    }
}