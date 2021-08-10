using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Context _context = new Context();
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        public PartialViewResult Statistic()
        {
            var heading = hm.GetList().Count();
            ViewBag.heading = heading;
            var content = cm.GetList().Count();
            ViewBag.content = content;
            var writer = wm.GetList().Count();
            ViewBag.writer = writer;
            var message = mm.ListAll().Count();
            ViewBag.message = message;
            
            return PartialView();
        }
    }
}