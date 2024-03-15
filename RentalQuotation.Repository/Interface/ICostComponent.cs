using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalQuotation.Model;


namespace RentalQuotation.Repository.Interface
{
    public interface ICostComponent
    {
        void Delete(int quotationId);
        QuotationDetail Update(QuotationDetail model);
        QuotationDetail Insert(QuotationDetail emp);
    }
}
