using App.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Database.Interface
{
    public interface ITaskRepository
    {
        Task<bool> AddTask(ProjectTask task);
        Task<ProjectTask> GeTaskById(int id);
    }
}
