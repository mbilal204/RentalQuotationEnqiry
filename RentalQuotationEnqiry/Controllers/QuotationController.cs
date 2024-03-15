using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RentalQuotation.Model;
using RentalQuotation.Repository.Interface;
using RentalQuotationEnqiry.Models;

namespace RentalQuotationEnqiry.Controllers
{
    public class QuotationController : Controller
    {

        private readonly IQuotationData _quotationData;
        private readonly ICostComponent _costCompData;

        public QuotationController(IQuotationData quotationData, ICostComponent costCompData)
        {
            _quotationData = quotationData;
            _costCompData = costCompData;
        }
        [LoginAttribute]
        public ActionResult Index()
        {
            string val = Session["Login"].ToString();
            User u = JsonConvert.DeserializeObject<User>(val);
            ViewBag.AdminUser = 0;
            if (u.Role.RoleName.ToUpper()=="ADMIN")
            {
                ViewBag.AdminUser = 1;
            }
            var quotations = _quotationData.GetAll().ToList();
            return View(quotations);
        }



        [HttpPost]
        public JsonResult AddRemarks(QuotationList modelData)
        {
            try
            {
                var dat = _quotationData.Update(modelData);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [LoginAttribute]
        public ActionResult CreateNewQuotation()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateQuotation(QuotationList modelData)
        {
            try
            {
                var dat = _quotationData.Insert(modelData);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { result = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [LoginAttribute]
        public ActionResult AddNewCostComponent()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCostComponent(QuotationDetail modelData)
        {
            try
            {
                var dat = _costCompData.Insert(modelData);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { result = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}