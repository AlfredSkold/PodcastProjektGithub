using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace WindowsFormsApp1
{
    public partial class MainWIndow : Form
    {
        public MainWIndow()
        {
            InitializeComponent();
            fyllComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void laggTillPodcast_Click(object sender, EventArgs e)
        {
            var url = tbURL.Text;
            var namn = tbPodNamn.Text;
            var intervall = cbValjIntervall.Text;
            bool nyKategori = false;
            var kategori = cbKategori.Text;
            if (cbKategori.Text == "")
            {
                kategori = tbNyKategori.Text;
                nyKategori = true;
            }
            Podcast metod = new Podcast();
            metod.nyPod(nyKategori, url, namn, intervall, kategori);

            metod.hamtaAvsnitt(url);
        }

        public void fyllComboBox()
        {
            Podcast lista = new Podcast();
            List<string> listaKategorier = lista.listaMedKategoriNamn();
            foreach(string element in listaKategorier)
            {
                cbValjEnKategori.Items.Add(element);
            }
            
        }
    }
}
