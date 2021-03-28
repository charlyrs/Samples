using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Describtion { get; set; }
        public int CreatorId { get; set; }

        public List<User> Users { get; set; }
        
    }
}
