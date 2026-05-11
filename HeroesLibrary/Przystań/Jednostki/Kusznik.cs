using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Kusznik : Jednostka
    {
        public Kusznik()
        {
            Nazwa = "Kusznik"; Poziom = 2; CzyUlepszona = true;
            Koszt = new Zasoby(150, 0, 0);
            Atak = 6; Obrona = 3; LiczbaStrzal = 24;
        }
        public override Jednostka Klonuj() => new Kusznik();
    }
}
