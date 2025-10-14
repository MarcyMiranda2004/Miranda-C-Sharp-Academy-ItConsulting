namespace EssSistemaConfSis
{
    public class ConfigurazioneSistema
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        private ConfigurazioneSistema() { }

        private static ConfigurazioneSistema _instance;
        public static ConfigurazioneSistema Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurazioneSistema();
                }

                return _instance;
            }
        }

        public void Imposta(string chiave, string valore)
        {
            _dictionary[chiave] = valore;
        }

        public string Leggi(string chiave)
        {
            if (_dictionary.ContainsKey(chiave))
            {
                return _dictionary[chiave];
            }
            else
            {
                return $"Chiave: {chiave} non ha un valore corrispondete o non è stata trovata nel dizionario";
            }
        }

        public void StampaTutte()
        {
            Console.WriteLine("Configurazioni attuali:");
            foreach (var coppia in _dictionary)
            {
                Console.WriteLine($"{coppia.Key} = {coppia.Value}");
            }
        }
    }
}