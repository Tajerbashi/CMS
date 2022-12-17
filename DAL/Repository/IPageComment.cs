using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPageComment
    {
        IEnumerable<PageComment> GetCommentByNewsId(int id);
        bool AddComment(PageComment pageComment);
    }
}
