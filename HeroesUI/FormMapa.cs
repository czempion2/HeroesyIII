using HeroesLibrary;
using HeroesLibrary.Modele;
using HeroesLibrary.Przystañ.Budynki;


namespace HeroesUI
{
    public partial class FormMapa : Form
    {
        private Zamek zamekGracza;
        private Bohater glownyBohater;
        private int dzienGry = 1;
        private int tydzienGry = 1;
        private int miesiacGry = 1;
        public FormMapa()
        {
            InitializeComponent();
            aktualna_data.Text = $"Miesi¹c {miesiacGry}, Tydzieñ {tydzienGry}, Dzieñ {dzienGry}";

            zamekGracza = new ZamekLudzi();
            glownyBohater = new Bohater("Christian", 1, 2, 1, 1);

            zamekGracza.SurowceZmienione += OdswiezPasekNaMapie;
            OdswiezPasekNaMapie(zamekGracza.Skarbiec);


        }
        private void OdswiezPasekNaMapie(Zasoby obecneZasoby)
        {
            zloto.Text = $"Z³oto: {obecneZasoby.Zloto}";
            drewno.Text = $"Drewno: {obecneZasoby.Drewno}";
            ruda.Text = $"Ruda: {obecneZasoby.Ruda}";
        }
        private void btnWejdzDoZamku_Click(object sender, EventArgs e)
        {
            FormZamek oknoZamku = new FormZamek(zamekGracza, glownyBohater);

            oknoZamku.ShowDialog();
        }

        private void btnKartaBohatera_Click(object sender, EventArgs e)
        {
            FormBohater oknoBohatera = new FormBohater(glownyBohater);
            oknoBohatera.ShowDialog();
        }

        private void tura_Click(object sender, EventArgs e)
        {
            zamekGracza.DodajSurowce(1000, 2, 2);
            glownyBohater.DodajDoswiadczenie(250);
            dzienGry++; 

            if (dzienGry > 7)
            {
                dzienGry = 1;
                tydzienGry++; 

                if (tydzienGry > 4)
                {
                    tydzienGry = 1;
                    miesiacGry++;  
                }
            }

            aktualna_data.Text = $"Miesi¹c {miesiacGry}, Tydzieñ {tydzienGry}, Dzieñ {dzienGry}";

            if (dzienGry == 1)
            {
                MessageBox.Show("Astrologowie og³aszaj¹ nowy tydzieñ!\nPopulacja stworzeñ zwiêksza siê.", "Nowy Tydzieñ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Rozpoczêto now¹ turê! Zyskano zasoby i doœwiadczenie.");
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerZapisu.Zapisz(zamekGracza, glownyBohater, dzienGry, tydzienGry, miesiacGry);
            MessageBox.Show("Gra zosta³a zapisana!", "Zapis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stan = ManagerZapisu.Wczytaj();
            if (stan != null)
            {
                zamekGracza.Skarbiec.Zloto = stan.Skarbiec.Zloto;
                zamekGracza.Skarbiec.Drewno = stan.Skarbiec.Drewno;
                zamekGracza.Skarbiec.Ruda = stan.Skarbiec.Ruda;

                OdswiezPasekNaMapie(zamekGracza.Skarbiec);

                dzienGry = stan.Dzien;
                tydzienGry = stan.Tydzien;
                miesiacGry = stan.Miesiac;

                aktualna_data.Text = $"Miesi¹c {miesiacGry}, Tydzieñ {tydzienGry}, Dzieñ {dzienGry}";

                for (int i = 0; i < stan.StanBudynkow.Count; i++)
                {
                    zamekGracza.Infrastruktura[i].CzyWybudowany = stan.StanBudynkow[i];
                }

                glownyBohater.Armia.Clear(); 
                if (stan.TypyJednostekWArmii != null)
                {
                    foreach (string nazwaTypu in stan.TypyJednostekWArmii)
                    {
                        Type typJednostki = Type.GetType(nazwaTypu);
                        if (typJednostki != null)
                        {
                            Jednostka j = (Jednostka)Activator.CreateInstance(typJednostki);
                            glownyBohater.DodajDoArmii(j);
                        }
                    }
                }

                MessageBox.Show("Gra wczytana pomyœlnie!");
            }
        }

        private void FormMapa_Load(object sender, EventArgs e)
        {

        }
    }
}
