using System;
using System.Collections.Generic;
using System.Text;

namespace App.Database.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Column Column { get; set; }
        public override string ToString()
        {
            return string.Format(Title);
        }
    }
}
