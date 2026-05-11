using HeroesLibrary.Modele;

namespace HeroesLibrary.Przystań.Jednostki
{
    public class Kawalerzysta : Jednostka
    {
        public Kawalerzysta()
        {
            Nazwa = "Kawalerzysta"; Poziom = 6; CzyUlepszona = false;
            Koszt = new Zasoby(1000, 0, 0);
            Atak = 15; Obrona = 15; LiczbaStrzal = 0;
        }
        public override Jednostka Klonuj() => new Kawalerzysta();
    }
}
