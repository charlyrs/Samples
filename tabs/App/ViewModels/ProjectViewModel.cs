﻿using App.Database;
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
                 
                    project.Users.Add(CurrentUser);
                    await _projectRepo.AddProjectAsync(project);
                    CurrentUser.Projects.Add(project);
                    await _userRepo.UpdateUserAsync(CurrentUser);
            
                });
            }
        }
        

        public ProjectViewModel(ProjectRepo projectRepo, UserRepo userRepo, UserViewModel currentUser)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            var user = _userRepo.GetUserByNickname(currentUser.UserNickname);
            CurrentUser = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
