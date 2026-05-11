using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class Swiatynia : Budynek
    {
        public Swiatynia()
        {
            Nazwa = "Świątynia"; 
            KosztBudowy = new Zasoby(3000, 5, 5); 
            CzyWybudowany = false;
            WymaganyBudynek = typeof(Klasztor);
        }
        public override Jednostka Rekrutuj() => new Fanatyk();
    }
}
