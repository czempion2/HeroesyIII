namespace HeroesUI
{
    partial class FormBohaterAgrael
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBohaterAgrael));
            usun_jednostke = new Button();
            progressBarExp = new ProgressBar();
            back = new Button();
            listBoxArmia = new ListBox();
            lblStatystyki = new Label();
            PicAgrael = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicAgrael).BeginInit();
            SuspendLayout();
            // 
            // usun_jednostke
            // 
            usun_jednostke.Location = new Point(649, 315);
            usun_jednostke.Name = "usun_jednostke";
            usun_jednostke.Size = new Size(127, 62);
            usun_jednostke.TabIndex = 11;
            usun_jednostke.Text = "Usuń";
            usun_jednostke.UseVisualStyleBackColor = true;
            usun_jednostke.Click += usun_jednostke_Click;
            // 
            // progressBarExp
            // 
            progressBarExp.Location = new Point(33, 25);
            progressBarExp.Name = "progressBarExp";
            progressBarExp.Size = new Size(215, 29);
            progressBarExp.TabIndex = 10;
            // 
            // back
            // 
            back.Location = new Point(24, 377);
            back.Name = "back";
            back.Size = new Size(106, 48);
            back.TabIndex = 9;
            back.Text = "Powrót";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // listBoxArmia
            // 
            listBoxArmia.FormattingEnabled = true;
            listBoxArmia.Location = new Point(520, 25);
            listBoxArmia.Name = "listBoxArmia";
            listBoxArmia.Size = new Size(256, 284);
            listBoxArmia.TabIndex = 8;
            // 
            // lblStatystyki
            // 
            lblStatystyki.AutoSize = true;
            lblStatystyki.Font = new Font("Segoe UI", 15F);
            lblStatystyki.Location = new Point(268, 77);
            lblStatystyki.Name = "lblStatystyki";
            lblStatystyki.Size = new Size(73, 35);
            lblStatystyki.TabIndex = 7;
            lblStatystyki.Text = "Staty:";
            // 
            // PicAgrael
            // 
            PicAgrael.Image = (Image)resources.GetObject("PicAgrael.Image");
            PicAgrael.Location = new Point(33, 77);
            PicAgrael.Name = "PicAgrael";
            PicAgrael.Size = new Size(215, 246);
            PicAgrael.TabIndex = 6;
            PicAgrael.TabStop = false;
            // 
            // FormBohaterAgrael
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(usun_jednostke);
            Controls.Add(progressBarExp);
            Controls.Add(back);
            Controls.Add(listBoxArmia);
            Controls.Add(lblStatystyki);
            Controls.Add(PicAgrael);
            Name = "FormBohaterAgrael";
            Text = "Agrael";
            ((System.ComponentModel.ISupportInitialize)PicAgrael).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button usun_jednostke;
        private ProgressBar progressBarExp;
        private Button back;
        private ListBox listBoxArmia;
        private Label lblStatystyki;
        private PictureBox PicAgrael;
    }
}