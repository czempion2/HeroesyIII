using HeroesLibrary.Modele;
using HeroesLibrary.Przystañ;
using HeroesLibrary.Inferno;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using WMPLib;
namespace HeroesUI
{
    public partial class FormMapa : Form
    {
        private WindowsMediaPlayer odtwarzaczMuzyki;
        private Zamek zamekPrzystan;
        private Zamek zamekInferno;
        private Bohater christian;
        private Bohater agrael;

        private Kopalnia obiektKopalniaZlota1;
        private Kopalnia obiektKopalniaDrewna1;
        private Kopalnia obiektKopalniaRudy1;

        private Kopalnia obiektKopalniaZlota2;
        private Kopalnia obiektKopalniaDrewna2;
        private Kopalnia obiektKopalniaRudy2;

        private bool czyTuraPrzystani = true;
        private int dzienRozgrywki = 1;

        public FormMapa()
        {
            InitializeComponent();

            wlaczMuzyke("Soundtrack/soundtrack.mp3");

            btnWejdzDoInferno.Click += btnWejdzDoInferno_Click;
            btnKartaBohateraInferno.Click += btnKartaBohateraInferno_Click;

            

            zamekPrzystan = new ZamekLudzi();
            zamekInferno = new ZamekInferno();

            zamekPrzystan.Skarbiec = new Zasoby(2000, 20, 20);
            zamekInferno.Skarbiec = new Zasoby(2000, 20, 20);

            christian = new Bohater("Christian", 1, 2, 2, 2);
            christian.DodajDoArmii(new Jednostka("Pikinier", 1, new Zasoby(60, 0, 0), false, 4, 5, 0, "", 10, 1, 3, 4) { Ilosc = 15 });

            agrael = new Bohater("Agrael", 2, 1, 3, 2);
            agrael.DodajDoArmii(new Jednostka("Chowaniec", 1, new Zasoby(70, 0, 0), true, 4, 4, 0, "", 4, 1, 2, 7) { Ilosc = 20 });

            obiektKopalniaZlota1 = new Kopalnia("Kopalnia Zlota", TypSurowca.Zloto, 1000);
            obiektKopalniaZlota1.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaZlota1.Straznik.DodajDoArmii(new Jednostka("Zbrojny", 3, new Zasoby(200, 0, 0), false, 8, 8, 0, "", 25, 3, 6, 6) { Ilosc = 10 });

            obiektKopalniaDrewna1 = new Kopalnia("Tartak", TypSurowca.Drewno, 2);
            obiektKopalniaDrewna1.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaDrewna1.Straznik.DodajDoArmii(new Jednostka("Pikinier", 1, new Zasoby(75, 0, 0), true, 6, 5, 0, "", 10, 2, 3, 5) { Ilosc = 15 });

            obiektKopalniaRudy1 = new Kopalnia("Kopalnia Rudy", TypSurowca.Ruda, 2);
            obiektKopalniaRudy1.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaRudy1.Straznik.DodajDoArmii(new Jednostka("Kusznik", 2, new Zasoby(125, 0, 0), false, 6, 4, 12, "", 13, 2, 4, 4) { Ilosc = 20 });

            obiektKopalniaZlota2 = new Kopalnia("Kopalnia Zlota (Prawa)", TypSurowca.Zloto, 1000);
            obiektKopalniaZlota2.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaZlota2.Straznik.DodajDoArmii(new Jednostka("Cerber", 4, new Zasoby(250, 0, 0), false, 10, 10, 0, "", 35, 7, 9, 5) { Ilosc = 5 });

            obiektKopalniaDrewna2 = new Kopalnia("Tartak (Prawy)", TypSurowca.Drewno, 2);
            obiektKopalniaDrewna2.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaDrewna2.Straznik.DodajDoArmii(new Jednostka("Gog", 3, new Zasoby(250, 0, 0), true, 10, 8, 0, "", 25, 2, 7, 8) { Ilosc = 8 });

            obiektKopalniaRudy2 = new Kopalnia("Kopalnia Rudy (Prawa)", TypSurowca.Ruda, 2);
            obiektKopalniaRudy2.Straznik = new Bohater("Straznicy", 0, 0, 0, 0);
            obiektKopalniaRudy2.Straznik.DodajDoArmii(new Jednostka("Chochlik", 1, new Zasoby(50, 0, 0), false, 2, 3, 0, "", 4, 1, 2, 5) { Ilosc = 30 });

            zamekPrzystan.SurowceZmienione += OdswiezPasekNaMapie;
            zamekInferno.SurowceZmienione += OdswiezPasekNaMapie;

            PodepnijKliknieciaStraznikow();
            AktualizujNapisTury();
            OdswiezPasekNaMapie(null);
            OdswiezPrzyciskiKopalni();
        }

