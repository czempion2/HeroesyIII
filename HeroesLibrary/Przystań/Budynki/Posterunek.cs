using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class Posterunek : Budynek
    {
        public Posterunek()
        {
            Nazwa = "Posterunek";
            KosztBudowy = new Zasoby(500, 5, 5);
            CzyWybudowany = false;
        }

        public override Jednostka Rekrutuj() => new Pikinier();
    }
}
