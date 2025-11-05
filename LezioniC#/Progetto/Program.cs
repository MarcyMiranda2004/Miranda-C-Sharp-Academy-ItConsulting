using System;

class Program
{
    static void Main(string[] args)
    {
        string connString = "server=localhost;user=root;password=MySql@2317;database=rubrica_db";
        DbConnection db = new DbConnection(connString);

        while (true)
        {
            StampaMenu();
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    InserisciContatto(db);
                    break;

                case "2":
                    VisualizzaContatti(db);
                    break;

                case "3":
                    EliminaContatto(db);
                    break;

                case "0":
                    Console.WriteLine("Chiusura programma...");
                    return;

                default:
                    Console.WriteLine("Opzione non valida. Riprova.\n");
                    break;
            }
        }
    }

    static void StampaMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n=== RUBRICA CONTATTI ===");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("[1] Inserisci un nuovo contatto");
        Console.WriteLine("[2] Visualizza tutti i contatti");
        Console.WriteLine("[3] Elimina un contatto per nome");
        Console.WriteLine("[0] Esci");
        Console.Write("\nScegli un'opzione: ");
        Console.ResetColor();
    }

    static void InserisciContatto(DbConnection db)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();

        db.InsertDB(nome, telefono);
    }

    static void VisualizzaContatti(DbConnection db)
    {
        db.ReadDB();
    }

    static void EliminaContatto(DbConnection db)
    {
        Console.Write("Inserisci il nome del contatto da eliminare: ");
        string nome = Console.ReadLine();

        db.DeleteDB(nome);
    }
}
