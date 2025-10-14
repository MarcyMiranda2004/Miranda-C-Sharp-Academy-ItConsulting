using EssFabbricaVeicolo.Veicolo;

namespace EssFabbricaVeicolo.Auto
{
    public class Auto : VeicoloAbs, IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio dell'auto");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Auto");
        }
    }
}