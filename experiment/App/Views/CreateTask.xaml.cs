using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database.DataBase;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTask : ContentPage
    {
        public CreateTask()
        {
            InitializeComponent();
        }
        private async void BackToProjectView(object sender, EventArgs e)
        {
           /* var projectViewModel = (ProjectViewModel)(Navigation.NavigationStack[^2].BindingContext);
            await projectViewModel.UpdateViewModel(projectViewModel.ProjectId);
            var toDoColumn = projectViewModel.ProjectColumns[0];
            var inProgressColumn = projectViewModel.ProjectColumns[1];
            var doneColumn = projectViewModel.ProjectColumns[2];
            var columnViewModel = new ColumnsViewModel(new ColumnRepository(App.DBpath))
            {
                ProjectId = projectViewModel.ProjectId,
                ToDoColumn = toDoColumn,
                InProgressColumn = inProgressColumn,
                DoneColumn = doneColumn

            };
            var aPageToReplace = new ProjectTabbedPage(projectViewModel)
            {
                Children = {new ProjectView() {BindingContext = columnViewModel}, new ProjectInfo() {BindingContext = projectViewModel}}
            };
            var pageToRemove = (ProjectTabbedPage) Navigation.NavigationStack[^2];
            Navigation.RemovePage(pageToRemove);
            Navigation.InsertPageBefore(aPageToReplace, this);
           
            //page.Children[0].BindingContext = columnVm;*/
            
            await Navigation.PopAsync();
        }
    }
}