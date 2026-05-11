namespace HeroesUI
{
    partial class FormBohater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBohater));
            picBoxPortret = new PictureBox();
            lblStatystyki = new Label();
            listBoxArmia = new ListBox();
            back = new Button();
            progressBarExp = new ProgressBar();
            usun_jednostke = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxPortret).BeginInit();
            SuspendLayout();
            // 
            // picBoxPortret
            // 
            picBoxPortret.Image = (Image)resources.GetObject("picBoxPortret.Image");
            picBoxPortret.Location = new Point(45, 90);
            picBoxPortret.Name = "picBoxPortret";
            picBoxPortret.Size = new Size(215, 246);
            picBoxPortret.TabIndex = 0;
            picBoxPortret.TabStop = false;
            // 
            // lblStatystyki
            // 
            lblStatystyki.AutoSize = true;
            lblStatystyki.Font = new Font("Segoe UI", 15F);
            lblStatystyki.Location = new Point(280, 90);
            lblStatystyki.Name = "lblStatystyki";
            lblStatystyki.Size = new Size(73, 35);
            lblStatystyki.TabIndex = 1;
            lblStatystyki.Text = "Staty:";
            // 
            // listBoxArmia
            // 
            listBoxArmia.FormattingEnabled = true;
            listBoxArmia.Location = new Point(532, 38);
            listBoxArmia.Name = "listBoxArmia";
            listBoxArmia.Size = new Size(256, 284);
            listBoxArmia.TabIndex = 2;
            // 
            // back
            // 
            back.Location = new Point(36, 390);
            back.Name = "back";
            back.Size = new Size(106, 48);
            back.TabIndex = 3;
            back.Text = "Powrót";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // progressBarExp
            // 
            progressBarExp.Location = new Point(45, 38);
            progressBarExp.Name = "progressBarExp";
            progressBarExp.Size = new Size(215, 29);
            progressBarExp.TabIndex = 4;
            // 
            // usun_jednostke
            // 
            usun_jednostke.Location = new Point(661, 328);
            usun_jednostke.Name = "usun_jednostke";
            usun_jednostke.Size = new Size(127, 62);
            usun_jednostke.TabIndex = 5;
            usun_jednostke.Text = "Usuń";
            usun_jednostke.UseVisualStyleBackColor = true;
            usun_jednostke.Click += usun_jednostke_Click;
            // 
            // FormBohater
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(usun_jednostke);
            Controls.Add(progressBarExp);
            Controls.Add(back);
            Controls.Add(listBoxArmia);
            Controls.Add(lblStatystyki);
            Controls.Add(picBoxPortret);
            Name = "FormBohater";
            Text = "Bohater";
            ((System.ComponentModel.ISupportInitialize)picBoxPortret).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBoxPortret;
        private Label lblStatystyki;
        private ListBox listBoxArmia;
        private Button back;
        private ProgressBar progressBarExp;
        private Button usun_jednostke;
    }
}