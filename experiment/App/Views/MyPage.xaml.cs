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
        public MyPage(UserViewModel userViewModel)
        {
            InitializeComponent();
            
            NavigationPage userPage = new NavigationPage(new UserPage(userViewModel)) {BarBackgroundColor = Color.Teal} ;
            NavigationPage projectPage = new NavigationPage(new ProjectsPage(userViewModel)){BarBackgroundColor = Color.Teal};

          
            userPage.Title = "Account";
            projectPage.Title = "Projects";
            
            this.BarBackgroundColor = Color.Teal;
            this.BarTextColor = Color.White;

            Children.Add(projectPage);
            Children.Add(userPage);
        }
    }
}