using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Krzyzowiec : Jednostka
    {
        public Krzyzowiec()
        {
            Nazwa = "Krzyżowiec"; Poziom = 4; CzyUlepszona = true;
            Koszt = new Zasoby(400, 0, 0);
            Atak = 12; Obrona = 12; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Krzyzowiec();
    }
}
