using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        public ObservableCollection<ProjectTask> ToDoColumnTasks
        {
            get => new ObservableCollection<ProjectTask>(ToDoColumn.Tasks);
            set
            {
                ToDoColumn.Tasks = value.ToList();
                OnPropertyChanged();

            }
        }

        public ObservableCollection<ProjectTask> InProgressColumnTasks
        {
            get => new ObservableCollection<ProjectTask>(InProgressColumn.Tasks);
            set
            {
                InProgressColumn.Tasks = value.ToList();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProjectTask> DoneColumnTasks
        {
            get => new ObservableCollection<ProjectTask>(DoneColumn.Tasks);
            set
            {
                DoneColumn.Tasks = value.ToList();
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
                ToDoColumnTasks = new ObservableCollection<ProjectTask>(columns[0].Tasks);
                InProgressColumnTasks =  new ObservableCollection <ProjectTask>(columns[1].Tasks);
                DoneColumnTasks = new ObservableCollection<ProjectTask>(columns[2].Tasks);
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
