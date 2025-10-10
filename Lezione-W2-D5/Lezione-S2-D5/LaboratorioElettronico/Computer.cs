namespace LaboratorioElettronico.Computer
{
    using LaboratorioElettronico.Dispositivi;

    public class Computer : DispositivoElettronico
    {
        public override void Accendi()
        {
            Console.WriteLine($"Accensione del Computer Modello: {Modello} in corso...");
            Console.WriteLine("Il Computer è ora Online");
        }

        public override void Spegni()
        {
            Console.WriteLine($"Spegnimento del Computer Modello: {Modello} in corso...");
            Console.WriteLine("Il Computer è ora Offline");
        }
    }
}