using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class KrolewskiGryf : Jednostka
    {
        public KrolewskiGryf()
        {
            Nazwa = "Królewski Gryf"; Poziom = 3; CzyUlepszona = true;
            Koszt = new Zasoby(240, 0, 0);
            Atak = 9; Obrona = 9; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new KrolewskiGryf();
    }
}
