using HeroesLibrary.Modele;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HeroesUI
{
    public partial class FormBitwa : Form
    {
        private Bohater graczAtakujacy;
        private Bohater graczBroniacy;

        private Button[,] polaBitwy;
        private ListBox logBitewny;
        private Label lblKolejka;

        private class OddzialNaMapie
        {
            public Jednostka Wojsko { get; set; }
            public Bohater Dowodca { get; set; }
            public bool CzyZLewej { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private List<OddzialNaMapie> inicjatywa = new List<OddzialNaMapie>();
        private int aktualnyIndeksKolejki = 0;

        private OddzialNaMapie AktywnyOddzial => inicjatywa[aktualnyIndeksKolejki];

        public FormBitwa(Bohater atakujacy, Bohater obronca)
        {
            InitializeComponent();
            this.Text = $"Bitwa! {atakujacy.Imie} vs {obronca.Imie}";
            
            this.StartPosition = FormStartPosition.CenterScreen;

            graczAtakujacy = atakujacy;
            graczBroniacy = obronca;

            ZbudujArene();
            RozstawArmie();
            RozpocznijBitwe();
        }

        private void ZbudujArene()
        {

            this.Size = new Size(1400, 770);

            polaBitwy = new Button[10, 8];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(80, 80),
                        Location = new Point(20 + (x * 80), 50 + (y * 80)),
                        Font = new Font("Arial", 7, FontStyle.Bold),
                        Name = $"{x},{y}",
                        BackColor = Color.WhiteSmoke
                    };
                    btn.Click += PoleNaPlanszy_Click;
                    this.Controls.Add(btn);
                    polaBitwy[x, y] = btn;
                }
            }

            lblKolejka = new Label
            {
                Location = new Point(20, 15),
                Size = new Size(800, 30),
                Font = new Font("Arial", 14, FontStyle.Bold),
                Text = "Przygotowania do bitwy..."
            };
            this.Controls.Add(lblKolejka);

            logBitewny = new ListBox
            {
                Size = new Size(450, this.ClientSize.Height - 100),
                Font = new Font("Consolas", 9)
            };

            int dynamiczneX = this.ClientSize.Width - logBitewny.Width - 20;
            logBitewny.Location = new Point(dynamiczneX, 50);


            logBitewny.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            this.Controls.Add(logBitewny);

        }

        private void RozstawArmie()
        {
            for (int i = 0; i < graczAtakujacy.Armia.Count; i++)
            {
                inicjatywa.Add(new OddzialNaMapie
                {
                    Wojsko = graczAtakujacy.Armia[i],
                    Dowodca = graczAtakujacy,
                    CzyZLewej = true,
                    X = 0,
                    Y = i
                });
            }

            for (int i = 0; i < graczBroniacy.Armia.Count; i++)
            {
                inicjatywa.Add(new OddzialNaMapie
                {
                    Wojsko = graczBroniacy.Armia[i],
                    Dowodca = graczBroniacy,
                    CzyZLewej = false,
                    X = 9,
                    Y = i
                });
            }
        }

        private void RozpocznijBitwe()
        {
            inicjatywa = inicjatywa.OrderByDescending(o => o.Wojsko.Szybkosc).ToList();
            aktualnyIndeksKolejki = 0;

            ZapiszWLogu($"BITWA ROZPOCZĘTA! ");
            OdswiezPlansze();
        }

        private void OdswiezPlansze()
        {
            foreach (var btn in polaBitwy)
            {
                btn.Text = "";
                btn.BackColor = Color.WhiteSmoke;
                btn.Tag = null;
            }

            foreach (var oddzial in inicjatywa)
            {
                Button pole = polaBitwy[oddzial.X, oddzial.Y];
                pole.Tag = oddzial;
                pole.Text = $"[{oddzial.Wojsko.Ilosc}x]\n{oddzial.Wojsko.Nazwa}\nHP: {oddzial.Wojsko.AktualneHP}/{oddzial.Wojsko.MaxHP}";
                pole.BackColor = oddzial.CzyZLewej ? Color.LightBlue : Color.LightCoral;
            }

            var aktywny = AktywnyOddzial;
            polaBitwy[aktywny.X, aktywny.Y].BackColor = Color.Gold;
            lblKolejka.Text = $"Tura: {aktywny.Wojsko.Nazwa} (Gracz: {aktywny.Dowodca.Imie}) | Ruch: {aktywny.Wojsko.Szybkosc}";

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (polaBitwy[x, y].Tag == null) 
                    {
                        int dystans = Math.Max(Math.Abs(x - aktywny.X), Math.Abs(y - aktywny.Y));
                        if (dystans <= aktywny.Wojsko.Szybkosc)
                        {
                            polaBitwy[x, y].BackColor = Color.LightGray; 
                        }
                    }
                }
            }
        }

        private void PoleNaPlanszy_Click(object sender, EventArgs e)
        {
            Button kliknietyGuzik = (Button)sender;
            string[] koordynaty = kliknietyGuzik.Name.Split(',');
            int celX = int.Parse(koordynaty[0]);
            int celY = int.Parse(koordynaty[1]);

            var aktywny = AktywnyOddzial;
            int odlegloscDoKlikniecia = Math.Max(Math.Abs(celX - aktywny.X), Math.Abs(celY - aktywny.Y));

            if (kliknietyGuzik.Tag == null)
            {
                if (odlegloscDoKlikniecia <= aktywny.Wojsko.Szybkosc)
                {
                    ZapiszWLogu($"{aktywny.Wojsko.Nazwa} maszeruje.");
                    aktywny.X = celX;
                    aktywny.Y = celY;
                    NastepnaTura();
                }
                else
                {
                    MessageBox.Show("Zbyt daleko! Ten oddział nie ma tyle szybkości.", "Błąd ruchu");
                }
            }
            else
            {
                OddzialNaMapie cel = (OddzialNaMapie)kliknietyGuzik.Tag;

                if (cel.CzyZLewej == aktywny.CzyZLewej)
                {
                    MessageBox.Show("To Twój sojusznik, mój Panie! Wybierz inny cel.", "Rozkaz odwołany");
                    return;
                }

                if (aktywny.Wojsko.LiczbaStrzal > 0)
                {
                    WykonajAtak(aktywny, cel);
                    aktywny.Wojsko.LiczbaStrzal--; 
                    NastepnaTura();
                    return;
                }

                if (odlegloscDoKlikniecia == 1) 
                {
                    WykonajAtak(aktywny, cel);
                    NastepnaTura();
                }
                else 
                {
                    Point? docelowePole = null;
                    int najkrotszyWymaganyRuch = int.MaxValue;

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue; 

                            int sprawdzanyX = cel.X + dx;
                            int sprawdzanyY = cel.Y + dy;

                            if (sprawdzanyX >= 0 && sprawdzanyX < 10 && sprawdzanyY >= 0 && sprawdzanyY < 8)
                            {
                                if (polaBitwy[sprawdzanyX, sprawdzanyY].Tag == null)
                                {
                                    int dystansDoCelu = Math.Max(Math.Abs(sprawdzanyX - aktywny.X), Math.Abs(sprawdzanyY - aktywny.Y));

                                    if (dystansDoCelu <= aktywny.Wojsko.Szybkosc)
                                    {
                                        if (dystansDoCelu < najkrotszyWymaganyRuch)
                                        {
                                            najkrotszyWymaganyRuch = dystansDoCelu;
                                            docelowePole = new Point(sprawdzanyX, sprawdzanyY);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (docelowePole.HasValue)
                    {
                        ZapiszWLogu($"{aktywny.Wojsko.Nazwa} podbiega i szarżuje na wroga!");
                        aktywny.X = docelowePole.Value.X;
                        aktywny.Y = docelowePole.Value.Y;

                        WykonajAtak(aktywny, cel); 
                        NastepnaTura();
                    }
                    else
                    {
                        MessageBox.Show("Wróg jest za daleko lub nie ma wolnego miejsca dookoła niego na atak!", "Brak zasięgu");
                    }
                }
            }
        }

        private void WykonajAtak(OddzialNaMapie atakujacy, OddzialNaMapie obronca)
        {
            int atak = atakujacy.Wojsko.Atak + atakujacy.Dowodca.Atak;
            int obrona = obronca.Wojsko.Obrona + obronca.Dowodca.Obrona;

            Random rnd = new Random();
            int dmgBaza = rnd.Next(atakujacy.Wojsko.MinObrazenia, atakujacy.Wojsko.MaxObrazenia + 1);
            int dmgTotal = dmgBaza * atakujacy.Wojsko.Ilosc;

            double mnoznik = 1.0;
            if (atak > obrona) mnoznik += 0.05 * (atak - obrona);
            else if (obrona > atak) mnoznik -= 0.025 * (obrona - atak);

            if (mnoznik > 4.0) mnoznik = 4.0;
            if (mnoznik < 0.3) mnoznik = 0.3;

            int ostateczneObrazenia = (int)(dmgTotal * mnoznik);
            int stareIloscObroncy = obronca.Wojsko.Ilosc;

            obronca.Wojsko.OtrzymajObrazenia(ostateczneObrazenia);
            int zabici = stareIloscObroncy - obronca.Wojsko.Ilosc;

            ZapiszWLogu($"{atakujacy.Wojsko.Nazwa} uderza: {ostateczneObrazenia} obr. Ginie: {zabici}x {obronca.Wojsko.Nazwa}.");

            if (obronca.Wojsko.Ilosc <= 0)
            {
                ZapiszWLogu($"☠️ {obronca.Wojsko.Nazwa} rozbity!");
                obronca.Dowodca.Armia.Remove(obronca.Wojsko);
                inicjatywa.Remove(obronca);

                SprawdzWarunekZwyciestwa();
            }
        }

        private void NastepnaTura()
        {
            if (inicjatywa.Count <= 1) return;

            aktualnyIndeksKolejki++;
            if (aktualnyIndeksKolejki >= inicjatywa.Count)
            {
                aktualnyIndeksKolejki = 0;
                ZapiszWLogu("--- NOWA RUNDA ---");
            }

            OdswiezPlansze();
        }

        private void SprawdzWarunekZwyciestwa()
        {
            bool zyjaLewi = inicjatywa.Any(o => o.CzyZLewej);
            bool zyjaPrawi = inicjatywa.Any(o => !o.CzyZLewej);

            if (!zyjaPrawi)
            {
                MessageBox.Show($"CHWAŁA ZWYCIĘZCOM!\n{graczAtakujacy.Imie} wygrywa!", "Koniec Bitwy");
                this.Close();
            }
            else if (!zyjaLewi)
            {
                MessageBox.Show($"TRAGICZNA PORAŻKA...\nZwycięża {graczBroniacy.Imie}.", "Koniec Bitwy");
                this.Close();
            }
        }

        private void ZapiszWLogu(string wiadomosc)
        {
            logBitewny.Items.Add(wiadomosc);
            logBitewny.TopIndex = logBitewny.Items.Count - 1;
        }
    }
}