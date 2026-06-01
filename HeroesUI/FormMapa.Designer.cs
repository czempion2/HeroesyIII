namespace HeroesUI
{
    partial class FormMapa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMapa));
            zloto = new Label();
            drewno = new Label();
            ruda = new Label();
            btnWejdzDoZamku = new Button();
            btnKartaBohatera = new Button();
            menuStrip1 = new MenuStrip();
            zapiszToolStripMenuItem = new ToolStripMenuItem();
            wczytajToolStripMenuItem = new ToolStripMenuItem();
            tura = new Button();
            aktualna_data = new Label();
            listaKopalni = new Label();
            kopalniaDrewna = new Button();
            kopalniaRudy = new Button();
            kopalniaZlota = new Button();
            btnWejdzDoInferno = new Button();
            btnKartaBohateraInferno = new Button();
            kopkamien = new Button();
            kopdrewna = new Button();
            kopzlota = new Button();
            straznikDrewna1 = new Button();
            straznikRudy1 = new Button();
            straznikZlota1 = new Button();
            straznikZlota2 = new Button();
            straznikDrewna2 = new Button();
            straznikRudy2 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // zloto
            // 
            zloto.AutoSize = true;
            zloto.Location = new Point(916, 733);
            zloto.Name = "zloto";
            zloto.Size = new Size(48, 20);
            zloto.TabIndex = 0;
            zloto.Text = "Złoto:";
            // 
            // drewno
            // 
            drewno.AutoSize = true;
            drewno.Location = new Point(550, 733);
            drewno.Name = "drewno";
            drewno.Size = new Size(64, 20);
            drewno.TabIndex = 1;
            drewno.Text = "Drewno:";
            // 
            // ruda
            // 
            ruda.AutoSize = true;
            ruda.Location = new Point(737, 733);
            ruda.Name = "ruda";
            ruda.Size = new Size(46, 20);
            ruda.TabIndex = 2;
            ruda.Text = "Ruda:";
            // 
            // btnWejdzDoZamku
            // 
            btnWejdzDoZamku.Image = (Image)resources.GetObject("btnWejdzDoZamku.Image");
            btnWejdzDoZamku.Location = new Point(47, 75);
            btnWejdzDoZamku.Name = "btnWejdzDoZamku";
            btnWejdzDoZamku.Size = new Size(189, 207);
            btnWejdzDoZamku.TabIndex = 20;
            btnWejdzDoZamku.UseVisualStyleBackColor = true;
            btnWejdzDoZamku.Click += btnWejdzDoZamku_Click;
            // 
            // btnKartaBohatera
            // 
            btnKartaBohatera.Image = (Image)resources.GetObject("btnKartaBohatera.Image");
            btnKartaBohatera.Location = new Point(73, 253);
            btnKartaBohatera.Name = "btnKartaBohatera";
            btnKartaBohatera.Size = new Size(136, 153);
            btnKartaBohatera.TabIndex = 7;
            btnKartaBohatera.UseVisualStyleBackColor = true;
            btnKartaBohatera.Click += btnKartaBohatera_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { zapiszToolStripMenuItem, wczytajToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1509, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // zapiszToolStripMenuItem
            // 
            zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            zapiszToolStripMenuItem.Size = new Size(66, 24);
            zapiszToolStripMenuItem.Text = "Zapisz";
            zapiszToolStripMenuItem.Click += zapiszToolStripMenuItem_Click;
            // 
            // wczytajToolStripMenuItem
            // 
            wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            wczytajToolStripMenuItem.Size = new Size(74, 24);
            wczytajToolStripMenuItem.Text = "Wczytaj";
            wczytajToolStripMenuItem.Click += wczytajToolStripMenuItem_Click;
            // 
            // tura
            // 
            tura.Image = (Image)resources.GetObject("tura.Image");
            tura.Location = new Point(1403, 645);
            tura.Name = "tura";
            tura.Size = new Size(54, 101);
            tura.TabIndex = 8;
            tura.UseVisualStyleBackColor = true;
            tura.Click += tura_Click;
            // 
            // aktualna_data
            // 
            aktualna_data.AutoSize = true;
            aktualna_data.Location = new Point(192, 9);
            aktualna_data.Name = "aktualna_data";
            aktualna_data.Size = new Size(108, 20);
            aktualna_data.TabIndex = 21;
            aktualna_data.Text = "Dzień pierwszy";
            // 
            // listaKopalni
            // 
            listaKopalni.AutoSize = true;
            listaKopalni.Location = new Point(570, 9);
            listaKopalni.Name = "listaKopalni";
            listaKopalni.Size = new Size(71, 20);
            listaKopalni.TabIndex = 22;
            listaKopalni.Text = "Kopalnie:";
            // 
            // kopalniaDrewna
            // 
            kopalniaDrewna.Image = (Image)resources.GetObject("kopalniaDrewna.Image");
            kopalniaDrewna.Location = new Point(47, 546);
            kopalniaDrewna.Name = "kopalniaDrewna";
            kopalniaDrewna.Size = new Size(180, 170);
            kopalniaDrewna.TabIndex = 23;
            kopalniaDrewna.UseVisualStyleBackColor = true;
            kopalniaDrewna.Click += kopalniaDrewna_Click;
            // 
            // kopalniaRudy
            // 
            kopalniaRudy.Image = (Image)resources.GetObject("kopalniaRudy.Image");
            kopalniaRudy.Location = new Point(297, 546);
            kopalniaRudy.Name = "kopalniaRudy";
            kopalniaRudy.Size = new Size(180, 170);
            kopalniaRudy.TabIndex = 24;
            kopalniaRudy.UseVisualStyleBackColor = true;
            kopalniaRudy.Click += kopalniaRudy_Click;
            // 
            // kopalniaZlota
            // 
            kopalniaZlota.Image = (Image)resources.GetObject("kopalniaZlota.Image");
            kopalniaZlota.Location = new Point(420, 75);
            kopalniaZlota.Name = "kopalniaZlota";
            kopalniaZlota.Size = new Size(183, 171);
            kopalniaZlota.TabIndex = 25;
            kopalniaZlota.UseVisualStyleBackColor = true;
            kopalniaZlota.Click += kopalniaZlota_Click;
            // 
            // btnWejdzDoInferno
            // 
            btnWejdzDoInferno.Image = (Image)resources.GetObject("btnWejdzDoInferno.Image");
            btnWejdzDoInferno.Location = new Point(1257, 72);
            btnWejdzDoInferno.Name = "btnWejdzDoInferno";
            btnWejdzDoInferno.Size = new Size(200, 207);
            btnWejdzDoInferno.TabIndex = 26;
            btnWejdzDoInferno.UseVisualStyleBackColor = true;
            // 
            // btnKartaBohateraInferno
            // 
            btnKartaBohateraInferno.Image = (Image)resources.GetObject("btnKartaBohateraInferno.Image");
            btnKartaBohateraInferno.Location = new Point(1288, 249);
            btnKartaBohateraInferno.Name = "btnKartaBohateraInferno";
            btnKartaBohateraInferno.Size = new Size(136, 153);
            btnKartaBohateraInferno.TabIndex = 27;
            btnKartaBohateraInferno.UseVisualStyleBackColor = true;
            // 
            // kopkamien
            // 
            kopkamien.Image = (Image)resources.GetObject("kopkamien.Image");
            kopkamien.Location = new Point(1028, 528);
            kopkamien.Name = "kopkamien";
            kopkamien.Size = new Size(180, 170);
            kopkamien.TabIndex = 29;
            kopkamien.UseVisualStyleBackColor = true;
            kopkamien.Click += kopkamien_Click;
            // 
            // kopdrewna
            // 
            kopdrewna.Image = (Image)resources.GetObject("kopdrewna.Image");
            kopdrewna.Location = new Point(1028, 75);
            kopdrewna.Name = "kopdrewna";
            kopdrewna.Size = new Size(180, 170);
            kopdrewna.TabIndex = 28;
            kopdrewna.UseVisualStyleBackColor = true;
            kopdrewna.Click += kopdrewna_Click;
            // 
            // kopzlota
            // 
            kopzlota.Image = (Image)resources.GetObject("kopzlota.Image");
            kopzlota.Location = new Point(781, 75);
            kopzlota.Name = "kopzlota";
            kopzlota.Size = new Size(183, 171);
            kopzlota.TabIndex = 30;
            kopzlota.UseVisualStyleBackColor = true;
            kopzlota.Click += kopzlota_Click;
            // 
            // straznikDrewna1
            // 
            straznikDrewna1.Image = (Image)resources.GetObject("straznikDrewna1.Image");
            straznikDrewna1.Location = new Point(88, 477);
            straznikDrewna1.Name = "straznikDrewna1";
            straznikDrewna1.Size = new Size(96, 87);
            straznikDrewna1.TabIndex = 31;
            straznikDrewna1.UseVisualStyleBackColor = true;
            // 
            // straznikRudy1
            // 
            straznikRudy1.Image = (Image)resources.GetObject("straznikRudy1.Image");
            straznikRudy1.Location = new Point(338, 477);
            straznikRudy1.Name = "straznikRudy1";
            straznikRudy1.Size = new Size(96, 87);
            straznikRudy1.TabIndex = 32;
            straznikRudy1.UseVisualStyleBackColor = true;
            // 
            // straznikZlota1
            // 
            straznikZlota1.Image = (Image)resources.GetObject("straznikZlota1.Image");
            straznikZlota1.Location = new Point(464, 236);
            straznikZlota1.Name = "straznikZlota1";
            straznikZlota1.Size = new Size(96, 87);
            straznikZlota1.TabIndex = 33;
            straznikZlota1.UseVisualStyleBackColor = true;
            // 
            // straznikZlota2
            // 
            straznikZlota2.Image = (Image)resources.GetObject("straznikZlota2.Image");
            straznikZlota2.Location = new Point(822, 218);
            straznikZlota2.Name = "straznikZlota2";
            straznikZlota2.Size = new Size(96, 87);
            straznikZlota2.TabIndex = 34;
            straznikZlota2.UseVisualStyleBackColor = true;
            // 
            // straznikDrewna2
            // 
            straznikDrewna2.Image = (Image)resources.GetObject("straznikDrewna2.Image");
            straznikDrewna2.Location = new Point(1069, 218);
            straznikDrewna2.Name = "straznikDrewna2";
            straznikDrewna2.Size = new Size(96, 87);
            straznikDrewna2.TabIndex = 35;
            straznikDrewna2.UseVisualStyleBackColor = true;
            // 
            // straznikRudy2
            // 
            straznikRudy2.Image = (Image)resources.GetObject("straznikRudy2.Image");
            straznikRudy2.Location = new Point(1069, 482);
            straznikRudy2.Name = "straznikRudy2";
            straznikRudy2.Size = new Size(96, 87);
            straznikRudy2.TabIndex = 36;
            straznikRudy2.UseVisualStyleBackColor = true;
            // 
            // FormMapa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1509, 758);
            Controls.Add(straznikRudy2);
            Controls.Add(straznikDrewna2);
            Controls.Add(straznikZlota2);
            Controls.Add(straznikZlota1);
            Controls.Add(straznikRudy1);
            Controls.Add(straznikDrewna1);
            Controls.Add(kopzlota);
            Controls.Add(kopkamien);
            Controls.Add(kopdrewna);
            Controls.Add(btnKartaBohateraInferno);
            Controls.Add(btnWejdzDoInferno);
            Controls.Add(kopalniaZlota);
            Controls.Add(kopalniaRudy);
            Controls.Add(kopalniaDrewna);
            Controls.Add(listaKopalni);
            Controls.Add(aktualna_data);
            Controls.Add(tura);
            Controls.Add(btnKartaBohatera);
            Controls.Add(btnWejdzDoZamku);
            Controls.Add(ruda);
            Controls.Add(drewno);
            Controls.Add(zloto);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMapa";
            Text = "Heroes";
            Load += FormMapa_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label zloto;
        private Label drewno;
        private Label ruda;
        private Button btnWejdzDoZamku;
        private Button btnKartaBohatera;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem zapiszToolStripMenuItem;
        private ToolStripMenuItem wczytajToolStripMenuItem;
        private Button tura;
        private Label aktualna_data;
        private Label listaKopalni;
        private Button kopalniaDrewna;
        private Button kopalniaRudy;
        private Button kopalniaZlota;
        private Button btnWejdzDoInferno;
        private Button btnKartaBohateraInferno;
        private Button kopkamien;
        private Button kopdrewna;
        private Button kopzlota;
        private Button straznikDrewna1;
        private Button straznikRudy1;
        private Button straznikZlota1;
        private Button straznikZlota2;
        private Button straznikDrewna2;
        private Button straznikRudy2;
    }
}
