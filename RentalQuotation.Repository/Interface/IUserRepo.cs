using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalQuotation.Model;


namespace RentalQuotation.Repository.Interface
{
    public interface IUserRepo
    {
        void Delete(int id);
        User Update(User model);
        User Edit(int id);
        User Insert(User model);
        IEnumerable<User> GetAll();
       User Login(User model);
    }
}
