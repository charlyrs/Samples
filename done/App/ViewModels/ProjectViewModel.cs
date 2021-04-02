using App.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ProjectViewModel
    {
        private readonly ProjectRepo _projectRepo;
        private readonly UserRepo _userRepo;
        public User CurrentUser;


        public List<Project> Projects
        {
            get
            {
                return CurrentUser.Projects;
            }
            set
            {
                CurrentUser.Projects = value;
                OnPropertyChanged();
            }
        }

        public string ProjectTitle { get; set; }

        public string ProjectsDescribtion { get; set; }
        
        public List <User> ProjectUsers { get; set; }


        
        public async Task<bool> UpdateProjects()
        {
            try
            {
                CurrentUser.Projects = await _userRepo.GetProjects(CurrentUser);
                //ProjectUsers = _projectRepo.GetUsers()
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var project = new Project
                    {
                        Title = ProjectTitle,
                        Describtion = ProjectsDescribtion,
                        Users = new List<User>()
                    };
                    //проблема тут! добавление проекта в базу не работает
                   
                    var track = await _projectRepo.AddProjectAsync(project);
                    var id = project.Id;
                   // var u = await _userRepo.GetUserByIdAsync(CurrentUser.Id);
                    await _projectRepo.AddUserToProjectAsync(CurrentUser.Id, id);
                    

                });
            }
        }
        

        public ProjectViewModel(ProjectRepo projectRepo, UserRepo userRepo, UserViewModel currentUser)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            //var user =_userRepo.GetUserByNickname(currentUser.UserNickname);
            CurrentUser = currentUser.UserModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
