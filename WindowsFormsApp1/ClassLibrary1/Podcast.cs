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
            MessageBox.Show("Podcasten " + namn + " har blivit tillagd i kategorin " + kategoriNamn + ".");
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



        public void laggTillNyPodcast(String URL, String namn, string intervall, String kategori)
        {
            Avsnitt avsnittelm = new Avsnitt();
            List<string> speladeAvsnitt = avsnittelm.hamtaSpeladeAvsnitt(namn, kategori);
            string path = Directory.GetCurrentDirectory() + @"/" + kategori + @"\" + namn + @".xml";
            File.Delete(path);
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

                for (int j = 0; j < speladeAvsnitt.Count; j++)
                {
                    
                        xmlOut.WriteElementString("title", title.InnerText);
                        xmlOut.WriteElementString("enclosure", enclosure.InnerText);
                    if (speladeAvsnitt[j] == "Listened")
                    {
                        xmlOut.WriteElementString("status", "Listened");
                    } else
                    {
                        xmlOut.WriteElementString("status", "Unlistened");
                    }
                }
                    

                xmlOut.WriteEndElement();
                i++;
            }
            xmlOut.WriteEndDocument();
            xmlOut.Close();
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

            var podUrl = podcastsElm.hamtaPodcastInfo("url", kategori, podcast);

            return podUrl;
        }

        public string hamtaPodcastIntervall(string kategori, string podcast)
        {
            PodcastData podcastsElm = new PodcastData();

            var intervall = podcastsElm.hamtaPodcastInfo("interval", kategori, podcast);
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

        public void skrivBeskrivning(string kategori, string podcast, string avsnitt, RichTextBox rtb)
        {
            string beskrivning;

            AvsnittData avsnittElm = new AvsnittData();


            beskrivning = avsnittElm.hamtaAvsnittsInfo(kategori, podcast, avsnitt, "description");

            rtb.Text = beskrivning;
        }

        public void skrivPodcastInfo(string valdKategori, string valdPod, TextBox tburl, TextBox tbnamn, ComboBox cbkategori, ComboBox cbpodcast, ComboBox cbintervall, ComboBox cbnykategori)
        {
            tburl.Text = hamtaPodcastUrl(valdKategori, valdPod);
            tbnamn.Text = cbpodcast.Text;

            var valdPodIntervall = hamtaPodcastIntervall(valdKategori, valdPod);

            var valdPodIntervallIndex = hamtaIntervalIndex(valdPodIntervall);

            cbintervall.SelectedIndex = valdPodIntervallIndex;
            cbnykategori.SelectedIndex = cbkategori.SelectedIndex;
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

            if (valdPodcast != nyttNamn)
            {
                bytPodNamn(valdKategori, valdPodcast, nyttNamn);
                MessageBox.Show("Infon för podcast " + nyttNamn + " är uppdaterad.");
            }
            else
            {
                MessageBox.Show("Infon för podcast " + valdPodcast + " är uppdaterad.");
            }
        }

        public void andraPodcastItem(string kategori, string podcast, string item, string nyttItem)
        {
            PodcastData podelm = new PodcastData();
            if(nyttItem != "")
            {
                podelm.andraPodcastInfo(kategori, podcast, item, nyttItem);
            }
        }

        public void bytPodNamn(string kategori, string podcast, string nyttNamn)
        {
            if (nyttNamn != "")
            {
                string gammalPath = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + ".xml";
                string nyPath = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + nyttNamn + ".xml";
                File.Move(gammalPath, nyPath);
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
                MessageBox.Show(podcast + " är borttagen.");
            }
        }

        public void rensaFaltAndraPod(ComboBox cbAndraPod, TextBox tbAndraPodUrl, TextBox tbAndraPodNamn, ComboBox cbAndraPodIntervall, ComboBox cbAndraPodAndraKategori)
        {
            cbAndraPod.Items.Clear();
            tbAndraPodUrl.Clear();
            tbAndraPodNamn.Clear();
            cbAndraPodIntervall.Items.Clear();
            cbAndraPodAndraKategori.Items.Clear();
        }

        public void rensaFaltNyPod(TextBox tbURL, TextBox tbPodNamn, ComboBox cbValjIntervall, TextBox tbNyKategori)
        {
            tbURL.Clear();
            tbPodNamn.Clear();
            cbValjIntervall.Items.Clear();
            tbNyKategori.Clear();
        }

        
    }
}
