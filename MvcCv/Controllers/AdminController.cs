using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
  
    public class AdminController : Controller
    {
		// GET: Admin
		GenericRepository<TBLADMIN> repo = new GenericRepository<TBLADMIN>();
		public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Ekle(TBLADMIN p)
		{
			
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		public ActionResult AdminSil(int id)
		{
			var veri = repo.Find(x => x.ID == id);
			repo.Tdelete(veri);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AdminDuzenle(int id)
		{
			var veri = repo.Find(x => x.ID == id);
			return View(veri);
		}
		[HttpPost]
		public ActionResult AdminDuzenle(TBLADMIN t)
		{
			var veri = repo.Find(x => x.ID == t.ID);
			veri.KullaniciAdi = t.KullaniciAdi;
			veri.Sifre = t.Sifre;
			repo.TUpdate(veri);
			return RedirectToAction("Index");
		}
	}
}