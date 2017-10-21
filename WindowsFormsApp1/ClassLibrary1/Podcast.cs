using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Logic
{
    public class Podcast
    {
        public void nyPod (String url, String namn, String intervall, string kategori, string nyKategoriNamn)
        {
            NyPodcast podcast = new NyPodcast();
            bool nyKategori = false;
            string kategoriNamn;
            if(nyKategoriNamn == "")
            {
                kategoriNamn = kategori;
                
            } else
            {
                kategoriNamn = nyKategoriNamn;
                nyKategori = true;
            }

            laggTillNyPodcast(nyKategori, url, namn, intervall, kategoriNamn);
        }
        private void laggTillNyPodcast(bool nyKategori, String URL, String namn, string intervall, String kategori)
        {

            if (nyKategori)
            {
                Directory.CreateDirectory(kategori);
            }


            string path = Directory.GetCurrentDirectory() + @"/" + kategori + @"\" + namn + @".xml";
            Console.WriteLine(path);
            rss rssVar = new rss();
            XmlDocument doc = rssVar.hamtaXML(URL);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            switch (intervall)
            {
                case "Var 5e sekund":
                    intervall = "5000";
                    break;
                case "Var 10e sekund":
                    intervall = "10000";
                    break;
                case "Var 20e sekund":
                    intervall = "20000";
                    break;
                case "Var 30e sekund":
                    intervall = "30000";
                    break;
            }

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("channel");
            xmlOut.WriteElementString("interval", intervall);
            xmlOut.WriteElementString("url", URL);
            xmlOut.WriteElementString("lastSync", DateTime.Now.ToString());
            int i = 0;
            foreach (XmlNode item
               in doc.DocumentElement.SelectNodes("channel/item"))
            {
                var title = item.SelectSingleNode("title");
                var description = item.SelectSingleNode("description");
                var enclosure = item.SelectSingleNode("enclosure/@url");

                xmlOut.WriteStartElement("item");

                xmlOut.WriteAttributeString("ID", "pod" + i);

                if (description.InnerText.Equals(""))
                {
                    xmlOut.WriteElementString("description", "Unfortunately, no description is available.");
                }
                else
                {
                    xmlOut.WriteElementString("description", description.InnerText);
                }

                xmlOut.WriteElementString("title", title.InnerText);
                xmlOut.WriteElementString("enclosure", enclosure.InnerText);
                xmlOut.WriteElementString("status", "Unlistened");

                xmlOut.WriteEndElement();
                i++;
            }
            xmlOut.WriteEndDocument();
            xmlOut.Close();


        }
        public List<string> hamtaAvsnitt (String podcast, string kategori)
        {
            List<string> allaAvsnitt = new List<string>();
            XmlDocument xm = new XmlDocument();
            string list = "//title";

            string path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            xm.Load(path);
            XmlNodeList Xn = xm.SelectNodes(list);

            foreach (XmlNode xNode in Xn)
            {
                allaAvsnitt.Add(xNode.InnerText);
            }
            return allaAvsnitt;
        }

        public string[] listaMedKategoriNamn()
        {
            String path = Directory.GetCurrentDirectory();
            string[] kategoriLista = Directory.GetDirectories(path);
            return kategoriLista;

        }

        public void fyllComboboxMedPodcasts(string kategori, ComboBox combobox)
        {
            String path = Directory.GetCurrentDirectory() + @"\" + kategori;
            string[] lista = Directory.GetFiles(path);
            combobox.Items.Clear();
            for (int i = 0; i < lista.Length; i++)
            {
                if (new FileInfo(lista[i]).Name.Contains(".xml"))
                {
                    string filnamn = new FileInfo(lista[i]).Name.Replace(".xml", "");
                    combobox.Items.Add(filnamn);
                }
            }

        }
        

        public string hamtaPodcastUrl(string kategori, string podcast)
        {
            PodcastData podcastsElm = new PodcastData();

            var podUrl = podcastsElm.hamtaEttYttrePodcastItem("channel", "url", kategori, podcast);

            return podUrl;
        }

        public bool lyssnadPa(string kategori, string podcast, string avsnitt)
        {
            bool lyssnad = false;
            PodcastData podcastDataElement = new PodcastData();
            var hamtad = podcastDataElement.hamtaEttInnrePodcastItem(kategori, podcast, avsnitt, "status");
            if(hamtad == "Listened")
            {
                lyssnad = true;
            }
            return lyssnad;
        }
        public string hamtaPodcastIntervall(string kategori, string podcast)
        {
            PodcastData podcastsElm = new PodcastData();

            var intervall = podcastsElm.hamtaEttYttrePodcastItem("channel", "interval", kategori, podcast);
            switch(intervall)
            {
                case "5000":
                    intervall = "Var 5e sekund";
                    break;
                case "10000":
                    intervall = "Var 10e sekund";
                    break;
                case "20000":
                    intervall = "Var 20e sekund";
                    break;
                case "30000":
                    intervall = "Var 30e sekund";
                    break;
            }
            return intervall;
        }

        public int hamtaIntervalIndex(string intervallText)
        {
            int intervallIndex= 0;

            switch (intervallText)
            {
                case "Var 5e sekund":
                    intervallIndex = 0;
                    break;
                case "Var 10e sekund":
                    intervallIndex = 1;
                    break;
                case "Var 20e sekund":
                    intervallIndex = 2;
                    break;
                case "Var 30e sekund":
                    intervallIndex = 3;
                    break;
            }
            return intervallIndex;
        }

        public string hamtaPodDesc(string kategori, string podcast, string avsnitt)
        {
            string podDesc;

            PodcastData podcastDataElement = new PodcastData();

            
            podDesc = podcastDataElement.hamtaEttInnrePodcastItem(kategori, podcast, avsnitt, "description");


            return podDesc;
        }

        public string hamtaLjudfil(string kategori, string podcast, string avsnitt)
        {
            PodcastData podcastDataElement = new PodcastData();
            avsnittSpelad(kategori, podcast, avsnitt);
            string ljudfilUrl = podcastDataElement.hamtaEttInnrePodcastItem(kategori, podcast, avsnitt, "enclosure");
            var ljudfilPath = podcastDataElement.hamtaLjudfil(ljudfilUrl, kategori, podcast, avsnitt);
            return ljudfilPath;
        }

        public void spelaLjudfil(string path)
        {
            System.Diagnostics.Process.Start(path);

        }

        public void avsnittSpelad(string kategori, string podcast, string avsnitt)
        {
            PodcastData podcastDataElement = new PodcastData();
            podcastDataElement.andraInnrePodcastItem(kategori, podcast, avsnitt, "status", "Listened");
        }

        public bool arAvsnittSpelat(string kategori, string podcast, string avsnitt)
        {
            PodcastData podcastDataElement = new PodcastData();
            bool spelad = false;
            var status = podcastDataElement.hamtaEttInnrePodcastItem(kategori, podcast, avsnitt, "status");
            if (status == "Listened")
            {
                spelad = true;
            }
            return spelad;
        }

        public void andraPodcast(string valdKategori, string valdPodcast, string nyUrl, string nyttNamn, string nyttIntervall, string nyKategori)
        {
            switch(nyttIntervall)
            {
                case "Var 5e sekund":
                    nyttIntervall = "5000";
                    break;
                case "Var 10e sekund":
                    nyttIntervall = "10000";
                    break;
                case "Var 20e sekund":
                    nyttIntervall = "20000";
                    break;
                case "Var 30e sekund":
                    nyttIntervall = "30000";
                    break;
            }
            andraPodcastItem(valdKategori, valdPodcast, "url", nyUrl);
            andraPodcastItem(valdKategori, valdPodcast, "interval", nyttIntervall);
            bytPodNamn(valdKategori, valdPodcast, nyttNamn);
        }

        public void andraPodcastItem(string kategori, string podcast, string item, string nyttItem)
        {
            PodcastData podelm = new PodcastData();
            if(nyttItem != "")
            {
                podelm.andraYttrePodcastItem(kategori, podcast, item, nyttItem);
            }
        }

        public void bytPodNamn(string kategori, string podcast, string nyttNamn)
        {
            PodcastData podelm = new PodcastData();
            if (nyttNamn != "")
            {
                podelm.bytPodcastNamn(kategori, podcast, nyttNamn);
            }
        }

        public void taBortPodcast(string kategori, string podcast, TextBox tbAndraPodNamn, TextBox tbAndraPodUrl, ComboBox cbAndraPodIntervall, ComboBox cbAndraPod)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill ta bort podcasten " +podcast+ "?", "Ta bort podcast", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                File.Delete(path);
                tbAndraPodNamn.Clear();
                tbAndraPodUrl.Clear();
                cbAndraPodIntervall.Items.Clear();
                cbAndraPod.Items.Clear();
            }
        }

        public void hamtaNyttAvsnitt(string url, string kategori, string podcast)
        {

        }
    }
}
