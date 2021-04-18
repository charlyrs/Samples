using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database;
using App.Database.DataBase;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectTabbedPage : TabbedPage
    {
        public ProjectTabbedPage(ProjectViewModel projectViewModel)
        {
            if (BindingContext == null)
            {
                BindingContext = projectViewModel;
            }
            else
            {
                projectViewModel = (ProjectViewModel) BindingContext;
            }

            var toDoColumn = projectViewModel.ProjectColumns[0];
            var inProgressColumn = projectViewModel.ProjectColumns[1];
            var doneColumn = projectViewModel.ProjectColumns[2];
            var columnsViewModel = new ColumnsViewModel(new ProjectRepository(App.DBpath))
            {
                ProjectId = projectViewModel.ProjectId,
                ToDoColumn = toDoColumn,
                InProgressColumn = inProgressColumn,
                DoneColumn = doneColumn

            };

            ContentPage projectView = (new ProjectView(){BindingContext = columnsViewModel});
            ContentPage projectInfo = (new ProjectInfo(){BindingContext = projectViewModel});


            projectView.Title = "Project";
            projectInfo.Title = "Info";
            this.BarBackgroundColor = Color.Teal;
            this.BarTextColor = Color.White;

            
            Children.Add(projectView);
            Children.Add(projectInfo);
            InitializeComponent();
        }
    }
}