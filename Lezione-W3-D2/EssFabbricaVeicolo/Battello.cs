namespace EssFabbricaVeicolo.Battello
{
    public class Battello : IVeicolo
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