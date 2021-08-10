using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        Context c = new Context();
        MessageValidator messagevalidator = new MessageValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];

            var sendMail = mm.GetListInbox(p).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListSendbox(p).Count();
            ViewBag.receiverMail = receiverMail;

            var draft = mm.GetList(p).Count(x => x.isDraft == true);
            ViewBag.drafts = draft;

            var readMessage = mm.GetList(p).Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetListUnRead(p).Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult Newmessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Newmessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                p.SenderMail = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Draft()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            var draftList = messagelist.FindAll(x => x.isDraft == true);
            return View(draftList);
        }
        public ActionResult IsRead(int id)
        {
            var result = mm.GetByID(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            mm.MessageUpdate(result);
            return RedirectToAction("ReadMessage");
        }
        public ActionResult ReadMessage()
        {
            string p = (string)Session["WriterMail"];
            var readMessage = mm.GetList(p).Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }
        public ActionResult UnReadMessage()
        {
            string p = (string)Session["WriterMail"];
            var unReadMessage = mm.GetListUnRead(p);
            return View(unReadMessage);
        }
        public ActionResult Search(string p)
        {
            string d = (string)Session["WriterMail"];
            var values = mm.GetSearch(p, d);
            return View(values);
        }
    }
}