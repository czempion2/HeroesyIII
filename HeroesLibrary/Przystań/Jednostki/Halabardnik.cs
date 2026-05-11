using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Halabardnik : Jednostka
    {
        public Halabardnik()
        {
            Nazwa = "Halabardnik";
            Poziom = 1;
            CzyUlepszona = true;
            Koszt = new Zasoby(80, 0, 0);
            Atak = 5;
            Obrona = 5;
            LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Halabardnik();
    }
}
