using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssBar
{
    public class ConLatte : DecoratoreBevande
    {
        public ConLatte(IBevanda bevanda) : base(bevanda) { }

        public override string Descrizione()
        {
            string descrizioneBase = base.Descrizione();
            Console.WriteLine($"Latte Aggiunto");
            return descrizioneBase + " con aggiunta di latte";
        }

        public override double Costo()
        {
            double costoBase = base.Costo();
            return costoBase + 0.25;
        }
    }
}