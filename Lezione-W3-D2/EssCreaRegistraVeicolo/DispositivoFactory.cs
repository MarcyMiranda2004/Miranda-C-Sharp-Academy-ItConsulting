using EssConfigSis.Computer;

namespace EssConfigSis.DispositivoFactory
{
    public abstract class DispositivoFactory
    {
        public static DispositivoAbs CreaDispositivo(string tipo)
        {
            switch (tipo.ToUpper())
            {
                case "COMPUTER":
                    return new Computer.Computer();

                case "STAMPANTE":
                    return new Stampante.Stampante();

                default:
                    Console.WriteLine($"Errore: tipo errato non presente");
                    return null;
            }
        }
    }
}