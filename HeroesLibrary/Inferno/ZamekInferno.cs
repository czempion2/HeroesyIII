using System;
using HeroesLibrary.Modele;

namespace HeroesLibrary.Inferno
{
    public class ZamekInferno : Zamek
    {
        public ZamekInferno() : base()
        {
            Przychod = new Zasoby(1000, 2, 2);
        }

        protected override void InicjalizujInfrastrukture()
        {

            var chochlik = new Jednostka("Chochlik", 1, new Zasoby(50, 0, 0), false, 2, 3, maxHP: 4, minObrazenia: 1, maxObrazenia: 2, szybkosc: 5);
            var chowaniec = new Jednostka("Chowaniec", 1, new Zasoby(70, 0, 0), true, 4, 4, maxHP: 4, minObrazenia: 1, maxObrazenia: 2, szybkosc: 7);

            var gog = new Jednostka("Gog", 2, new Zasoby(125, 0, 0), false, 6, 4, liczbaStrzal: 12, maxHP: 13, minObrazenia: 2, maxObrazenia: 4, szybkosc: 4);
            var magog = new Jednostka("Magog", 2, new Zasoby(175, 0, 0), true, 7, 4, liczbaStrzal: 24, maxHP: 13, minObrazenia: 2, maxObrazenia: 4, szybkosc: 6);

            var piekielnyOgar = new Jednostka("Piekielny ogar", 3, new Zasoby(200, 0, 0), false, 10, 6, maxHP: 25, minObrazenia: 2, maxObrazenia: 7, szybkosc: 7);
            var cerber = new Jednostka("Cerber", 3, new Zasoby(250, 0, 0), true, 10, 8, maxHP: 25, minObrazenia: 2, maxObrazenia: 7, szybkosc: 8);

            var demon = new Jednostka("Demon", 4, new Zasoby(250, 0, 0), false, 10, 10, maxHP: 35, minObrazenia: 7, maxObrazenia: 9, szybkosc: 5);
            var rogatyDemon = new Jednostka("Rogaty demon", 4, new Zasoby(270, 0, 0), true, 11, 11, maxHP: 40, minObrazenia: 7, maxObrazenia: 9, szybkosc: 6);

            var czart = new Jednostka("Czart", 5, new Zasoby(500, 0, 0), false, 13, 13, maxHP: 45, minObrazenia: 13, maxObrazenia: 17, szybkosc: 6);
            var czarciLord = new Jednostka("Czarci lord", 5, new Zasoby(700, 0, 0), true, 15, 15, maxHP: 45, minObrazenia: 13, maxObrazenia: 17, szybkosc: 7);

            var ifryt = new Jednostka("Ifryt", 6, new Zasoby(900, 0, 0), false, 16, 14, maxHP: 90, minObrazenia: 16, maxObrazenia: 24, szybkosc: 9);
            var sultanskiIfryt = new Jednostka("Sułtański ifryt", 6, new Zasoby(1100, 0, 0), true, 16, 14, maxHP: 90, minObrazenia: 16, maxObrazenia: 24, szybkosc: 13);

            var diabel = new Jednostka("Diabeł", 7, new Zasoby(2700, 0, 0), false, 19, 21, maxHP: 160, minObrazenia: 30, maxObrazenia: 40, szybkosc: 11);
            var arcydiabel = new Jednostka("Arcydiabeł", 7, new Zasoby(4000, 0, 0), true, 26, 28, maxHP: 200, minObrazenia: 30, maxObrazenia: 40, szybkosc: 17);

            Infrastruktura.Add(new Budynek("Urodzisko", new Zasoby(500, 5, 0), null, chochlik));
            Infrastruktura.Add(new Budynek("Ulepszone Urodzisko", new Zasoby(1000, 5, 5), "Urodzisko", chowaniec));

            Infrastruktura.Add(new Budynek("Sale grzechu", new Zasoby(1000, 5, 0), null, gog));
            Infrastruktura.Add(new Budynek("Ulepszone Sale grzechu", new Zasoby(1000, 5, 0), "Sale grzechu", magog));

            Infrastruktura.Add(new Budynek("Psiarnia", new Zasoby(1000, 0, 5), null, piekielnyOgar));
            Infrastruktura.Add(new Budynek("Ulepszona Psiarnia", new Zasoby(1000, 0, 5), "Psiarnia", cerber));

            Infrastruktura.Add(new Budynek("Wrota demonów", new Zasoby(1500, 5, 5), null, demon));
            Infrastruktura.Add(new Budynek("Ulepszone Wrota demonów", new Zasoby(2000, 5, 5), "Wrota demonów", rogatyDemon));

            Infrastruktura.Add(new Budynek("Przedsionek piekieł", new Zasoby(3000, 10, 10), null, czart));
            Infrastruktura.Add(new Budynek("Ulepszony Przedsionek piekieł", new Zasoby(3000, 10, 10), "Przedsionek piekieł", czarciLord));

            Infrastruktura.Add(new Budynek("Jezioro ognia", new Zasoby(4000, 20, 0), null, ifryt));
            Infrastruktura.Add(new Budynek("Ulepszone Jezioro ognia", new Zasoby(5000, 20, 0), "Jezioro ognia", sultanskiIfryt));

            Infrastruktura.Add(new Budynek("Przeklęty pałac", new Zasoby(10000, 15, 15), null, diabel));
            Infrastruktura.Add(new Budynek("Ulepszony Przeklęty pałac", new Zasoby(20000, 20, 20), "Przeklęty pałac", arcydiabel));
        }
    }
}