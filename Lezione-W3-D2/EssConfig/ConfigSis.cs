namespace EssConfigSis
{
    public class ConfigSis
    {
        private static ConfigSis _instance;

        private readonly Dictionary<string, string> _configs = new Dictionary<string, string>();

        private ConfigSis() { }

        public ConfigSis Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigSis();
                }

                return _instance;
            }
        }

        public void Imposta(string chiave, string valore)
        {
            _configs[chiave] = (valore);
        }

        public string Leggi(string chiave)
        {
            if (_configs.ContainsKey(chiave))
            {
                return _configs[chiave];
            }
            else
            {
                Console.WriteLine($"Chiave {chiave} errata o non presente");
                Console.WriteLine();
                return null;
            }
        }

        public void StampaTutte()
        {
            Console.WriteLine($"Configurazioni:");
            foreach (var cv in _configs)
            {
                Console.WriteLine($"{cv.Key}, {cv.Value}");
            }
        }
    }
}
