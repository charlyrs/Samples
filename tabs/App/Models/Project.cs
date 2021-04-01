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

        public List<User> Users { get; set; }
        public override string ToString()
        {
            return string.Format("({0}) {1}, {2}", Id, Title, Describtion);
        }

    }
}
