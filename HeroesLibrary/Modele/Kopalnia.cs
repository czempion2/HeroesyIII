using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Modele
{
    public enum TypSurowca
    {
        Zloto,
        Drewno,
        Ruda
    }

    public class Kopalnia
    {
        public string Nazwa { get; set; }
        public TypSurowca Typ { get; set; }
        public int Produkcja { get; set; }
        public bool CzyZajeta { get; set; }
        public Bohater Straznik { get; set; }

        public Kopalnia(string nazwa, TypSurowca typ, int produkcja)
        {
            Nazwa = nazwa;
            Typ = typ;
            Produkcja = produkcja;
            CzyZajeta = false;
        }

        public override string ToString()
        {
            return $"{Nazwa} (+{Produkcja}/tura)";
        }
    }
}
