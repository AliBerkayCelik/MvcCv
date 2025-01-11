using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TBLSOSYALMEDYA> repo = new GenericRepository<TBLSOSYALMEDYA>();
        // GET: SosyalMedya
        public ActionResult Index()
        {

            var veriler = repo.List();
            return View(veriler);
        }
        public ActionResult Sil(int id)
        {
            var veri = repo.Find(x => x.ID == id);
            repo.Tdelete(veri);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
			var veri = repo.Find(x => x.ID == id);
			return View(veri);
		}
		[HttpPost]
		public ActionResult Duzenle(TBLSOSYALMEDYA p)
		{
			var veri = repo.Find(x => x.ID == p.ID);
			veri.Ad = p.Ad;
			veri.Link = p.Link;
			veri.ikon = p.ikon;
			repo.TUpdate(veri);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Ekle(TBLSOSYALMEDYA p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
	}
}