        private void PodepnijKliknieciaStraznikow()
        {
            var sz1 = this.Controls.Find("straznikZlota1", true).FirstOrDefault() as Button;
            if (sz1 != null) sz1.Click += kopalniaZlota_Click;

            var sd1 = this.Controls.Find("straznikDrewna1", true).FirstOrDefault() as Button;
            if (sd1 != null) sd1.Click += kopalniaDrewna_Click;

            var sr1 = this.Controls.Find("straznikRudy1", true).FirstOrDefault() as Button;
            if (sr1 != null) sr1.Click += kopalniaRudy_Click;

            var sz2 = this.Controls.Find("straznikZlota2", true).FirstOrDefault() as Button;
            if (sz2 != null) sz2.Click += kopzlota_Click;

            var sd2 = this.Controls.Find("straznikDrewna2", true).FirstOrDefault() as Button;
            if (sd2 != null) sd2.Click += kopdrewna_Click;

            var sr2 = this.Controls.Find("straznikRudy2", true).FirstOrDefault() as Button;
            if (sr2 != null) sr2.Click += kopkamien_Click;
        }

        private void AktualizujNapisTury()
        {
            int miesiac = ((dzienRozgrywki - 1) / 28) + 1;
            int tydzien = (((dzienRozgrywki - 1) % 28) / 7) + 1;
            int dzien = ((dzienRozgrywki - 1) % 7) + 1;

            string formatDaty = $"Miesiac {miesiac}, Tydzien {tydzien}, Dzien {dzien}";
            string frakcja = czyTuraPrzystani ? "Przystan" : "Inferno";

            aktualna_data.Text = $"Tura: {frakcja} ({formatDaty})";

            Bohater aktywnyBohater = czyTuraPrzystani ? christian : agrael;
            if (aktywnyBohater.PosiadaneKopalnie.Count == 0)
                listaKopalni.Text = "Kopalnie: brak";
            else
                listaKopalni.Text = "Kopalnie: " + string.Join(", ", aktywnyBohater.PosiadaneKopalnie.Select(k => k.Nazwa));
        }
        private void SprawdzStanGry()
        {
            bool christianZyl = christian.Armia.Sum(j => j.Ilosc) > 0;
            bool agraelZyl = agrael.Armia.Sum(j => j.Ilosc) > 0;

            var picChristian = this.Controls.Find("picChristian", true).FirstOrDefault() as PictureBox;
            var picAgrael = this.Controls.Find("picAgrael", true).FirstOrDefault() as PictureBox;

            if (picChristian != null) picChristian.Visible = christianZyl;
            if (picAgrael != null) picAgrael.Visible = agraelZyl;

            if (!christianZyl && agraelZyl)
            {
                MessageBox.Show("Christian straci³ ca³¹ armiê! AGRAEL WYGRYWA GRÊ!", "KONIEC GRY");
                Application.Exit();
            }
            else if (!agraelZyl && christianZyl)
            {
                MessageBox.Show("Agrael straci³ ca³¹ armiê! CHRISTIAN WYGRYWA GRÊ!", "KONIEC GRY");
                Application.Exit();
            }
        }
        private void OdswiezPasekNaMapie(Zasoby puste)
        {
            Zasoby obecneZasoby = czyTuraPrzystani ? zamekPrzystan.Skarbiec : zamekInferno.Skarbiec;

            zloto.Text = $"Zloto: {obecneZasoby.Zloto}";
            drewno.Text = $"Drewno: {obecneZasoby.Drewno}";
            ruda.Text = $"Ruda: {obecneZasoby.Ruda}";
        }

        private void AktualizujTekstPrzycisku(string nazwaPrzycisku, Kopalnia kopalnia, string bazowaNazwa, bool znikajacyStraznik = false)
        {
            var btn = this.Controls.Find(nazwaPrzycisku, true).FirstOrDefault() as Button;
            if (btn != null)
            {
                if (kopalnia.Straznik != null && kopalnia.Straznik.Armia.Count > 0)
                {
                    btn.Visible = true;
                    if (znikajacyStraznik)
                        btn.Text = "";
                    else
                        btn.Text = "";
                }
                else
                {
                    if (znikajacyStraznik)
                    {
                        btn.Visible = false;
                    }
                    else
                    {
                        btn.Visible = true;
                        btn.Text = bazowaNazwa;
                    }
                }
            }
        }

