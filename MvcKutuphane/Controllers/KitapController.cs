using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD +" "+ i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;








            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            return View();
        }
    }
}