using App.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ProjectViewModel
    {
        private readonly ProjectRepo _projectRepo;
        private readonly UserRepo _userRepo;

        //private  User Creator;
        private IEnumerable<Project> _projects;


        public IEnumerable<Project> Projects
        {
            get
            {
                return Creator.Projects;
            }
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }

        public string ProjectTitle { get; set; }

        public string ProjectsDescribtion { get; set; }
        public User Creator { get; set; }
        public List <User> ProjectUsers { get; set; }

        //public string UserNickname { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Projects = await _projectRepo.GetProjectsAsync();
                });
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
                        CreatorId = Creator.Id
                        

                        
                    };
                    this.ProjectUsers.Add(Creator);
                    project.Users.Add(Creator);
                    var user = _userRepo.GetUserByNickname(Creator.Nickname);
                    user.Projects.Add(project);
                    _ = _userRepo.UpdateUserAsync(user);
                    await _projectRepo.AddProjectAsync(project);
                    /*Projects = await _projectRepo.GetProjectsAsync();
                    OnPropertyChanged("Projects");*/
                });
            }
        }

        public ProjectViewModel(ProjectRepo projectRepo, UserRepo model)
        {
            _projectRepo = projectRepo;
            _userRepo = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
