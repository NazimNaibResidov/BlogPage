using BlogPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPage.Controllers
{
    public class CategoryController : Controller
    {
        BlogContext context=new  BlogContext ();
        
       
        // GET: Category
        public ActionResult Index()
        {
            return View(context.Kategoris.ToList());
        }
    }
}