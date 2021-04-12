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
        public MyPage(UserViewModel model)
        {
            InitializeComponent();
            
            NavigationPage navigationPage = new NavigationPage(new UserPage(model)) {BarBackgroundColor = Color.Teal} ;
            NavigationPage prPage = new NavigationPage(new ProjectsPage(model)){BarBackgroundColor = Color.Teal};

          
            navigationPage.Title = "Account";
            prPage.Title = "Projects";
            
            this.BarBackgroundColor = Color.Teal;
            this.BarTextColor = Color.White;

            Children.Add(prPage);
            Children.Add(navigationPage);
        }
    }
}