using System;
using System.Collections.Generic;
using System.Text;

namespace App.Database.Models
{
    public class Column
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Project Project { get; set; }
        public override string ToString()
        {
            return string.Format(Title);
        }
    }
}
