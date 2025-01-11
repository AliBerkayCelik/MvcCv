using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        CvDataBaseEntities1 db=new CvDataBaseEntities1();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TBLSOSYALMEDYA.ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Egitim()
        {
            var egitim=db.TBLEGITIM.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenek = db.TBLYETENEKLER.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobiler()
        {
			var hobi = db.TBLHOBILERIM.ToList();
            return PartialView(hobi);
		}
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TBLSERTIFIKA.ToList();
            return PartialView(sertifika);

        }
        [HttpGet]
		public PartialViewResult iletisim()
		{
			
			return PartialView();
		}
        [HttpPost]
		public PartialViewResult iletisim(TBLILETISIM t)
		{
            t.Tarih =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
			return PartialView();
		}
	}
}