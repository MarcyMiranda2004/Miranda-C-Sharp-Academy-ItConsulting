using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D3.EssPasticceria
{
    public class ConGlassa : DecoraTorte
    {
        public ConGlassa(ITorta torta) : base(torta) { }

        public override string Descrizione()
        {
            string descrizioneBase = base.Descrizione();
            return descrizioneBase + " con aggiunta di Glassa";
        }
    }
}