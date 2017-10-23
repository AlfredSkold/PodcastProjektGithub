using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    public class AvsnittData
    {
        public void andraAvsnittsInfo(string kategori, string podcast, string avsnitt, string attAndra, string nyInfo)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            
            string podID = hamtaAvsnittsId(kategori, podcast, avsnitt).ToString();

            string newValue = nyInfo;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xmlDoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xmlDoc.GetElementsByTagName(attAndra)[i];
                if ((cl.GetAttribute("ID")) == podID)
                {
                    add.InnerText = nyInfo;
                }
            }

            xmlDoc.Save(path);
        }

        private string hamtaAvsnittsId(string kategori, string podcast, string avsnitt)
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

        public string hamtaAvsnittsInfo(string kategori, string podcast, string avsnitt, string info)
        {
            var podcastItem = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            string podID = hamtaAvsnittsId(kategori, podcast, avsnitt).ToString();

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("item");
            string text = "";
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName(info)[i];
                text = cl.GetAttribute("ID");
                if ((cl.GetAttribute("ID")) == podID)
                {
                    podcastItem = add.InnerText;
                    Console.WriteLine(podcastItem + "    " + cl.GetAttribute("title") + "     " + avsnitt);
                    break;
                }
            }
            Console.WriteLine(text);
            rfile.Close();

            return podcastItem;
        }

        public List<string> hamtaFranAllaAvsnitt(string kategori, string podcast, string info)
        {
            List<string> podcastTitlar = new List<string>();
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("item")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName(info)[i];
                podcastTitlar.Add(add.InnerText); 
            }

            rfile.Close();

            return podcastTitlar;
        }

        public int nyaListanCount(string podcast)
        {
            List<string> podcastTitlar = new List<string>();
            var path = Directory.GetCurrentDirectory() + @"\xmlFiler\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(path, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("item");
            int antal = list.Count;

            rfile.Close();
            return antal;
        }
    }
}
