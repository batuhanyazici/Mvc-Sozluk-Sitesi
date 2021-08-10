using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageValidator messagevalidator = new MessageValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
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
                p.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
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
        public ActionResult Draft(string p)
        {
            var messagelist = mm.GetListSendbox( p);
            var draftList = messagelist.FindAll(x=>x.isDraft==true);
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
        public ActionResult ReadMessage(string p)
        {
            var readMessage = mm.GetList(p).Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }
        public ActionResult UnReadMessage(string p)
        {
            var unReadMessage = mm.GetListUnRead(p);
            return View(unReadMessage);
        }
        public ActionResult Search(string p)
        {
            string d = (string)Session["WriterMail"];
            var values = mm.GetSearch(p,d);
            return View(values);
        }
    }
}