using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ContentPage navigationPage = (new ProjectView(){BindingContext = model});
            ContentPage prPage = (new ProjectInfo(){BindingContext = model});


            navigationPage.Title = "Project";
            prPage.Title = "Info";
            this.BarBackgroundColor = Color.Teal;
            this.BarTextColor = Color.White;

            Children.Add(prPage);
            Children.Add(navigationPage);
            InitializeComponent();
        }
    }
}