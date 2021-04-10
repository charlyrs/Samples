using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Project>> GetProjectsAsync();

        Task<Project> GetProjectByIdAsync(int id);

        Task<bool> AddProjectAsync(Project project);

        Task<bool> UpdateProjectAsync(Project project);

        Task<bool> RemoveProjectAsync(int id);

        
    }
}
