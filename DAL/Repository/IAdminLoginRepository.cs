using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAdminLoginRepository:IDisposable
    {
        IEnumerable<AdminLogin> GetAllAdmin();
        AdminLogin GetAdminById(int Id);
        bool CreateAdmin(AdminLogin admin);
        bool UpdateAdmin(AdminLogin admin);
        bool DeleteAdmin(AdminLogin admin);
        bool DeleteAdmin(int Id);
        bool IsAdmin(AdminLogin admin);
        void Save();
    }
}
