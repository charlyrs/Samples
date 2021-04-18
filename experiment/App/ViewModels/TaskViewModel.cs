using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using App.Database.DataBase;
using App.Database.Interface;
using App.Database.Models;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private readonly ITaskRepository _taskRepository;

        public TaskViewModel(ITaskRepository repository)
        {
            _taskRepository = repository;
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
                    var columnRepository = new ColumnRepository(App.DBpath);
                    await columnRepository.AddTaskToColumn(task, TaskColumn.Id);

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
