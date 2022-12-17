using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Write Group Title !")]
        [Display(Name = "Group Title")]
        [MaxLength(150)]
        public String GroupTitle { get; set; }

        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {

        }
    }
}
