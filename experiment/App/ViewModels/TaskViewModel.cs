using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using App.Database.DataBase;
using App.Database.Models;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private readonly TaskRepo _taskRepo;

        public TaskViewModel(TaskRepo repo)
        {
            _taskRepo = repo;
        }
        public string TaskTitle { get; set; }
        public Column TaskColumn { get; set; }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var task = new ProjectTask()
                    {
                        Title = TaskTitle,
                        Column = TaskColumn
                    };
                    var cRepo = new ColumnRepo(App.DBpath);
                    await cRepo.AddTaskToColumn(task, TaskColumn.Id);

                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
