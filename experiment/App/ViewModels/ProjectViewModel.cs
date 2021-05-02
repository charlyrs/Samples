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
using App.Interface;
using App.Services;

namespace App.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly CheckInputService _checkInputService = new CheckInputService();
        private readonly NavigationService _navigationService = new NavigationService();
        public User CurrentUser;

        public string ProjectTitle { get; set; }
        public string ProjectsDescription { get; set; }
        public int ProjectId { get; set; }
        public  List<Column> ProjectColumns { get; set; }
        public List <User> ProjectUsers { get; set; }

        #region methods
        public async Task<bool> UpdateViewModel(int projectId)
        {
            try
            {
                var foundProject = await _projectRepository.GetProjectByIdAsync(projectId);
                ProjectId = foundProject.Id;
                ProjectTitle = foundProject.Title;
                ProjectsDescription = foundProject.Description;
                ProjectUsers = await _projectRepository.GetUsers(foundProject);
                ProjectColumns = await _projectRepository.GetColumns(foundProject.Id); 
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private async Task<int> AddProject()
        {
            var project = new Project
            {
                Title = ProjectTitle,
                Description = ProjectsDescription,
                Users = new List<User>()
            };
            var track = await _projectRepository.AddProjectAsync(project);
            await _projectRepository.AddDefaultColumnsToProject(project.Id);
            ProjectColumns = await _projectRepository.GetColumns(project.Id);
            ProjectId = project.Id;
            await _projectRepository.AddUserToProjectAsync(CurrentUser.Id, project.Id);
            return ProjectId;
        }
        #endregion


        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var correctInput = _checkInputService.CheckProjectInput(this);
                    if (!correctInput)
                    {
                        await Application.Current.MainPage.DisplayAlert("Project", "Title and description can't be empty", "Ok");
                    }
                    else
                    {
                        await AddProject();
                        

                    }
                });
            }
        }
        

        public ProjectViewModel(IProjectRepository projectRepository, IUserRepository userRepository, UserViewModel currentUser)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            CurrentUser = currentUser.UserModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
