using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepository;

        public User UserModel { get; set;}
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserNickname { get; set; }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public List<Project> UserProjects
        {
            get => UserModel.Projects;
            set
            {
                UserModel.Projects = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        #region methods
        public async Task UpdateUserProjects()
        {
              var user = await _userRepository.GetUserByNickname(UserNickname);
              var userProjects = await _userRepository.GetProjects(user);
              UserProjects = userProjects;
              UserModel.Projects = userProjects;
        }
       
        #endregion

        #region commands

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await UpdateUserProjects();
                    RefreshData();
                });
            }
        }
        private void RefreshData()
        {
            IsRefreshing = false;
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
