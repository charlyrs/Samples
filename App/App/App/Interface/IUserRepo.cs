using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace App
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<bool> AddUserAsync(User product);

        Task<bool> UpdateUserAsync(User product);

        Task<bool> RemoveUserAsync(int id);

        Task<IEnumerable<User>> QueryProductsAsync(Func<User, bool> predicate);
    }
}
