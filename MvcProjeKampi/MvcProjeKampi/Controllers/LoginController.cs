using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        AdminLoginManager adminloginmanager = new AdminLoginManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.AdminUserPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            p.AdminUserPassword = result;

            //Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            var adminuserinfo = adminloginmanager.GetAdmin(p.AdminUserName, p.AdminUserPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string writerpassword = p.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(writerpassword)));
            p.WriterPassword = result;

            //Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            var adminuserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.WriterMail, false);
                Session["WriterMail"] = adminuserinfo.WriterMail;
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public PartialViewResult WriterName()
        {
            string p = (string)Session["WriterMail"];
            string name = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.name = name;
            string surname = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterSurname).FirstOrDefault();
            ViewBag.surname = surname;
            return PartialView();
        }

    }
}