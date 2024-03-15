using RentalQuotation.Model;
using RentalQuotation.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotation.Repository
{
    public class CostComponentRepu : ICostComponent
    {
        private readonly RentalQuotationEntities _db;

        public CostComponentRepu(RentalQuotationEntities db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            try
            {
                var data = _db.QuotationDetails.Find(id);
                _db.QuotationDetails.Remove(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public QuotationDetail Insert(QuotationDetail model)
        {
            try
            {
                var data = _db.QuotationDetails.Add(model);
                _db.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public QuotationDetail Update(QuotationDetail model)
        {
            try
            {
                var data = _db.QuotationDetails.Add(model);
                _db.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
    }
}
