using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalQuotation.Model;


namespace RentalQuotation.Repository.Interface
{
    public interface IRoleRepo
    {
        void Delete(int id);
        Role Update(Role model);
        Role Edit(int id);
        Role Insert(Role model);
        IEnumerable<Role> GetAll();
        IEnumerable<Menu> GetMenus();

    }
}
