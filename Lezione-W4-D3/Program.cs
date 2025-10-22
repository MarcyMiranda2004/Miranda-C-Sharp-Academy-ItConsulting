using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int scelta;

            do
            {
                Console.WriteLine($"Che Esercizio vuoi vedere ?");

                Console.WriteLine($"[0] Esci");
                Console.WriteLine($"Scelta:");
                scelta = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine($"Esco dal programma...");
                        break;

                    default:
                        Console.WriteLine($"Errore: scelta non valida!");
                        break;
                }

            } while (scelta != 0);

        }
    }
}