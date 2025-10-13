namespace DesignPattern
{
    public class Logger2
    {
        private static Logger2 _instance;

        private readonly List<string> _logs = new List<string>();

        private Logger2() { }

        public void Log(string message)
        {
            _logs.Add(message);
            Console.WriteLine($"log: {message} aggiunto alla lista");
            Console.WriteLine();
        }

        public void StampaLog()
        {
            Console.WriteLine();
            Console.WriteLine("--- LOG REGISTRATI ---");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine();
        }

        public static Logger2 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger2();
            }

            return _instance;
        }

        public void ScriviMessaggio(string messaggio)
        {
            if (messaggio == null)
            {
                messaggio = "nessun messaggio da loggare";
            }

            Console.WriteLine(messaggio);
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            Log(messaggio);
        }
    }
}