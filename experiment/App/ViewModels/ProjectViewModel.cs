using App.Database;
using App.Database.Models;
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

        public string ProjectTitle { get; set; }
        public string ProjectsDescription { get; set; }
        public int ProjectID { get; set; }
        public  List<Column> ProjectColumns { get; set; }
        public List <User> ProjectUsers { get; set; }

        public async Task<bool> Update()
        {
            try
            {
                CurrentUser.Projects = await _userRepo.GetProjects(CurrentUser);
                var project = await _projectRepo.GetProjectByIdAsync(ProjectID);
                ProjectUsers = await _projectRepo.GetUsers(project);
                ProjectColumns = await _projectRepo.GetColumns(project.Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> UpdateViewModel(Project pr)
        {
            try
            {
                ProjectID = pr.Id;
                ProjectTitle = pr.Title;
                ProjectsDescription = pr.Description;
                ProjectUsers = pr.Users;
                var project = await _projectRepo.GetProjectByIdAsync(pr.Id);
                var c = await _projectRepo.GetColumns(pr.Id);
                ProjectColumns = c;
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
                        Description = ProjectsDescription,
                        Users = new List<User>()
                    };
                    var track = await _projectRepo.AddProjectAsync(project);
                    var id = project.Id;
                    await _projectRepo.AddDefaultColumnsToProject(project.Id);
                    ProjectColumns = await _projectRepo.GetColumns(id);
                    ProjectID = id;
                    await _projectRepo.AddUserToProjectAsync(CurrentUser.Id, id);
                    

                });
            }
        }
        

        public ProjectViewModel(ProjectRepo projectRepo, UserRepo userRepo, UserViewModel currentUser)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            CurrentUser = currentUser.UserModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
