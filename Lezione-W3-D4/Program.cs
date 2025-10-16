using System.Runtime.CompilerServices;
using Lezione_W3_D4.EssCalcolatrice;

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
}
