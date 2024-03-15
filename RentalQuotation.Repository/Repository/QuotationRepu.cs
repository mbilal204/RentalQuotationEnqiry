using RentalQuotation.Model;
using RentalQuotation.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotation.Repository
{
    public class QuotationRepu : IQuotationData
    {
        private readonly RentalQuotationEntities _db;

        public QuotationRepu(RentalQuotationEntities db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            try
            {
                var data = _db.QuotationLists.Find(id);
                _db.QuotationLists.Remove(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<QuotationList> GetAll()
        {
            try
            {
                var data = _db.QuotationLists.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public QuotationList Insert(QuotationList model)
        {
            try
            {
                var data = _db.QuotationLists.Add(model);
                _db.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public QuotationList Update(QuotationList model)
        {
            try
            {
                var quotationData = _db.QuotationLists.Where(x => x.Id == model.Id).FirstOrDefault();
                if (quotationData != null)
                {
                    quotationData.Remarks = model.Remarks;
                    quotationData.QuotationStatus = model.QuotationStatus;
                    _db.SaveChanges();
                }
                return quotationData;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
    }
}
