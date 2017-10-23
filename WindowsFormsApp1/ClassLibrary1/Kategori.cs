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
                MessageBox.Show("Kategorin har nu namnet " +nyttNamn+ ".");
            }
        }

        public void bytKategori(string kategori, string podcast, string nyKategori)
        {
            if (kategori != nyKategori)
            {
                KategoriData katelm = new KategoriData();
                katelm.bytKategori(kategori, podcast, nyKategori);
                MessageBox.Show(podcast+ " är flyttad till kategorin " +nyKategori+ ".");
            }
        }

        public void skapaNyKategori(string kategoriNamn, TextBox tb)
        {

            if (kategoriNamn != "")
            {
                string path = Directory.GetCurrentDirectory() + @"\" + kategoriNamn;
                Directory.CreateDirectory(path);
                MessageBox.Show("Kategorin " + kategoriNamn + " är skapad!");
                tb.Clear();
            }
            
        }

        public void taBortKategori(string kategoriNamn, ComboBox combobox)
        {

            string path = Directory.GetCurrentDirectory() + @"\" + kategoriNamn;
            DialogResult dialogResult = MessageBox.Show(@"Är du säker på att du vill ta bort kategorin " + kategoriNamn + "? \n Du tar även bort alla podcasts i kategorin.", "Ta bort kategori", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Directory.Delete(path, true);
                combobox.Items.Clear();
                MessageBox.Show(kategoriNamn + " och alla podcasts däri är borttagna.");
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
                if(!filnamn.Contains("xmlFiler"))
                {
                    combobox.Items.Add(filnamn);
                }
            }

        }

    }
}
