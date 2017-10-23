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

        public string hamtaPodcastInfo(string tagName, string kategori, string podcast)
        {
            var podcastItem = "";
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream fileS = new FileStream(path, FileMode.Open);
            xdoc.Load(fileS);
            XmlNodeList list = xdoc.GetElementsByTagName("channel");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement xElm = (XmlElement)xdoc.GetElementsByTagName(tagName)[i];
                podcastItem = xElm.InnerText;
                Console.WriteLine(podcastItem);
                break;
            }

            fileS.Close();

            return podcastItem;
        }



        
        
        public void andraPodcastInfo(string kategori, string podcast, string item, string nyInfo)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + kategori + @"\" + podcast + @".xml";
            
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("channel");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement add = (XmlElement)xmlDoc.GetElementsByTagName(item)[i];
                add.InnerText = nyInfo;
            }

            xmlDoc.Save(path);
        }
    }
}
