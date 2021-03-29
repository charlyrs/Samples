using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Views;
using App.ViewModels;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        private static ProjectViewModel mainModel;
        public ProjectsPage(UserViewModel model)
        {
            var useres = App.UserRepository.GetUsersAsync();
            
            var projectModel = new ProjectViewModel(App.ProjectRepository, App.UserRepository) {Creator = App.UserRepository.GetUserByNickname(model.UserNickname)};
            BindingContext = projectModel;
            mainModel = projectModel;
            InitializeComponent();
            
        }
        private async void ToCreateProjectPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProject(mainModel));
        }

    }
}