using HeroesLibrary.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Przystań
{
    public class ZamekLudzi : Zamek
    {
        public ZamekLudzi() : base()
        {
        }

        protected override void InicjalizujInfrastrukture()
        {
            var pikinier = new Jednostka("Pikinier", 1, new Zasoby(60, 0, 0), false, 4, 5, maxHP: 10, minObrazenia: 1, maxObrazenia: 3, szybkosc: 4);
            var halabardnik = new Jednostka("Halabardnik", 1, new Zasoby(75, 0, 0), true, 6, 5, maxHP: 10, minObrazenia: 2, maxObrazenia: 3, szybkosc: 5);

            var lucznik = new Jednostka("Łucznik", 2, new Zasoby(100, 0, 0), false, 6, 3, liczbaStrzal: 12, maxHP: 10, minObrazenia: 2, maxObrazenia: 3, szybkosc: 4);
            var kusznik = new Jednostka("Kusznik", 2, new Zasoby(150, 0, 0), true, 6, 3, liczbaStrzal: 24, maxHP: 10, minObrazenia: 2, maxObrazenia: 3, szybkosc: 6);

            var gryf = new Jednostka("Gryf", 3, new Zasoby(200, 0, 0), false, 8, 8, maxHP: 25, minObrazenia: 3, maxObrazenia: 6, szybkosc: 6);
            var krolewskiGryf = new Jednostka("Królewski Gryf", 3, new Zasoby(240, 0, 0), true, 9, 9, maxHP: 25, minObrazenia: 3, maxObrazenia: 6, szybkosc: 9);

            var zbrojny = new Jednostka("Zbrojny", 4, new Zasoby(250, 0, 0), false, 10, 12, maxHP: 35, minObrazenia: 6, maxObrazenia: 9, szybkosc: 5);
            var krzyzowiec = new Jednostka("Krzyżowiec", 4, new Zasoby(400, 0, 0), true, 12, 12, maxHP: 35, minObrazenia: 7, maxObrazenia: 10, szybkosc: 6);

            var mnich = new Jednostka("Mnich", 5, new Zasoby(400, 0, 0), false, 12, 7, liczbaStrzal: 12, maxHP: 30, minObrazenia: 10, maxObrazenia: 12, szybkosc: 5);
            var fanatyk = new Jednostka("Fanatyk", 5, new Zasoby(450, 0, 0), true, 12, 7, liczbaStrzal: 24, maxHP: 30, minObrazenia: 10, maxObrazenia: 12, szybkosc: 7);

            var kawalerzysta = new Jednostka("Kawalerzysta", 6, new Zasoby(1000, 0, 0), false, 15, 15, maxHP: 100, minObrazenia: 15, maxObrazenia: 25, szybkosc: 7);
            var czempion = new Jednostka("Czempion", 6, new Zasoby(1200, 0, 0), true, 16, 16, maxHP: 100, minObrazenia: 20, maxObrazenia: 25, szybkosc: 9);

            var aniol = new Jednostka("Anioł", 7, new Zasoby(3000, 0, 0), false, 20, 20, maxHP: 200, minObrazenia: 50, maxObrazenia: 50, szybkosc: 12);
            var archaniol = new Jednostka("Archanioł", 7, new Zasoby(5000, 0, 0), true, 30, 30, maxHP: 250, minObrazenia: 50, maxObrazenia: 50, szybkosc: 18);


            Infrastruktura.Add(new Budynek(
                nazwa: "Posterunek",
                kosztBudowy: new Zasoby(500, 5, 0),
                wymaganyBudynek: null,
                rekrutowanaJednostka: pikinier));

            Infrastruktura.Add(new Budynek(
                nazwa: "Strażnica",
                kosztBudowy: new Zasoby(1000, 5, 5),
                wymaganyBudynek: "Posterunek",
                rekrutowanaJednostka: halabardnik));

            Infrastruktura.Add(new Budynek(
                nazwa: "Wieża Łuczników",
                kosztBudowy: new Zasoby(1000, 5, 0),
                wymaganyBudynek: null,
                rekrutowanaJednostka: lucznik));

            Infrastruktura.Add(new Budynek(
                nazwa: "Bastion Łuczników",
                kosztBudowy: new Zasoby(1000, 5, 0),
                wymaganyBudynek: "Wieża Łuczników",
                rekrutowanaJednostka: kusznik));

            Infrastruktura.Add(new Budynek(
                nazwa: "Gniazdo Gryfów",
                kosztBudowy: new Zasoby(1000, 0, 0),
                wymaganyBudynek: null,
                rekrutowanaJednostka: gryf));

            Infrastruktura.Add(new Budynek(
                nazwa: "Bastion Gryfów",
                kosztBudowy: new Zasoby(1000, 0, 5),
                wymaganyBudynek: "Gniazdo Gryfów",
                rekrutowanaJednostka: krolewskiGryf));

            Infrastruktura.Add(new Budynek(
                nazwa: "Koszary Zbrojnych",
                kosztBudowy: new Zasoby(1500, 5, 5),
                wymaganyBudynek: null,
                rekrutowanaJednostka: zbrojny));

            Infrastruktura.Add(new Budynek(
                nazwa: "Bastion Mieczników",
                kosztBudowy: new Zasoby(2000, 5, 5),
                wymaganyBudynek: "Koszary Zbrojnych",
                rekrutowanaJednostka: krzyzowiec));

            Infrastruktura.Add(new Budynek(
                nazwa: "Klasztor",
                kosztBudowy: new Zasoby(3000, 10, 10),
                wymaganyBudynek: null,
                rekrutowanaJednostka: mnich));

            Infrastruktura.Add(new Budynek(
                nazwa: "Świątynia",
                kosztBudowy: new Zasoby(3000, 10, 10),
                wymaganyBudynek: "Klasztor",
                rekrutowanaJednostka: fanatyk));

            Infrastruktura.Add(new Budynek(
                nazwa: "Stajnie",
                kosztBudowy: new Zasoby(4000, 20, 0),
                wymaganyBudynek: null,
                rekrutowanaJednostka: kawalerzysta));

            Infrastruktura.Add(new Budynek(
                nazwa: "Szkółka Kawalerii",
                kosztBudowy: new Zasoby(5000, 20, 0),
                wymaganyBudynek: "Stajnie",
                rekrutowanaJednostka: czempion));

            Infrastruktura.Add(new Budynek(
                nazwa: "Portal Chwały",
                kosztBudowy: new Zasoby(10000, 10, 10),
                wymaganyBudynek: null,
                rekrutowanaJednostka: aniol));

            Infrastruktura.Add(new Budynek(
                nazwa: "Sanktuarium",
                kosztBudowy: new Zasoby(20000, 20, 20),
                wymaganyBudynek: "Portal Chwały",
                rekrutowanaJednostka: archaniol));
        }
    }
}
