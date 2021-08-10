using DataAccesLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName="Yazılım",
                CategoryCount=8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName="Seyehat",
                CategoryCount=4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }
        public ActionResult CategoryPieChart()
        {
            return View();
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> categoryCharts = new List<CategoryClass>();
            using (var context = new Context())
            {
                categoryCharts = context.Categories.Select(c => new CategoryClass
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }

            return categoryCharts;
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }

        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var context = new Context())
            {
                writerCharts = context.writers.Select(c => new WriterChart
                {
                    WriterName = c.WriterName,
                    WriterCount = c.headings.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        //public List<HeadingChart> HeadingList()
        //{
        //    List<HeadingChart> headingCharts = new List<HeadingChart>();
        //    using (var context = new Context())
        //    {
        //        headingCharts = context.Headings.Select(c => new HeadingChart
        //        {
        //            HeadingName = c.HeadingName,
        //            ContentCount = c.Contents.Count()
        //        }).ToList();
        //    }

        //    return headingCharts;
        //}
        //public ActionResult HeadingChart()
        //{
        //    return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        //}
    }
}