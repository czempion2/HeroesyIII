using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesLibrary.Wyjatki;

namespace HeroesLibrary.Modele
{
    public class Bohater
    {
        public string Imie { get; set; }
        public int Atak { get; set; }
        public int Obrona { get; set; }
        public int Moc { get; set; }
        public int Wiedza { get; set; }
        public List<Jednostka> Armia { get; private set; }
        public int Doswiadczenie { get; private set; }
        public int MaxDoswiadczenie { get; private set; }
        public int PoziomBohatera { get; private set; }

        public Bohater(string imie, int atak, int obrona, int moc, int wiedza)
        {
            Imie = imie;
            Atak = atak;
            Obrona = obrona;
            Moc = moc;
            Wiedza = wiedza;
            Armia = new List<Jednostka>();

            Doswiadczenie = 0;
            MaxDoswiadczenie = 1000;
            PoziomBohatera = 1;
        }

        public void DodajDoArmii(Jednostka jednostka)
        {
            if (Armia.Count >= 7)
                throw new PelnaArmiaException($"{Imie} nie ma już miejsca w armii!");
            Armia.Add(jednostka);
        }

        public void DodajDoswiadczenie(int exp)
        {
            Doswiadczenie += exp;
            while (Doswiadczenie >= MaxDoswiadczenie)
            {
                PoziomBohatera++;
                Doswiadczenie -= MaxDoswiadczenie;
                MaxDoswiadczenie = (int)(MaxDoswiadczenie * 1.5);
                Atak += 2;
                Obrona += 1;
                Moc += 1;
                Wiedza += 1;
            }
        }

        public void UsunZArmii(int indeks)
        {
            if (indeks >= 0 && indeks < Armia.Count)
            {
                Armia.RemoveAt(indeks);
            }
        }
    }
}
