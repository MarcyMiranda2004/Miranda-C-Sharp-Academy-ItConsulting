namespace Gelateria;

public class Components
{
    public static void StampaMenu(string[] gusti, double[] prezzi)
    {
        Console.WriteLine("Menu:");
        for (int i = 0; i < gusti.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {gusti[i]} - {prezzi[i]}€");
        }
    }

    public static double CalcolaTotale(int[] gustiScelti, int count, double[] prezzi)
    {
        double totale = 0;
        for (int i = 0; i < count; i++)
        {
            totale += prezzi[gustiScelti[i]];
        }
        return totale;
    }
}
