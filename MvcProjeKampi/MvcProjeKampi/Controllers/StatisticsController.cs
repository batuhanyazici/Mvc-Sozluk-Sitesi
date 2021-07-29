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
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context context = new Context();
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            ViewBag.value = categoryvalues.Count();
            
            var headingvalues = hm.GetList();
            ViewBag.Heading = headingvalues.Count(x =>x.CategoryId==25);

            var writervalues = wm.GetList();
            ViewBag.Writers = writervalues.Count(x => x.WriterName.Contains("A"));

            ViewBag.MaxCategory = context.Headings.Max(x => x.Category.CategoryName);

            var TrueResults = context.Categories.Count(x => x.CategoryStatus == true);
            var FalseResults = context.Categories.Count(x => x.CategoryStatus == false);

            ViewBag.Status = (TrueResults - FalseResults);





            return View();
        }

    }
}