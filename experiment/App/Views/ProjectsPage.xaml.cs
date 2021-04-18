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
        private ProjectViewModel _selectedViewModel;
        public ProjectsPage(UserViewModel userViewModel)
        {
            var projectRepository = new ProjectRepository(App.DBpath);
            var userRepository = new UserRepository(App.DBpath);
            var projectViewModel = new ProjectViewModel(projectRepository, userRepository, userViewModel);
            _selectedViewModel = projectViewModel;
            BindingContext = userViewModel;
            InitializeComponent();


        }
        private async void ToCreateProjectPage(object sender, EventArgs e)
        {
            var u = (UserViewModel)BindingContext;
            await Navigation.PushAsync(new CreateProject(_selectedViewModel, u));
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var selectedProject = (Project)e.SelectedItem;
            await _selectedViewModel.UpdateViewModel(selectedProject.Id);
            var projectTabbedPage = new ProjectTabbedPage(_selectedViewModel);
            await Navigation.PushAsync(projectTabbedPage);
        }

    }
}