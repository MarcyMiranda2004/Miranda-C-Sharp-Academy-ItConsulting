namespace EssCreaRegistraVeicolo.VeicoloFactory
{
    public abstract class VeicoloFactory
    {
        public static Veicolo CreaVeicolo(string tipo)
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
                    Console.WriteLine($"Errore: tipo errato non presente");
                    return null;
            }
        }
    }
}