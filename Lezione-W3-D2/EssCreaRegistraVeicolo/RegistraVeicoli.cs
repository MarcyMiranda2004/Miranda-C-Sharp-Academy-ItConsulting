namespace EssCreaRegistraVeicolo.RegistraVeicoli
{
    public class RegistraVeicoli
    {
        private static RegistraVeicoli _instance;
        private readonly List<Veicolo> _veicoli = new List<Veicolo>();

        private RegistraVeicoli() { }

        public void Registra(Veicolo veicolo)
        {
            _veicoli.Add(veicolo);
            Console.WriteLine($"Veicolo aggiunto alla lista");
            Console.WriteLine();
        }

        public void StampaVeicoli()
        {
            Console.WriteLine($"Veicoli:");
            foreach (Veicolo v in _veicoli)
            {
                v.ToString();
                v.Avvia();
                v.MostraTipo();
                Console.WriteLine();
            }
        }

        public static RegistraVeicoli GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegistraVeicoli();
            }

            return _instance;
        }
    }
}