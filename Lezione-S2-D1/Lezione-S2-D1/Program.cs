using Gelateria;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto alla Gelateria Dolce Gelo!");
        Console.WriteLine("(Con una spesa superiore ai 1€ hai diritto a un 10% di sconto)");

        string[] gusti = { "Cioccolato", "Nocciola", "Caffè", "Pistacchio", "Zuppa Inglese" };
        double[] prezzi = { 0.11, 0.12, 0.15, 0.20, 0.18 };
        Components.StampaMenu(gusti, prezzi);

        int[] gustiScelti = new int[20];
        int count = 0;
        int scelta;

        do
        {
            Console.Write("Inserisci il numero del gusto (0 per terminare): ");
            if (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Inserisci un numero valido!");
                continue;
            }

            if (scelta < 1 || scelta > gusti.Length)
            {
                Console.WriteLine("Scelta non valida, riprova.");
            }
            else
            {
                gustiScelti[count] = scelta - 1;
                count++;
                Console.WriteLine($"Gusto {gusti[scelta - 1]} aggiunto al cono!");
            }

        } while (scelta != 0);

        double totale = Components.CalcolaTotale(gustiScelti, count, prezzi);

        if (totale > 1)
        {
            Console.WriteLine("Hai diritto a uno sconto del 10%!");
            totale *= 0.9;
        }

        Console.WriteLine("\n--- Riepilogo Ordine ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{gusti[gustiScelti[i]]} - {prezzi[gustiScelti[i]]}€");
        }

        Console.WriteLine($"Totale da pagare: {totale}€");
        Console.WriteLine("Grazie per aver scelto Dolce Gelo!");
    }
}
