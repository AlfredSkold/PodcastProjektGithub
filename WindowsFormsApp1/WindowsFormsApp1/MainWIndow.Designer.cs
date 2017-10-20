namespace WindowsFormsApp1
{
    partial class MainWIndow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.cbAndraPodKategori = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblHeadAndraPod = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblAndraPodKategori = new System.Windows.Forms.Label();
            this.cbAndraPodAndraKategori = new System.Windows.Forms.ComboBox();
            this.lblAndraPodIntervall = new System.Windows.Forms.Label();
            this.cbAndraPodIntervall = new System.Windows.Forms.ComboBox();
            this.lblAndraPodUrl = new System.Windows.Forms.Label();
            this.tbAndraPodUrl = new System.Windows.Forms.TextBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.laggTillPodcast = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbValjEnKategori = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbValjEnPodcast = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnAndraPodcast = new System.Windows.Forms.Button();
            this.btnTaBortPod = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNyKategori = new System.Windows.Forms.TextBox();
            this.tbPodNamn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbValjIntervall = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.btnMerInfo = new System.Windows.Forms.Button();
            this.clbAvsnitt = new System.Windows.Forms.CheckedListBox();
            this.cbAndraPod = new System.Windows.Forms.ComboBox();
            this.lblAndraPodValjKategori = new System.Windows.Forms.Label();
            this.lblAndraPod = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(487, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "Lägg till en podcast";
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(790, 312);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(147, 21);
            this.comboBox8.TabIndex = 86;
            // 
            // cbAndraPodKategori
            // 
            this.cbAndraPodKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAndraPodKategori.FormattingEnabled = true;
            this.cbAndraPodKategori.Location = new System.Drawing.Point(790, 60);
            this.cbAndraPodKategori.Name = "cbAndraPodKategori";
            this.cbAndraPodKategori.Size = new System.Drawing.Size(152, 21);
            this.cbAndraPodKategori.TabIndex = 84;
            this.cbAndraPodKategori.SelectedIndexChanged += new System.EventHandler(this.cbAndraPodKategori_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(31, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 16);
            this.label18.TabIndex = 83;
            this.label18.Text = "Välj en kategori";
            // 
            // lblHeadAndraPod
            // 
            this.lblHeadAndraPod.AutoSize = true;
            this.lblHeadAndraPod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadAndraPod.Location = new System.Drawing.Point(786, 35);
            this.lblHeadAndraPod.Name = "lblHeadAndraPod";
            this.lblHeadAndraPod.Size = new System.Drawing.Size(135, 20);
            this.lblHeadAndraPod.TabIndex = 82;
            this.lblHeadAndraPod.Text = "Ändra en podcast";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 81;
            this.label10.Text = "Avsnitt";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(806, 416);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(114, 23);
            this.button8.TabIndex = 78;
            this.button8.Text = "Ta bort kategori";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(729, 340);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 77;
            this.label16.Text = "Nytt namn";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(790, 340);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(152, 20);
            this.textBox6.TabIndex = 76;
            // 
            // lblAndraPodKategori
            // 
            this.lblAndraPodKategori.AutoSize = true;
            this.lblAndraPodKategori.Location = new System.Drawing.Point(721, 169);
            this.lblAndraPodKategori.Name = "lblAndraPodKategori";
            this.lblAndraPodKategori.Size = new System.Drawing.Size(62, 13);
            this.lblAndraPodKategori.TabIndex = 75;
            this.lblAndraPodKategori.Text = "Ny Kategori";
            this.lblAndraPodKategori.Click += new System.EventHandler(this.lblAndraPodKategori_Click);
            // 
            // cbAndraPodAndraKategori
            // 
            this.cbAndraPodAndraKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAndraPodAndraKategori.FormattingEnabled = true;
            this.cbAndraPodAndraKategori.Location = new System.Drawing.Point(790, 166);
            this.cbAndraPodAndraKategori.Name = "cbAndraPodAndraKategori";
            this.cbAndraPodAndraKategori.Size = new System.Drawing.Size(152, 21);
            this.cbAndraPodAndraKategori.TabIndex = 74;
            // 
            // lblAndraPodIntervall
            // 
            this.lblAndraPodIntervall.AutoSize = true;
            this.lblAndraPodIntervall.Location = new System.Drawing.Point(677, 139);
            this.lblAndraPodIntervall.Name = "lblAndraPodIntervall";
            this.lblAndraPodIntervall.Size = new System.Drawing.Size(106, 13);
            this.lblAndraPodIntervall.TabIndex = 73;
            this.lblAndraPodIntervall.Text = "Uppdateringsintervall";
            this.lblAndraPodIntervall.Click += new System.EventHandler(this.lblAndraPodIntervall_Click);
            // 
            // cbAndraPodIntervall
            // 
            this.cbAndraPodIntervall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAndraPodIntervall.FormattingEnabled = true;
            this.cbAndraPodIntervall.Location = new System.Drawing.Point(790, 139);
            this.cbAndraPodIntervall.Name = "cbAndraPodIntervall";
            this.cbAndraPodIntervall.Size = new System.Drawing.Size(152, 21);
            this.cbAndraPodIntervall.TabIndex = 72;
            // 
            // lblAndraPodUrl
            // 
            this.lblAndraPodUrl.AutoSize = true;
            this.lblAndraPodUrl.Location = new System.Drawing.Point(738, 116);
            this.lblAndraPodUrl.Name = "lblAndraPodUrl";
            this.lblAndraPodUrl.Size = new System.Drawing.Size(45, 13);
            this.lblAndraPodUrl.TabIndex = 71;
            this.lblAndraPodUrl.Text = "Ny URL";
            this.lblAndraPodUrl.Click += new System.EventHandler(this.lblAndraPodUrl_Click);
            // 
            // tbAndraPodUrl
            // 
            this.tbAndraPodUrl.Location = new System.Drawing.Point(790, 113);
            this.tbAndraPodUrl.Name = "tbAndraPodUrl";
            this.tbAndraPodUrl.Size = new System.Drawing.Size(152, 20);
            this.tbAndraPodUrl.TabIndex = 70;
            // 
            // cbKategori
            // 
            this.cbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(490, 154);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(152, 21);
            this.cbKategori.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(487, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 16);
            this.label9.TabIndex = 68;
            this.label9.Text = "Eller lägg till i en ny kategori";
            // 
            // laggTillPodcast
            // 
            this.laggTillPodcast.Location = new System.Drawing.Point(490, 235);
            this.laggTillPodcast.Name = "laggTillPodcast";
            this.laggTillPodcast.Size = new System.Drawing.Size(114, 23);
            this.laggTillPodcast.TabIndex = 67;
            this.laggTillPodcast.Text = "Lägg till podcast";
            this.laggTillPodcast.UseVisualStyleBackColor = true;
            this.laggTillPodcast.Click += new System.EventHandler(this.laggTillPodcast_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(206, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Välj en podcast";
            // 
            // cbValjEnKategori
            // 
            this.cbValjEnKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValjEnKategori.FormattingEnabled = true;
            this.cbValjEnKategori.Location = new System.Drawing.Point(34, 45);
            this.cbValjEnKategori.MaxDropDownItems = 20;
            this.cbValjEnKategori.Name = "cbValjEnKategori";
            this.cbValjEnKategori.Size = new System.Drawing.Size(147, 21);
            this.cbValjEnKategori.Sorted = true;
            this.cbValjEnKategori.TabIndex = 65;
            this.cbValjEnKategori.SelectedIndexChanged += new System.EventHandler(this.cbValjEnKategori_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(786, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "Ändra en kategori";
            // 
            // cbValjEnPodcast
            // 
            this.cbValjEnPodcast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValjEnPodcast.FormattingEnabled = true;
            this.cbValjEnPodcast.Location = new System.Drawing.Point(209, 45);
            this.cbValjEnPodcast.Name = "cbValjEnPodcast";
            this.cbValjEnPodcast.Size = new System.Drawing.Size(147, 21);
            this.cbValjEnPodcast.TabIndex = 63;
            this.cbValjEnPodcast.SelectedIndexChanged += new System.EventHandler(this.cbValjEnPodcast_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(806, 387);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 23);
            this.button5.TabIndex = 62;
            this.button5.Text = "Ändra kategori";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnAndraPodcast
            // 
            this.btnAndraPodcast.Location = new System.Drawing.Point(806, 201);
            this.btnAndraPodcast.Name = "btnAndraPodcast";
            this.btnAndraPodcast.Size = new System.Drawing.Size(114, 23);
            this.btnAndraPodcast.TabIndex = 61;
            this.btnAndraPodcast.Text = "Ändra podcast";
            this.btnAndraPodcast.UseVisualStyleBackColor = true;
            this.btnAndraPodcast.Click += new System.EventHandler(this.btnAndraPodcast_Click);
            // 
            // btnTaBortPod
            // 
            this.btnTaBortPod.Location = new System.Drawing.Point(829, 230);
            this.btnTaBortPod.Name = "btnTaBortPod";
            this.btnTaBortPod.Size = new System.Drawing.Size(75, 23);
            this.btnTaBortPod.TabIndex = 60;
            this.btnTaBortPod.Text = "Ta bort podcasts";
            this.btnTaBortPod.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Kategorinamn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Välj kategori";
            // 
            // tbNyKategori
            // 
            this.tbNyKategori.Location = new System.Drawing.Point(490, 209);
            this.tbNyKategori.Name = "tbNyKategori";
            this.tbNyKategori.Size = new System.Drawing.Size(152, 20);
            this.tbNyKategori.TabIndex = 57;
            // 
            // tbPodNamn
            // 
            this.tbPodNamn.Location = new System.Drawing.Point(490, 87);
            this.tbPodNamn.Name = "tbPodNamn";
            this.tbPodNamn.Size = new System.Drawing.Size(152, 20);
            this.tbPodNamn.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Ange namn ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Välj uppdateringsintervall";
            // 
            // cbValjIntervall
            // 
            this.cbValjIntervall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValjIntervall.FormattingEnabled = true;
            this.cbValjIntervall.Location = new System.Drawing.Point(490, 113);
            this.cbValjIntervall.Name = "cbValjIntervall";
            this.cbValjIntervall.Size = new System.Drawing.Size(152, 21);
            this.cbValjIntervall.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "URL";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(490, 61);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(152, 20);
            this.tbURL.TabIndex = 51;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(209, 96);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(132, 85);
            this.btnPlay.TabIndex = 88;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(209, 265);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(257, 180);
            this.rtbDesc.TabIndex = 89;
            this.rtbDesc.Text = "";
            // 
            // btnMerInfo
            // 
            this.btnMerInfo.Location = new System.Drawing.Point(209, 235);
            this.btnMerInfo.Name = "btnMerInfo";
            this.btnMerInfo.Size = new System.Drawing.Size(114, 23);
            this.btnMerInfo.TabIndex = 90;
            this.btnMerInfo.Text = "Mer info";
            this.btnMerInfo.UseVisualStyleBackColor = true;
            this.btnMerInfo.Click += new System.EventHandler(this.btnMerInfo_Click);
            // 
            // clbAvsnitt
            // 
            this.clbAvsnitt.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.clbAvsnitt.FormattingEnabled = true;
            this.clbAvsnitt.Location = new System.Drawing.Point(23, 96);
            this.clbAvsnitt.Name = "clbAvsnitt";
            this.clbAvsnitt.Size = new System.Drawing.Size(173, 349);
            this.clbAvsnitt.TabIndex = 91;
            // 
            // cbAndraPod
            // 
            this.cbAndraPod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAndraPod.FormattingEnabled = true;
            this.cbAndraPod.Location = new System.Drawing.Point(790, 86);
            this.cbAndraPod.Name = "cbAndraPod";
            this.cbAndraPod.Size = new System.Drawing.Size(152, 21);
            this.cbAndraPod.TabIndex = 92;
            this.cbAndraPod.SelectedIndexChanged += new System.EventHandler(this.cbAndraPod_SelectedIndexChanged);
            // 
            // lblAndraPodValjKategori
            // 
            this.lblAndraPodValjKategori.AutoSize = true;
            this.lblAndraPodValjKategori.Location = new System.Drawing.Point(738, 64);
            this.lblAndraPodValjKategori.Name = "lblAndraPodValjKategori";
            this.lblAndraPodValjKategori.Size = new System.Drawing.Size(46, 13);
            this.lblAndraPodValjKategori.TabIndex = 93;
            this.lblAndraPodValjKategori.Text = "Kategori";
            // 
            // lblAndraPod
            // 
            this.lblAndraPod.AutoSize = true;
            this.lblAndraPod.Location = new System.Drawing.Point(738, 90);
            this.lblAndraPod.Name = "lblAndraPod";
            this.lblAndraPod.Size = new System.Drawing.Size(46, 13);
            this.lblAndraPod.TabIndex = 94;
            this.lblAndraPod.Text = "Podcast";
            // 
            // MainWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 472);
            this.Controls.Add(this.lblAndraPod);
            this.Controls.Add(this.lblAndraPodValjKategori);
            this.Controls.Add(this.cbAndraPod);
            this.Controls.Add(this.clbAvsnitt);
            this.Controls.Add(this.btnMerInfo);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.cbAndraPodKategori);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblHeadAndraPod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.lblAndraPodKategori);
            this.Controls.Add(this.cbAndraPodAndraKategori);
            this.Controls.Add(this.lblAndraPodIntervall);
            this.Controls.Add(this.cbAndraPodIntervall);
            this.Controls.Add(this.lblAndraPodUrl);
            this.Controls.Add(this.tbAndraPodUrl);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.laggTillPodcast);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbValjEnKategori);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbValjEnPodcast);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnAndraPodcast);
            this.Controls.Add(this.btnTaBortPod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNyKategori);
            this.Controls.Add(this.tbPodNamn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbValjIntervall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbURL);
            this.Name = "MainWIndow";
            this.Text = "Podcast viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox cbAndraPodKategori;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblHeadAndraPod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblAndraPodKategori;
        private System.Windows.Forms.ComboBox cbAndraPodAndraKategori;
        private System.Windows.Forms.Label lblAndraPodIntervall;
        private System.Windows.Forms.ComboBox cbAndraPodIntervall;
        private System.Windows.Forms.Label lblAndraPodUrl;
        private System.Windows.Forms.TextBox tbAndraPodUrl;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button laggTillPodcast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbValjEnKategori;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbValjEnPodcast;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnAndraPodcast;
        private System.Windows.Forms.Button btnTaBortPod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNyKategori;
        private System.Windows.Forms.TextBox tbPodNamn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbValjIntervall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Button btnMerInfo;
        private System.Windows.Forms.CheckedListBox clbAvsnitt;
        private System.Windows.Forms.ComboBox cbAndraPod;
        private System.Windows.Forms.Label lblAndraPodValjKategori;
        private System.Windows.Forms.Label lblAndraPod;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