        private void OdswiezPrzyciskiKopalni()
        {
            AktualizujTekstPrzycisku("kopalniaZlota", obiektKopalniaZlota1, "");
            AktualizujTekstPrzycisku("kopalniaDrewna", obiektKopalniaDrewna1, "");
            AktualizujTekstPrzycisku("kopalniaRudy", obiektKopalniaRudy1, "");

            AktualizujTekstPrzycisku("kopzlota", obiektKopalniaZlota2, "");
            AktualizujTekstPrzycisku("kopdrewna", obiektKopalniaDrewna2, "");
            AktualizujTekstPrzycisku("kopkamien", obiektKopalniaRudy2, "");

            AktualizujTekstPrzycisku("straznikZlota1", obiektKopalniaZlota1, "", true);
            AktualizujTekstPrzycisku("straznikDrewna1", obiektKopalniaDrewna1, "", true);
            AktualizujTekstPrzycisku("straznikRudy1", obiektKopalniaRudy1, "", true);

            AktualizujTekstPrzycisku("straznikZlota2", obiektKopalniaZlota2, "", true);
            AktualizujTekstPrzycisku("straznikDrewna2", obiektKopalniaDrewna2, "", true);
            AktualizujTekstPrzycisku("straznikRudy2", obiektKopalniaRudy2, "", true);
        }

        private void FormMapa_Load(object sender, EventArgs e)
        {
        }

