using App.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IProjectRepository
    {

        Task<Project> GetProjectByIdAsync(int projectId);

        Task<bool> AddProjectAsync(Project project);

        Task<bool> UpdateProjectAsync(Project project);

        Task<bool> RemoveProjectAsync(int id);
        Task<bool> AddDefaultColumnsToProject(int projectId);
        Task<List<Column>> GetColumns(int projectId);
        Task<bool> AddUserToProjectAsync(int userId, int projectId);
        Task<List<User>> GetUsers(Project project);



    }
}
