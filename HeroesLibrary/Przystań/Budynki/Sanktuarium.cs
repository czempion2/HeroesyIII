using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;
using System;
namespace HeroesLibrary.Przystań.Budynki
{
    public class Sanktuarium : Budynek
    {
        public Sanktuarium()
        {
            Nazwa = "Sanktuarium";
            KosztBudowy = new Zasoby(20000, 10, 10);
            CzyWybudowany = false;
            WymaganyBudynek = typeof(PortalChwaly);
        }
        public override Jednostka Rekrutuj() => new Archaniol();
    }
}
