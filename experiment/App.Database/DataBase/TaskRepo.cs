using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Database.Models;

namespace App.Database.DataBase
{
    public class TaskRepo
    {
        private readonly DatabaseContext _databaseContext;

        public TaskRepo(string path)
        {
            _databaseContext = new DatabaseContext(path);
        }

        public async Task<bool> AddTask(ProjectTask task)
        {
            try
            {
                await _databaseContext.Tasks.AddAsync(task);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ProjectTask> GeTaskById(int id)
        {
            try
            {
                var task = await _databaseContext.Tasks.FindAsync(id);
                return task;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
