using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Database.DataBase;
using App.ViewModels;

namespace App.Services
{
    public class CheckInputService
    {
        public bool CheckIfInputIsNotEmpty(RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel.UserEmail == null || registrationViewModel.UserNickname == null ||
                registrationViewModel.UserPassword == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckIfNicknameIsUnique(RegistrationViewModel registrationViewModel)
        {
            var userRepository = new UserRepository(App.DBpath);
            var user = await userRepository.GetUserByNickname(registrationViewModel.UserNickname);
            if (user != null)
            {
                return false;
            }
            return true;

        }
        public bool CheckProjectInput (ProjectViewModel projectViewModel)
        {
            if(projectViewModel.ProjectTitle == null || projectViewModel.ProjectsDescription == null)
            {
                return false;
            }
            return true;
        }

    }
}
