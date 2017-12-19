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
            // form'la gelen veriler alınıyor:
            string anahtar_kelime = form_collection["anahtar_kelime"];
            string url = form_collection["url"];

            // verilerin içinden boşluk karakterleri siliniyor:
            anahtar_kelime = anahtar_kelime.Replace(" ", "");
            url = url.Replace(" ", "");

            // gelen veriler çoklu olduğundan/virgülle ayrıldığından tek tek elde ediliyor
            string[] anahtar_kelimeler = anahtar_kelime.Split(',');
            string[] urller = url.Split(',');


            List<SonucModel> liste = new List<SonucModel>();

            // işlemler...

            for (int i = 0; i < urller.Length; i++)
            {
                string _url=urller[i];

                Web_Url_Islemleri web_url_islemleri = new Web_Url_Islemleri();
                string icerik = web_url_islemleri.TemizWebSayfasiIcerigiAl(_url);

                SonucModel sonuc = new SonucModel();
                sonuc.url = _url;
                sonuc.baslik = web_url_islemleri.BasligiAl(icerik);

                for (int j = 0; j < anahtar_kelimeler.Length; j++)
                {
                    string _anahtar_kelime = anahtar_kelimeler[j];
                    int gecme_sayisi = web_url_islemleri.IcerikteKelimeSay(icerik, _anahtar_kelime);

                    Anahtar_Kelime keyword = new Anahtar_Kelime();
                    keyword.isim = _anahtar_kelime;
                    keyword.sayi = gecme_sayisi;

                    sonuc.anahtar_kelimeler.Add(keyword);
                }

                // elde edilen her sayfa için oluşturulan sonuc nesnesi listeye ekleniyor:
                liste.Add(sonuc);
            }


            // puanlama işlemi:
            // formülasyon
            // her sayfa için verilen anahtar kelimelerin bulunma sayıları toplanıp,
            // elde edilen sayı puan oluyor
            for (int i = 0; i < liste.Count; i++)
            {
                SonucModel sonuc = liste.ElementAt(i);

                for (int j = 0; j < sonuc.anahtar_kelimeler.Count; j++)
                {
                    sonuc.puan += sonuc.anahtar_kelimeler.ElementAt(j).sayi;
                }
            }


            TempData["liste"] = liste;

            return RedirectToAction("Sonuc");

        }

        public ActionResult Sonuc()
        {
            return View();
        }
    }
}