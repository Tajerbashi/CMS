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
        IEnumerable<PageComment> GetAllPageComment();
        PageComment GetPageCommentId(int Id);
        bool CreatePageComment(PageComment comment);
        bool UpdatePageComment(PageComment comment);
        bool DeletePageComment(PageComment comment);
        bool DeletePageComment(int Id);
        void Save();
    }
}
