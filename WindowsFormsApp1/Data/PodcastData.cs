using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Data
{
    public class PodcastData
    {

        public string hamtaEttYttrePodcastItem(string tag, string item, string kategori, string podcast)
        {
            var podcastUrl = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName(tag);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName(item)[i];
                podcastUrl = cl.InnerText;
                Console.WriteLine(podcastUrl);
                break;
            }

            rfile.Close();

            return podcastUrl;
        }

        public string hamtaEttInnrePodcastItem(string kategori, string podcast, string avsnitt, string id, string item)
        {
            var podcastItem = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("channel");
            string text= "";
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName(item)[i];
                text = cl.GetAttribute("ID");
                if ((cl.GetAttribute("ID")) == id)
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

        public string hamtaPodId(string kategori, string podcast, string avsnitt)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            string podId = "";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("channel");

            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName("title")[i];
                if (add.InnerText == avsnitt)
                {
                    podId = cl.GetAttribute("ID");
                    break;
                }
            }
            rfile.Close();

            return podId;
        }
    }
}
