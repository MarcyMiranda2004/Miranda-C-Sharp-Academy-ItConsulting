using EssFabbricaVeicolo.Veicolo;

namespace EssFabbricaVeicolo.Battello
{
    public class Battello : VeicoloAbs, IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio del battello");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Battello");
        }
    }
}