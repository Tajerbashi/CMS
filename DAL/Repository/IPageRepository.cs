using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageId(int Id);
        bool CreatePage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int Id);
        void Save();
        IEnumerable<Page> TopNews(int take=4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int take=5);
        IEnumerable<Page> ShowPageByGroupId(int id);
    }
}
