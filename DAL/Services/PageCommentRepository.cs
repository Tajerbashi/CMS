using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PageCommentRepository : IPageComment
    {
        DBContextsModels DB;
        public PageCommentRepository(DBContextsModels db)
        {
            this.DB = db;
        }

        public bool AddComment(PageComment pageComment)
        {
            DB.PageComments.Add(pageComment);
            DB.SaveChanges();
            return true;
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return DB.PageComments.Where(c => c.PageId == pageId);
        }

    }
}
