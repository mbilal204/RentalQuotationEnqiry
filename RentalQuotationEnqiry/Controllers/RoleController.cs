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
    public class RoleController : Controller
    {
        private readonly IRoleRepo _roleData;
        public RoleController(IRoleRepo roleData)
        {
            _roleData = roleData;
        }
        [LoginAttribute]
        public ActionResult Index()
        {
            var roles = _roleData.GetAll().ToList();
            return View(roles);
        }
        [LoginAttribute]
        public ActionResult Create()
        {
            List<Menu> menu = _roleData.GetMenus().ToList();
            ViewBag.Menu = menu;
            return View();
        }


        public ActionResult Delete(int id)
        {
            _roleData.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            List<Menu> menu = _roleData.GetMenus().ToList();
            ViewBag.Menu = menu;
            var edt = _roleData.Edit(id);
            return View("Create", edt);
        }
        [HttpPost]
        public ActionResult Save(Role model)
        {
            if (model.RoleId > 0)
                _roleData.Update(model);
            else
                _roleData.Insert(model);
            return RedirectToAction("Index");
        }
    }
}