        private void btnWejdzDoZamku_Click(object sender, EventArgs e)
        {
            if (!czyTuraPrzystani)
            {
                MessageBox.Show("To nie jest tura Przystani! Nie mozesz zarzadzac tym zamkiem.", "Brak tury", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            FormZamek oknoPrzystani = new FormZamek(zamekPrzystan, christian);
            wyciszMuzyke();
            wlaczMuzyke("Soundtrack/zamekLudzi.mp3");
            oknoPrzystani.ShowDialog();
            OdswiezPasekNaMapie(null);
            wyciszMuzyke();
            wlaczMuzyke("Soundtrack/soundtrack.mp3");

        }

        private void btnWejdzDoInferno_Click(object sender, EventArgs e)
        {
            if (czyTuraPrzystani)
            {
                MessageBox.Show("To nie jest tura Inferno! Demony nie usluchaja Twoich rozkazow.", "Brak tury", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            FormInferno oknoInferno = new FormInferno(zamekInferno, agrael);
            wyciszMuzyke();
            wlaczMuzyke("Soundtrack/zamekDemony.mp3");
            oknoInferno.ShowDialog();
            OdswiezPasekNaMapie(null);
            wyciszMuzyke();
            wlaczMuzyke("Soundtrack/soundtrack.mp3");

        }

        private void btnKartaBohatera_Click(object sender, EventArgs e)
        {
            if (czyTuraPrzystani)
            {
                FormBohater oknoBohatera = new FormBohater(christian);
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/christian.mp3");
                oknoBohatera.ShowDialog();
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/soundtrack.mp3");
            }
            else
            {
                FormBitwa oknoBitwy = new FormBitwa(agrael, christian);
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/walka.mp3");
                oknoBitwy.ShowDialog();
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/soundtrack.mp3");

                SprawdzStanGry();
            }
            
        }

        private void btnKartaBohateraInferno_Click(object sender, EventArgs e)
        {
            if (!czyTuraPrzystani)
            {
                FormBohaterAgrael oknoBohatera = new FormBohaterAgrael(agrael);
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/agrael.mp3");
                oknoBohatera.ShowDialog();
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/soundtrack.mp3");
            }
            else
            {
                FormBitwa oknoBitwy = new FormBitwa(christian, agrael);
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/walka.mp3");
                oknoBitwy.ShowDialog();
                wyciszMuzyke();
                wlaczMuzyke("Soundtrack/soundtrack.mp3");

                SprawdzStanGry();
            }
            
        }

        private void ZapiszKopalnie(StreamWriter sw, Kopalnia kopalnia)
        {
            sw.WriteLine(christian.PosiadaneKopalnie.Contains(kopalnia) ? 1 : (agrael.PosiadaneKopalnie.Contains(kopalnia) ? 2 : 0));
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("savegame.txt"))
                {
                    sw.WriteLine(dzienRozgrywki);
                    sw.WriteLine(czyTuraPrzystani);
                    sw.WriteLine($"{zamekPrzystan.Skarbiec.Zloto};{zamekPrzystan.Skarbiec.Drewno};{zamekPrzystan.Skarbiec.Ruda}");
                    sw.WriteLine($"{zamekInferno.Skarbiec.Zloto};{zamekInferno.Skarbiec.Drewno};{zamekInferno.Skarbiec.Ruda}");

                    ZapiszKopalnie(sw, obiektKopalniaZlota1);
                    ZapiszKopalnie(sw, obiektKopalniaDrewna1);
                    ZapiszKopalnie(sw, obiektKopalniaRudy1);
                    ZapiszKopalnie(sw, obiektKopalniaZlota2);
                    ZapiszKopalnie(sw, obiektKopalniaDrewna2);
                    ZapiszKopalnie(sw, obiektKopalniaRudy2);

                    sw.WriteLine(string.Join(";", zamekPrzystan.Infrastruktura.Select(b => b.CzyWybudowany ? "1" : "0")));
                    sw.WriteLine(string.Join(";", zamekInferno.Infrastruktura.Select(b => b.CzyWybudowany ? "1" : "0")));

                    sw.WriteLine(christian.Armia.Count);
                    foreach (var j in christian.Armia)
                    {
                        sw.WriteLine($"{j.Nazwa};{j.Ilosc};{j.AktualneHP}");
                    }

                    sw.WriteLine(agrael.Armia.Count);
                    foreach (var j in agrael.Armia)
                    {
                        sw.WriteLine($"{j.Nazwa};{j.Ilosc};{j.AktualneHP}");
                    }
                }
                MessageBox.Show("Stan gry zostal zapisany pomyslnie.", "Zapisz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad zapisu: " + ex.Message);
            }
        }

        private void WczytajKopalnie(StreamReader sr, Kopalnia kopalnia)
        {
            int kod = int.Parse(sr.ReadLine());
            if (kod == 1) christian.PosiadaneKopalnie.Add(kopalnia);
            else if (kod == 2) agrael.PosiadaneKopalnie.Add(kopalnia);
            kopalnia.CzyZajeta = (kod != 0);
            if (kopalnia.CzyZajeta && kopalnia.Straznik != null) kopalnia.Straznik.Armia.Clear();
        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("savegame.txt"))
                {
                    MessageBox.Show("Brak zapisanego stanu gry!");
                    return;
                }

                using (StreamReader sr = new StreamReader("savegame.txt"))
                {
                    dzienRozgrywki = int.Parse(sr.ReadLine());
                    czyTuraPrzystani = bool.Parse(sr.ReadLine());

                    string[] mPrzystan = sr.ReadLine().Split(';');
                    zamekPrzystan.Skarbiec = new Zasoby(int.Parse(mPrzystan[0]), int.Parse(mPrzystan[1]), int.Parse(mPrzystan[2]));

                    string[] mInferno = sr.ReadLine().Split(';');
                    zamekInferno.Skarbiec = new Zasoby(int.Parse(mInferno[0]), int.Parse(mInferno[1]), int.Parse(mInferno[2]));

                    christian.PosiadaneKopalnie.Clear();
                    agrael.PosiadaneKopalnie.Clear();

                    WczytajKopalnie(sr, obiektKopalniaZlota1);
                    WczytajKopalnie(sr, obiektKopalniaDrewna1);
                    WczytajKopalnie(sr, obiektKopalniaRudy1);
                    WczytajKopalnie(sr, obiektKopalniaZlota2);
                    WczytajKopalnie(sr, obiektKopalniaDrewna2);
                    WczytajKopalnie(sr, obiektKopalniaRudy2);

                    string[] bPrzystan = sr.ReadLine().Split(';');
                    for (int i = 0; i < bPrzystan.Length && i < zamekPrzystan.Infrastruktura.Count; i++)
                    {
                        zamekPrzystan.Infrastruktura[i].CzyWybudowany = (bPrzystan[i] == "1");
                    }

                    string[] bInferno = sr.ReadLine().Split(';');
                    for (int i = 0; i < bInferno.Length && i < zamekInferno.Infrastruktura.Count; i++)
                    {
                        zamekInferno.Infrastruktura[i].CzyWybudowany = (bInferno[i] == "1");
                    }

                    christian.Armia.Clear();
                    int countC = int.Parse(sr.ReadLine());
                    for (int i = 0; i < countC; i++)
                    {
                        string[] units = sr.ReadLine().Split(';');
                        Jednostka j = StworzJednostkePoNazwie(units[0]);
                        if (j != null)
                        {
                            j.Ilosc = int.Parse(units[1]);
                            j.AktualneHP = int.Parse(units[2]);
                            christian.Armia.Add(j);
                        }
                    }

                    agrael.Armia.Clear();
                    int countA = int.Parse(sr.ReadLine());
                    for (int i = 0; i < countA; i++)
                    {
                        string[] units = sr.ReadLine().Split(';');
                        Jednostka j = StworzJednostkePoNazwie(units[0]);
                        if (j != null)
                        {
                            j.Ilosc = int.Parse(units[1]);
                            j.AktualneHP = int.Parse(units[2]);
                            agrael.Armia.Add(j);
                        }
                    }
                }

                AktualizujNapisTury();
                OdswiezPasekNaMapie(null);
                OdswiezPrzyciskiKopalni();
                MessageBox.Show("Stan gry zostal wczytany pomyslnie.", "Wczytaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad wczytywania: " + ex.Message);
            }
        }

