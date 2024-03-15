using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RentalQuotation.Model;

namespace RentalQuotationEnqiry.Models
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string val = null;
            if (filterContext.HttpContext.Session["Login"] != null)
            {
                val = filterContext.HttpContext.Session["Login"].ToString();
            }

            if (string.IsNullOrEmpty(val))
            {
                filterContext.Result = new RedirectResult("/User/Login");
                return;
            }
            else
            {
                User u = JsonConvert.DeserializeObject<User>(val);

                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                bool hasRight = false;
                foreach (var item in u.Role.RoleMenus)
                {
                    if (controllerName == item.Menu.ControllerName)
                    {
                        hasRight = true;
                    }
                }
                if (hasRight == false)
                {
                    filterContext.Result = new RedirectResult("/User/Login");
                    return;
                }
                //List<RoleMenu> roleMenus = u.Role.RoleMenu.Where(x => x.Menu.ControllerName == controllerName).ToList(); //Linq Query
                //if (roleMenus.Count==0)
                //{
                //    context.Result = new RedirectResult("/Users/Login");
                //    return;
                //}
            }
        }
    }
}