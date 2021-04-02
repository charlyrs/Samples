using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProject : ContentPage
    {
        private UserViewModel currentUser;
        //private Command SaveCommand; 
        
        public CreateProject(ProjectViewModel model, UserViewModel uModel)
        {
            currentUser = uModel;
            BindingContext = model;
            
           // this.SaveCommand = new Command<object, EventArgs>( async (s, e) => await BackToProjects(s,e));
            InitializeComponent();
        }
        private async void BackToProjects(object sender, EventArgs e)
        {
            //var pr = (ProjectViewModel)BindingContext;
            await currentUser.UpdateUserProjects();
            await Navigation.PushModalAsync(new MyPage(currentUser));
            
        }
    }
}