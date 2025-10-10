using Astrattismo;
public class Programma
{
    public static void Main()
    {
        int scelta;

        do
        {
            Console.WriteLine($"Che Esercizio Vuoi Vedere ?");
            Console.WriteLine($"[1] Astrattismo");
            Console.WriteLine($"[0] Esci");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssAstrattismo();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Scelta Non Valida");
                    break;
            }

        } while (scelta != 0);

    }

    public static void EssAstrattismo()
    {
        Veicolo miaAuto = new Auto();
        miaAuto.Avvia();

        IVeicoloElettrico mioScooter = new ScooterElettrico();
        mioScooter.Ricarica();
    }
}