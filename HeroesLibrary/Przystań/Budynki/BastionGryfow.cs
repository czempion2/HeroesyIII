using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class BastionGryfow : Budynek
    {
        public BastionGryfow()
        {
            Nazwa = "Bastion Gryfów"; 
            KosztBudowy = new Zasoby(1000, 0, 0); 
            CzyWybudowany = false;
            WymaganyBudynek = typeof(GniazdoGryfow);
        }
        public override Jednostka Rekrutuj() => new KrolewskiGryf();
    }
}
