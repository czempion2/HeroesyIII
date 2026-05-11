using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Modele
{
    public class StanGry
    {
        public Zasoby Skarbiec { get; set; }
        public List<bool> StanBudynkow { get; set; }
        public int BohaterExp { get; set; }
        public int BohaterLevel { get; set; }
        public List<string> TypyJednostekWArmii { get; set; }
        public int Dzien { get; set; }
        public int Tydzien { get; set; }
        public int Miesiac { get; set; }
    }
}
