using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Budynki;
using HeroesLibrary.Wyjatki;
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
    public partial class FormZamek : Form
    {
        private Zamek zamek;
        private Bohater goscWZamku;

        public FormZamek(Zamek przekazanyZamek, Bohater bohaterGracza)
        {
            InitializeComponent();

            zamek = przekazanyZamek;
            goscWZamku = bohaterGracza;

            zamek.SurowceZmienione += OdswiezPasekWZamku;
            OdswiezPasekWZamku(zamek.Skarbiec);

            ZaktualizujPrzyciskiBudynkow();
            OdswiezListeRekrutacji();
        }
        private void OdswiezListeRekrutacji()
        {
            listBoxRekrutacja.Items.Clear();

            foreach (var jednostka in zamek.PobierzDostepneDoKupienia())
            {
                listBoxRekrutacja.Items.Add(jednostka);
            }
        }
        private void ZaktualizujPrzyciskiBudynkow()
        {
            AktualizujGuzik(btnZbudujPosterunek, typeof(Posterunek));
            AktualizujGuzik(btnZbudujStraznica, typeof(Strażnica));

            AktualizujGuzik(btnZbudujWiezaLucznikow, typeof(WiezaLucznikow));
            AktualizujGuzik(btnZbudujBastionKusznikow, typeof(BastionLucznikow));

            AktualizujGuzik(btnZbudujGniazdoGryfow, typeof(GniazdoGryfow));
            AktualizujGuzik(btnZbudujBastionGryfow, typeof(BastionGryfow));

            AktualizujGuzik(btnZbudujKoszaryZbrojnych, typeof(KoszaryZbrojnych));
            AktualizujGuzik(btnZbudujBastionMiecznikow, typeof(BastionMiecznikow));

            AktualizujGuzik(btnZbudujKlasztor, typeof(Klasztor));
            AktualizujGuzik(btnZbudujSwiatynia, typeof(Swiatynia));

            AktualizujGuzik(btnZbudujStajnie, typeof(Stajnie));
            AktualizujGuzik(btnZbudujSzkolaKawalerii, typeof(SzkolkaKawalerii));

            AktualizujGuzik(btnZbudujPortalChwaly, typeof(PortalChwaly));
            AktualizujGuzik(btnZbudujSanktuarium, typeof(Sanktuarium));

            OdswiezListeRekrutacji();
        }

        private void SprobujZbudowac(Type typBudynku)
        {
            var budynek = zamek.Infrastruktura.FirstOrDefault(b => b.GetType() == typBudynku);

            if (budynek == null || budynek.CzyWybudowany) return;

            string komunikat = $"Czy chcesz wybudować: {budynek.Nazwa}?\n\n" +
                               $"KOSZT BUDOWY:\n" +
                               $"- Złoto: {budynek.KosztBudowy.Zloto}\n" +
                               $"- Drewno: {budynek.KosztBudowy.Drewno}\n" +
                               $"- Ruda: {budynek.KosztBudowy.Ruda}";

            DialogResult decyzja = MessageBox.Show(komunikat, "Plany budowy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (decyzja == DialogResult.Yes)
            {
                try
                {
                    zamek.Wybuduj(budynek);
                    MessageBox.Show($"Pomyślnie wzniesiono: {budynek.Nazwa}!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ZaktualizujPrzyciskiBudynkow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Budowa wstrzymana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void OdswiezPasekWZamku(Zasoby obecneZasoby)
        {
            zloto.Text = $"Złoto: {obecneZasoby.Zloto}";
            drewno.Text = $"Drewno: {obecneZasoby.Drewno}";
            ruda.Text = $"Ruda: {obecneZasoby.Ruda}";
        }
        private void btnZbudujPosterunek_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Posterunek));
        }
        private void btnZbudujWiezaLucznikow_Click_1(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(WiezaLucznikow));
        }
        private void btnZbudujStraznica_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Strażnica));
        }

        private void btnZbudujBastionKusznikow_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(BastionLucznikow));
        }

        private void btnZbudujGniazdoGryfow_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(GniazdoGryfow));
        }

        private void btnZbudujBastionGryfow_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(BastionGryfow));
        }

        private void btnZbudujKoszaryZbrojnych_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(KoszaryZbrojnych));
        }

        private void btnZbudujBastionMiecznikow_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(BastionMiecznikow));
        }

        private void btnZbudujKlasztor_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Klasztor));
        }

        private void btnZbudujSwiatynia_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Swiatynia));
        }

        private void btnZbudujStajnie_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Stajnie));
        }

        private void btnZbudujSzkolaKawalerii_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(SzkolkaKawalerii));
        }

        private void btnZbudujPortalChwaly_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(PortalChwaly));
        }

        private void btnZbudujSanktuarium_Click(object sender, EventArgs e)
        {
            SprobujZbudowac(typeof(Sanktuarium));
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRekrutuj_Click(object sender, EventArgs e)
        {
            if (listBoxRekrutacja.SelectedItem == null)
            {
                MessageBox.Show("Mój Panie, najpierw wskaż jednostkę z listy!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxRekrutacja.SelectedItem is Jednostka wybrana)
            {
                try
                {
                    zamek.KupJednostke(wybrana, goscWZamku);

                    MessageBox.Show($"Pomyślnie zrekrutowano: {wybrana.Nazwa}!\nJednostka czeka w armii bohatera.", "Chwała!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Problem z rekrutacją", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AktualizujGuzik(Button btn, Type typBudynku)
        {
            var budynek = zamek.Infrastruktura.FirstOrDefault(b => b.GetType() == typBudynku);
            if (budynek == null) return;

            if (budynek.CzyWybudowany)
            {
                btn.Enabled = false;
                btn.Text = "Wybudowano";
            }
            else
            {
                if (budynek.WymaganyBudynek != null)
                {
                    var wymog = zamek.Infrastruktura.FirstOrDefault(b => b.GetType() == budynek.WymaganyBudynek);

                    if (wymog != null && !wymog.CzyWybudowany)
                    {
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.Enabled = true;
                    }
                }
                else
                {
                    btn.Enabled = true;
                }
            }
        }
    }
}
