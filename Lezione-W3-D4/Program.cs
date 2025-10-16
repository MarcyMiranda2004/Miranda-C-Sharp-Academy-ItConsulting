using System.Runtime.CompilerServices;
using Lezione_W3_D4.EssCalcolatrice;
using Lezione_W3_D4.EssRistorante;

class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"Che Esercizio vuoi vedere ?");
            Console.WriteLine($"[1] Strategy");
            Console.WriteLine($"[2] Calcolatrice");
            Console.WriteLine($"[3] Ristorante");

            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssStrategy();
                    break;

                case 2:
                    EssCalcolatrice();
                    break;

                case 3:
                    EssRistorante();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Errore: scelta non valida!");
                    break;
            }

        } while (scelta != 0);
    }

    public static void EssStrategy()
    {
        // var context = new Context();

        // // Usa la strategia di somma
        // context.SetStrategy(new ConcreteStrategyAdd());
        // Console.Write("Somma: ");
        // context.ExecuteStrategy(10, 5);  // Output: 15

        // // Cambia strategia in sottrazione
        // context.SetStrategy(new ConcreteStrategySubtract());
        // Console.Write("Sottrazione: ");
        // context.ExecuteStrategy(10, 5);  // Output: 5

        // // Cambia strategia in moltiplicazione
        // context.SetStrategy(new ConcreteStrategyMultiply());
        // Console.Write("Moltiplicazione: ");
        // context.ExecuteStrategy(10, 5);  // Output: 50
    }

    public static void EssCalcolatrice()
    {
        Console.WriteLine($"===CALCOLATRICE===");
        Console.WriteLine($"Inserisci il primo numero");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine($"Inserisci il secondo numero");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine($"Che operazione vuoi effettuare ?");
        Console.WriteLine($"[1] Addizione");
        Console.WriteLine($"[2] Sottrazione");
        Console.WriteLine($"[3] Divisione");
        int sceltaOp = int.Parse(Console.ReadLine());

        var ctx = new Context();

        switch (sceltaOp)
        {
            case 1:
                ctx.SetStrategy(new StrategiaSomma());
                ctx.ExecuteStrategy(a, b);
                break;

            case 2:
                ctx.SetStrategy(new StrategiaSottrazione());
                ctx.ExecuteStrategy(a, b);
                break;

            case 3:
                ctx.SetStrategy(new StrategiaDivisione());
                ctx.ExecuteStrategy(a, b);
                break;

            default:
                Console.WriteLine($"Operazione non valida!");
                break;
        }
    }

    public static void EssRistorante()
    {
        Console.WriteLine("Benvenuto nel ristorante dello Chef Remi!");
        Console.Write("Scegli un piatto base (Pizza, Hamburger, Insalata): ");
        string tipo = Console.ReadLine();

        IPiatto piatto = PiattoFactory.Crea(tipo);

        if (piatto == null)
        {
            Console.WriteLine("Errore: tipo non valido!");
            return;
        }

        Console.Write("\nVuoi aggiungere formaggio? (y/n): ");
        if (Console.ReadKey().KeyChar == 'y') piatto = new ConFormaggio(piatto);

        Console.Write("\nVuoi aggiungere bacon? (y/n): ");
        if (Console.ReadKey().KeyChar == 'y') piatto = new ConBacon(piatto);

        Console.Write("\nVuoi aggiungere salsa? (y/n): ");
        if (Console.ReadKey().KeyChar == 'y') piatto = new ConSalsa(piatto);

        Console.WriteLine("\n\nScegli metodo di preparazione:");
        Console.WriteLine("[1] Fritto");
        Console.WriteLine("[2] Al Forno");
        Console.WriteLine("[3] Alla Griglia");
        Console.Write("Scelta: ");
        int scelta = int.Parse(Console.ReadLine());

        Chef chef = new Chef();
        switch (scelta)
        {
            case 1: chef.ImpostaStrategia(new Fritto()); break;
            case 2: chef.ImpostaStrategia(new AlForno()); break;
            case 3: chef.ImpostaStrategia(new AllaGriglia()); break;
            default: chef.ImpostaStrategia(new AlForno()); break;
        }

        Console.WriteLine("\n--- RISULTATO ---");
        Console.WriteLine(piatto.Descrizione());
        Console.WriteLine(chef.PreparaPiatto(piatto));
    }
}
