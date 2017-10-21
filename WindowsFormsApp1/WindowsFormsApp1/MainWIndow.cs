using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            fyllComboBoxes();
        }
        
        private void fyllComboBoxes()
        {
            fyllComboBoxKategorier();
            fillComboBoxIntervall(cbAndraPodIntervall);
            fillComboBoxIntervall(cbValjIntervall);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void laggTillPodcast_Click(object sender, EventArgs e)
        {

            var url = tbURL.Text;
            var namn = tbPodNamn.Text;
            var intervall = cbValjIntervall.Text;
            var kategori = cbKategori.Text;
            var nyKategoriNamn = tbNyKategori.Text;

            Podcast metod = new Podcast();
            metod.nyPod(url, namn, intervall, kategori, nyKategoriNamn);

            if (kategori == "")
            {
                kategori = nyKategoriNamn;
            }
            MessageBox.Show("Podcasten " + namn + " har blivit tillagd i kategorin " + kategori + ".");
            fyllComboBoxKategorier();
        }

        private void fyllComboBoxKategorier()
        {
            Kategori kategori = new Kategori();

            kategori.fyllComboboxMedKategorier(cbKategori);
            kategori.fyllComboboxMedKategorier(cbValjEnKategori);
            kategori.fyllComboboxMedKategorier(cbAndraPodAndraKategori);
            kategori.fyllComboboxMedKategorier(cbAndraPodKategori);
            kategori.fyllComboboxMedKategorier(cbAndraKat);
            
        }
        

        private void cbValjEnKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            Podcast podcast = new Podcast();
            var kategori = cbValjEnKategori.Text;
            podcast.fyllComboboxMedPodcasts(kategori, cbValjEnPodcast);
        }

        private void cbValjEnPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbAvsnitt.Items.Clear();
            var kategori = cbValjEnKategori.Text;
            var podcast = cbValjEnPodcast.Text;
            Podcast enPodcast = new Podcast();
            int i = 0;
            List<string> allaAvsnitt = enPodcast.hamtaAvsnitt(podcast, kategori);
            foreach (var avsnitt in allaAvsnitt)
            {
                clbAvsnitt.Items.Add(avsnitt);
                if (enPodcast.arAvsnittSpelat(kategori, podcast, avsnitt))
                {

                    clbAvsnitt.SetItemChecked(i, true);
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
            var kategori = cbAndraPodKategori.Text;
            Podcast podcast = new Podcast();
            podcast.fyllComboboxMedPodcasts(kategori, cbAndraPod);
        }

        private void lblAndraPodUrl_Click(object sender, EventArgs e)
        {

        }

        private void btnAndraPodcast_Click(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPodcast = cbAndraPod.Text;

            var nyUrl = tbAndraPodUrl.Text;
            var nyttNamn = tbAndraPodNamn.Text;
            var nyttIntervall = cbAndraPodIntervall.Text;
            var nyKategori = cbAndraPodAndraKategori.Text;

            Podcast podelm = new Podcast();
            podelm.andraPodcast(valdKategori, valdPodcast, nyUrl, nyttNamn, nyttIntervall, nyKategori);

            Kategori kategori = new Kategori();
            kategori.andraKategoriNamn(valdKategori, nyKategori);

            fyllComboBoxKategorier();
        }

        private void cbAndraPod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPod = cbAndraPod.Text;
            Podcast podcastElm = new Podcast();

            tbAndraPodUrl.Text = podcastElm.hamtaPodcastUrl(valdKategori, valdPod);
            tbAndraPodNamn.Text = cbAndraPod.Text;

            var valdPodIntervall = podcastElm.hamtaPodcastIntervall(valdKategori, valdPod);

            var valdPodIntervallIndex = podcastElm.hamtaIntervalIndex(valdPodIntervall);

            cbAndraPodIntervall.SelectedIndex = valdPodIntervallIndex;
            cbAndraPodAndraKategori.SelectedIndex = cbAndraPodKategori.SelectedIndex;
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
            clbAvsnitt.SetItemChecked(clbAvsnitt.SelectedIndex, true);
            MessageBox.Show("Laddar ner avsnittet och spelar den strax");
            Podcast podcastElement = new Podcast();
            var ljudfilPath = podcastElement.hamtaLjudfil(valdKategori, valdPod, valtAvsnitt);

            podcastElement.spelaLjudfil(ljudfilPath);

        }

        private void clbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void clbAvsnitt_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var kategori = cbValjEnKategori.Text;
            var podcast = cbValjEnPodcast.Text;
            var avsnitt = clbAvsnitt.Text;

            Podcast podelm = new Podcast();
            podelm.avsnittSpelad(kategori, podcast, avsnitt);
        }

        private void btnSkapaNyKat_Click(object sender, EventArgs e)
        {
            var nyttKategoriNamn = tbSkapaNyKat.Text;
            Kategori kategori = new Kategori();
            if (nyttKategoriNamn != "")
            { 
                kategori.skapaNyKategori(nyttKategoriNamn);
                MessageBox.Show("Kategorin " + nyttKategoriNamn + " är skapad!");
                tbSkapaNyKat.Clear();
                fyllComboBoxKategorier();
            }
        }

        private void btnAndraKat_Click(object sender, EventArgs e)
        {
            var nyttKategoriNamn = tbAndraKat.Text;
            var gammaltKategoriNamn = cbAndraKat.Text;
            Kategori kategori = new Kategori();
            kategori.andraKategoriNamn(gammaltKategoriNamn, nyttKategoriNamn);
        }

        private void btnTaBortPod_Click(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPod = cbAndraPod.Text;
            Podcast podcast = new Podcast();
            podcast.taBortPodcast(valdKategori, valdPod, tbAndraPodNamn, tbAndraPodUrl, cbAndraPodIntervall, cbAndraPod);
            
            fyllComboBoxKategorier();
        }

        private void btnTaBortKat_Click(object sender, EventArgs e)
        {
            var valdKategori = cbAndraKat.Text;
            Kategori kategori = new Kategori();
            kategori.taBortKategori(valdKategori, cbAndraKat);
        }
    }
}
