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
        private UserViewModel currentUser;
        public CreateProject(ProjectViewModel model, UserViewModel uModel)
        {
            currentUser = uModel;
            BindingContext = model;
            InitializeComponent();
        }
        private async void BackToProjects(object sender, EventArgs e)
        {
            var pr = (ProjectViewModel)BindingContext;
            currentUser.UpdateUserProjects(pr);
            await Navigation.PushModalAsync(new MyPage(currentUser));
        }
    }
}