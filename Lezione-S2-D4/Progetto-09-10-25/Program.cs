using GestioneMateriale;
using System;
using System.Collections.Generic;
using GestioneVestiti;

class Program
{
    // La lista dei materiali in magazzino
    static List<Materiale> magazzino = new List<Materiale>();


    public static void Main(string[] args)
    {
        Console.WriteLine("Gestione Fabbrica di Vestiti");

        bool continua = true;
        while (continua)
        {
            MostraMenu();
            string scelta = Console.ReadLine();
            Console.WriteLine();

            switch (scelta)
            {
                case "1":
                    AggiungiMateriale();
                    break;
                case "2":
                    MostraMateriali();
                    break;
                case "3":
                    CalcolaCostoProduzione();
                    break;
                case "4":
                    CalcolaPrezzoVendita();
                    break;
                case "5":
                    CalcolaVestitiProducibili();
                    break;
                case "6":
                    CreaVestito();
                    break;
                case "0":
                    continua = false;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    break;
            }

            if (continua)
            {
                Console.WriteLine("\nPremi INVIO per continuare...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    // === METODI DI SUPPORTO ===

    // Metodo che mostra il menu di gestione della fabbrica
    static void MostraMenu()
    {
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("[1] Aggiungi materiale");
        Console.WriteLine("[2] Visualizza materiali disponibili");
        Console.WriteLine("[3] Calcola costo di produzione di un vestito");
        Console.WriteLine("[4] Calcolo prezzo ideale di vendita di un vestito");
        Console.WriteLine("[5] Calcolo quantità di vestiti producibili");
        Console.WriteLine("[6] Crea Vestito");


        Console.WriteLine("[0] Esci");
        Console.Write("Scelta: ");
    }
    static void AggiungiMateriale()
    {
        Materiale.AggiungiMateriale(magazzino);
    }

    static void MostraMateriali()
    {
        Materiale.MostraMateriali(magazzino);
    }

    static void CalcolaCostoProduzione()
    {
        Console.WriteLine("Inserisci cm per vestito:");
        double cm = double.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci costo al cm:");
        decimal costo = decimal.Parse(Console.ReadLine());

        decimal risultato = Vestiti.CalcolaCostoProduzione(cm, costo);
        Console.WriteLine($"Costo produzione: {risultato:F2} €");
    }

    static void CalcolaPrezzoVendita()
    {
        if (magazzino.Count == 0)
        {
            Console.WriteLine("Non ci sono materiali in magazzino!");
            return;
        }

        Console.WriteLine("Scegli il materiale da usare:");
        for (int i = 0; i < magazzino.Count; i++)
            Console.WriteLine($"[{i + 1}] {magazzino[i].TipoMateriale}");

        int scelta = int.Parse(Console.ReadLine()) - 1;
        if (scelta < 0 || scelta >= magazzino.Count)
        {
            Console.WriteLine("Scelta non valida.");
            return;
        }

        Materiale materiale = magazzino[scelta];

        Console.WriteLine("Inserisci cm per vestito:");
        double cmPerVestito = double.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci margine di profitto (%)");
        decimal margine = decimal.Parse(Console.ReadLine());

        decimal prezzo = Vestiti.CalcolaPrezzoVendita(cmPerVestito, materiale.CostoMetroMateriale, margine);
        Console.WriteLine($"Prezzo di vendita suggerito: {prezzo:F2} €");
    }

    static void CalcolaVestitiProducibili()
    {
        if (magazzino.Count == 0)
        {
            Console.WriteLine("Non ci sono materiali in magazzino!");
            return;
        }

        Console.WriteLine("Scegli il materiale da usare:");
        for (int i = 0; i < magazzino.Count; i++)
            Console.WriteLine($"[{i + 1}] {magazzino[i].TipoMateriale}");

        int scelta = int.Parse(Console.ReadLine()) - 1;
        if (scelta < 0 || scelta >= magazzino.Count)
        {
            Console.WriteLine("Scelta non valida.");
            return;
        }

        Materiale materiale = magazzino[scelta];

        Console.WriteLine("Inserisci cm necessari per un vestito:");
        double cmPerVestito = double.Parse(Console.ReadLine());

        int quantita = Vestiti.CalcolaQuantitaVestiti(materiale.QuantitaCm, cmPerVestito);
        Console.WriteLine($"Puoi creare {quantita} vestiti con il materiale '{materiale.TipoMateriale}'.");
    }


    static void CreaVestito()
    {
        Vestiti.CreaVestito(magazzino);
    }
}
