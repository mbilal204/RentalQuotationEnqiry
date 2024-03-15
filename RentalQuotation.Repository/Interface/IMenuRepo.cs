using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalQuotation.Model;


namespace RentalQuotation.Repository.Interface
{
    public interface IMenuRepo
    {
        void Delete(int id);
        Menu Update(Menu model);
        Menu Edit(int id);
        Menu Insert(Menu model);
        IEnumerable<Menu> GetAll();
    }
}
