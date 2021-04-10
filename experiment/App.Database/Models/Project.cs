using System;
using System.Collections.Generic;
using System.Text;
using App.Database.Models;

namespace App
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<Column> Columns { get; set; }
        public  List<User> Users { get; set; }
        public override string ToString()
        {
            return string.Format(Title);
        }

    }
}
