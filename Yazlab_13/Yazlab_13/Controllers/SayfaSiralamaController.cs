using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yazlab_13.Models;

namespace Yazlab_13.Controllers
{
    public class SayfaSiralamaController : Controller
    {
        // GET: SayfaSiralama
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transaction_SayfaSiralama(FormCollection form_collection)
        {
            string anahtar_kelime = form_collection["anahtar_kelime"];
            string url = form_collection["url"];

            List<SonucModel> liste = new List<SonucModel>();

            // işlemler...


            //  sahte işlemler::

            SonucModel sm1 = new SonucModel()
            {
                puan = 7,
                baslik = "Siber Güvenlik Önceliğimizdir",
                url = "https://www.ueaka.gov.tr/sayfalar/Siber_Guvenlik_Onceligimizdir"
            };
            SonucModel sm2 = new SonucModel()
            {
                puan = 3,
                baslik = "Türkiye'de Bilgi Güvenliği",
                url = "https://www.ueaka.gov.tr/sayfalar/Turkiyede_Bilgi_Guvenligi"
            };
            SonucModel sm3 = new SonucModel()
            {
                puan = 1,
                baslik = "Ortadoğuda Güvenlik Algısı",
                url = "https://gg.blogspot.com/sayfalar/Orta_doguda_guvenlik_algısı"
            };


            liste.Add(sm1);
            liste.Add(sm2);
            liste.Add(sm3);

            TempData["liste"] = liste;

            return RedirectToAction("Sonuc");

        }

        public ActionResult Sonuc()
        {
            return View();
        }
    }
}