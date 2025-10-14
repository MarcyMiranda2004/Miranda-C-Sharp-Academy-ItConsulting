namespace EssFabbricaVeicolo.Camion
{
    public class Camion : IVeicolo
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