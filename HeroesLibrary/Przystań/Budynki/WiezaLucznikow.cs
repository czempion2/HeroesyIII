using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;


namespace HeroesLibrary.Przystań.Budynki
{
    public class WiezaLucznikow : Budynek
    {
        public WiezaLucznikow()
        {
            Nazwa = "Wieża Łuczników";
            KosztBudowy = new Zasoby(1000, 10, 0); 
            CzyWybudowany = false;
        }

        public override Jednostka Rekrutuj() => new Lucznik();
    }
}
