using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Required(ErrorMessage = "Selected Group!")]
        [Display(Name = "Group Title")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Title is Empty !")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public String Title { get; set; }

        [Required(ErrorMessage = "Description is Empty !")]
        [Display(Name = "Description")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required(ErrorMessage = "Text is Empty !")]
        [Display(Name = "Text")]
        [DataType(DataType.MultilineText)]
        public String Text { get; set; }

        [Required(ErrorMessage = "Visit is Empty !")]
        [Display(Name = "Visit")]
        public int Visit { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "ShowSlider is Empty !")]
        [Display(Name = "ShowSlider")]
        public bool ShowSlider { get; set; }

        [Required(ErrorMessage = "CreateTime is Empty !")]
        [Display(Name = "CreateTime")]
        [DisplayFormat(DataFormatString ="{0: yyyy/MM/dd}")]
        public DateTime CreateTime { get; set; }

        public virtual List<PageComment> PageComments { get; set; }
        public virtual PageGroup PageGroup { get; set; }

        public Page()
        {

        }

    }

}
