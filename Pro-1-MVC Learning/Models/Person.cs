using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Family { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}