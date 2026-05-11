using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Archaniol : Jednostka
    {
        public Archaniol()
        {
            Nazwa = "Archanioł"; Poziom = 7; CzyUlepszona = true;
            Koszt = new Zasoby(5000, 0, 0);
            Atak = 30; Obrona = 30; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Archaniol();
    }
}
