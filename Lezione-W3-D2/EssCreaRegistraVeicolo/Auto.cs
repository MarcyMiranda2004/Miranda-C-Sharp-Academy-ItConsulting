namespace EssCreaRegistraVeicolo.Auto
{
    public class Auto : Veicolo
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Del Auto");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Auto");
        }
    }
}