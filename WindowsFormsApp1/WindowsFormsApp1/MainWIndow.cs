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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MainWIndow : Form
    {
        public MainWIndow()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"/Kategorier/");
            fyllComboBoxKategorier();
            
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
            
        }

        public void fyllComboBoxKategorier()
        {
            Podcast lista = new Podcast();
            string[] listaKategorier = lista.listaMedKategoriNamn();

            for (int i = 0; i < listaKategorier.Length; i++)
            {
                string kategoriNamn = new FileInfo(listaKategorier[i]).Name;

                cbKategori.Items.Add(kategoriNamn);
                cbValjEnKategori.Items.Add(kategoriNamn);
            }
        }

        public void fyllComboBoxPodcasts()
        {
            
            var kategori = cbValjEnKategori.Text;
            Podcast lista = new Podcast();
            string[] listaPodcasts = lista.listaFranEnKategori(kategori);

            for (int i = 0; i < listaPodcasts.Length; i++)
            {
                string filNamn = new FileInfo(listaPodcasts[i]).Name.Replace(".xml", "");
                
                cbValjEnPodcast.Items.Add(filNamn);
            }
        }

        private void cbValjEnKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbValjEnPodcast.Items.Clear();
            fyllComboBoxPodcasts();

        }

        private void cbValjEnPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kategori = cbValjEnKategori.Text;
            var podcast = cbValjEnPodcast.Text;
            Podcast enPodcast = new Podcast();

            List<string> allaAvsnitt = enPodcast.hamtaAvsnitt(podcast, kategori);
            foreach (var avsnitt in allaAvsnitt)
            {
                clbAvsnitt.Items.Add(avsnitt);
            }
        }
    }
}
