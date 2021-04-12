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
    public partial class ProjectTabbedPage : TabbedPage
    {
        public ProjectTabbedPage(ProjectViewModel model)
        {
            if (BindingContext == null)
            {
                BindingContext = model;
            }
            else
            {
                model = (ProjectViewModel) BindingContext;
            }

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

            ContentPage navigationPage = (new ProjectView(){BindingContext = columnVm});
            ContentPage prPage = (new ProjectInfo(){BindingContext = model});


            navigationPage.Title = "Project";
            prPage.Title = "Info";
            this.BarBackgroundColor = Color.Teal;
            this.BarTextColor = Color.White;

            
            Children.Add(navigationPage);
            Children.Add(prPage);
            InitializeComponent();
        }
    }
}