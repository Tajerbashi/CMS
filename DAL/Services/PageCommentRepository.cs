using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PageCommentRepository : IPageComment
    {
        DBContextsModels DB;
        public PageCommentRepository(DBContextsModels db)
        {
            this.DB = db;
        }
        public bool CreatePageComment(PageComment comment)
        {
            try
            {
                DB.PageComments.Add(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageComment(PageComment comment)
        {
            try
            {
                DB.Entry(comment).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageComment(int Id)
        {
            try
            {
                var comment = GetPageCommentId(Id);
                DeletePageComment(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<PageComment> GetAllPageComment()
        {
            return DB.PageComments;
        }

        public PageComment GetPageCommentId(int Id)
        {
            return DB.PageComments.Find(Id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool UpdatePageComment(PageComment comment)
        {
            try
            {
                DB.Entry(comment).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
