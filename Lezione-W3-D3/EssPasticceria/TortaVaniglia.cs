using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D3.EssPasticceria
{
    public class TortaVaniglia : TortaAbs, ITorta
    {
        public string Descrizione()
        {
            return $"Ottima torta alla vaniglia";
        }
    }
}