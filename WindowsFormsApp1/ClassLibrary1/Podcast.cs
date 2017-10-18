using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class Podcast
    {
        public void nyPod (String url, String namn, String intervall, String kategori)
        {
            NyPodcast podcast = new NyPodcast();
            podcast.addPod(url, namn, intervall, kategori);
        }

        public void hamtaAvsnitt (String url, )
        {

        }


    }
}
