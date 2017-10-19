using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.IO;
using System.Xml;

namespace Logic
{
    public class Podcast
    {
        public void nyPod (bool nyKategori, String url, String namn, String intervall, String kategori)
        {
            if(nyKategori)
            {
                String path = @"\" + Directory.GetCurrentDirectory() + kategori;
                Directory.CreateDirectory(kategori);
            }
            NyPodcast podcast = new NyPodcast();
            podcast.addPod(nyKategori, url, namn, intervall, kategori);
        }

        public void hamtaAvsnitt (String url)
        {

        }

        public List<string> listaMedKategoriNamn()
        {
            List<string> namn = new List<string>();
            String path = Directory.GetCurrentDirectory() + @"\KategoriNamn.xml";
            XmlTextWriter xtw;
            xtw = new XmlTextWriter(path, Encoding.UTF8);
            XmlDocument xdoc = new XmlDocument();
            xtw.WriteStartDocument();
            xtw.WriteStartElement("KategoriNamn");
            xtw.WriteEndElement();
            xtw.Close();

            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("Kategorier");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName("Namn")[i];
                    namn.Add(add.InnerText);
            }
            rfile.Close();

            return namn;

        }

        public string[] listaFranEnKategori(string kategori)
        {
            String path = Directory.GetCurrentDirectory() + @"\" + kategori;
            string[] filNamn = Directory.GetFiles(path);
            return filNamn;

        }


    }
}
