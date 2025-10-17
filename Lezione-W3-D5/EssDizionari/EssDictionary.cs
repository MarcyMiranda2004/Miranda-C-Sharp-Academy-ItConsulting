#region Classe Utente
using System;
using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
#endregion

#region ActionLog
public class ActionLog
{
    public DateTime Timestamp { get; set; }
    public string ActionType { get; set; }
    public string Metadata { get; set; }
}
#endregion

#region InMemory (Singleton)
public class InMemory
{
    private static InMemory _instance;
    public static InMemory Instance => _instance ??= new InMemory();

    public Dictionary<int, User> Users { get; private set; }
    public Dictionary<int, List<ActionLog>> ActionsByUser { get; private set; }

    private InMemory()
    {
        Users = new Dictionary<int, User>();
        ActionsByUser = new Dictionary<int, List<ActionLog>>();
    }
}
#endregion

#region Creazione Utente e Azione (Factory)
public static class UserFactory
{
    private static int userCounter = 1;

    public static User CreateUser(string username, string email)
    {
        return new User
        {
            Id = userCounter++,
            Username = username,
            Email = email,
            IsActive = true,
            CreatedAt = DateTime.Now
        };
    }

    public static ActionLog CreateAction(string type, string metadata)
    {
        return new ActionLog
        {
            Timestamp = DateTime.Now,
            ActionType = type,
            Metadata = metadata
        };
    }
}
#endregion

#region Programma principale
// class Program
// {
//     public static void Main(string[] args)
//     {

//         var dataBase = InMemory.Instance;

//         var user1 = UserFactory.CreateUser("Marcello", "marcellomiranda2006@gmail.com");
//         dataBase.Users[user1.Id] = user1;
//         Console.WriteLine($"Utente creato: {user1.Username}");

//         var action1 = UserFactory.CreateAction("LOGIN", "Accesso al sistema");

//         if (!dataBase.ActionsByUser.ContainsKey(user1.Id))
//             dataBase.ActionsByUser[user1.Id] = new List<ActionLog>();

//         dataBase.ActionsByUser[user1.Id].Add(action1);

//         var action2 = UserFactory.CreateAction("LOGOUT", "Uscita dal sistema");
//         dataBase.ActionsByUser[user1.Id].Add(action2);

//         Console.WriteLine("\nStorico Azioni:");
//         foreach (var log in dataBase.ActionsByUser[user1.Id])
//         {
//             Console.WriteLine($"[{log.Timestamp}] {log.ActionType} - {log.Metadata}");
//         }
//     }
// }
#endregion
