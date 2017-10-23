using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class KategoriData
    {
        public void andraKategoriNamn(string kategori, string nyttNamn)
        {
            string gammalPath = Directory.GetCurrentDirectory() +@"\"+ kategori;
            string nyPath = Directory.GetCurrentDirectory() + @"\" + nyttNamn;
            Directory.Move(gammalPath, nyPath);
        }

        public void bytKategori(string kategori, string podcast, string nyKategori)
        {
            string gammalPath = Directory.GetCurrentDirectory() + @"\" + kategori +@"\"+ podcast+ @".xml";
            string nyPath = Directory.GetCurrentDirectory() + @"\" + nyKategori + @"\" + podcast + @".xml";
            File.Move(gammalPath, nyPath);
        }
    }
}
