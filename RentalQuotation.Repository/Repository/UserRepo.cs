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
    public class UserRepo : IUserRepo
    {
        private readonly RentalQuotationEntities _db;
        public UserRepo(RentalQuotationEntities db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            try
            {
                var data = _db.Users.Find(id);
                _db.Users.Remove(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Edit(int id)
        {
            var user = _db.Users.Find(id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var users = _db.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public User Insert(User model)
        {
            try
            {
                var user = _db.Users.Add(model);
                _db.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Update(User model)
        {
            var user = _db.Users.Add(model);
            _db.SaveChanges();
            return user;
        }

        public User Login(User model)
        {
            var lst = _db.Users.Where(a => a.Email == model.Email && a.Password == model.Password).FirstOrDefault();
            return lst;
        }
    }
}
