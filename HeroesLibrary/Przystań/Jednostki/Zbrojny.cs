using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Zbrojny : Jednostka
    {
        public Zbrojny()
        {
            Nazwa = "Zbrojny"; 
            Poziom = 4; 
            CzyUlepszona = false;
            Koszt = new Zasoby(300, 0, 0);
            Atak = 10; Obrona = 12; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Zbrojny();
    }
}