        private Jednostka StworzJednostkePoNazwie(string nazwa)
        {
            switch (nazwa)
            {
                case "Pikinier": return new Jednostka("Pikinier", 1, new Zasoby(60, 0, 0), false, 4, 5, 0, "", 10, 1, 3, 4);
                case "Halabardnik": return new Jednostka("Halabardnik", 1, new Zasoby(75, 0, 0), true, 6, 5, 0, "", 10, 2, 3, 5);
                case "£ucznik": return new Jednostka("£ucznik", 2, new Zasoby(100, 0, 0), false, 6, 3, 12, "", 10, 2, 3, 4);
                case "Kusznik": return new Jednostka("Kusznik", 2, new Zasoby(150, 0, 0), true, 6, 3, 24, "", 10, 2, 3, 6);
                case "Gryf": return new Jednostka("Gryf", 3, new Zasoby(200, 0, 0), false, 8, 8, 0, "", 25, 3, 6, 6);
                case "Królewski Gryf": return new Jednostka("Królewski Gryf", 3, new Zasoby(240, 0, 0), true, 9, 9, 0, "", 25, 3, 6, 9);
                case "Zbrojny": return new Jednostka("Zbrojny", 4, new Zasoby(250, 0, 0), false, 10, 12, 0, "", 35, 6, 9, 5);
                case "Krzy¿owiec": return new Jednostka("Krzy¿owiec", 4, new Zasoby(400, 0, 0), true, 12, 12, 0, "", 35, 7, 10, 6);
                case "Mnich": return new Jednostka("Mnich", 5, new Zasoby(400, 0, 0), false, 12, 7, 12, "", 30, 10, 12, 5);
                case "Fanatyk": return new Jednostka("Fanatyk", 5, new Zasoby(450, 0, 0), true, 12, 7, 24, "", 30, 10, 12, 7);
                case "Kawalerzysta": return new Jednostka("Kawalerzysta", 6, new Zasoby(1000, 0, 0), false, 15, 15, 0, "", 100, 15, 25, 7);
                case "Czempion": return new Jednostka("Czempion", 6, new Zasoby(1200, 0, 0), true, 16, 16, 0, "", 100, 20, 25, 9);
                case "Anio³": return new Jednostka("Anio³", 7, new Zasoby(3000, 0, 0), false, 20, 20, 0, "", 200, 50, 50, 12);
                case "Archanio³": return new Jednostka("Archanio³", 7, new Zasoby(5000, 0, 0), true, 30, 30, 0, "", 250, 50, 50, 18);
                case "Chochlik": return new Jednostka("Chochlik", 1, new Zasoby(50, 0, 0), false, 2, 3, 0, "", 4, 1, 2, 5);
                case "Chowaniec": return new Jednostka("Chowaniec", 1, new Zasoby(70, 0, 0), true, 4, 4, 0, "", 4, 1, 2, 7);
                case "Gog": return new Jednostka("Gog", 2, new Zasoby(125, 0, 0), false, 6, 4, 12, "", 13, 2, 4, 4);
                case "Magog": return new Jednostka("Magog", 2, new Zasoby(175, 0, 0), true, 7, 4, 24, "", 13, 2, 4, 6);
                case "Piekielny ogar": return new Jednostka("Piekielny ogar", 3, new Zasoby(200, 0, 0), false, 10, 6, 0, "", 25, 2, 7, 7);
                case "Cerber": return new Jednostka("Cerber", 3, new Zasoby(250, 0, 0), true, 10, 8, 0, "", 25, 2, 7, 8);
                case "Demon": return new Jednostka("Demon", 4, new Zasoby(250, 0, 0), false, 10, 10, 0, "", 35, 7, 9, 5);
                case "Rogaty demon": return new Jednostka("Rogaty demon", 4, new Zasoby(270, 0, 0), true, 11, 11, 0, "", 40, 7, 9, 6);
                case "Czart": return new Jednostka("Czart", 5, new Zasoby(500, 0, 0), false, 13, 13, 0, "", 45, 13, 17, 6);
                case "Czarci lord": return new Jednostka("Czarci lord", 5, new Zasoby(700, 0, 0), true, 15, 15, 0, "", 45, 13, 17, 7);
                case "Ifryt": return new Jednostka("Ifryt", 6, new Zasoby(900, 0, 0), false, 16, 14, 0, "", 90, 16, 24, 9);
                case "Su³tañski ifryt": return new Jednostka("Su³tañski ifryt", 6, new Zasoby(1100, 0, 0), true, 16, 14, 0, "", 90, 16, 24, 13);
                case "Diabe³": return new Jednostka("Diabe³", 7, new Zasoby(2700, 0, 0), false, 19, 21, 0, "", 160, 30, 40, 11);
                case "Arcydiabe³": return new Jednostka("Arcydiabe³", 7, new Zasoby(4000, 0, 0), true, 26, 28, 0, "", 200, 30, 40, 17);
                default: return null;
            }
        }

