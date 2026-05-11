
using HeroesLibrary.Wyjatki;


namespace HeroesLibrary.Modele
{
    public abstract class Zamek
    {
        public Zasoby Skarbiec { get; protected set; }
        public List<Budynek> Infrastruktura { get; protected set; }

        public event Action<Zasoby> SurowceZmienione;

        public Zamek()
        {
            Skarbiec = new Zasoby(5000, 20, 20);
            Infrastruktura = new List<Budynek>();
        }

        public void DodajSurowce(int zloto, int drewno, int ruda)
        {
            Skarbiec.Zloto += zloto;
            Skarbiec.Drewno += drewno;
            Skarbiec.Ruda += ruda;
            SurowceZmienione?.Invoke(Skarbiec);
        }
        public void KupJednostke(Jednostka jednostkaDoKupienia, Bohater kupujacy)
        {
            if (Skarbiec.Zloto < jednostkaDoKupienia.Koszt.Zloto || Skarbiec.Drewno < jednostkaDoKupienia.Koszt.Drewno || Skarbiec.Ruda < jednostkaDoKupienia.Koszt.Ruda)
            {
                throw new BrakSurowcowException("Brakuje surowców na rekrutację jednostki!");
            }

            kupujacy.DodajDoArmii(jednostkaDoKupienia.Klonuj()); 

            Skarbiec.Zloto -= jednostkaDoKupienia.Koszt.Zloto;
            Skarbiec.Drewno -= jednostkaDoKupienia.Koszt.Drewno;
            Skarbiec.Ruda -= jednostkaDoKupienia.Koszt.Ruda;

            SurowceZmienione?.Invoke(Skarbiec);
        }
        public void Wybuduj(Budynek budynek)
        {
            if (budynek.CzyWybudowany)
                throw new InvalidOperationException("Ten budynek jest już wybudowany!");

            if (budynek.WymaganyBudynek != null)
            {
                var wymagany = Infrastruktura.FirstOrDefault(b => b.GetType() == budynek.WymaganyBudynek);
                if (wymagany == null || !wymagany.CzyWybudowany)
                {
                    throw new InvalidOperationException($"Zanim to zbudujesz, musisz wybudować: {wymagany?.Nazwa ?? budynek.WymaganyBudynek.Name}!");
                }
            }

            if (Skarbiec.Zloto < budynek.KosztBudowy.Zloto || Skarbiec.Drewno < budynek.KosztBudowy.Drewno || Skarbiec.Ruda < budynek.KosztBudowy.Ruda)
                throw new BrakSurowcowException($"Brakuje surowców na wybudowanie: {budynek.Nazwa}!");

            Skarbiec.Zloto -= budynek.KosztBudowy.Zloto;
            Skarbiec.Drewno -= budynek.KosztBudowy.Drewno;
            Skarbiec.Ruda -= budynek.KosztBudowy.Ruda;

            budynek.CzyWybudowany = true;
            SurowceZmienione?.Invoke(Skarbiec);
        }

        public IEnumerable<Jednostka> PobierzDostepneDoKupienia()
        {
            return Infrastruktura
                .Where(b => b.CzyWybudowany)
                .Select(b => b.Rekrutuj())
                .OrderBy(j => j.Poziom)
                .ThenBy(j => j.Koszt.Zloto);
        }
    }
}
