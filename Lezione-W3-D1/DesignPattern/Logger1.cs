namespace DesignPattern.Logger1
{
    public class Logger1
    {
        private static Logger1 _instance;
        public static Logger1 Instance;

        private Logger1(Logger1 instance) { }

        public static Logger1 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger1(_instance);
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
        }
    }
}