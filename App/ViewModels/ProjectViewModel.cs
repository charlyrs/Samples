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
        private readonly User Creator;
        private IEnumerable<Project> _projects;


        public IEnumerable<Project> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }

        public string ProjectTitle { get; set; }

        public string ProjectsDescribtion { get; set; }
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

                        
                    };

                    project.Users.Add(Creator);
                    await _projectRepo.AddProjectAsync(project);
                });
            }
        }

        public ProjectViewModel(ProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
