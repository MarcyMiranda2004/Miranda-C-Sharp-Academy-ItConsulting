using EssFabbricaVeicolo.Auto;
using EssFabbricaVeicolo.Moto;
using EssFabbricaVeicolo.Camion;
using EssFabbricaVeicolo.Motoscafo;
using EssFabbricaVeicolo.Peschereccio;
using EssFabbricaVeicolo.Battello;
using EssFabbricaVeicolo.FabbricheNavi;

namespace EssFabbricaVeicolo.VeicoloFactory
{
    public abstract class VeicoloFactory
    {
        public static IVeicolo CreaVeicolo(string tipo)
        {
            switch (tipo)
            {
                case "Auto":
                    return new Auto.Auto();

                case "Moto":
                    return new Moto.Moto();

                case "Camion":
                    return new Camion.Camion();

                default:
                    return NaviFactory.CreaNave(tipo);
            }
        }
    }
}