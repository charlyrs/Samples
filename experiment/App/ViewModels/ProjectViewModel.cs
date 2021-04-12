using App.Database;
using App.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Database.DataBase;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private readonly ProjectRepo _projectRepo;
        private readonly UserRepo _userRepo;
        public User CurrentUser;

        public string ProjectTitle { get; set; }
        public string ProjectsDescription { get; set; }
        public int ProjectID { get; set; }
        public  List<Column> ProjectColumns { get; set; }
        public List <User> ProjectUsers { get; set; }

        /*public async Task<bool> Update()
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
        }*/
        public async Task<bool> UpdateViewModel(int projectId)
        {
            try
            {
                var pr = await _projectRepo.GetProjectByIdAsync(projectId);
                ProjectID = pr.Id;
                ProjectTitle = pr.Title;
                ProjectsDescription = pr.Description;
                ProjectUsers = await _projectRepo.GetUsers(pr);
                ProjectColumns = await _projectRepo.GetColumns(pr.Id); ;
                var repo = new ColumnRepo(App.DBpath);
                ProjectColumns[0].Tasks = await repo.GeTasks(ProjectColumns[0].Id); 
                ProjectColumns[1].Tasks = await repo.GeTasks(ProjectColumns[1].Id); 
                ProjectColumns[2].Tasks = await repo.GeTasks(ProjectColumns[2].Id); 
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
                    await _projectRepo.AddDefaultColumnsToProject(project.Id);
                    ProjectColumns = await _projectRepo.GetColumns(project.Id);
                    ProjectID = project.Id;
                    await _projectRepo.AddUserToProjectAsync(CurrentUser.Id, project.Id);
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
