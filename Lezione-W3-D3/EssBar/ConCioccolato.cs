using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssBar
{
    public class ConCioccolato : DecoratoreBevande
    {
        public ConCioccolato(IBevanda bevanda) : base(bevanda) { }

        public override string Descrizione()
        {
            string descrizioneBase = base.Descrizione();
            Console.WriteLine($"Cioccolato Aggiunto");
            return descrizioneBase + " con aggiunta di Cioccolato";
        }

        public override double Costo()
        {
            double costoBase = base.Costo();
            return costoBase + 0.45;
        }
    }
}