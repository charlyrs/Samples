using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database.Models;
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

        public async Task<bool> AddDefaultColumnsToProject(int projectId)
        {
            try
            {
                var project = await _databaseContext.Projects.FindAsync(projectId);
                var c1 = new Column() {Title = "To Do", Project = project};
                var c2 = new Column() { Title = "In Progress", Project = project};
                var c3 = new Column() { Title = "Done", Project = project};
                await _databaseContext.Columns.AddAsync(c1);
                await _databaseContext.Columns.AddAsync(c2);
                await _databaseContext.Columns.AddAsync(c3);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public async Task<List<Column>> GetColumns(int projectId)
        {
            try
            {
                //var project = await _databaseContext.Projects.FindAsync(projectId);
                var columns = _databaseContext.Columns.Where(c => c.Project.Id == projectId);
                var res = await columns.ToListAsync();
                return res;

            }
            catch (Exception e)
            {
                return null;
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
        public async Task<List<User>> GetUsers(Project project)
        {
            try
            {
                var users = _databaseContext.Users.Where(u => u.Projects.Any(p => p.Id == project.Id));
                return users.ToList();
            }
            catch (Exception e)
            {
                return null;
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
