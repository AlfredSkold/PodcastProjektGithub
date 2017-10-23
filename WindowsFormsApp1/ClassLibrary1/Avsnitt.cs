using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Logic
{
    public class Avsnitt
    {
        

        public async void fyllClbMedAvsnitt(string kategori, string podcast, ListBox clb, Label lbl)
        {

            clb.Items.Clear();

            Task<List<string>> result;

            
                result = fyllListan(kategori, podcast);
                lbl.Text = "Hämtar podcastens avsnitt...";

            List<string> allaAvsnitt = new List<string>();
            await result;
            allaAvsnitt = result.Result;

            foreach (string item in allaAvsnitt)
            {
                clb.Items.Add(item);
            }

            lbl.Text = "Avsnitt för " + podcast+ ":";
        }

        public async void fyllClbMedAvsnittNytt(string kategori, string podcast, ListBox clb, Label lbl)
        {
            
            clb.Items.Clear();
            Podcast podcastelm = new Podcast();
            Task<List<string>> result;
            var url = podcastelm.hamtaPodcastUrl(kategori, podcast);
            var intervall = podcastelm.hamtaPodcastIntervall(kategori, podcast);

            result = fyllListan(kategori, podcast);
            
            var nyttNamn = Directory.GetCurrentDirectory() +@"\"+ kategori+@"\" + podcast + ".xml";
            var gammaltNamn = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + "ny.xml";

            var path = Directory.GetCurrentDirectory() + @"\xmlFiler\" + podcast + ".xml";
            lbl.Text = "Finns ett nytt avsnitt för denna podcast, hämtar avsnitt...";
            podcastelm.bytUtXmlFil(kategori, podcast, url, intervall);
            
            List<string> allaAvsnitt = new List<string>();
            await result;
            File.Delete(path);
            File.Delete(nyttNamn);
            File.Move(gammaltNamn, nyttNamn);
            allaAvsnitt = result.Result;

            foreach (string item in allaAvsnitt)
            {
                clb.Items.Add(item);
            }

            lbl.Text = "Avsnitt för " + podcast + ":";
        }


        private async Task<List<string>> fyllListan(string kategori, string podcast)
        {
            return await Task.Run(() =>
            {

                List<string> allaAvsnitt = hamtaAvsnitt(podcast, kategori);
                for (int i = 0; i < allaAvsnitt.Count; i++)
                {
                    if (arAvsnittSpelat(kategori, podcast, allaAvsnitt[i]))
                    {
                        allaAvsnitt[i] += " (Lyssnad på)";
                    }
                }
                return allaAvsnitt;
            });
        }
        
        public async Task<bool> kollaOmNyttAvsnittFinns(string kategori, string podcast)
        {
            return await Task.Run(() =>
            {
                bool finns = false;
                Podcast podcastelm = new Podcast();
                List<string> allaGamlaAvsnitt = hamtaAvsnitt(podcast, kategori);
                laddaNerNyaAvsnitt(kategori, podcast);
                List<string> allaNyaAvsnitt = hamtaAvsnitt(podcast, "xmlFiler");
                var path = Directory.GetCurrentDirectory() + @"\xmlFiler\" + podcast + ".xml";
                var pathGammal = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + ".xml";

                if(allaGamlaAvsnitt.Count == allaNyaAvsnitt.Count)
                {
                    File.Delete(path);
                } else
                {
                    finns=  true;
                }
                return finns;
            });
        }

        private void laddaNerNyaAvsnitt(string kategori, string podcast)
        {
            Podcast podcastelm = new Podcast();
            var url = podcastelm.hamtaPodcastUrl(kategori, podcast);
            var intervall = podcastelm.hamtaPodcastIntervall(kategori, podcast);
            podcastelm.laggTillNyPodcast(false, url, podcast, intervall, "xmlFiler");
        }

        public string hamtaIntervallFörPod(string kategori, string podcast)
        {
            PodcastData podcastData = new PodcastData();
            string intervallTid = podcastData.hamtaPodcastInfo("interval", kategori, podcast);

            return intervallTid;
        }

        public bool arAvsnittSpelat(string kategori, string podcast, string avsnitt)
        {
            AvsnittData podcastDataElement = new AvsnittData();
            bool spelad = false;
            var status = podcastDataElement.hamtaAvsnittsInfo(kategori, podcast, avsnitt, "status");
            if (status == "Listened")
            {
                spelad = true;
            }
            return spelad;
        }

        private List<string> hamtaAvsnitt(String podcast, string kategori)
        {
            List<string> allaAvsnitt = new List<string>();
            XmlDocument xm = new XmlDocument();
            string list = "//title";

            string path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            xm.Load(path);
            XmlNodeList Xn = xm.SelectNodes(list);
            var hej = Xn.Count;
            foreach (XmlNode xNode in Xn)
            {
                allaAvsnitt.Add(xNode.InnerText);
            }
            return allaAvsnitt;
        }

        public List<string> hamtaSpeladeAvsnitt(String podcast, string kategori)
        {
            List<string> allaAvsnitt = new List<string>();
            XmlDocument xm = new XmlDocument();
            string list = "//status";

            string path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            xm.Load(path);
            XmlNodeList Xn = xm.SelectNodes(list);
            foreach (XmlNode xNode in Xn)
            {
                allaAvsnitt.Add(xNode.InnerText);
            }
            return allaAvsnitt;
        }

        public void spelaAvsnitt(string kategori, string podcast, string avsnitt, ListBox clb, int valtAvsnittIndex)
        {
            string avsnittFixad = avsnitt.Replace(".", "");
            string path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + avsnittFixad + ".mp3";
            MessageBox.Show("Laddar ner avsnittet och spelar strax");
            Console.WriteLine(path);

            if(!arAvsnittSpelat(kategori, podcast, avsnitt))
            {
                hamtaLjudfil(kategori, podcast, avsnitt, path);
                sattAvsnittSpelad(kategori, podcast, avsnitt);
                
            }

            System.Diagnostics.Process.Start(path);
        }

        private void hamtaLjudfil(string kategori, string podcast, string avsnitt, string path)
        {
            AvsnittData podcastDataElement = new AvsnittData();
            
            string ljudfilUrl = podcastDataElement.hamtaAvsnittsInfo(kategori, podcast, avsnitt, "enclosure");
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(new System.Uri(ljudfilUrl), path);
            }
        }

        public void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            System.Windows.Forms.ProgressBar progressbar = new System.Windows.Forms.ProgressBar();
            progressbar.Value = e.ProgressPercentage;
        }

        public void spelaLjudfil(string path)
        {
            

        }

        private void sattAvsnittSpelad(string kategori, string podcast, string avsnitt)
        {
            AvsnittData podelm = new AvsnittData();
            podelm.andraAvsnittsInfo(kategori, podcast, avsnitt, "status", "Listened");
        }

        public void hamtaNyttAvsnitt(string url, string kategori, string podcast)
        {

        }
    }
}
