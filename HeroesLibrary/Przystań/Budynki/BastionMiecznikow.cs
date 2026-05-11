using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class BastionMiecznikow : Budynek
    {
        public BastionMiecznikow()
        {
            Nazwa = "Bastion Mieczników"; 
            KosztBudowy = new Zasoby(2000, 5, 5); 
            CzyWybudowany = false;
            WymaganyBudynek = typeof(KoszaryZbrojnych);
        }
        public override Jednostka Rekrutuj() => new Krzyzowiec();
    }
}
