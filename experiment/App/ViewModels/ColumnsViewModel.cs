using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using App.Database;
using App.Database.DataBase;
using App.Database.Models;

namespace App.ViewModels
{
    public class ColumnsViewModel : INotifyPropertyChanged
    {
        private readonly ColumnRepo _columnRepo;

        public ColumnsViewModel(ColumnRepo repo)
        {
            _columnRepo = repo;
        }
        public int ProjectId { get; set; }
        public Column ToDoColumn { get; set; }
        public Column InProgressColumn { get; set; }
        public Column DoneColumn { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
