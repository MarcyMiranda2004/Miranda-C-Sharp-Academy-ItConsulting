using EssFabbricaVeicolo.Veicolo;

namespace EssFabbricaVeicolo.Motoscafo
{
    public class Motoscafo : VeicoloAbs, IVeicolo
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