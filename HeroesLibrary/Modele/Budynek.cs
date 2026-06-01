

namespace HeroesLibrary.Modele
{
    public class Budynek
    {
        public string Nazwa { get; set; }
        public Zasoby KosztBudowy { get; set; }
        public bool CzyWybudowany { get; set; }

        public string WymaganyBudynek { get; set; }

        public Jednostka RekrutowanaJednostka { get; set; }

        public Budynek(string nazwa, Zasoby kosztBudowy, string wymaganyBudynek = null, Jednostka rekrutowanaJednostka = null)
        {
            Nazwa = nazwa;
            KosztBudowy = kosztBudowy;
            WymaganyBudynek = wymaganyBudynek;
            RekrutowanaJednostka = rekrutowanaJednostka;
            CzyWybudowany = false;
        }

        public Jednostka Rekrutuj()
        {
            return RekrutowanaJednostka;
        }

        public override string ToString() => $"{Nazwa}";
    }
}
