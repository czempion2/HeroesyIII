using System.Text.Json;
using HeroesLibrary.Modele;

namespace HeroesLibrary
{
    public static class ManagerZapisu
    {
        private static string sciezka = "savegame.json";

        public static void Zapisz(Zamek zamek, Bohater bohater, int d, int t, int m)
        {
            var stan = new StanGry
            {
                Skarbiec = zamek.Skarbiec,
                StanBudynkow = zamek.Infrastruktura.Select(b => b.CzyWybudowany).ToList(),
                BohaterExp = bohater.Doswiadczenie,
                BohaterLevel = bohater.PoziomBohatera,
                Dzien = d,
                Tydzien = t,
                Miesiac = m,
                TypyJednostekWArmii = bohater.Armia.Select(j => j.GetType().AssemblyQualifiedName).ToList()
            };

            string jsonString = JsonSerializer.Serialize(stan);
            File.WriteAllText(sciezka, jsonString);
        }

        public static StanGry Wczytaj()
        {
            if (!File.Exists(sciezka)) return null;

            string jsonString = File.ReadAllText(sciezka);
            return JsonSerializer.Deserialize<StanGry>(jsonString);
        }
    }
}
