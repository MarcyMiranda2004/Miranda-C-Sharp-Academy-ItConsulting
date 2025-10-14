namespace EssCreaRegistraVeicolo
{
    public abstract class Veicolo : IVeicolo
    {
        public virtual void Avvia()
        {
            Console.WriteLine($"Avvio Del Veicolo");
        }

        public virtual void MostraTipo()
        {
            Console.WriteLine($"Tipo: Veicolo");
        }
    }
}