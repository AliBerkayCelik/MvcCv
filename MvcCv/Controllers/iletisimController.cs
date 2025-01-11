using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
		GenericRepository<TBLILETISIM> repo = new GenericRepository<TBLILETISIM>();
		// GET: iletisim
		public ActionResult Index()
        {
            var mesajlar=repo.List();
            return View(mesajlar);
        }
        public ActionResult iletisimSil(int id)
        {
            var iletisim=repo.Find(x=>x.ID==id);
            repo.Tdelete(iletisim);
            return RedirectToAction("Index");
        }
    }
}