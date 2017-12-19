using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yazlab_13.Models
{
    public class SonucModel
    {
        public string url { get; set; }
        public string baslik { get; set; }
        public int puan { get; set; }
        public List<Anahtar_Kelime> anahtar_kelimeler { get; set; }

        public SonucModel()
        {
            anahtar_kelimeler = new List<Anahtar_Kelime>();
        }
    }
}