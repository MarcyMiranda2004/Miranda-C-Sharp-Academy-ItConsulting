// namespace Lezione_W4_D1.DependecyInjection
// {
//     public interface ILogger
//     {
//         void Log(string message);
//     }

//     public class ConsoleLogger : ILogger
//     {
//         public void Log(string message)
//         {
//             Console.WriteLine($"LOG: {message}");
//         }
//     }

//     public class UserService
//     {
//         private readonly ILogger _logger;

//         public UserService(ILogger logger)
//         {
//             _logger = logger;
//         }

//         public void CreateUser(string name)
//         {
//             _logger.Log($"User '{name}' created.");
//         }
//     }

//     /* 
//     Constructor Injection:

//     In questo esempio, UserService dipende da una funzionalità di logging rappresentata dall'interfaccia ILogger. 

//     Invece di creare direttamente un'istanza concreta di un logger all'interno della classe UserService, 
//     tale istanza viene iniettata tramite il costruttore. Questo approccio:

//     Rispetta il principio dell'inversione delle dipendenze (DIP), poiché UserService dipende da un'astrazione (ILogger) 
//     e non da una specifica implementazione (ConsoleLogger).

//     Aumenta la flessibilità, permettendo di sostituire facilmente l'implementazione del logger (es. file logger, 
//     database logger, logger di test).

//     Migliora la testabilità, in quanto possiamo passare un mock o una finta implementazione di ILogger durante i test.
//     */
// }