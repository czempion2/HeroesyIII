using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Modele
{
    public class Jednostka
    {
        public string Nazwa { get; set; }
        public int Poziom { get; set; }
        public Zasoby Koszt { get; set; }
        public bool CzyUlepszona { get; set; }


        public int Atak { get; set; }
        public int Obrona { get; set; }
        public int LiczbaStrzal { get; set; }
        public string SciezkaDoObrazka { get; set; }


        public int Ilosc { get; set; }     
        public int MaxHP { get; set; }       
        public int AktualneHP { get; set; }   
        public int MinObrazenia { get; set; }  
        public int MaxObrazenia { get; set; }  
        public int Szybkosc { get; set; }     

        public Jednostka(string nazwa, int poziom, Zasoby koszt, bool czyUlepszona, int atak, int obrona,
                         int liczbaStrzal = 0, string sciezkaDoObrazka = "",
                         int maxHP = 10, int minObrazenia = 1, int maxObrazenia = 2, int szybkosc = 5)
        {
            Nazwa = nazwa;
            Poziom = poziom;
            Koszt = koszt;
            CzyUlepszona = czyUlepszona;
            Atak = atak;
            Obrona = obrona;
            LiczbaStrzal = liczbaStrzal;
            SciezkaDoObrazka = sciezkaDoObrazka;

            Ilosc = 1; 
            MaxHP = maxHP;
            AktualneHP = maxHP; 
            MinObrazenia = minObrazenia;
            MaxObrazenia = maxObrazenia;
            Szybkosc = szybkosc;
        }

        public Jednostka Klonuj()
        {
            var klon = new Jednostka(Nazwa, Poziom, new Zasoby(Koszt.Zloto, Koszt.Drewno, Koszt.Ruda),
                                     CzyUlepszona, Atak, Obrona, LiczbaStrzal, SciezkaDoObrazka,
                                     MaxHP, MinObrazenia, MaxObrazenia, Szybkosc);
            klon.Ilosc = this.Ilosc;
            klon.AktualneHP = this.AktualneHP;
            return klon;
        }

        public void OtrzymajObrazenia(int obrazenia)
        {
            if (obrazenia <= 0) return;

            AktualneHP -= obrazenia;

            while (AktualneHP <= 0 && Ilosc > 0)
            {
                Ilosc--; 

                if (Ilosc > 0)
                {
                    AktualneHP += MaxHP;
                }
                else
                {
                    AktualneHP = 0;
                }
            }
        }

        public override string ToString()
        {
            string info = $"[{Ilosc}x] {Nazwa} (Atk: {Atak}, Obr: {Obrona}, HP: {MaxHP})";
            if (LiczbaStrzal > 0) info += $" [Strzały: {LiczbaStrzal}]";
            return info;
        }
    }
}
