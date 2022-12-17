using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class PageComment
    {
        [Key]
        public int PageCommentId { get; set; }

        [Required(ErrorMessage = "News Title is Empty !")]
        [Display(Name = "News Title")]
        public int PageId { get; set; }

        [Required(ErrorMessage = "News Name is Empty !")]
        [Display(Name = "Name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "WebSite")]
        [MaxLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        public virtual Page Page { get; set; }

    }
}
