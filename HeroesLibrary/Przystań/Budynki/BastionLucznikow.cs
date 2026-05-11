using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class BastionLucznikow : Budynek
    {
        public BastionLucznikow()
        {
            Nazwa = "Bastion Łuczników"; 
            KosztBudowy = new Zasoby(1000, 5, 0);
            CzyWybudowany = false;
            WymaganyBudynek = typeof(WiezaLucznikow);
        }
        public override Jednostka Rekrutuj() => new Kusznik();
    }
}
