using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Modele
{
    public abstract class Jednostka
    {
        public string Nazwa { get; protected set; }
        public int Poziom { get; protected set; }
        public Zasoby Koszt { get; protected set; }
        public bool CzyUlepszona { get; protected set; }
        public int Atak { get; protected set; }
        public int Obrona { get; protected set; }
        public int LiczbaStrzal { get; protected set; } 
        public string SciezkaDoObrazka { get; protected set; }

        public abstract Jednostka Klonuj();

        public override string ToString()
        {
            string info = $"{Nazwa} (Atk: {Atak}, Obr: {Obrona})";
            if (LiczbaStrzal > 0) info += $" [Strzały: {LiczbaStrzal}]";
            return info;
        }
    }
}
