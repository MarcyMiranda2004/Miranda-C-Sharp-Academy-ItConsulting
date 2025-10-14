namespace EssCreaRegistraVeicolo.Moto
{
    public class Moto : Veicolo
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Della Moto");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Moto");
        }
    }
}