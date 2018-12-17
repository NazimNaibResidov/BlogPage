using BlogPage.Models;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogPage.Controllers
{
    public class UsersController : Controller
    {
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(users users,HttpPostedFileBase File)
        {
            Yazar yaz = new Yazar();
            if (File!=null)
            {
               yaz.ResimID= ProfilPhto(File);
            }
            else
            {
                ProfilPhto(File);
            }
           
            MembershipCreateStatus status;
            MembershipUser user=   Membership.CreateUser(users.name, users.password,users.email,"naib","nazim",true,out status);
            if (user.IsApproved)
            {
                if(Session["id"]==null)
                {
                   
                       HttpContext.Session["id"] =user.ProviderUserKey;
                }
                yaz.Adi = user.UserName;
                yaz.Mail = user.Email;
                yaz.Tarixi = DateTime.Now;
                yaz.Aktivmi = true;
                yaz.Soyadi = users.surname;
                yaz.id =(Guid) user.ProviderUserKey;
                context.Yazars.Add(yaz);
                context.SaveChanges();
                FormsAuthentication.RedirectFromLoginPage(user.UserName, true);
                return RedirectToAction("Enter");
            }
            switch (status)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    break;
                case MembershipCreateStatus.UserRejected:
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    break;
                case MembershipCreateStatus.ProviderError:
                    break;
                default:
                    break;
            }




            return View();
        }
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(users users)
        {

            if(Membership.ValidateUser(users.name, users.password))
            {
                if (Session["id"] == null)
                {
                
                      HttpContext.Session["id"]=Membership.GetUser(users.name).ProviderUserKey;
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Users");
            }
           
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        private int ProfilPhto(HttpPostedFileBase fileBase)
        {
            Resim rs = new Resim();
            if (fileBase != null)
            {

                Image image = Image.FromStream(fileBase.InputStream);
                Bitmap profil = new Bitmap(image, 50, 50);
                string name = Guid.NewGuid() + Path.GetExtension(fileBase.FileName);
                profil.Save(Server.MapPath("~/Content/img/profil/" + name));
                rs.Adi = name.ToString();

                rs.Yazar = "/Content/img/profil/" + name;
               

            }
            else
            {
                rs.Yazar = "/Content/img/profil/Gray.jpg";
            }
            context.Resims.Add(rs);
            context.SaveChanges();
            return rs.id;
        }
    }
}