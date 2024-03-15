using RentalQuotation.Model;
using RentalQuotation.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotation.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly RentalQuotationEntities _db;
        public RoleRepo(RentalQuotationEntities db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            try
            {
                var data = _db.Roles.Find(id);
                _db.Roles.Remove(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                var roles = _db.Roles.ToList();
                return roles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Role Insert(Role model)
        {
            try
            {
                var role = _db.Roles.Add(model);
                _db.SaveChanges();
                return role;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Role Update(Role model)
        {
            var role = _db.Roles.Add(model);
            _db.SaveChanges();
            return role;
        }
        public Role Edit(int id)
        {
            var model = _db.Roles.Where(x => x.RoleId == id).Include(z => z.RoleMenus).FirstOrDefault();
            return model;
        }

        public IEnumerable<Menu> GetMenus()
        {
            var menus = _db.Menus.ToList();
            return menus;
        }
    }
}
