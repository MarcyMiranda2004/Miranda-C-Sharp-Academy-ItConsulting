using EssFabbricaVeicolo.Veicolo;

namespace EssFabbricaVeicolo.Peschereccio
{
    public class Peschereccio : VeicoloAbs, IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio del peschereccio");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Peschereccio");
        }
    }
}