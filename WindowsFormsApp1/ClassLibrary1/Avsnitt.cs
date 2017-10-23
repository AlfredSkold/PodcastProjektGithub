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

        //private async Task<List<string>> hamtaNyttAvsnitt(string kategori, string podcast)
        //{
        //    PodcastData podcastData = new PodcastData();
        //    AvsnittData avsnittData = new AvsnittData();
        //    string path = Directory.GetCurrentDirectory() + @"\xmlfiler\" + podcast + ".xml";
        //    string gammalPath = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + ".xml";



        //    return await Task.Run(() =>
        //    {
        //        List<string> allaAvsnitt = new List<string>();
        //        int i = 0;
        //        XmlDocument xdocNy = new XmlDocument();
        //        FileStream rfileNy = new FileStream(path, FileMode.Open);
        //        xdocNy.Load(rfileNy);

        //        XmlNodeList listNyaAvsnitt = xdocNy.GetElementsByTagName("item");
        //        XmlNode nyttAvsnitt = listNyaAvsnitt[0];
        //        XmlNodeList skfsdklfsdl = xdocNy.GetElementsByTagName("Channel");

        //        XmlDocument xdocGammal = new XmlDocument();
        //        FileStream rfileGammal = new FileStream(gammalPath, FileMode.Open);
        //        xdocGammal.Load(rfileGammal);

        //        var intervall = podcastData.hamtaPodcastInfo("interval", kategori, podcast);
        //        var podUrl = podcastData.hamtaPodcastInfo("url", kategori, podcast);


        //        XmlNodeList listGamlaAvsnitt = xdocGammal.GetElementsByTagName("item");

        //        nyttAvsnitt.PrependChild(skfsdklfsdl[0]);

        //        Console.WriteLine(skfsdklfsdl[0].InnerText + " " + nyttAvsnitt.InnerText);




                //XmlDocument xdoc = new XmlDocument();
                //FileStream rfile = new FileStream(gammalPath, FileMode.Open);
                //xdoc.Load(rfile);

                //XmlNodeList list = xdoc.GetElementsByTagName("item");
                //nyttAvsnitt.InsertBefore(nyttAvsnitt, list[i]);
                //var titelList = xdoc.GetElementsByTagName("title");
                //var nyttAvsnittTitle = titelList[i].InnerText;



                //rss rssVar = new rss();
                //XmlDocument doc = rssVar.hamtaXML(path);
                //XmlWriterSettings settings = new XmlWriterSettings();
                //settings.Indent = true;
                //settings.IndentChars = ("    ");
                //XmlWriter xmlOut = XmlWriter.Create(gammalPath, settings);


                //xmlOut.WriteStartDocument();
                //xmlOut.WriteStartElement("channel");
                //xmlOut.WriteElementString("interval", intervall);
                //xmlOut.WriteElementString("url", podUrl);
                //xmlOut.WriteElementString("lastSync", DateTime.Now.ToString());
                //int k = 0;
                //foreach (XmlNode item
                //   in list)
                //{


                //    var title = item.SelectSingleNode("title");

                //    var description = item.SelectSingleNode("description");
                //    var enclosure = item.SelectSingleNode("enclosure/@url");
                //    var dennaTitle = title.InnerText;
                //    var arLyssnad = avsnittData.hamtaAvsnittsInfo(kategori, podcast, dennaTitle, "status");

                //    xmlOut.WriteStartElement("item");

                //    xmlOut.WriteAttributeString("ID", "pod" + k);

                //    if (description.InnerText.Equals(""))
                //    {
                //        xmlOut.WriteElementString("description", "Unfortunately, no description is available.");
                //    }
                //    else
                //    {
                //        xmlOut.WriteElementString("description", description.InnerText);
                //    }
                //if (arLyssnad == "Unlistened")
                //{
                //    xmlOut.WriteElementString("title", title.InnerText);
                //} else
                //{
                //    xmlOut.WriteElementString("title", title.InnerText + " (lyssnad)");
                //}

                //    xmlOut.WriteElementString("enclosure", enclosure.InnerText);

                //if (arLyssnad == "Unlistened")
                //{
                //    xmlOut.WriteElementString("status", "Unlistened");
                //} else
                //{
                //    xmlOut.WriteElementString("status", "Listened");
                //}
                //    xmlOut.WriteEndElement();
                //    k++;
                //}
                //xmlOut.WriteEndDocument();
                //xmlOut.Close();


                //allaAvsnitt.Insert(0, nyttAvsnittTitle);

                //File.Delete(gammalPath);
                //File.Move(path, gammalPath);
                //allaAvsnitt.Insert(0, nyttAvsnittTitle);





        //        return allaAvsnitt;
        //    });
        //}



        //public async void nyttavsnittfyllclb(string kategori, string podcast, ListBox lb, Label lbl)
        //{
        //    var tid = hamtaIntervallFörPod(kategori, podcast);


        //    Task<List<string>> result = hamtaNyttAvsnitt(kategori, podcast);

        //        lb.Items.Clear();
        //        lbl.Text = "Nytt avsnitt har släppts, hämtar avsnitt...";


        //        List<string> allaavsnitt = new List<string>();
        //        await result;
        //        allaavsnitt = result.Result;

        //        foreach (string item in allaavsnitt)
        //        {
        //            lb.Items.Add(item);
        //        }

        //        lbl.Text = "avsnitt för " + podcast + ":";



        //}

        //public bool nyttAvsnittFinns(string kategori, string podcast, string url)
        //{
        //    //AvsnittData avsnittData = new AvsnittData();
        //    //string path = Directory.GetCurrentDirectory() + @"\xmlfiler\" + podcast + ".xml";


        //    //bool nyttAvsnitt = false;
        //    //using (WebClient wc = new WebClient())
        //    //{
        //    //    wc.DownloadFileAsync(new System.Uri(url), path);
        //    //}

        //    //int antalNya = avsnittData.nyaListanCount(podcast);
        //    //List<string> allaAvsnitt = hamtaAvsnitt(podcast, kategori);
        //    //if (allaAvsnitt.Count < 290)
        //    //{
        //    //    nyttAvsnitt = true;
        //    //} 
        //    //{
        //    //    File.Delete(path);
        //    //}
        //    return true;
        //}



        public string hamtaIntervallFörPod(string kategori, string podcast)
        {
            PodcastData podcastData = new PodcastData();
            string intervallTid = podcastData.hamtaPodcastInfo("interval", kategori, podcast);

            return intervallTid;
        }

        private bool arAvsnittSpelat(string kategori, string podcast, string avsnitt)
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
            var hej = Xn.Count;
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
