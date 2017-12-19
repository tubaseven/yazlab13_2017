using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yazlab_13.Models;

namespace Yazlab_13.Controllers
{
    public class URLdeSayController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Transaction_UrldeSay(FormCollection form_collection)
        {
            string anahtar_kelime = form_collection["anahtar_kelime"];
            string url = form_collection["url"];

            Web_Url_Islemleri web_url_islemleri = new Web_Url_Islemleri();


            string html_url_icerigi = web_url_islemleri.HttpIstegiYap(url);
            string temiz_url_icerigi = web_url_islemleri.HtmlIfadeleriniTemizle(html_url_icerigi);
            int gecme_sayisi = web_url_islemleri.IcerikteKelimeSay(temiz_url_icerigi, anahtar_kelime);

            string baslik = web_url_islemleri.BasligiAl(html_url_icerigi);



            //  sahte işlemler::

            SonucModel sm1 = new SonucModel()
            {
                puan = gecme_sayisi,
                baslik = baslik,
                url = url
            };


            TempData["sonuc"] = sm1;

            return RedirectToAction("Sonuc");
        }

        public ActionResult Sonuc()
        {
            return View();
        }
    }
}