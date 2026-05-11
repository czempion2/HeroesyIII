using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Fanatyk : Jednostka
    {
        public Fanatyk()
        {
            Nazwa = "Fanatyk"; Poziom = 5; CzyUlepszona = true;
            Koszt = new Zasoby(450, 0, 0);
            Atak = 12; Obrona = 10; LiczbaStrzal = 24;
        }
        public override Jednostka Klonuj() => new Fanatyk();
    }
}
