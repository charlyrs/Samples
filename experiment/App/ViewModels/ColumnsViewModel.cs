using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Database;
using App.Database.DataBase;
using App.Database.Interface;
using App.Database.Models;
using App.Interface;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ColumnsViewModel : INotifyPropertyChanged
    {
        private readonly IProjectRepository _projectRepository;

        public ColumnsViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Column ToDoColumn;
        public Column InProgressColumn;
        public Column DoneColumn;
        public int ProjectId { get; set; }

        public List<ProjectTask> ToDoColumnTasks
        {
            get => ToDoColumn.Tasks;
            set
            {
                ToDoColumn.Tasks = value;
                OnPropertyChanged();

            }
        }

        public List<ProjectTask> InProgressColumnTasks
        {
            get => InProgressColumn.Tasks;
            set
            {
                InProgressColumn.Tasks = value;
                OnPropertyChanged();
            }
        }

        public List<ProjectTask> DoneColumnTasks
        {
            get => DoneColumn.Tasks;
            set
            {
                DoneColumn.Tasks = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public async Task<bool> UpdateColumns()
        {
            try
            {
                var columns = await _projectRepository.GetColumns(ProjectId);
                ToDoColumn = columns[0];
                InProgressColumn = columns[1];
                DoneColumn = columns[2];
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await UpdateColumns();
                    IsRefreshing = false;
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
