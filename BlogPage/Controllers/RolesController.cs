using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogPage.Controllers
{
   
    public class RolesController : Controller
    {
       
     
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string name)
        {
            Roles.CreateRole(name);
            return View();
        }
        public ActionResult AUR()
        {
            ViewBag.roles = Roles.GetAllRoles();
            ViewBag.user = Membership.GetAllUsers();
            return View();
        }
        [HttpPost]
        public ActionResult AUR(string roleName,string userName)
        {
            Roles.AddUserToRole(userName, roleName);
            return RedirectToAction("Index", "Home");
        }
    }
}