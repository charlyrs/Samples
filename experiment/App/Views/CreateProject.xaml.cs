using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;
using App.Services;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProject : ContentPage
    {
      
       
        public CreateProject(ProjectViewModel projectViewModel)
        {
           
            BindingContext = projectViewModel;
            InitializeComponent();
        }
        private async void BackToProject(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

    }
}