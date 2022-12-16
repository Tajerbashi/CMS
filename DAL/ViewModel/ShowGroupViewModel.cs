using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class ShowGroupViewModel
    {
        public int GroupId { get; set; }
        public String GroupTitle { get; set; }
        public int PageCount { get; set; }
    }
}
