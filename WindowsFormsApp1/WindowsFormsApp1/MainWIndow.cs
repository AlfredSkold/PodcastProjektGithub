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
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class MainWIndow : Form
    {
       

        public MainWIndow()
        {
            InitializeComponent();
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\xmlFiler");
            fyllComboBoxes();
        }
        
        private void fyllComboBoxes()
        {
            fyllComboBoxKategorier();
            fillComboBoxIntervall(cbValjIntervall);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void laggTillPodcast_Click(object sender, EventArgs e)
        {
            if (Validation.textFieldInteTomt(tbURL, tbPodNamn, "En url", "Ett namn") 
                && Validation.kollaUrl(tbURL.Text) 
                && Validation.comboBoxInteTomt(cbValjIntervall, "Uppdateringsintervall") 
                && Validation.textFieldOchComboboxEndastEnVald(tbNyKategori, cbKategori)
                && Validation.textFieldOchComboboxInteTomt(tbNyKategori, cbKategori))
            {
                var url = tbURL.Text;
                var namn = tbPodNamn.Text;
                var intervall = cbValjIntervall.Text;
                var kategoriNamn = cbKategori.Text;
                var nyKategoriNamn = tbNyKategori.Text;

                Podcast podcast = new Podcast();
                podcast.nyPod(url, namn, intervall, kategoriNamn, nyKategoriNamn);

                podcast.rensaFaltNyPod(tbURL, tbPodNamn, cbValjIntervall, tbNyKategori);
                fyllComboBoxKategorier();
            }
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



        private async void cbValjEnPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kategori = cbValjEnKategori.Text;
            var podcast = cbValjEnPodcast.Text;
            Avsnitt avsnitt = new Avsnitt();
            Podcast enpodcast = new Podcast();

            if(enpodcast.harIntervallPaserat(kategori, podcast))
            {
                Task<bool> result;
                result = avsnitt.kollaOmNyttAvsnittFinns(kategori, podcast);
                lblAvsnitt.Text = "Kollar om det finns nya avsnitt för denna Podcast...";
                if (await result)
                {
                    avsnitt.fyllClbMedAvsnittNytt(kategori, podcast, lbAvsnitt, lblAvsnitt);
                }
                else
                {
                    avsnitt.fyllClbMedAvsnitt(kategori, podcast, lbAvsnitt, lblAvsnitt);
                }
            } else
            {
                avsnitt.fyllClbMedAvsnitt(kategori, podcast, lbAvsnitt, lblAvsnitt);
            }
        }



        private void fillComboBoxIntervall(ComboBox cb)
        {
            cb.Items.Add("Var 5e sekund");
            cb.Items.Add("Var 10e sekund");
            cb.Items.Add("Var 20e sekund");
            cb.Items.Add("Var 30e sekund");
        }

  

        private void cbAndraPodKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kategori = cbAndraPodKategori.Text;
            Podcast podcast = new Podcast();
            podcast.fyllComboboxMedPodcasts(kategori, cbAndraPod);
        }

        private void btnAndraPodcast_Click(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPodcast = cbAndraPod.Text;

            var nyUrl = tbAndraPodUrl.Text;
            var nyttNamn = tbAndraPodNamn.Text;
            var nyttIntervall = cbAndraPodIntervall.Text;
            var nyKategori = cbAndraPodAndraKategori.Text;

            if((Validation.comboBoxInteTomt(cbAndraPodKategori, "Podkategori") && Validation.comboBoxInteTomt(cbAndraPod, "Podcast")
                && Validation.kollaUrl(nyUrl) && Validation.textFieldInteTomt(tbAndraPodNamn, "Podnamn") && Validation.comboBoxInteTomt(cbAndraPodAndraKategori, "Kategori"))
            {
                if (cbAndraPodIntervall.SelectedItem == null)
                {
                    MessageBox.Show("Vänligen ange en uppdateringsintervall för podcasten");
                    return;
                }

                else
                {

                    Podcast podelm = new Podcast();
                    podelm.andraPodcast(valdKategori, valdPodcast, nyUrl, nyttNamn, nyttIntervall, nyKategori);

                    Kategori kategori = new Kategori();
                    kategori.bytKategori(valdKategori, valdPodcast, nyKategori);

                    podelm.rensaFaltAndraPod(cbAndraPod, tbAndraPodUrl, tbAndraPodNamn, cbAndraPodIntervall, cbAndraPodAndraKategori);
                    fyllComboBoxKategorier();
                } } }



        private void cbAndraPod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valdKategori = cbAndraPodKategori.Text;
            var valdPod = cbAndraPod.Text;
            Podcast podcastElm = new Podcast();
            fillComboBoxIntervall(cbAndraPodIntervall);
            podcastElm.skrivPodcastInfo(valdKategori, valdPod, tbAndraPodUrl, tbAndraPodNamn, cbAndraPodKategori, cbAndraPod, cbAndraPodIntervall, cbAndraPodAndraKategori);
            
        }

        

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Validation.comboBoxInteTomt(cbValjEnKategori, "Kategori") && Validation.comboBoxInteTomt(cbValjEnPodcast, "podcast")
               && Validation.lbInteTomt(lbAvsnitt.Text, "Ett avsnitt"))
            {
                var valtAvsnitt = lbAvsnitt.Text;
                var valdKategori = cbValjEnKategori.Text;
                var valdPod = cbValjEnPodcast.Text;
                var valtAvsnittIndex = lbAvsnitt.SelectedIndex;


                Avsnitt avsnitt = new Avsnitt();
                avsnitt.spelaAvsnitt(valdKategori, valdPod, valtAvsnitt, lbAvsnitt, valtAvsnittIndex);
                avsnitt.fyllClbMedAvsnitt(valdKategori, valdPod, lbAvsnitt, lblAvsnitt);
            }
        }

        private void btnSkapaNyKat_Click(object sender, EventArgs e)
        {
            if (Validation.textFieldInteTomt(tbSkapaNyKat, "Kategorinamn"))
            {
                var nyttKategoriNamn = tbSkapaNyKat.Text;
                Kategori kategori = new Kategori();

                kategori.skapaNyKategori(nyttKategoriNamn, tbSkapaNyKat);
                fyllComboBoxKategorier();
            }
        
            
        }

        private void btnAndraKat_Click(object sender, EventArgs e)
        {
            if (Validation.comboBoxInteTomt(cbAndraKat, "Kategori")
                && Validation.textFieldInteTomt(tbAndraKat, "Ett nytt namn"))
            {
                var nyttKategoriNamn = tbAndraKat.Text;
                var gammaltKategoriNamn = cbAndraKat.Text;
                Kategori kategori = new Kategori();
                kategori.andraKategoriNamn(gammaltKategoriNamn, nyttKategoriNamn);
                tbAndraKat.Clear();
                fyllComboBoxKategorier();
            }
        }

        private void btnTaBortPod_Click(object sender, EventArgs e)
        {
            if (Validation.comboBoxInteTomt(cbAndraPodKategori, "Podkategori") && Validation.comboBoxInteTomt(cbAndraPod, "Podcast") 
                && Validation.kollaUrl(tbAndraPodUrl.Text) && Validation.textFieldInteTomt(tbAndraPodNamn, "Podnamn") 
                && Validation.comboBoxInteTomt(cbAndraPodAndraKategori, "Kategori"))
            {
                var valdKategori = cbAndraPodKategori.Text;
                var valdPod = cbAndraPod.Text;
                Podcast podcast = new Podcast();
                podcast.taBortPodcast(valdKategori, valdPod, tbAndraPodNamn, tbAndraPodUrl, cbAndraPodIntervall, cbAndraPod);

                fyllComboBoxKategorier();
            }
        }

        private void btnTaBortKat_Click(object sender, EventArgs e)
        {
            if (Validation.comboBoxInteTomt(cbAndraKat, "Kategori"))
            {
                var valdKategori = cbAndraKat.Text;
                Kategori kategori = new Kategori();
                kategori.taBortKategori(valdKategori, cbAndraKat);
                fyllComboBoxKategorier();
            }
        }

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valtAvsnittLb = lbAvsnitt.Text;
            var valtAvsnitt = valtAvsnittLb.Replace(" (Lyssnad på)", "");
            var valdPodcast = cbValjEnPodcast.Text;
            var valdKategori = cbValjEnKategori.Text;

            Podcast podcastElement = new Podcast();
            podcastElement.skrivBeskrivning(valdKategori, valdPodcast, valtAvsnitt, rtbDesc);
        }
    }
}
