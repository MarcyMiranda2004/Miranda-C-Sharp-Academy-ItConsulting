using EssSistemaConfSis;

namespace EssConfigSis.Modulo1
{
    public class Modulo1
    {
        public void Esegui()
        {
            var config = ConfigurazioneSistema.Instance;
            config.Imposta("Tema", "Scuro");
            Console.WriteLine($"Modulo 1 Tema = {config.Leggi("Tema")}");
        }
    }
}