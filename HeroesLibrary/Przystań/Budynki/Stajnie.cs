using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class Stajnie : Budynek
    {
        public Stajnie()
        {
            Nazwa = "Stajnie"; 
            KosztBudowy = new Zasoby(4000, 20, 0); 
            CzyWybudowany = false;
        }
        public override Jednostka Rekrutuj() => new Kawalerzysta();
    }
}
