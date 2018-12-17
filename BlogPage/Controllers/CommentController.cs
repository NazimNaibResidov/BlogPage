using BlogPage.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogPage.Controllers
{
    public class CommentController : Controller
    {
        BlogContext context = new BlogContext();
     
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Yorum yorum,int id)
        {
            yorum.EkelemeTarixi = DateTime.Now;
            yorum.MakaleID = id;
           
            yorum.YazarID=(Guid)Session["id"];
            context.Yorums.Add(yorum);
            context.SaveChanges();
            return RedirectToAction("Detay", "Makale", new { id });

        }
        [HttpPost]
        public ActionResult  E(users users,int id)
        {

           
            if(Membership.ValidateUser(users.name,users.password))
             {
                Yazar yazar = new Yazar();
                yazar.Adi = users.name;
                yazar.Soyadi = users.name;
                yazar.Aktivmi = true;
                yazar.Tarixi = DateTime.Now;
                yazar.id = (Guid)Membership.GetUser(users.name).ProviderUserKey;
                
                if (Session["id"] == null)
                {
                   HttpContext.Session["id"] =(Guid)Membership.GetUser(users.name).ProviderUserKey;
                }
              }
          return  RedirectToAction("Detay","Makale", new {  id });
            
        }


    }
}