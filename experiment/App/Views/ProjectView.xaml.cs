using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database.DataBase;
using App.Database.Models;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectView : ContentPage
    {
       
        public ProjectView()
        {
            InitializeComponent();
        }
        private async void ToDoTaskPage(object sender, EventArgs e)
        {
            var taskViewModel = new TaskViewModel(new TaskRepository(App.DBpath))
            {
                TaskColumn = ((ColumnsViewModel)BindingContext).ToDoColumn
            };
            await Navigation.PushAsync(new CreateTask(){BindingContext = taskViewModel});
        }
        private async void InProgressTaskPage(object sender, EventArgs e)
        {
            var taskViewModel = new TaskViewModel(new TaskRepository(App.DBpath))
            {
                TaskColumn = ((ColumnsViewModel)BindingContext).InProgressColumn
            };
            await Navigation.PushAsync(new CreateTask() { BindingContext = taskViewModel});
        }
        private async void DoneTaskPage(object sender, EventArgs e)
        {
            var taskViewModel = new TaskViewModel(new TaskRepository(App.DBpath))
            {
                TaskColumn = ((ColumnsViewModel)BindingContext).DoneColumn
            };
            await Navigation.PushAsync(new CreateTask() {BindingContext = taskViewModel});
        }
    }
}