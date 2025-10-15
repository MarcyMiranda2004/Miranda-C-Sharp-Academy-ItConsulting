using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssBar
{
    public class ConPanna : DecoratoreBevande
    {
        public ConPanna(IBevanda bevanda) : base(bevanda) { }

        public override string Descrizione()
        {
            string descrizioneBase = base.Descrizione();
            Console.WriteLine($"Panna Aggiunto");
            return descrizioneBase + " con aggiunta di Panna";
        }

        public override double Costo()
        {
            double costoBase = base.Costo();
            return costoBase + 0.65;
        }
    }
}