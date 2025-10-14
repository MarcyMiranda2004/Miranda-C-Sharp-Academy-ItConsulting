using EssFabbricaVeicolo.Motoscafo;
using EssFabbricaVeicolo.Peschereccio;
using EssFabbricaVeicolo.Battello;

namespace EssFabbricaVeicolo.FabbricheNavi
{
    public abstract class NaviFactory
    {
        public static IVeicolo CreaNave(string tipo)
        {
            switch (tipo)
            {
                case "Motoscafo":
                    return new Motoscafo.Motoscafo();

                case "Peschereccio":
                    return new Peschereccio.Peschereccio();

                case "Battello":
                    return new Battello.Battello();

                default:
                    Console.WriteLine($"Tipo non valido o non presente");
                    return null;
            }
        }
    }
}