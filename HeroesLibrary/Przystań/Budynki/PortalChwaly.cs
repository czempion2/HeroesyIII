using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;

namespace HeroesLibrary.Przystań.Budynki
{
    public class PortalChwaly : Budynek
    {
        public PortalChwaly()
        {
            Nazwa = "Portal Chwały"; 
            KosztBudowy = new Zasoby(10000, 10, 10); 
            CzyWybudowany = false;
        }
        public override Jednostka Rekrutuj() => new Aniol();
    }
}
