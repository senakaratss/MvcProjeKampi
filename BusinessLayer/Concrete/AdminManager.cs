using BusinessLayer.Abstract;
using BusinessLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAddBL(Admin admin)
        {
            admin.AdminPassword = BCryptHasher.Hash(admin.AdminPassword);
            _adminDal.Insert(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdateBL(Admin admin)
        {
            var currentAdmin = _adminDal.Get(x => x.AdminId == admin.AdminId);
            currentAdmin.AdminUsername = admin.AdminUsername;
            currentAdmin.AdminRole = admin.AdminRole;
            if (!string.IsNullOrEmpty(admin.AdminPassword))
            {
                currentAdmin.AdminPassword = BCryptHasher.Hash(admin.AdminPassword);
            }
            _adminDal.Update(currentAdmin);

        }

        public Admin GetAdminByIdBL(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetAdminByUsernameBL(string username)
        {
            return _adminDal.GetByUsername(username);
        }

        public List<Admin> GetListBL()
        {
            return _adminDal.List();
        }

        public Admin LoginBL(string username, string password)
        {
            var admin = _adminDal.Get(x => x.AdminUsername == username);
            if (admin == null)
            {
                return null;
            }
            bool isValidPassword = BCryptHasher.Verify(password, admin.AdminPassword);
            return isValidPassword ? admin : null;
        }
    }
}
