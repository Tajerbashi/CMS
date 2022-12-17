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
        DBContextsModels DB;
        public PageRepository(DBContextsModels db)
        {
            this.DB = db;
        }
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

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<Page> GetAllPage()
        {
            return DB.Pages;
        }

        public Page GetPageId(int Id)
        {
            return DB.Pages.Find(Id);
        }

        public IEnumerable<Page> LastNews(int take = 5)
        {
            return DB.Pages.OrderByDescending(news => news.CreateTime).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return DB.Pages.Where(page => page.ShowSlider);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return DB.Pages.Where(c => c.Title.Contains(search) || c.Text.Contains(search) || c.Description.Contains(search) || c.Tags.Contains(search)).Distinct();
        }

        public IEnumerable<Page> ShowPageByGroupId(int id)
        {
            return DB.Pages.Where(p => p.GroupID==id);
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return DB.Pages.OrderByDescending(n => n.Visit).Take(take);
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
