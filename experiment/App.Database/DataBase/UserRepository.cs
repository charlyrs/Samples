using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(string dbPath)
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
        public async Task<List<Project>> GetProjects(User user)
        {
            try
            {
                var projects =  _databaseContext.Projects.Include(s => s.Users).Where(p => p.Users.Any(u => user.Nickname == u.Nickname));
                
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
                var users = _databaseContext.Users.Where(u => u.Nickname == name);
                var foundUser = users.FirstOrDefault();

                return foundUser;
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
        public async Task<bool> AddProjectToUserAsync(int userId, int projectId)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(userId);
                var project = await _databaseContext.Projects.FindAsync(projectId);
                user.Projects.Add(project);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //shit
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
