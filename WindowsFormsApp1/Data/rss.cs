using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Data
{
    internal class InternalClass
    {
        internal string xml = "";
    }

    public class rss : AbstractClass
    {
        public override XmlDocument hamtaXML(string url)
        {
            InternalClass iClass = new InternalClass();
            var xml = iClass.xml;
            //Ladda hem XML.
            using (var client = new System.Net.WebClient())
            {
                client.Encoding = Encoding.UTF8;
                xml = client.DownloadString(url);
            }

            //Skapa en objektrepresentation.
            var dom = skapaXml();
            dom.LoadXml(xml);
            return dom;
        }
    }
}
