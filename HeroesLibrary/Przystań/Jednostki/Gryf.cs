using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Gryf : Jednostka
    {
        public Gryf()
        {
            Nazwa = "Gryf"; Poziom = 3; CzyUlepszona = false;
            Koszt = new Zasoby(200, 0, 0);
            Atak = 8; Obrona = 8; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Gryf();
    }
}
