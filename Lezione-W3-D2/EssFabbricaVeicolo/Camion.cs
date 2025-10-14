using EssFabbricaVeicolo.Veicolo;

namespace EssFabbricaVeicolo.Camion
{
    public class Camion : VeicoloAbs, IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio dell camion");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Camion");
        }
    }
}