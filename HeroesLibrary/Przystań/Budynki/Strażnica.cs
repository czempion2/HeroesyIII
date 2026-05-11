using HeroesLibrary.Modele;
using System;
using System.Collections.Generic;

using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class Strażnica : Budynek
    {
        public Strażnica()
        {
            Nazwa = "Strażnica";
            KosztBudowy = new Zasoby(1000, 5, 5);
            CzyWybudowany = false;
            WymaganyBudynek = typeof(Posterunek); 
        }

        public override Jednostka Rekrutuj() => new Halabardnik();
    }
}
