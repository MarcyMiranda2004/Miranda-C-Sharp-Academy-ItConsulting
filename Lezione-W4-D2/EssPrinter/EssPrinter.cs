using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssFileUploader
{
    #region INTERFACCIA
    public interface ILogger
    {
        void Log(string messaggio);
    }
    #endregion

    #region IMPLEMENTAZIONE
    public class ConsoleLog : ILogger
    {
        public void Log(string messaggio)
        {
            Console.WriteLine($"(3) Log: {messaggio}");
        }
    }
    #endregion

    #region SETTER INJECTION
    public class Printer()
    {
        public ILogger logger { get; set; }

        public void Print(string testo)
        {

            if (logger == null)
            {
                Console.WriteLine(testo);
                return;
            }

            logger.Log($"(2) Printer: {testo}");
        }
    }
    #endregion
}