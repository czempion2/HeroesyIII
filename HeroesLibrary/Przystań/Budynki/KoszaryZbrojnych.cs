using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;


namespace HeroesLibrary.Przystań.Budynki
{
    public class KoszaryZbrojnych : Budynek
    {
        public KoszaryZbrojnych()
        {
            Nazwa = "Koszary"; 
            KosztBudowy = new Zasoby(2000, 0, 5); 
            CzyWybudowany = false;
        }
        public override Jednostka Rekrutuj() => new Zbrojny();
    }
}
