using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;
using App.Database;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : TabbedPage
    {
        private readonly string path;
        public MyPage(UserViewModel model)
        {
            InitializeComponent();
            //path = dbpath;
            //var repo = new UserRepo();
            //var projectRepo = new ProjectRepo();
            NavigationPage navigationPage = new NavigationPage(new UserPage(model)) ;
            NavigationPage prPage = new NavigationPage(new ProjectsPage(model)
            { 
               // BindingContext = new ProjectViewModel(projectRepo) { Creator = repo.GetLastUser()}
            }) ;

          
            navigationPage.Title = "Account";
            prPage.Title = "Projects";

           
            Children.Add(navigationPage);
            Children.Add(prPage);
            
        }
    }
}