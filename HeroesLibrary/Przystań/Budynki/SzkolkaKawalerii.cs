using HeroesLibrary.Modele;
using HeroesLibrary.Przystań.Jednostki;


namespace HeroesLibrary.Przystań.Budynki
{
    public class SzkolkaKawalerii : Budynek
    {
        public SzkolkaKawalerii()
        {
            Nazwa = "Szkółka Kawalerii"; 
            KosztBudowy = new Zasoby(4000, 10, 0); 
            CzyWybudowany = false;
            WymaganyBudynek = typeof(Stajnie);
        }
        public override Jednostka Rekrutuj() => new Czempion();
    }
}
