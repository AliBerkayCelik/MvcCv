using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        
        GenericRepository<TBLYETENEKLER> repo=new GenericRepository<TBLYETENEKLER>();
        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
		public ActionResult YeniYetenek(TBLYETENEKLER p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Tdelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
			var yetenek = repo.Find(x => x.ID == id);
			return View(yetenek);
        }
		[HttpPost]
		public ActionResult YetenekGuncelle(TBLYETENEKLER t)
		{
			var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek=t.Yetenek;
            repo.TUpdate(y);
			return RedirectToAction("Index");
		}
	}
}