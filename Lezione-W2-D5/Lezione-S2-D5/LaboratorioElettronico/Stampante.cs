namespace LaboratorioElettronico
{
    using LaboratorioElettronico.Dispositivi;

    public class Stampante : DispositivoElettronico
    {
        public override void Accendi()
        {
            Console.WriteLine($"Accensione della Stampante Modello: {Modello} in corso...");
            Console.WriteLine("La Stampante è ora Online");
        }

        public override void Spegni()
        {
            Console.WriteLine($"Spegnimento della Stampante Modello: {Modello} in corso...");
            Console.WriteLine("La Stampante è ora Offline");
        }
    }
}