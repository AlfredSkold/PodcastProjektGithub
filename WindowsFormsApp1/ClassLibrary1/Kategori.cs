using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.IO;
using System.Windows.Forms;

namespace Logic
{
    public class Kategori
    {

        public void andraKategoriNamn(string valdKategori, string nyttNamn)
        {
            KategoriData katelm = new KategoriData();
            if (nyttNamn != "" && nyttNamn != valdKategori)
            {
                katelm.andraKategoriNamn(valdKategori, nyttNamn);
            }
        }

        public void bytKategori(string kategori, string podcast, string nyKategori)
        {
            KategoriData katelm = new KategoriData();
            katelm.bytKategori(kategori, podcast, nyKategori);
        }

        public void skapaNyKategori(string kategoriNamn)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + kategoriNamn;
            Directory.CreateDirectory(path);
        }

        public void taBortKategori(string kategoriNamn, ComboBox combobox)
        {

            string path = Directory.GetCurrentDirectory() + @"\" + kategoriNamn;
            DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill ta bort kategorin " + kategoriNamn + "?", "Ta bort kategori", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Directory.Delete(path, true);
                combobox.Items.Clear();
            }
        }
        public void fyllComboboxMedKategorier(ComboBox combobox)
        {
            String path = Directory.GetCurrentDirectory();
            string[] lista = Directory.GetDirectories(path);
            combobox.Items.Clear();
            for (int i = 0; i < lista.Length; i++)
            {
                string filnamn = new FileInfo(lista[i]).Name;
                combobox.Items.Add(filnamn);

            }

        }

    }
}
