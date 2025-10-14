using System;
using System.Net.Http.Headers;

namespace FactoryMethod
{
    // Product: definisce l'interfaccia del prodotto
    public interface IProduct
    {
        void Operation();
    }

    // ConcreteProductA: implementa IProduct
    public class ConcreteProductA : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("Esecuzione di ConcreteProductA.Operation()");
        }
    }

    // ConcreteProductB: un altro prodotto concreto
    public class ConcreteProductB : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("Esecuzione di ConcreteProductB.Operation()");
        }
    }

    // Creator: dichiara il Factory Method 
    public abstract class Creator
    {
        // Factory Method: restituisce un IProduct
        public abstract IProduct FactoryMethod();

        // Un metodo del creator che utilizza il prodotto
        public void AnOperation()
        {
            // Creazione del prodotto tramite FactoryMethod
            IProduct product = FactoryMethod();
            product.Operation();
        }
    }

    // ConcreteCreatorA: implementa FactoryMethod per ConcreteProductA
    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // ConcreteCreatorB: implementa FactoryMethod per ConcreteProductB
    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // Esempio di utilizzo (Client)
    // class Program
    // {
    //     static void Main()
    //     {
    //         Creator creatorA = new ConcreteCreatorA();
    //         creatorA.AnOperation(); // usa ConcreteProductA

    //         Creator creatorB = new ConcreteCreatorB();
    //         creatorB.AnOperation(); // usa ConcreteProductB
    //     }
    // }
}
