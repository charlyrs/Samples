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

        Task<bool> AddProjectAsync(User product);

        Task<bool> UpdateProjectAsync(User product);

        Task<bool> RemoveProjectAsync(int id);

        Task<IEnumerable<Project>> QueryProjectssAsync(Func<User, bool> predicate);
    }
}
