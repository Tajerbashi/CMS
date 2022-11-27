using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public byte Age { get; set; }
    }
}