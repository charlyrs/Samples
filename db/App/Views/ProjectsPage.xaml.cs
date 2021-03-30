using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        public ProjectsPage()
        {
            var u = new User() { Email = "234", Nickname = "67", Password = "ghjk" };
            App._userRepo.AddUserAsync(u);
            InitializeComponent();
            //StackLayout st = new StackLayout();
            
        }
       
    }
}