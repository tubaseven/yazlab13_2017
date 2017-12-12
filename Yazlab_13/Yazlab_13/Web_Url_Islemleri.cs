using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Yazlab_13
{
    class Web_Url_Islemleri
    {
        public int IcerikteKelimeSay(string p_icerik, string p_aranan_kelime)
        {
            // aramalarda küçük harfle arama yapılsın diye
            p_aranan_kelime = p_aranan_kelime.ToLower();
            p_icerik = p_icerik.ToLower();

            int gecme_sayisi = 0;

            int index = 0;

            do
            {
                int new_index = p_icerik.IndexOf(p_aranan_kelime, index);
                if (new_index != -1)
                {
                    index = new_index + 1;
                    gecme_sayisi++;
                }
                else
                {
                    break;
                }
            } while (index < p_icerik.Length);

            return gecme_sayisi;
        }







        public string TemizWebSayfasiIcerigiAl(string p_url)
        {
            string html_web_sayfasi = HttpIstegiYap(p_url);
            string temizlenmis_icerik = HtmlIfadeleriniTemizle(html_web_sayfasi);

            return temizlenmis_icerik;
        }


        public string BasligiAl(string p_icerik)
        {
            Match m = Regex.Match(p_icerik, @"<title>\s*(.+?)\s*</title>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return "";
            }
        }


        public string HtmlIfadeleriniTemizle(string p_icerik)
        {
            if (p_icerik == null || p_icerik == string.Empty)
                return string.Empty;

            return System.Text.RegularExpressions.Regex.Replace(p_icerik, "<[^>]*>", string.Empty);
        }

        public string HttpIstegiYap(string url)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.UTF8.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?
            return sb.ToString();
        }
    }
}