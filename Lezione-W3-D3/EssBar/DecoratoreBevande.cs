using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssBar
{
    public class DecoratoreBevande : IBevanda
    {
        protected IBevanda _bevanda;

        protected DecoratoreBevande(IBevanda bevanda)
        {
            _bevanda = bevanda;
        }

        public virtual string Descrizione()
        {
            return _bevanda.Descrizione();
        }

        public virtual double Costo()
        {
            return _bevanda.Costo();
        }
    }
}