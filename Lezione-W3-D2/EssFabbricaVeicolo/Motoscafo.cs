namespace EssFabbricaVeicolo.Motoscafo
{
    public class Motoscafo : IVeicolo
    {
        public void Avvia()
        {
            Console.WriteLine($"Avvio del motoscafo");
        }

        public void MostraTipo()
        {
            Console.WriteLine($"Tipo: Motoscafo");
        }
    }
}