        private void SprobujZajacKopalnie(Kopalnia kopalnia, Bohater bohater)
        {
            if (bohater.PosiadaneKopalnie.Contains(kopalnia))
            {
                MessageBox.Show("Ta kopalnia juz nalezy do Ciebie!", "Informacja");
                return;
            }

            if (kopalnia.Straznik != null && kopalnia.Straznik.Armia.Count > 0)
            {
                DialogResult odp = MessageBox.Show($"Dostepu do {kopalnia.Nazwa} bronia straznicy: {kopalnia.Straznik.Armia[0].Ilosc}x {kopalnia.Straznik.Armia[0].Nazwa}!\nCzy chcesz ich zaatakowac?", "Walka ze straznikami", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (odp == DialogResult.Yes)
                {
                    wyciszMuzyke();
                    wlaczMuzyke("Soundtrack/walka.mp3");
                    FormBitwa bitwa = new FormBitwa(bohater, kopalnia.Straznik);
                    bitwa.ShowDialog();
                    SprawdzStanGry();
                    if (kopalnia.Straznik.Armia.Count == 0)
                    {
                        ZajmijKopalnie(kopalnia, bohater);
                    }
                    else
                    {
                        MessageBox.Show("Twoje wojska poniosly kleske! Straznicy wciaz bronia kopalni.", "Porazka");
                    }
                }
            }
            else
            {
                ZajmijKopalnie(kopalnia, bohater);
            }

            OdswiezPrzyciskiKopalni();
            wyciszMuzyke();
            wlaczMuzyke("Soundtrack/soundtrack.mp3");
        }

        private void ZajmijKopalnie(Kopalnia kopalnia, Bohater bohater)
        {
            Bohater przeciwnik = (bohater == christian) ? agrael : christian;
            if (przeciwnik.PosiadaneKopalnie.Contains(kopalnia))
            {
                przeciwnik.PosiadaneKopalnie.Remove(kopalnia);
                MessageBox.Show($"Odebrales kopalnie graczowi {przeciwnik.Imie}!", "Kopalnia odbita!");
            }

            kopalnia.CzyZajeta = true;
            bohater.PosiadaneKopalnie.Add(kopalnia);

            AktualizujNapisTury();

            MessageBox.Show($"Sukces! {bohater.Imie} przejal kontrole nad: {kopalnia.Nazwa}.\nZapewni to surowce na poczatku Twojej kolejnej tury.", "Kopalnia zdobyta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kopalniaZlota_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaZlota1, aktywny);
        }

        private void kopalniaDrewna_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaDrewna1, aktywny);
        }

