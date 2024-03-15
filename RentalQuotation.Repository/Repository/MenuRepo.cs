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
    public class MenuRepo : IMenuRepo
    {
        private readonly RentalQuotationEntities _db;
        public MenuRepo(RentalQuotationEntities db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            try
            {
                var data = _db.Menus.Find(id);
                _db.Menus.Remove(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Menu> GetAll()
        {
            try
            {
                var menus = _db.Menus.ToList();
                return menus;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public Menu Insert(Menu model)
        {
            try
            {
                var menu = _db.Menus.Add(model);
                _db.SaveChanges();
                return menu;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Menu Update(Menu model)
        {
            try
            {
                _db.Entry(model).State = EntityState.Modified;
                _db.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Menu Edit(int id)
        {
            var model = _db.Menus.Find(id);
            return model;
        }

    }
}
