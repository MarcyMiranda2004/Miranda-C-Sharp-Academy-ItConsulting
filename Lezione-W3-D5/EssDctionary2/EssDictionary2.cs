#region DICTIONARY
using System.Runtime.InteropServices.Marshalling;

public class RubricaTelefonica
{
    public Dictionary<string, string> Rubrica = new();

    public void AggiungiContatto(string numero, string nome)
    {
        if (!Rubrica.ContainsKey(numero))
        {
            Rubrica[numero] = nome;
            Console.WriteLine($"Contatto aggiunto: {nome} ({numero})");
        }
        else
        {
            Console.WriteLine("Numero già presente nella rubrica!");
        }
    }

    public void MostraContatti()
    {
        Console.WriteLine("Rubrica:");
        if (Rubrica.Count == 0)
        {
            Console.WriteLine("Nessun contatto salvato.");
        }
        else
        {
            foreach (var contatto in Rubrica)
                Console.WriteLine($"{contatto.Value} - {contatto.Key}");
        }
        Console.WriteLine();
    }
}

public class Divisore
{
    public Dictionary<string, int> ParoleDct = new();

    public void DividiEConta(string frase)
    {
        string[] paroleArr = frase.Split(" ");

        foreach (string parole in paroleArr)
        {
            string parolaMin = parole.ToLower();

            if (ParoleDct.ContainsKey(parolaMin))
            {
                ParoleDct[parolaMin]++;
            }
            else
            {
                ParoleDct.Add(parolaMin, 1);
            }
        }

        StampaParole();
    }

    public void StampaParole()
    {
        foreach (var e in ParoleDct)
        {
            Console.WriteLine($"{e.Key} si ripete {e.Value} volte");
        }
    }
}
#endregion

#region 
class Program
{
    public static void Main(string[] args)
    {
        var rubrica = new RubricaTelefonica();
        int scelta;

        do
        {
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi un contatto alla rubrica");
            Console.WriteLine("[2] Mostra tutti i contatti");
            Console.WriteLine($"[3] Dividi frase in parole");

            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    Console.Write("Inserisci il numero del contatto: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Inserisci il nome del contatto: ");
                    string contactName = Console.ReadLine();

                    rubrica.AggiungiContatto(phoneNumber, contactName);
                    break;

                case 2:
                    rubrica.MostraContatti();
                    break;

                case 3:
                    Divisore divisore = new();

                    Console.WriteLine($"Inserisci una frase");
                    string frase = Console.ReadLine();
                    divisore.DividiEConta(frase);
                    break;

                case 0:
                    Console.WriteLine("Esco dal programma...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

            Console.WriteLine();

        } while (scelta != 0);
    }
}
#endregion
