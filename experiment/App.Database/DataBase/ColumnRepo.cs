using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Database.DataBase
{
    public class ColumnRepo
    {
        private readonly DatabaseContext _databaseContext;
        public ColumnRepo(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<List<ProjectTask>> GeTasks(int columnId)
        {
            try
            {
                var tasks = _databaseContext.Tasks.Where(t => t.Column.Id == columnId);
                var res = await tasks.ToListAsync();
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AddTaskToColumn(ProjectTask task, int columnId)
        {
            try
            {
                var column = await _databaseContext.Columns.FindAsync(columnId);
                task.Column = column;
                await _databaseContext.Tasks.AddAsync(task);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
