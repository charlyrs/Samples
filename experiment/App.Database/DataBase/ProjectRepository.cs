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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProjectRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            try
            {
                var project = await _databaseContext.Projects.FindAsync(projectId);

                return project;
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

                var column1 = new Column() {Title = "To Do", Project = project};
                var column2 = new Column() { Title = "In Progress", Project = project};
                var column3 = new Column() { Title = "Done", Project = project};

                await _databaseContext.Columns.AddAsync(column1);
                await _databaseContext.Columns.AddAsync(column2);
                await _databaseContext.Columns.AddAsync(column3);
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
                var columns = _databaseContext.Columns.Include(c => c.Tasks).Where(c => c.Project.Id == projectId);
                var res = await columns.ToListAsync();
                return res;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> AddUserToProjectAsync(int userId, int projectId)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(userId);
                var project = await _databaseContext.Projects.FindAsync(projectId);
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
                var res = await users.ToListAsync();
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<bool> UpdateProjectAsync(Project project)
        {
            try
            {
                var tracking = _databaseContext.Update(project);

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
