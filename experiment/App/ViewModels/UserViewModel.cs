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
        private readonly UserRepo _userRepo;
        public User UserModel;

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserNickname { get; set; }

        public List<Project> UserProjects { get; set; }

       
        public async Task UpdateUserProjects()
        {
              var user = await _userRepo.GetUserByNickname(UserNickname);
              var userProjects = await _userRepo.GetProjects(user);
              UserProjects = userProjects;
              UserModel.Projects = userProjects;
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
                    UserModel = await _userRepo.GetUserByNickname(UserNickname);
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
