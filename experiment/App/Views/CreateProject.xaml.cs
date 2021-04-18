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
    public partial class CreateProject : ContentPage
    {
        private readonly UserViewModel _currentUser;
        public CreateProject(ProjectViewModel projectViewModel, UserViewModel userViewModel)
        {
            _currentUser = userViewModel;
            BindingContext = projectViewModel;
            InitializeComponent();
        }
        private async void BackToProjects(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}