// using System;
// using System.Collections.Generic;

// // 1. Strategy: definisce l'interfaccia comune per tutti gli algoritmi
// public interface IStrategy
// {
//     // Ad esempio, elaborare una lista di numeri in modi diversi
//     int DoOperation(int a, int b);
// }

// // 2. ConcreteStrategyAdd: implementa la somma
// public class ConcreteStrategyAdd : IStrategy
// {
//     public int DoOperation(int a, int b)
//     {
//         return a + b;
//     }
// }

// // 3. ConcreteStrategySubtract: implementa la sottrazione
// public class ConcreteStrategySubtract : IStrategy
// {
//     public int DoOperation(int a, int b)
//     {
//         return a - b;
//     }
// }

// // 4. ConcreteStrategyMultiply: implementa la moltiplicazione
// public class ConcreteStrategyMultiply : IStrategy
// {
//     public int DoOperation(int a, int b)
//     {
//         return a * b;
//     }
// }

// // 5. Context: utilizza una strategia per eseguire l'operazione
// public class Context
// {
//     // Riferimento alla strategia corrente
//     private IStrategy _strategy;

//     // Permette di cambiare strategia a runtime
//     public void SetStrategy(IStrategy strategy)
//     {
//         _strategy = strategy;
//     }

//     // Esegue l'algoritmo tramite la strategia corrente
//     public void ExecuteStrategy(int a, int b)
//     {
//         if (_strategy == null)
//         {
//             Console.WriteLine("Nessuna strategia impostata.");
//             return;
//         }
//         int result = _strategy.DoOperation(a, b);
//         Console.WriteLine($"Risultato dell'operazione: {result}");
//     }
// }

// // 6. Client: configura il contesto e usa diverse strategie

// /* 
// Strategy

// Il Context non conosce i dettagli dei calcoli: si affida all’interfaccia IStrategy.

// Per aggiungere un nuovo algoritmo, basta creare una nuova classe ConcreteStrategyX che implementi IStrategy, senza toccare il Context.

// La strategia può essere modificata anche a runtime, rendendo il comportamento dell’applicazione molto flessibile.
//  */