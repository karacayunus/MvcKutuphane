using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); //tabloları tutacak ve propertieslere erişim sağlayacak
        public ActionResult Index()
        {
            var degerler = db.TBLUYELER.ToList();
            return View(degerler);
        }
    }
}