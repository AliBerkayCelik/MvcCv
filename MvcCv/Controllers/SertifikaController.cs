using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
		GenericRepository<TBLSERTIFIKA> repo = new GenericRepository<TBLSERTIFIKA>();
		// GET: Sertifika
		public ActionResult Index()
        {
            var sertifka = repo.List();
            return View(sertifka);
        }
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
		[HttpPost]
		public ActionResult SertifikaGuncelle(TBLSERTIFIKA p)
		{
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Tarih = p.Tarih;
            sertifika.Aciklama = p.Aciklama;
            sertifika.SertikaLink = p.SertikaLink;
            repo.TUpdate(sertifika);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
		[HttpPost]
		public ActionResult YeniSertifika(TBLSERTIFIKA p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }
	}
}