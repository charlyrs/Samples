using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserRepo _userRepo;
        private IEnumerable<User> _users;
        
        public IEnumerable<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserNickname { get; set; }

        public List<Project> UserProjects { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Users = await _userRepo.GetUsersAsync();
                });
            }
        }
        public void UpdateUserProjects(ProjectViewModel model)
        {
            if (model.CurrentUser.Nickname == UserNickname)
            {
                UserProjects = (List<Project>)model.Projects;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var user = new User
                    {
                        Email = UserEmail,
                        Password = UserPassword,
                        Nickname = UserNickname,
                        Projects = new List<Project>()
                        
                    };
                   
                    await _userRepo.AddUserAsync(user);
                });
            }
        }
 
        public UserViewModel(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
