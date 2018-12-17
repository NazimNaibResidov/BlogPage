using BlogPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPage.Controllers
{
    public class HomeController : Controller
    {
        BlogContext context = new BlogContext();
       
        public ActionResult Index(int id = 1)
        {
            ViewBag.num= context.Makales.Count() / 2;
           

            int count = (id - 1) * 2;
            var data = context.Makales.OrderByDescending(x => x.id).Skip(count).Take(2);
            return View("Blog", data);
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string name)
        {
            return View();
        }
        public ActionResult Popular()
        {
            ViewBag.pop = context.Makales.OrderByDescending(x => x.EkelemeTarixi).Take(4).ToList();
            return View(context.Makales.OrderByDescending(x => x.Begeni).Take(4).ToList());
        }
       
     }
}