//using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Nickname { get; set; }
        public  List<Project> Projects { get; set; }

        /*public static explicit operator User(UserViewModel v)
        {
            throw new NotImplementedException();
        }*/
        public override string ToString()
        {
            return string.Format(Nickname);
        }
    }
}
