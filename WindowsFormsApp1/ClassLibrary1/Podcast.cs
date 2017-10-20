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
            NyPodcast podcast = new NyPodcast();
            podcast.addPod(nyKategori, url, namn, intervall, kategori);
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

        public string[] listaFranEnKategori(string kategori)
        {
            String path = Directory.GetCurrentDirectory() + @"\" + kategori;
            string[] filNamn = Directory.GetFiles(path);
            return filNamn;

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

            var podUrl = podcastsElm.hamtaEttYttrePodcastItem("channel", "interval", kategori, podcast);

            return podUrl;
        }

        public int hamtaIntervalIndex(string intervallText)
        {
            int intervallIndex= 0;

            switch (intervallText)
            {
                case "5000":
                    intervallIndex = 0;
                    break;
                case "10000":
                    intervallIndex = 1;
                    break;
                case "20000":
                    intervallIndex = 2;
                    break;
                case "30000":
                    intervallIndex = 3;
                    break;
                default:
                    intervallIndex = 5;
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
            if (podcastDataElement.hamtaEttInnrePodcastItem(kategori, podcast, avsnitt, "status").Equals("Lyssnad"));
            {
                spelad = true;
            }
            return spelad;
        }
    }
}
