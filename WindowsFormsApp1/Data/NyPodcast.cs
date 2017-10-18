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
        public void addPod(String URL, String namn, String intervall, String kategori)
        {
            var databas = "C:\\Users\\alfre\\Desktop\\Visual Studios\\Projekt\\PodcastProjektGithub\\WindowsFormsApp1\\Data\\Databas.xml";

            openXMLDoc(databas);

            insertItems(databas, URL, namn, intervall, kategori);
        }
        private void openXMLDoc(String databas)
        {
            XmlTextWriter xtw;
            xtw = new XmlTextWriter(databas, Encoding.UTF8);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("Podcasts");
            xtw.WriteEndElement();
            xtw.Close();
        }

        private void insertItems(String databas, String URL, String namn, String intervall, String kategori)
        {
           
            XmlDocument xd = new XmlDocument();
            FileStream lfile = new FileStream(databas, FileMode.Open);
            xd.Load(lfile);

            XmlElement cl = xd.CreateElement("Podcast");
            cl.SetAttribute("Name", namn);

            XmlElement naUrl = xd.CreateElement("Url");
            XmlText naUrlText = xd.CreateTextNode(URL);
            XmlElement naNamn = xd.CreateElement("namn");
            XmlText naNamntext = xd.CreateTextNode(namn);
            XmlElement naIntervall = xd.CreateElement("Intervall");
            XmlText naIntervallText = xd.CreateTextNode(intervall);
            XmlElement naKategori = xd.CreateElement("Kategori");
            XmlText naKategoriText = xd.CreateTextNode(kategori);

            naUrl.AppendChild(naUrlText);
            cl.AppendChild(naUrl);
            naNamn.AppendChild(naNamntext);
            cl.AppendChild(naNamn);
            naIntervall.AppendChild(naIntervallText);
            cl.AppendChild(naIntervall);
            naKategori.AppendChild(naKategoriText);
            cl.AppendChild(naKategori);

            xd.DocumentElement.AppendChild(cl);

            lfile.Close();
            xd.Save(databas);
        }
    }
}
