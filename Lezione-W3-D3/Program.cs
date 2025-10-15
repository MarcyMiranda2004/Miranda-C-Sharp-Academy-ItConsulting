using System.Diagnostics;
using EssBar;
using Lezione_W3_D3.EssPasticceria;

class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"che esercizio vuoi vedere?");
            Console.WriteLine($"[1] Bar");
            Console.WriteLine($"[2] Pasticceria");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    EssBar();
                    break;

                case 2:
                    EssPasticceria();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma");
                    break;

                default:
                    Console.WriteLine($"Scelta non valida!");
                    break;
            }


        } while (scelta != 0);
    }

    public static void EssBar()
    {
        int sceltaBar;

        do
        {
            Console.WriteLine($"\nBenvenuto al Bar");
            Console.WriteLine($"Che bevanda vuoi?");
            Console.WriteLine($"[1] Caffè");
            Console.WriteLine($"[2] Thè");
            Console.WriteLine($"[0] Esci");
            Console.Write($"Scelta: ");

            if (!int.TryParse(Console.ReadLine(), out sceltaBar))
            {
                Console.WriteLine("Inserisci un numero valido!");
                continue;
            }

            IBevanda bevanda = null;

            switch (sceltaBar)
            {
                case 1:
                    bevanda = new Caffe();
                    break;

                case 2:
                    bevanda = new Te();
                    break;

                case 0:
                    Console.WriteLine($"Arrivederci!");
                    return;

                default:
                    Console.WriteLine($"Scelta non valida!");
                    continue;
            }

            Console.Write("\nVuoi decorare la tua bevanda? (y/n): ");
            char risposta = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (risposta == 'y')
            {
                bool aggiungiAltro = true;
                do
                {
                    Console.WriteLine($"\nScegli decorazione:");
                    Console.WriteLine($"[1] Latte");
                    Console.WriteLine($"[2] Panna");
                    Console.WriteLine($"[3] Cioccolato");
                    Console.WriteLine($"[0] Nessuna / Fine decorazioni");
                    Console.Write($"Scelta: ");
                    int decorazione = int.Parse(Console.ReadLine());

                    switch (decorazione)
                    {
                        case 1:
                            bevanda = new ConLatte(bevanda);
                            Console.WriteLine("Aggiunto Latte");
                            break;
                        case 2:
                            bevanda = new ConPanna(bevanda);
                            Console.WriteLine("Aggiunta Panna");
                            break;
                        case 3:
                            bevanda = new ConCioccolato(bevanda);
                            Console.WriteLine("Aggiunto Cioccolato");
                            break;
                        case 0:
                            aggiungiAltro = false;
                            continue;
                        default:
                            Console.WriteLine("Scelta non valida!");
                            continue;
                    }

                    Console.Write("\nVuoi aggiungere un'altra decorazione? (y/n): ");
                    aggiungiAltro = Char.ToLower(Console.ReadKey().KeyChar) == 'y';
                    Console.WriteLine();

                } while (aggiungiAltro);
            }

            Console.WriteLine($"\n La tua bevanda: {bevanda.Descrizione()}");
            Console.WriteLine($" Costo totale: {bevanda.Costo():0.00}€");
            Console.WriteLine();

        } while (true);
    }

    public static void EssPasticceria()
    {
        bool continua = true;
        string tortaBase;

        do
        {
            Console.WriteLine($"inserisci la torta da creare o Esci per uscire");
            tortaBase = Console.ReadLine();

            if (tortaBase.ToLower() == "esci") { continua = false; }

            TortaAbs nuovaTorta = TortaFactory.CreaTorta(tortaBase);

            if (nuovaTorta != null)
            {
                nuovaTorta.Descrizione();
            }
            else
            {
                Console.WriteLine($"Errore, {nuovaTorta} non è un tipo valido");
            }

        } while (continua);
    }
}
