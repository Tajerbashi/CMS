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
    public class PageRepository:IPageRepository
    {
        DBContextsModels DB = new DBContextsModels();
        public bool CreatePage(Page page)
        {
            try
            {
                DB.Pages.Add(page);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                DB.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePage(int Id)
        {
            try
            {
                var group = GetPageId(Id);
                DeletePage(group);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Page> GetAllPage()
        {
            return DB.Pages;
        }

        public Page GetPageId(int Id)
        {
            return DB.Pages.Find(Id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }
        public bool UpdatePage(Page page)
        {
            try
            {
                DB.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
