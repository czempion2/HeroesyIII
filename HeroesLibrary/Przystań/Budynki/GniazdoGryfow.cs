using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;


namespace HeroesLibrary.Przystań.Budynki
{
    public class GniazdoGryfow : Budynek
    {
        public GniazdoGryfow()
        {
            Nazwa = "Gniazdo Gryfów"; 
            KosztBudowy = new Zasoby(1000, 0, 0); 
            CzyWybudowany = false;
        }
        public override Jednostka Rekrutuj() => new Gryf();
    }
}
