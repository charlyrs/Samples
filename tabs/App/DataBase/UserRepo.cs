using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepo(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var products = await _databaseContext.Users.ToListAsync();

                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public User GetUserByNickname(string name)
        {
            try
            {
                var products = _databaseContext.Users.Where(predicate: u => u.Nickname == name);

                return products.FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }

        }
       

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Users.FindAsync(id);

                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }
      

        public async Task<bool> AddUserAsync(User product)
        {
            try
            {
                var tracking = await _databaseContext.Users.AddAsync(product);

                await _databaseContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User product)
        {
            try
            {
                var tracking = _databaseContext.Update(product);

                await _databaseContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Users.FindAsync(id);

                var tracking = _databaseContext.Remove(product);

                await _databaseContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

      
    }
}
