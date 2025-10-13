using DesignPattern;
using DesignPattern.Logger1;
public class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"Che esercizio vuoi vedere ?");
            Console.WriteLine($"[1] Logger1 1.0");
            Console.WriteLine($"[2] Logger1 2.0");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssLog1();
                    break;

                case 2:
                    EssLog2();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Inserire una scelta valida!");
                    break;
            }

        } while (scelta != 0);
    }

    public static void EssLog1()
    {
        Logger1 log1 = Logger1.GetInstance();
        log1.ScriviMessaggio("log1, prova 1");
    }

    public static void EssLog2()
    {
        Logger2 log2 = Logger2.GetInstance();
        log2.ScriviMessaggio("log2, prova 1");

        Logger2 log3 = Logger2.GetInstance();
        log3.ScriviMessaggio("log2, prova 2");

        log2.StampaLog();
    }
}