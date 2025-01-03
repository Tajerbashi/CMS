﻿using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PageGroupRepository : IPageGroupRepository
    {
        DBContextsModels DB;
        public PageGroupRepository(DBContextsModels db)
        {
            this.DB= db;
        }
        public bool CreateGroup(PageGroup pageGroup)
        {
            try
            {
                DB.PageGroups.Add(pageGroup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                DB.Entry(pageGroup).State= EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(int Id)
        {
            try
            {
                var group=GetGroupId(Id);
                DeleteGroup(group);
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

        public IEnumerable<PageGroup> GetAllGroup()
        {
            return DB.PageGroups;
        }

        public IEnumerable<ShowGroupViewModel> getGroupForView()
        {
            return DB.PageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupId = g.GroupId,
                GroupTitle= g.GroupTitle,
                PageCount=g.Pages.Count
            });
        }

        public PageGroup GetGroupId(int Id)
        {
            return DB.PageGroups.Find(Id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                DB.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
