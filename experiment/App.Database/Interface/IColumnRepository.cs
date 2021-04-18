using App.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Database.Interface
{
    public interface IColumnRepository
    {
        Task<List<ProjectTask>> GeTasks(int columnId);
        Task<bool> AddTaskToColumn(ProjectTask task, int columnId);
        Task<Column> GetColumnById(int id);
    }
}
