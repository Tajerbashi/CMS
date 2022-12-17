using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        DBContextsModels DB;
        public AdminLoginRepository(DBContextsModels DB)
        {
            this.DB = DB;
        }
        public bool CreateAdmin(DAL.AdminLogin admin)
        {
            try
            {
                DB.AdminLogins.Add(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAdmin(DAL.AdminLogin admin)
        {
            try
            {
                DB.Entry(admin).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAdmin(int Id)
        {
            try
            {
                DAL.AdminLogin admin = DB.AdminLogins.Find(Id);
                this.DeleteAdmin(admin);
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

        public DAL.AdminLogin GetAdminById(int Id)
        {
            return DB.AdminLogins.Find(Id);
        }

        public IEnumerable<DAL.AdminLogin> GetAllAdmin()
        {
            return DB.AdminLogins.ToList();
        }

        public bool IsAdmin(DAL.AdminLogin admin)
        {
            try
            {
                return DB.AdminLogins.Any(admins => admins.Username == admin.Username && admins.Password == admin.Password);

            }
            catch
            {
                return false;
            } 
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool UpdateAdmin(DAL.AdminLogin admin)
        {
            try
            {
                DB.Entry(admin).State= EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
