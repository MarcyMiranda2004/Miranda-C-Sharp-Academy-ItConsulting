namespace EssCreaRegistraVeicolo.Camion
{
    public class Camion : Veicolo
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Del Camion");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Camion");
        }
    }
}