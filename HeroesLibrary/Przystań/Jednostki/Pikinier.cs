using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Pikinier : Jednostka
    {
        public Pikinier()
        {
            Nazwa = "Pikinier";
            Poziom = 1;
            CzyUlepszona = false;
            Koszt = new Zasoby(60, 0, 0);
            Atak = 4;
            Obrona = 5;
            LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Pikinier();
    }
}
