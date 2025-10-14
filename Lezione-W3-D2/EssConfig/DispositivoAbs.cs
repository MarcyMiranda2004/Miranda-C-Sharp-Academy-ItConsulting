namespace EssConfigSis
{
    public abstract class DispositivoAbs : IDispositivo
    {
        public virtual void Avvia()
        {
            Console.WriteLine($"Avvio del Dispositivo");
        }

        public virtual void MostraTipo()
        {
            Console.WriteLine($"Tipo: Dispositivo");
        }
    }
}