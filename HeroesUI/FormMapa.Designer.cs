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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // zloto
            // 
            zloto.AutoSize = true;
            zloto.Location = new Point(524, 408);
            zloto.Name = "zloto";
            zloto.Size = new Size(48, 20);
            zloto.TabIndex = 0;
            zloto.Text = "Złoto:";
            // 
            // drewno
            // 
            drewno.AutoSize = true;
            drewno.Location = new Point(158, 408);
            drewno.Name = "drewno";
            drewno.Size = new Size(64, 20);
            drewno.TabIndex = 1;
            drewno.Text = "Drewno:";
            // 
            // ruda
            // 
            ruda.AutoSize = true;
            ruda.Location = new Point(345, 408);
            ruda.Name = "ruda";
            ruda.Size = new Size(46, 20);
            ruda.TabIndex = 2;
            ruda.Text = "Ruda:";
            // 
            // btnWejdzDoZamku
            // 
            btnWejdzDoZamku.Image = (Image)resources.GetObject("btnWejdzDoZamku.Image");
            btnWejdzDoZamku.Location = new Point(463, 68);
            btnWejdzDoZamku.Name = "btnWejdzDoZamku";
            btnWejdzDoZamku.Size = new Size(189, 191);
            btnWejdzDoZamku.TabIndex = 20;
            btnWejdzDoZamku.UseVisualStyleBackColor = true;
            btnWejdzDoZamku.Click += btnWejdzDoZamku_Click;
            // 
            // btnKartaBohatera
            // 
            btnKartaBohatera.Image = (Image)resources.GetObject("btnKartaBohatera.Image");
            btnKartaBohatera.Location = new Point(39, 68);
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
            menuStrip1.Size = new Size(886, 28);
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
            tura.Location = new Point(804, 327);
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
            // FormMapa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 450);
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
    }
}
