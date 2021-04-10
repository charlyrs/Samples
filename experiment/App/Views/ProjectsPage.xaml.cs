using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Views;
using App.ViewModels;
using App.Database;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        private ProjectViewModel mainModel;
        public ProjectsPage(UserViewModel model)
        {
            var repo = new ProjectRepo(App.DBpath);
            var urepo = new UserRepo(App.DBpath);
            var prVModel = new ProjectViewModel(repo, urepo, model);
            mainModel = prVModel;
            BindingContext = model;
            InitializeComponent();


        }
        private async void ToCreateProjectPage(object sender, EventArgs e)
        {
            var u = (UserViewModel)BindingContext;
            await Navigation.PushAsync(new CreateProject(mainModel, u));
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Project selectedProject = (Project)e.SelectedItem;
            await mainModel.UpdateViewModel(selectedProject);

            ProjectTabbedPage projectView = new ProjectTabbedPage(mainModel);
            await Navigation.PushAsync(projectView);
        }

    }
}