using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W3_D4.EssCalcolatrice
{
    #region INTERFACCE
    public interface IStrategiaOperazione
    {
        double Calcola(double a, double b);
    }
    #endregion

    #region STRATEGIE CONCRETE
    // SOMMA
    public class StrategiaSomma : IStrategiaOperazione
    {
        public double Calcola(double a, double b)
        {
            return a + b;
        }
    }

    // SOTTRAZIONE
    public class StrategiaSottrazione : IStrategiaOperazione
    {
        public double Calcola(double a, double b)
        {
            return a - b;
        }
    }

    // DIVISIONE
    public class StrategiaDivisione : IStrategiaOperazione
    {
        public double Calcola(double a, double b)
        {
            return a / b;
        }
    }
    #endregion

    #region CONTESTO
    public class Context
    {
        private IStrategiaOperazione _strategiaOp;

        public void SetStrategy(IStrategiaOperazione strategiaOp)
        {
            _strategiaOp = strategiaOp;
        }

        public void ExecuteStrategy(double a, double b)
        {
            if (_strategiaOp == null)
            {
                Console.WriteLine("Nessuna strategia impostata.");
                return;
            }

            double risultato = _strategiaOp.Calcola(a, b);
            Console.WriteLine($"Risultato dell'operazione di {a} e {b} è: {risultato}");
        }
    }
    #endregion
}