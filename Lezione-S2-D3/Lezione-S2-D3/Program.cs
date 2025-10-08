using GestioneVoloAereo;
using GestioneContoBancario;
using GestionePrenotaViaggio;
using GestioneSoldato;
using GestioneSoldato;
using GestioneFante;
using GestioneArtigliere;
using System.Xml.Serialization;
using GestioneVeicolo;
using GestioneAuto;
using GestioneMoto;
using GestioneCamion;

class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"Ciao, Che esercizio vuoi vedere ?");
            Console.WriteLine($"1: Volo Aereo");
            Console.WriteLine($"2: Conto Bancario");
            Console.WriteLine($"3: Prenota Viaggio");
            Console.WriteLine($"4: Esercito");
            Console.WriteLine($"5: Officina");

            Console.WriteLine($"0: Esci");

            Console.WriteLine();

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    EssVoloAereo();
                    break;

                case 2:
                    EssContoBancario();
                    break;

                case 3:
                    EssPrenotaViaggio();
                    break;

                case 4:
                    EssEsercito();
                    break;

                case 5:
                    EssOfficina();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"scelta non valida");
                    break;
            }

        } while (scelta != 0);
    }

    public static void EssVoloAereo()
    {
        VoloAereo volo1 = new VoloAereo("AZ123", 0);

        Console.WriteLine("\n--- Stato iniziale del volo ---");
        volo1.VisualizzaStato();

        Console.WriteLine("\n--- Effettuo prenotazione di 50 posti ---");
        volo1.EffettuaPrenotazione(50);
        volo1.VisualizzaStato();

        Console.WriteLine("\n--- Annullamento di 10 posti ---");
        volo1.AnnullaPrenotazione(10);
        volo1.VisualizzaStato();
    }

    public static void EssContoBancario()
    {
        ContoBancario conto = new ContoBancario();

        conto.Nome = "Marco";
        Console.WriteLine($"Nome");

        conto.Password = "Password1";
        Console.WriteLine($"Mi dispiace, ma la password è privata.");

        conto.OttieniSaldo();

        decimal importo = 100.57m;
        conto.Deposita(importo);
    }

    public static void EssPrenotaViaggio()
    {
        int sceltaPrenotazione;
        List<PrenotaViaggio> viaggi = new List<PrenotaViaggio>();

        do
        {
            Console.WriteLine($"Cosa vuoi fare ?");
            Console.WriteLine($"1: Effettua Prenotazione");
            Console.WriteLine($"2: Annulla Prenotazione");
            Console.WriteLine($"0: Esci");
            Console.WriteLine();

            sceltaPrenotazione = int.Parse(Console.ReadLine());

            switch (sceltaPrenotazione)
            {
                case 1:
                    PrenotaViaggio nuovoViaggio = new PrenotaViaggio();

                    Console.WriteLine($"Dove vuoi andare ?");
                    string sceltaDestinazione = Console.ReadLine();
                    nuovoViaggio.Destinazione = sceltaDestinazione;

                    Console.WriteLine($"Quanti posti vuoi prenotare ?");
                    int prenotazioni = int.Parse(Console.ReadLine());

                    nuovoViaggio.PrenotaPosti(prenotazioni);

                    Console.WriteLine($"Viaggio prenotato con successo!");
                    Console.WriteLine($"");

                    nuovoViaggio.VisualizzaStato();

                    viaggi.Add(nuovoViaggio);
                    break;

                case 2:
                    if (viaggi.Count == 0)
                    {
                        Console.WriteLine("Non hai ancora prenotato nessun viaggio.");
                        break;
                    }

                    Console.WriteLine("Inserisci il nome della destinazione da annullare:");
                    string destinazione = Console.ReadLine();

                    PrenotaViaggio viaggioTrovato = viaggi.FirstOrDefault(v => v.Destinazione == destinazione);

                    if (viaggioTrovato != null)
                    {
                        Console.Write("Quante prenotazioni vuoi annullare? ");
                        int daAnnullare = int.Parse(Console.ReadLine());
                        viaggioTrovato.AnnullaPrenotazione(daAnnullare);
                        viaggioTrovato.VisualizzaStato();
                    }
                    else
                    {
                        Console.WriteLine("Destinazione non trovata!");
                    }
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"inserire scelta valida");
                    break;
            }
        } while (sceltaPrenotazione != 0);

    }

    public static void EssEsercito()
    {
        List<Soldato> esercito = new List<Soldato>();
        int sceltaEsercito;

        do
        {
            Console.WriteLine($"Buongiorno Comandante Shepard, cosa vuole fare oggi ?");
            Console.WriteLine($"1: Crea un Fante");
            Console.WriteLine($"2: Crea un Artigliere");
            Console.WriteLine($"3: Vedere tutti i soldati");
            Console.WriteLine($"0: Esci");
            Console.WriteLine();

            sceltaEsercito = int.Parse(Console.ReadLine());

            switch (sceltaEsercito)
            {
                case 1:
                    Fante fante = new Fante();

                    Console.WriteLine($"Come si chiama il nuovo Fante?");
                    string nomeFante = Console.ReadLine();
                    fante.Nome = nomeFante;

                    Console.ReadLine();

                    Console.WriteLine($"Di che grado è il nuovo Fante?");
                    string gradoFante = Console.ReadLine();
                    fante.Grado = gradoFante;

                    Console.WriteLine();

                    Console.WriteLine($"Quanti anni di servizio ha gia il Fante ?");
                    int anniServizioFante = int.Parse(Console.ReadLine());
                    fante.AnniServizio = anniServizioFante;

                    Console.WriteLine();

                    Console.WriteLine($"Che arma ha in dotazione il Fante ?");
                    string armaFante = Console.ReadLine();
                    fante.Arma = armaFante;

                    esercito.Add(fante);

                    Console.WriteLine($"Fante Arruolato con successo!");
                    Console.WriteLine();
                    fante.Descrizione();
                    Console.WriteLine();

                    break;

                case 2:
                    Artigliere artigliere = new Artigliere();

                    Console.WriteLine($"Come si chiama il nuovo Artigliere?");
                    string nomeArtigliere = Console.ReadLine();
                    artigliere.Nome = nomeArtigliere;

                    Console.ReadLine();

                    Console.WriteLine($"Di che grado è il nuovo Artigliere?");
                    string gradoArtigliere = Console.ReadLine();
                    artigliere.Grado = gradoArtigliere;

                    Console.WriteLine();

                    Console.WriteLine($"Quanti anni di servizio ha gia il Artigliere ?");
                    int anniServizioArtigliere = int.Parse(Console.ReadLine());
                    artigliere.AnniServizio = anniServizioArtigliere;

                    Console.WriteLine();

                    Console.WriteLine($"in che calibro è specializzato l'Artigliere ?");
                    int calibroArtigliere = int.Parse(Console.ReadLine());
                    artigliere.Calibro = calibroArtigliere;

                    esercito.Add(artigliere);

                    Console.WriteLine($"Fante Arruolato con successo!");
                    Console.WriteLine();
                    artigliere.Descrizione();
                    Console.WriteLine();

                    break;

                case 3:
                    Console.WriteLine($"Soldati dell'esercito:");
                    foreach (Soldato soldato in esercito)
                    {
                        soldato.Descrizione();
                    }
                    break;

                case 0:
                    Console.WriteLine($"Chiusura del programma");
                    break;

                default:
                    Console.WriteLine($"inserire una scelta valida!");
                    break;
            }

        } while (sceltaEsercito != 0);
    }

    public static void EssOfficina()
    {
        List<Veicolo> veicoli = new List<Veicolo>();

        Auto a1 = new Auto("AB 123 BA");
        Console.WriteLine();
        veicoli.Add(a1);

        Moto m1 = new Moto("IT 12345");
        Console.WriteLine();
        veicoli.Add(m1);

        Camion c1 = new Camion("AZ 321 ZA");
        Console.WriteLine();
        veicoli.Add(c1);

        foreach (Veicolo v in veicoli)
        {
            Console.WriteLine(v.Targa);
            v.Ripara();
            Console.WriteLine();
        }
    }
}
