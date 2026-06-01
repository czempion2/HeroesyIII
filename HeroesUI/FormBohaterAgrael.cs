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
    public partial class FormBohaterAgrael : Form
    {
        private Bohater bohater;

        public FormBohaterAgrael(Bohater przekazanyBohater)
        {
            InitializeComponent();
            bohater = przekazanyBohater;

            this.Text = $"Bohater: {bohater.Imie}";

            WczytajDane();
        }

        private void WczytajDane()
        {
            lblStatystyki.Text = $"Imię: {bohater.Imie}\n\n" +
                                 $"Poziom: {bohater.PoziomBohatera}\n\n" +
                                 $"Atak: {bohater.Atak}\n" +
                                 $"Obrona: {bohater.Obrona}\n" +
                                 $"Moc: {bohater.Moc}\n" +
                                 $"Wiedza: {bohater.Wiedza}";

            progressBarExp.Maximum = bohater.MaxDoswiadczenie;
            progressBarExp.Value = bohater.Doswiadczenie;
            bohater.Armia.Sort((jednostka1, jednostka2) => jednostka1.Poziom.CompareTo(jednostka2.Poziom));
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
                MessageBox.Show("Wybierz oddział, który chcesz zwolnić ze służby!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int zaznaczonyIndeks = listBoxArmia.SelectedIndex;

            DialogResult decyzja = MessageBox.Show(
                "Czy na pewno chcesz rozwiązać ten oddział i odesłać go do domu?",
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
