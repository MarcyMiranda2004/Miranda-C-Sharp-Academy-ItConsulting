namespace EssConfigSis.Computer
{
    public class Computer : DispositivoAbs
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Del Computer");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Computer");
        }
    }
}