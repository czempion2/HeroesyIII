using HeroesLibrary.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary.Przystań.Budynki
{
    public class ZamekLudzi : Zamek
    {
        public ZamekLudzi() : base()
        {
            Infrastruktura.Add(new Posterunek());
            Infrastruktura.Add(new Strażnica()); 

            Infrastruktura.Add(new WiezaLucznikow());
            Infrastruktura.Add(new BastionLucznikow());

            Infrastruktura.Add(new GniazdoGryfow());
            Infrastruktura.Add(new BastionGryfow());

            Infrastruktura.Add(new KoszaryZbrojnych());
            Infrastruktura.Add(new BastionMiecznikow());

            Infrastruktura.Add(new Klasztor());
            Infrastruktura.Add(new Swiatynia());

            Infrastruktura.Add(new Stajnie());
            Infrastruktura.Add(new SzkolkaKawalerii());

            Infrastruktura.Add(new PortalChwaly());
            Infrastruktura.Add(new Sanktuarium());
        }
    }
}
