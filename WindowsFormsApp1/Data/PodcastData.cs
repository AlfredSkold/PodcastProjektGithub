using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;

namespace Data
{
    public class PodcastData
    {

        public string hamtaEttYttrePodcastItem(string tag, string item, string kategori, string podcast)
        {
            var podcastItem = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName(tag);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName(item)[i];
                podcastItem = cl.InnerText;
                Console.WriteLine(podcastItem);
                break;
            }

            rfile.Close();

            return podcastItem;
        }

        public string hamtaEttInnrePodcastItem(string kategori, string podcast, string avsnitt, string item)
        {
            var podcastItem = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            string podID = hamtaPodId(kategori, podcast, avsnitt).ToString();

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("item");
            string text= "";
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName(item)[i];
                text = cl.GetAttribute("ID");
                if ((cl.GetAttribute("ID")) == podID)
                {
                    podcastItem = add.InnerText;
                    Console.WriteLine(podcastItem + "    " +cl.GetAttribute("title") + "     " +avsnitt);
                    break;
                }
            }
            Console.WriteLine(text);
            rfile.Close();

            return podcastItem;
        }

        private string hamtaPodId(string kategori, string podcast, string avsnitt)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            string podId = "";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("item");

            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName("title")[i];
                if (add.InnerText == avsnitt)
                {
                    podId = cl.GetAttribute("ID");
                    Console.WriteLine(podId);
                    break;
                }
            }
            rfile.Close();

            return podId;
        }

        public string hamtaLjudfil (string url, string kategori, string podcast, string avsnitt)
        {
            WebClient client = new WebClient();
            string path = Directory.GetCurrentDirectory() + @"\" + kategori +  @"\"+avsnitt+"Ljudfil.mp3";
            client.DownloadFile(url, path);

            return path;
        }

        public void andraInnrePodcastItem(string kategori, string podcast, string avsnitt, string item, string nyttItem)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            string podID = hamtaPodId(kategori, podcast, avsnitt).ToString();

            string newValue = nyttItem;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("item");
            for (int i = 0; i < list.Count ; i++)
            {
                XmlElement cl = (XmlElement)xmlDoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xmlDoc.GetElementsByTagName(item)[i];
                if ((cl.GetAttribute("ID")) == podID)
                {
                    add.InnerText = nyttItem;
                }
            }
                
            xmlDoc.Save(path);
        }

        public void andraYttrePodcastItem(string kategori, string podcast, string item, string nyttItem)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("channel");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement add = (XmlElement)xmlDoc.GetElementsByTagName(item)[i];
                add.InnerText = nyttItem;
            }

            xmlDoc.Save(path);
        }

        public void bytPodcastNamn(string kategori, string podcast, string nyttNamn)
        {
            string gammalPath = Directory.GetCurrentDirectory() + @"\" + kategori+ @"\" +podcast+ ".xml";
            string nyPath = Directory.GetCurrentDirectory() + @"\" + kategori+ @"\" + nyttNamn + ".xml";
            File.Move(gammalPath, nyPath);
        }
    }
}
