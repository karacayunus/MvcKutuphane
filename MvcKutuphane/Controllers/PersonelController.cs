using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); //tabloları tutacak ve propertieslere erişim sağlayacak
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }

        [HttpGet]   //sayfa yüklenince bura çalışsın (ki formu bi normal bi boş toplam 2 kere yüklemesin)
        public ActionResult PersonelEkle()
        {

            return View();
        }
        [HttpPost]  //veri ekleyince bura çalışsın
        public ActionResult PersonelEkle(TBLPERSONEL p)  //ekleme için ActionResult oluşturduk
        {

            if (!ModelState.IsValid) {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);   //eklenece kısım
            db.SaveChanges();         //databaseye kaydetme
            return RedirectToAction("Index");
        }





        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);

        }

        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}