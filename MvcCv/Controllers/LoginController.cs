using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Index(TBLADMIN p)
		{
            CvDataBaseEntities1 db = new CvDataBaseEntities1();
            var veri = db.TBLADMIN.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (veri != null)
            {
                FormsAuthentication.SetAuthCookie(veri.KullaniciAdi, false);
                Session["KullaniciAdi"] = veri.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
			
		}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
	}
}