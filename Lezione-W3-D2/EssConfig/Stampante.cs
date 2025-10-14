namespace EssConfigSis.Stampante
{
    public class Stampante : DispositivoAbs
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Della Stampante");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Stampante");
        }
    }
}