using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D3.EssPasticceria
{
    public abstract class TortaAbs : ITorta
    {
        public virtual string Descrizione()
        {
            return $"Ottima torta";
        }
    }
}