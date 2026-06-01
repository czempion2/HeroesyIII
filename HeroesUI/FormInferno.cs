using HeroesLibrary.Modele;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HeroesUI
{
    public partial class FormInferno : Form
    {
        private Zamek zamek;
        private Bohater goscWZamku;

        public FormInferno(Zamek przekazanyZamek, Bohater bohaterGracza)
        {
            InitializeComponent();

            zamek = przekazanyZamek;
            goscWZamku = bohaterGracza;

            zamek.SurowceZmienione += OdswiezPasekWZamku;
            OdswiezPasekWZamku(zamek.Skarbiec);

            PodepnijZdarzenia();

            ZaktualizujPrzyciskiBudynkow();
            OdswiezListeRekrutacji();
        }

        private void PodepnijZdarzenia()
        {
            back.Click += (s, e) => this.Close();
            btnRekrutuj.Click += btnRekrutuj_Click;

            btnZbudujUrodzisko.Click += (s, e) => SprobujZbudowac("Urodzisko");
            btnZbudujUlepszoneUrodzisko.Click += (s, e) => SprobujZbudowac("Ulepszone Urodzisko");

            btnZbudujSaleGrzechu.Click += (s, e) => SprobujZbudowac("Sale grzechu");
            btnZbudujUlepszoneSaleGrzechu.Click += (s, e) => SprobujZbudowac("Ulepszone Sale grzechu");

            btnZbudujPsiarnia.Click += (s, e) => SprobujZbudowac("Psiarnia");
            btnZbudujUlepszonaPsiarnia.Click += (s, e) => SprobujZbudowac("Ulepszona Psiarnia");

            btnZbudujWrotaDemonow.Click += (s, e) => SprobujZbudowac("Wrota demonów");
            btnZbudujUlepszoneWrotaDemonów.Click += (s, e) => SprobujZbudowac("Ulepszone Wrota demonów");

            btnZbudujPrzedsionekPiekieł.Click += (s, e) => SprobujZbudowac("Przedsionek piekieł");
            btnZbudujUlepszonyPrzedsionekPiekieł.Click += (s, e) => SprobujZbudowac("Ulepszony Przedsionek piekieł");

            btnZbudujJezioroOgnia.Click += (s, e) => SprobujZbudowac("Jezioro ognia");
            btnZbudujUlepszoneJezioroOgnia.Click += (s, e) => SprobujZbudowac("Ulepszone Jezioro ognia");

            btnZbudujPrzeklętyPałac.Click += (s, e) => SprobujZbudowac("Przeklęty pałac");
            btnZbudujUlepszonyPrzeklętyPałac.Click += (s, e) => SprobujZbudowac("Ulepszony Przeklęty pałac");
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
            AktualizujGuzik(btnZbudujUrodzisko, "Urodzisko");
            AktualizujGuzik(btnZbudujUlepszoneUrodzisko, "Ulepszone Urodzisko");

            AktualizujGuzik(btnZbudujSaleGrzechu, "Sale grzechu");
            AktualizujGuzik(btnZbudujUlepszoneSaleGrzechu, "Ulepszone Sale grzechu");

            AktualizujGuzik(btnZbudujPsiarnia, "Psiarnia");
            AktualizujGuzik(btnZbudujUlepszonaPsiarnia, "Ulepszona Psiarnia");

            AktualizujGuzik(btnZbudujWrotaDemonow, "Wrota demonów");
            AktualizujGuzik(btnZbudujUlepszoneWrotaDemonów, "Ulepszone Wrota demonów");

            AktualizujGuzik(btnZbudujPrzedsionekPiekieł, "Przedsionek piekieł");
            AktualizujGuzik(btnZbudujUlepszonyPrzedsionekPiekieł, "Ulepszony Przedsionek piekieł");

            AktualizujGuzik(btnZbudujJezioroOgnia, "Jezioro ognia");
            AktualizujGuzik(btnZbudujUlepszoneJezioroOgnia, "Ulepszone Jezioro ognia");

            AktualizujGuzik(btnZbudujPrzeklętyPałac, "Przeklęty pałac");
            AktualizujGuzik(btnZbudujUlepszonyPrzeklętyPałac, "Ulepszony Przeklęty pałac");

            OdswiezListeRekrutacji();
        }

        private void SprobujZbudowac(string nazwaBudynku)
        {
            var budynek = zamek.Infrastruktura.FirstOrDefault(b => b.Nazwa == nazwaBudynku);

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

        private void btnRekrutuj_Click(object sender, EventArgs e)
        {
            if (listBoxRekrutacja.SelectedItem == null)
            {
                MessageBox.Show("Mój Panie, najpierw wskaż jednostkę z listy!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxRekrutacja.SelectedItem is Jednostka wybrana)
            {
                int iloscDoKupienia = 1;
                if (!int.TryParse(Ilosc.Text, out iloscDoKupienia) || iloscDoKupienia <= 0)
                {
                    MessageBox.Show("Mój Panie, podaj poprawną, dodatnią liczbę jednostek do rekrutacji!", "Nieprawidłowa ilość", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Jednostka paczkaWojska = wybrana.Klonuj();
                    paczkaWojska.Ilosc = iloscDoKupienia;

                    paczkaWojska.Koszt = new Zasoby(
                        wybrana.Koszt.Zloto * iloscDoKupienia,
                        wybrana.Koszt.Drewno * iloscDoKupienia,
                        wybrana.Koszt.Ruda * iloscDoKupienia
                    );

                    zamek.KupJednostke(paczkaWojska, goscWZamku);
                    MessageBox.Show($"Pomyślnie zrekrutowano: {wybrana.Nazwa} w liczbie {iloscDoKupienia} szt!\nJednostki czekają w armii bohatera.", "Chwała!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Ilosc.Text = "1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Problem z rekrutacją", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AktualizujGuzik(Button btn, string nazwaBudynku)
        {
            var budynek = zamek.Infrastruktura.FirstOrDefault(b => b.Nazwa == nazwaBudynku);
            if (budynek == null) return;

            if (budynek.CzyWybudowany)
            {
                btn.Enabled = false;
                btn.Text = "Wybudowano";
            }
            else
            {
                if (!string.IsNullOrEmpty(budynek.WymaganyBudynek))
                {
                    var wymog = zamek.Infrastruktura.FirstOrDefault(b => b.Nazwa == budynek.WymaganyBudynek);

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