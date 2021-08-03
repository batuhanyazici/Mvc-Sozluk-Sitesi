using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        Context _context = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult PartialContactMenu()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListInbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListSendbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draft = mm.GetList().Count(x => x.isDraft == true);
            ViewBag.drafts = draft;

            var readMessage = mm.GetList().Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetListUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }
    }
}