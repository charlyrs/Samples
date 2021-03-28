using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Database
{
    public class ProjectRepo
    {
        private readonly DatabaseContext _databaseContext;

        public ProjectRepo(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            try
            {
                var projects = await _databaseContext.Projects.ToListAsync();

                return projects;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Projects.FindAsync(id);

                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       /* public async Task<bool> AddUserToTheProject(User user)
        {
            try
            {
                
                var tracking = 
                    //await _databaseContext.Users.AddAsync(user);
                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == EntityState.Added;
                return isAdded;

            }
            catch (Exception e)
            {
                return false;
            }
        }*/

        public async Task<bool> AddProjectAsync(Project project)
        {
            try
            {

               
                var tracking = await _databaseContext.Projects.AddAsync(project);

                await _databaseContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProjectAsync(Project product)
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

        public async Task<bool> RemoveProjectAsync(int id)
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

        public async Task<IEnumerable<Project>> QueryProductsAsync(Func<Project, bool> predicate)
        {
            try
            {
                var products = _databaseContext.Projects.Where(predicate);

                return products.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
