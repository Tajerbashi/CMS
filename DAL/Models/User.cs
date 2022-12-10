using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User: Person
    {
        public List<string> Skills  { get; set; }
        public List<string> Intrests { get; set; }
        public string Instagram  { get; set; }
        public string GitHub { get; set; }
    }
}
