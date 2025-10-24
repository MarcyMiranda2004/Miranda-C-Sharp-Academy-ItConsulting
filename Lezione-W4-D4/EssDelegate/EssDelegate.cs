using System;

namespace Lezione_W4_D4.EssDelegate
{
    #region Ess 1 - Operazioni 
    public class Ess1
    {
        // 1. Definizione del delegato
        delegate int Operazione(int a, int b);

        // 2. Metodi compatibili col delegato
        static int Somma(int a, int b) => a + b;
        static int Moltiplica(int a, int b) => a * b;

        // 3. Metodo che riceve il delegato come parametro
        static int EseguiOperazione(Operazione operazione, int x, int y)
        {
            return operazione(x, y);
        }

        // 4. Metodo Main per test
        // public static void Main(string[] args)
        // {
        //     // Istanzio il delegato e lo collego ai metodi
        //     Operazione opSomma = Somma;
        //     Operazione opMoltiplica = Moltiplica;

        //     int risultato1 = EseguiOperazione(opSomma, 3, 5);
        //     int risultato2 = EseguiOperazione(opMoltiplica, 3, 5);

        //     Console.WriteLine($"Somma: {risultato1}");
        //     Console.WriteLine($"Moltiplicazione: {risultato2}");
        // }
    }
    #endregion

    #region Ess 2 - Logger
    public class Ess2
    {
        delegate string Logger(string message);

        static string StampaInConsole(string message) => $"[CONSOLE] {message}";
        static string SendEmail(string message) => $"[EMAIL] {message}";

        static string EseguiLog(Logger logger, string message) => logger(message);

        // public static void Main(string[] args)
        // {
        //     Logger logConsole = StampaInConsole;
        //     Logger LogEmail = SendEmail;

        //     string log1 = EseguiLog(logConsole, "Ciao!");
        //     string log2 = EseguiLog(LogEmail, "Benvenuto!");

        //     Console.WriteLine(log1);
        //     Console.WriteLine(log2);
        // }

    }
    #endregion
}
