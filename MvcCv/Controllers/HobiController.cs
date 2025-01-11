using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
		GenericRepository<TBLHOBILERIM> repo = new GenericRepository<TBLHOBILERIM>();
        // GET: Hobi
        [HttpGet]
		public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
		[HttpPost]
		public ActionResult Index(TBLHOBILERIM p)
		{
			var t=repo.Find(x=>x.ID==1);
			t.Aciklama=p.Aciklama;
			t.Aciklama2 = p.Aciklama2;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}