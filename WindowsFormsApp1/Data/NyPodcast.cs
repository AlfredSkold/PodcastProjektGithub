using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Data
{
    public class NyPodcast
    {
        public void addPod(bool nyKategori, String URL, String namn, String intervall, String kategori)
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

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("channel");
            xmlOut.WriteElementString("interval", intervall);
            xmlOut.WriteElementString("url", URL);
            xmlOut.WriteElementString("lastSync", DateTime.Now.ToString());
            int i = 0;
            foreach(XmlNode item
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
       

       
    }
}
