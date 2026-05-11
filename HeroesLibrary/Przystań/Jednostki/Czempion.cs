using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Czempion : Jednostka
    {
        public Czempion()
        {
            Nazwa = "Czempion"; 
            Poziom = 6; 
            CzyUlepszona = true;
            Koszt = new Zasoby(1200, 0, 0);
            Atak = 16; Obrona = 16; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Czempion();
    }
}
