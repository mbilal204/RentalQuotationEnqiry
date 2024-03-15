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
    public class UserController : Controller
    {

        private readonly IUserRepo _userData;
        public UserController(IUserRepo userData)
        {
            _userData = userData;
        }
        [LoginAttribute]
        public ActionResult Index()
        {
            var users = _userData.GetAll().ToList();
            return View(users);
        }
        [LoginAttribute]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Delete(int id)
        {
            _userData.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var edt = _userData.Edit(id);
            return View("Create", edt);
        }
        [HttpPost]
        public ActionResult Save(User model)
        {
            if (model.UserId > 0)
                _userData.Update(model);
            else
                _userData.Insert(model);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            var lst = _userData.Login(model);
            if (lst != null)
            {
                string s = JsonConvert.SerializeObject(lst, Formatting.Indented,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                            });

                Session["Login"] = s;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Incorrect Email or Password";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}