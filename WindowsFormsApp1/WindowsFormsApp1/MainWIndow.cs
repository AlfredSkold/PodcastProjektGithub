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
        private bool firstRun = true;
        public MainWIndow()
        {
            InitializeComponent();
            if (Properties.Settings.FirstRun == true)
            {
                firstRunSettings();
                Properties.Settings.FirstRun = false;
            }
            fyllComboBoxKategorier();
            fillComboBoxIntervall(cbAndraPodIntervall);
            fillComboBoxIntervall(cbValjIntervall);


        }
        private void firstRunSettings()
        {
            Directory.CreateDirectory("Kategorier");
            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"/Kategorier/");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void laggTillPodcast_Click(object sender, EventArgs e)
        {
            this.cbValjEnKategori.Items.Clear();
            this.cbKategori.Items.Clear();
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
            fyllComboBoxKategorier();
            MessageBox.Show(namn + " har blivit tillagd i kategorin " + kategori + ".");
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
                cbAndraPodAndraKategori.Items.Add(kategoriNamn);
                cbAndraPodKategori.Items.Add(kategoriNamn);
            }
        }

        public void fyllComboBoxPodcasts()
        {
            this.cbValjEnPodcast.Items.Clear();
            var kategori = cbValjEnKategori.Text;
            Podcast lista = new Podcast();
            string[] listaPodcasts = lista.listaFranEnKategori(kategori);
            string filNamn = "";
            for (int i = 0; i < listaPodcasts.Length; i++)
            {
                if (new FileInfo(listaPodcasts[i]).Name.Contains(".xml"))
                {
                   filNamn = new FileInfo(listaPodcasts[i]).Name.Replace(".xml", "");
                    cbValjEnPodcast.Items.Add(filNamn);
                }
                
            }
        }

        public void fyllComboBoxAndraPodcasts()
        {
            this.cbAndraPod.Items.Clear();
            var kategori = cbAndraPodKategori.Text;
            Podcast lista = new Podcast();
            string[] listaPodcasts = lista.listaFranEnKategori(kategori);

            for (int i = 0; i < listaPodcasts.Length; i++)
            {
                string filNamn = new FileInfo(listaPodcasts[i]).Name.Replace(".xml", "");

                cbAndraPod.Items.Add(filNamn);
            }
        }

        private void cbValjEnKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            fyllComboBoxPodcasts();
            Podcast podcastElement = new Podcast();
        }

        private void cbValjEnPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kategori = cbValjEnKategori.Text;
            var podcast = cbValjEnPodcast.Text;
            Podcast enPodcast = new Podcast();
            int i = 0;
            List<string> allaAvsnitt = enPodcast.hamtaAvsnitt(podcast, kategori);
            foreach (var avsnitt in allaAvsnitt)
            {
                if (enPodcast.arAvsnittSpelat(kategori, podcast, avsnitt))
                {
                    clbAvsnitt.Items.Add(avsnitt);
                    clbAvsnitt.SetItemChecked(i, false);
                }
                i++;
            }


        }

        private void fillComboBoxIntervall(ComboBox cb)
        {
            cb.Items.Add("Var 5e sekund");
            cb.Items.Add("Var 10e sekund");
            cb.Items.Add("Var 20e sekund");
            cb.Items.Add("Var 30e sekund");
        }

        private void fillComboBoxes()
        {
            fyllComboBoxKategorier();
        }

        private void cbAndraPodKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            fyllComboBoxAndraPodcasts();
        }

        private void lblAndraPodUrl_Click(object sender, EventArgs e)
        {

        }

        private void btnAndraPodcast_Click(object sender, EventArgs e)
        {
            var podcastAttAndra = cbAndraPod.Text;

        }

        private void cbAndraPod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPod = cbAndraPod.Text;
            Podcast podcastElm = new Podcast();

            var valdPodUrl = podcastElm.hamtaPodcastUrl(valdKategori, valdPod);
            tbAndraPodUrl.Text = valdPodUrl;

            var valdPodIntervall = podcastElm.hamtaPodcastIntervall(valdKategori, valdPod);

            var valdPodIntervallIndex = podcastElm.hamtaIntervalIndex(valdPodIntervall);
            cbAndraPodIntervall.SelectedIndex = valdPodIntervallIndex;
        }

        private void lblAndraPodIntervall_Click(object sender, EventArgs e)
        {

        }

        private void btnMerInfo_Click(object sender, EventArgs e)
        {
            var valtAvsnitt = clbAvsnitt.Text;
            var valdPodcast = cbValjEnPodcast.Text;
            var valdKategori = cbValjEnKategori.Text;

            Podcast podcastElement = new Podcast();

            var podDesc = podcastElement.hamtaPodDesc(valdKategori, valdPodcast, valtAvsnitt);
            rtbDesc.Text = podDesc;
        }

        private void lblAndraPodKategori_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var valtAvsnitt = clbAvsnitt.Text;
            var valdKategori = cbValjEnKategori.Text;
            var valdPod = cbValjEnPodcast.Text;
            MessageBox.Show("Laddar ner avsnittet och spelar den strax");
            Podcast podcastElement = new Podcast();
            var ljudfilPath = podcastElement.hamtaLjudfil(valdKategori, valdPod, valtAvsnitt);

            podcastElement.spelaLjudfil(ljudfilPath);

        }
    }
}
