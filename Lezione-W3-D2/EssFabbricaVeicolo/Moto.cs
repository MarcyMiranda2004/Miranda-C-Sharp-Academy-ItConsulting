namespace EssFabbricaVeicolo.Moto
{
    public class Moto : IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio della moto");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Moto");
        }
    }
}