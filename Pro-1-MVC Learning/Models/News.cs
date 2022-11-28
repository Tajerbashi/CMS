using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public int Like { get; set; }
        public int CommentCount { get; set; }
        public String CommentInfo { get; set; }
        public bool IsActive { get; set; }
    }
}