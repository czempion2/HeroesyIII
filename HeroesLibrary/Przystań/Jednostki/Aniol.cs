using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Aniol : Jednostka
    {
        public Aniol()
        {
            Nazwa = "Anioł"; Poziom = 7; CzyUlepszona = false;
            Koszt = new Zasoby(3000, 0, 0); 
            Atak = 20; Obrona = 20; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Aniol();
    }
}
