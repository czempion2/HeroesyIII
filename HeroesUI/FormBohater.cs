using HeroesLibrary.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroesUI
{
    public partial class FormBohater : Form
    {
        private Bohater bohater;

        public FormBohater(Bohater przekazanyBohater)
        {
            InitializeComponent();
            bohater = przekazanyBohater;

            WczytajDane();
        }

        private void WczytajDane()
        {

            lblStatystyki.Text = $"Poziom: {bohater.PoziomBohatera}\n\nAtak: {bohater.Atak}\nObrona: {bohater.Obrona}\nMoc: {bohater.Moc}\nWiedza: {bohater.Wiedza}";

            progressBarExp.Maximum = bohater.MaxDoswiadczenie;
            progressBarExp.Value = bohater.Doswiadczenie;

            listBoxArmia.Items.Clear();
            foreach (var jednostka in bohater.Armia)
            {
                listBoxArmia.Items.Add(jednostka.ToString());
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usun_jednostke_Click(object sender, EventArgs e)
        {
            if (listBoxArmia.SelectedIndex == -1)
            {
                MessageBox.Show("Mój Panie, najpierw wskaż oddział, który chcesz zwolnić ze służby!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int zaznaczonyIndeks = listBoxArmia.SelectedIndex;

            DialogResult decyzja = MessageBox.Show(
                "Czy na pewno chcesz rozwiązać ten oddział i odesłać go do domu? Tej decyzji nie można cofnąć.",
                "Zwolnienie ze służby",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (decyzja == DialogResult.Yes)
            {
                bohater.UsunZArmii(zaznaczonyIndeks);
                WczytajDane();
            }
        }
    }
}
