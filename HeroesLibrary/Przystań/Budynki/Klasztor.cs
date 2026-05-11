using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;


namespace HeroesLibrary.Przystań.Budynki
{
    public class Klasztor : Budynek
    {
        public Klasztor()
        {
            Nazwa = "Klasztor"; 
            KosztBudowy = new Zasoby(3000, 5, 5); 
            CzyWybudowany = false;
        }
        public override Jednostka Rekrutuj() => new Mnich();
    }
}
