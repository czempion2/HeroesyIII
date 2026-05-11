using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Mnich : Jednostka
    {
        public Mnich()
        {
            Nazwa = "Mnich"; Poziom = 5; CzyUlepszona = false;
            Koszt = new Zasoby(400, 0, 0);
            Atak = 10; Obrona = 9; LiczbaStrzal = 12;
        }
        public override Jednostka Klonuj() => new Mnich();
    }
}
