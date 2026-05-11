using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Lucznik : Jednostka
    {
        public Lucznik()
        {
            Nazwa = "Łucznik";
            Poziom = 2;
            CzyUlepszona = false;
            Koszt = new Zasoby(100, 0, 0);
            Atak = 6;
            Obrona = 3;
            LiczbaStrzal = 12;
        }
        public override Jednostka Klonuj() => new Lucznik();
    }
}
