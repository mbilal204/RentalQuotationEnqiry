using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalQuotation.Model;
using RentalQuotation.Repository.Interface;
using RentalQuotationEnqiry.Models;

namespace RentalQuotationEnqiry.Controllers
{
    public class MenuController : Controller
    {

        private readonly IMenuRepo _menuData;
        public MenuController(IMenuRepo menuData)
        {
            _menuData = menuData;
        }
        [LoginAttribute]
        public ActionResult Create()
        {
            return View();
        }
        [LoginAttribute]
        public ActionResult Index()
        {
            var quotations = _menuData.GetAll().ToList();
            return View(quotations);
        }
        public ActionResult Delete(int id)
        {
            _menuData.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var edt = _menuData.Edit(id);
            return View("Create", edt);
        }
        [HttpPost]
        public ActionResult Save(Menu model)
        {
            if (model.MenuId > 0)
                _menuData.Update(model);
            else
                _menuData.Insert(model);
            return RedirectToAction("Index");
        }
    }
}