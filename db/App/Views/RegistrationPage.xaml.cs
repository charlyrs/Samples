using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using App.Database;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        
        public RegistrationPage()
        {
            InitializeComponent();
           // App._path;

        }
        private async void ToProjects(object sender, EventArgs e)
        {
            var context = (UserViewModel)BindingContext;
            await Navigation.PushAsync(new ProjectsPage() {BindingContext = context });
        }
    }
}