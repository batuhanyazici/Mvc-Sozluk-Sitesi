﻿using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentCardController : Controller
    {
        
        TalentCardManager talentCardManager = new TalentCardManager(new EfTalentCardDal());
        // GET: TalentCard
        public ActionResult Index()
        {
            Context context = new Context();
            var cardValues = talentCardManager.GetAll();

            var result = context.talentCards.Sum(x => x.SkillPoint) * 250 / 100;
            ViewBag.result = result;
            var result2 = context.talentCards.Sum(x => x.SkillPoint2) * 250 / 100;
            ViewBag.result2 = result2;
            var result3 = context.talentCards.Sum(x => x.SkillPoint3) * 250 / 100;
            ViewBag.result3 = result3;
            var result4 = context.talentCards.Sum(x => x.SkillPoint4) * 250 / 100;
            ViewBag.result4 = result4;
            var result5 = context.talentCards.Sum(x => x.SkillPoint5) * 250 / 100;
            ViewBag.result5 = result5;
            var result6 = context.talentCards.Sum(x => x.SkillPoint6) * 250 / 100;
            ViewBag.result6 = result6;
            var result7 = context.talentCards.Sum(x => x.SkillPoint7) * 250 / 100;
            ViewBag.result7 = result7;
            var result8 = context.talentCards.Sum(x => x.SkillPoint8) * 250 / 100;
            ViewBag.result8 = result8;
            var result9 = context.talentCards.Sum(x => x.SkillPoint9) * 250 / 100;
            ViewBag.result9 = result9;
            var result10 = context.talentCards.Sum(x => x.SkillPoint10) * 250 / 100;
            ViewBag.result10 = result10;

            return View(cardValues);
        }

        [HttpGet]
        public ActionResult EditTalent(int id)
        {
            id = 1;
            var talentvalue = talentCardManager.GetById(id);
            return View(talentvalue);
        }

        [HttpPost]
        public ActionResult EditTalent(TalentCard p)
        {
            talentCardManager.TalentCardUpdate(p);
            return RedirectToAction("Index");
        }
    }
}