using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D1.EssDependencyInjection.cs
{
    #region INTERFACCIA
    public interface IGreeter
    {
        void Log(string nome);
    }
    #endregion

    #region CLASSI CONCRETE
    public class ConsoleGreeter : IGreeter
    {
        public void Log(string nome)
        {
            Console.WriteLine($"Ciao {nome} Benvenuto! ");
        }
    }
    #endregion

    #region SERVICE
    public class GreeterService
    {
        private readonly IGreeter _greeter;

        public GreeterService(IGreeter greeter)
        {
            _greeter = greeter ?? throw new ArgumentNullException(nameof(greeter));
        }

        public void Avvia(string nome)
        {
            _greeter.Log(nome);
        }
    }
    #endregion
}