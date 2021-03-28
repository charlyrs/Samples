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
        public MyPage(string dbpath)
        {
            InitializeComponent();
            path = dbpath;
            var repo = new UserRepo(dbpath);
            var projectRepo = new ProjectRepo(dbpath);
            NavigationPage navigationPage = new NavigationPage(new UserPage(repo)) ;
            NavigationPage prPage = new NavigationPage(new ProjectsPage()
            {
                BindingContext = new ProjectViewModel(projectRepo)
            }) ;

          
            navigationPage.Title = "Account";
            prPage.Title = "Projects";

           
            Children.Add(navigationPage);
            Children.Add(prPage);
            
        }
    }
}