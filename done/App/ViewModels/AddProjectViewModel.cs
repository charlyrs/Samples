using App.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class AddProjectViewModel
    {
        private readonly ProjectRepo _projectRepo;
        public string ProjectTitle { get; set; }

        public string ProjectsDescribtion { get; set; }
        public User Creator { get; set; }
        public List<User> ProjectUsers { get; set; }
    }
}