        private void kopalniaRudy_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaRudy1, aktywny);
        }

        private void kopkamien_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaRudy2, aktywny);
        }

        private void kopzlota_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaZlota2, aktywny);
        }

        private void kopdrewna_Click(object sender, EventArgs e)
        {
            Bohater aktywny = czyTuraPrzystani ? christian : agrael;
            SprobujZajacKopalnie(obiektKopalniaDrewna2, aktywny);
        }

        private void tura_Click(object sender, EventArgs e)
        {
            czyTuraPrzystani = !czyTuraPrzystani;

            if (czyTuraPrzystani)
            {
                dzienRozgrywki++;
            }

            int kopalniaZloto = 0, kopalniaDrewno = 0, kopalniaRuda = 0;
            string nazwaFrakcji = "";
            Bohater aktywnyBohater;
            Zamek aktywnyZamek;

            if (czyTuraPrzystani)
            {
                nazwaFrakcji = "PRZYSTAN (Christian)";
                aktywnyBohater = christian;
                aktywnyZamek = zamekPrzystan;
            }
            else
            {
                nazwaFrakcji = "INFERNO (Agrael)";
                aktywnyBohater = agrael;
                aktywnyZamek = zamekInferno;
            }

            foreach (var kopalnia in aktywnyBohater.PosiadaneKopalnie)
            {
                if (kopalnia.Typ == TypSurowca.Zloto) kopalniaZloto += kopalnia.Produkcja;
                else if (kopalnia.Typ == TypSurowca.Drewno) kopalniaDrewno += kopalnia.Produkcja;
                else if (kopalnia.Typ == TypSurowca.Ruda) kopalniaRuda += kopalnia.Produkcja;
            }

            int zamekZloto = aktywnyZamek.Przychod.Zloto;
            int zamekDrewno = RegulatoryLubJakKolidowalo(aktywnyZamek);
            int zamekRuda = RegulatoryLubJakKolidowalo2(aktywnyZamek);

            int sumaZloto = kopalniaZloto + zamekZloto;
            int sumaDrewno = kopalniaDrewno + zamekDrewno;
            int sumaRuda = kopalniaRuda + zamekRuda;

            aktywnyZamek.DodajSurowce(sumaZloto, sumaDrewno, sumaRuda);

            AktualizujNapisTury();
            OdswiezPasekNaMapie(null);

            string raport = $"NOWA TURA: {nazwaFrakcji}\n" +
                            $"========================================\n\n" +
                            $"PRZYCHOD Z TWOICH KOPALNI:\n" +
                            $"- Zloto: +{kopalniaZloto}\n" +
                            $"- Drewno: +{kopalniaDrewno}\n" +
                            $"- Ruda: +{kopalniaRuda}\n\n" +
                            $"PRZYCHOD Z TWOJEGO ZAMKU:\n" +
                            $"- Zloto: +{zamekZloto}\n" +
                            $"- Drewno: +{zamekDrewno}\n" +
                            $"- Ruda: +{zamekRuda}\n\n" +
                            $"LACZNIE DOSTARCZONO DO SKARBCA:\n" +
                            $"- Zloto: +{sumaZloto} | Drewno: +{sumaDrewno} | Ruda: +{sumaRuda}\n\n" +
                            $"Teraz przekaz myszke odpowiedniemu graczowi!";

            MessageBox.Show(raport, "Zmiana Tury - Raport Gospodarczy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int RegulatoryLubJakKolidowalo(Zamek z)
        {
            return z.Przychod.Drewno;
        }

        private int RegulatoryLubJakKolidowalo2(Zamek z)
        {
            return z.Przychod.Ruda;
        }

        private void wyciszMuzyke()
        {
            if (odtwarzaczMuzyki != null)
            {
                odtwarzaczMuzyki.controls.stop();
                odtwarzaczMuzyki.close();
            }
        }
        private void wlaczMuzyke(String sciezka)
        {
            try
            {
                odtwarzaczMuzyki = new WindowsMediaPlayer();
                odtwarzaczMuzyki.URL = sciezka;
                odtwarzaczMuzyki.settings.setMode("loop", true);
                odtwarzaczMuzyki.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("B³¹d muzyki: " + ex.Message);
            }
        }
        
        

    }
}