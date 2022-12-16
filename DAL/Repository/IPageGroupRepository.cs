using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<PageGroup> GetAllGroup();
        PageGroup GetGroupId(int Id);
        bool CreateGroup(PageGroup pageGroup);
        bool UpdateGroup(PageGroup pageGroup);
        bool DeleteGroup(PageGroup pageGroup);
        bool DeleteGroup(int Id);
        void Save();
        IEnumerable<ShowGroupViewModel> getGroupForView();
    }
}
