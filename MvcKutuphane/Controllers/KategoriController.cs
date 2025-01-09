using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;  //Veri tabanınını tabloları kullanmak içi n
namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); //tabloları tutacak ve propertieslere erişim sağlayacak
        public ActionResult Index()  //ActionResult'lar ile methot tanımlıyoruz bunları arka planda view sayfasıyla ilişkilendirerek işlem yapıyoruz

        {
            var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }

        [HttpGet]   //sayfa yüklenince bura çalışsın (ki formu bi normal bi boş toplam 2 kere yüklemesin)
        public ActionResult KategoriEkle()
        {
           
            return View();
        }
        [HttpPost]  //veri ekleyince bura çalışsın
        public ActionResult KategoriEkle(TBLKATEGORI p)  //ekleme için ActionResult oluşturduk
        {
            db.TBLKATEGORI.Add(p);   //eklenece kısım
            db.SaveChanges();         //databaseye kaydetme
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id) 
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}