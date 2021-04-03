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
        public async Task<List<Project>> GetProjects(User us)
        {
            try
            {
               
                var projects = _databaseContext.Projects.Where(p => p.Users.Any(u => us.Nickname == u.Nickname));
               
                return projects.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<User> GetUserByNickname(string name)
        {
            try
            {
                var products = _databaseContext.Users.Where( u => u.Nickname == name);
                var f = products.FirstOrDefault();

                return f;
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
      

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                var tracking = await _databaseContext.Users.AddAsync(user);

                await _databaseContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> AddProjectToUserAsync(int userID, int prID)
        {
            try
            {
                var u = await _databaseContext.Users.FindAsync(userID);
                var p = await _databaseContext.Projects.FindAsync(prID);
                u.Projects.Add(p);
                await _databaseContext.SaveChangesAsync();
                

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var toUpdate = _databaseContext.Users.Find(user.Id);
                toUpdate.Nickname = user.Nickname;
                toUpdate.Email = user.Email;
                toUpdate.Password = user.Password;
                toUpdate.Projects = user.Projects;
                await _databaseContext.SaveChangesAsync();
                var s = _databaseContext.Users.ToList();

               
                return true;
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
