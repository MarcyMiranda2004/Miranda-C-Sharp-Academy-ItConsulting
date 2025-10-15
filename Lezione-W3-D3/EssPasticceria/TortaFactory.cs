using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D3.EssPasticceria
{
    public class TortaFactory
    {
        public static TortaAbs CreaTorta(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "cioccolato":
                    return new TortaCioccolato();

                case "vaniglia":
                    return new TortaVaniglia();

                case "frutta":
                    return new TortaFrutta();
                default:
                    Console.WriteLine($"scelta non valida");
                    return null;
            }
        }
    }
}