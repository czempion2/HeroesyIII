

namespace HeroesLibrary.Modele
{
    public abstract class Budynek
    {
        public string Nazwa { get; protected set; }
        public Zasoby KosztBudowy { get; protected set; }
        public bool CzyWybudowany { get; set; }
        public Type WymaganyBudynek { get; protected set; }

        public abstract Jednostka Rekrutuj();
        public override string ToString() => $"{Nazwa}";
    }
}
