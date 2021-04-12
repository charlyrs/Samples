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
            var model = (ProjectViewModel)(Navigation.NavigationStack[^2].BindingContext);
            await model.UpdateViewModel(model.ProjectID);
            var toDo = model.ProjectColumns[0];
            var inProgress = model.ProjectColumns[1];
            var done = model.ProjectColumns[2];
            var columnVm = new ColumnsViewModel(new ColumnRepo(App.DBpath))
            {
                ProjectId = model.ProjectID,
                ToDoColumn = toDo,
                InProgressColumn = inProgress,
                DoneColumn = done

            };

            var page = (ProjectTabbedPage) Navigation.NavigationStack[^2];
            page.Children[0].BindingContext = columnVm;
            
            await Navigation.PopAsync();
        }
    }
}