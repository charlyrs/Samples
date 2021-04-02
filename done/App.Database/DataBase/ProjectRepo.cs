using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Database
{
    public class ProjectRepo : IProjectRepo
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

        public List<Project> GetProjectsByUser(User u)
        {
            return u.Projects;
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
        public async Task<bool> AddUserToProjectAsync(int UserID, int ProjectID)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(UserID);
                var project = await _databaseContext.Projects.FindAsync(ProjectID);
                project.Users.Add(user);
                await _databaseContext.SaveChangesAsync();

                return true;
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

        
    }
}
