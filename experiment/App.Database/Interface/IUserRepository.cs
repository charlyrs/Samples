using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace App
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<bool> AddUserAsync(User product);

        Task<bool> UpdateUserAsync(User product);

        Task<bool> RemoveUserAsync(int id);
        Task<List<Project>> GetProjects(User user);
        Task<User> GetUserByNickname(string name);
        Task<bool> AddProjectToUserAsync(int userId, int projectId);




    }
}
