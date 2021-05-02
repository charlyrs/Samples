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
using App.Database.DataBase;

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
            await Navigation.PushAsync(new CreateProject(_selectedViewModel));
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs eventArgs)
        {
            if (eventArgs.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
            var id = ((Project)eventArgs.SelectedItem).Id;

            await _selectedViewModel.UpdateViewModel(id);
            var projectTabbedPage = new ProjectTabbedPage(_selectedViewModel);

            await Navigation.PushAsync(projectTabbedPage);
            
        }

    }
}