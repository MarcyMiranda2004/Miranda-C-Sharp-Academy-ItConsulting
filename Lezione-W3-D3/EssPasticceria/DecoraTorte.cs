using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D3.EssPasticceria
{
    public class DecoraTorte : ITorta
    {
        protected ITorta _baseTorta;

        protected DecoraTorte(ITorta baseTorta)
        {
            _baseTorta = baseTorta;
        }

        public virtual string Descrizione()
        {
            return _baseTorta.Descrizione();
        }
    }
}