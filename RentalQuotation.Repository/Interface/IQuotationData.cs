using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalQuotation.Model;


namespace RentalQuotation.Repository.Interface
{
    public interface IQuotationData
    {
        void Delete(int quotationId);
        QuotationList Update(QuotationList model);
        QuotationList Insert(QuotationList model);
        IEnumerable<QuotationList> GetAll();
    }
}
