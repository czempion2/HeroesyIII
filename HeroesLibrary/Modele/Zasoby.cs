using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Modele
{
    public class Zasoby
    {
        public int Zloto { get; set; }
        public int Drewno { get; set; }
        public int Ruda { get; set; }

        public Zasoby(int zloto, int drewno, int ruda)
        {
            Zloto = zloto;
            Drewno = drewno;
            Ruda = ruda;
        }
    }
}
