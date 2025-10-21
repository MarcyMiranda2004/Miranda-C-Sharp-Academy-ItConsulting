using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssBookHub
{
    #region INTERFACCE
    public interface IInventoryService
    {
        void StockStatus();
    }

    public interface IPaymentProcessor
    {
        void Paga();
    }

    public interface IProdotto
    {
        void TipoProdotto();
    }
    #endregion

    #region FACTORY
    public class Libro : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Libro");

        }
    }

    public class Fumetto : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Fumetto");

        }
    }

    public class Rivista : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Rivista");

        }
    }

    public class ProductFactory
    {
        public static IProdotto CreaProdotto(string tipo)
        {
            return tipo.ToUpper() switch
            {
                "LIBRO" => new Libro(),
                "FUMETTO" => new Fumetto(),
                "RIVISTA" => new Rivista(),
                _ => throw new ArgumentException("Tipo prodotto non valido.")

            };
        }
    }
    #endregion

    #region SERVICE

    #endregion
}