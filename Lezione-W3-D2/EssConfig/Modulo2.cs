using EssSistemaConfSis;

namespace EssConfigSis.Modulo2
{
    public class Modulo2
    {
        public void Esegui()
        {
            var config = ConfigurazioneSistema.Instance;
            config.Imposta("Tema", "Chiaro");
            Console.WriteLine($"Modulo 2 Tema = {config.Leggi("Tema")}");
        }
    }
}