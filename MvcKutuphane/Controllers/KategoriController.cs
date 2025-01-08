using System;
using System.Collections.Generic;
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
    }
}