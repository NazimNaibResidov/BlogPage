using BlogPage.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogPage.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MakaleController : Controller
    {
        BlogContext context = new BlogContext();
        public ActionResult Add()
        {
            ViewBag.kat = context.Kategoris.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Makale makale,HttpPostedFileBase File)
        {

            makale.Begeni = 0;
            makale.EkelemeTarixi = DateTime.Now;
            makale.GoruntlemeSayi = 0;
            makale.ResimID = SaveImage(File);
            makale.YazarID = (Guid)Session["id"];
            context.Makales.Add(makale);
            context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
        public ActionResult Detay(int id)
        {
          var data=  context.Makales.FirstOrDefault(x => x.id==id);
            return View(data);
        }
        public ActionResult Enter(string name,string password,int id)
        {
            if(Membership.ValidateUser(name,password))
            {
                return RedirectToAction("Detay", new { id = id });
            }
            return RedirectToAction("Index");
            
        }
        private int SaveImage(HttpPostedFileBase File)
        {
            Image img = Image.FromStream(File.InputStream);
            Bitmap big = new Bitmap(img, 840,327);
            Bitmap mid = new Bitmap(img, 326, 127);
            Bitmap smal = new Bitmap(img, 50, 50);
            string boyuk =Guid.NewGuid()+ Path.GetExtension(File.FileName);
           
            big.Save(Server.MapPath("~/Content/img/big/" + boyuk));
            smal.Save(Server.MapPath("~/Content/img/sml/" + boyuk));
            mid.Save(Server.MapPath("~/Content/img/mid/" + boyuk));
            Resim rs = new Resim();
            rs.Big = "/Content/img/big/" + boyuk;
            rs.Samll = "/Content/img/sml/" + boyuk;
            rs.Midel= "/Content/img/mid/" + boyuk; 
           
            context.Resims.Add(rs);
            context.SaveChanges();
            return rs.id;

        }
    }
}