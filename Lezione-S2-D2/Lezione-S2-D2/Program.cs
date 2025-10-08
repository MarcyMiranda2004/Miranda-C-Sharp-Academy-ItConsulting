using GestioneLibro;
using GestioneMacchina;
using GestioneUtente;
using GestioneFilm;
using GestioneCane;
using GestioneGatto;
using GestioneUccello;
using GestioneVeicolo;
using GestioneAuto;
using GestioneMoto;
using GestioneCorso;
using GestioneCorsoMusica;
using GestioneCorsoPittura;
using GestioneCorsoDanza;

class Program
{
    static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"Ciao, Che esercizio vuoi vedere ?");
            Console.WriteLine($"1: Libro");
            Console.WriteLine($"2: Macchina");
            Console.WriteLine($"3: Film");
            Console.WriteLine($"4: Animale");
            Console.WriteLine($"5: Garage");
            Console.WriteLine($"6: Scuola");


            Console.WriteLine();

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    EssLibro();
                    break;

                case 2:
                    EssMacchina();
                    break;

                case 3:
                    EssFilm();
                    break;

                case 4:
                    EssAnimale();
                    break;

                case 5:
                    EssGarage();
                    break;

                case 6:
                    EssScuola();
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

    public static void EssLibro()
    {
        Libro l1 = new Libro("The Lord Of The Rings: The Fellowship Of The Ring", "Tolkien", 1954);
        Libro l2 = new Libro("The Lord Of The Rings: The Fellowship Of The Ring", "Tolkien", 1954);

        Console.WriteLine($"ToString:");
        Console.WriteLine(l1.ToString());
        Console.WriteLine(l2.ToString());
        Console.WriteLine();

        Console.WriteLine($"Equals:");
        Console.WriteLine($"l1 == l2 ? {l1.Equals(l2)}");
        Console.WriteLine();

        Console.WriteLine("Test GetHashCode:");
        Console.WriteLine($"Hash l1: {l1.GetHashCode()}");
        Console.WriteLine($"Hash l2: {l2.GetHashCode()}");
    }

    public static void EssMacchina()
    {
        List<Macchina> macchine = new List<Macchina>();
        List<Utente> utenti = new List<Utente>();

        Console.WriteLine($"Benvenuto da Los Santos Customs, Inserisci i tuoi dati per iniziare la modifica");
        Console.WriteLine();

        Console.Write("Inserisci il tuo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Inserisci il tuo Cognome: ");
        string cognome = Console.ReadLine();

        Console.Write("crediti iniziale: 5");
        int crediti = 5;

        Utente utente = new Utente(nome, cognome, crediti);
        utenti.Add(utente);

        Macchina macchina = new Macchina("V5 1000c", 120.57f, 500, 0);
        macchine.Add(macchina);

        Macchina.GestisciModifiche(utente, macchina);

    }

    public static void EssFilm()
    {
        List<Film> film = new List<Film>();
        Film f1 = new Film("The Thing", "John Carpenter", 1982, "Horror");
        film.Add(f1);

        Film f2 = new Film("The Mask", "Chuck Russell,", 1994, "Comico");
        film.Add(f2);

        Film f3 = new Film("The Fly", "David Cronenberg", 1986, "Horror/Sci-Fy");
        film.Add(f3);

        Film f4 = new Film("The truman Show", "Peter Weir", 1998, "Comico/Distopico");
        film.Add(f4);

        Film f5 = new Film("The Presence", "Tom Provost", 2010, "Horror");
        film.Add(f5);

        int sceltaFilm;

        do
        {
            Console.WriteLine($"Benvenuto da Blockbaster");
            Console.WriteLine();
            Console.WriteLine($"Cosa vuoi fare?");
            Console.WriteLine($"1: Noleggia Film");
            Console.WriteLine($"2: Stampa Elenco Film");
            Console.WriteLine($"3: Cerca Film Per Genere");

            sceltaFilm = int.Parse(Console.ReadLine());

            switch (sceltaFilm)
            {
                case 1:
                    Film.NoleggiaFilm(film);
                    break;

                case 2:
                    Film.StampaElencoFilm(film);
                    break;

                case 3:
                    Film.CercaGenereFilm(film);
                    break;

                default:
                    Console.WriteLine($"inserire scelta valida!");
                    break;

            }
        } while (sceltaFilm != 0);




    }

    public static void EssAnimale()
    {
        Cane c1 = new Cane();
        c1.FaiVerso();
        c1.Scodinzola();

        Gatto g1 = new Gatto();
        g1.FaiVerso();
        g1.FaLeFusa();

        Uccello u1 = new Uccello();
    }

    public static void EssGarage()
    {
        List<Veicolo> veicoli = new List<Veicolo>();

        Console.WriteLine($"Ben tornato da Los Santos Customs, che cosa vuoi fare oggi?");
        int sceltaVeicolo;

        do
        {
            Console.WriteLine($"\n1: Costruisci una Macchina");
            Console.WriteLine($"2: Costruisci una Moto");
            Console.WriteLine($"3: Stampa lista Veicoli");
            Console.WriteLine($"0: Esci");
            Console.WriteLine();


            sceltaVeicolo = int.Parse(Console.ReadLine());

            switch (sceltaVeicolo)
            {
                case 1:
                    Console.Write("Marca: ");
                    string marcaAuto = Console.ReadLine();
                    Console.Write("Modello: ");
                    string modelloAuto = Console.ReadLine();
                    Console.Write("Numero porte: ");
                    int porte = int.Parse(Console.ReadLine());

                    Auto nuovaAuto = new Auto(marcaAuto, modelloAuto, porte);
                    veicoli.Add(nuovaAuto);

                    Console.WriteLine("Auto creata:");
                    nuovaAuto.StampaInfo();
                    break;

                case 2:
                    Console.Write("Marca: ");
                    string marcaMoto = Console.ReadLine();

                    Console.Write("Modello: ");
                    string modelloMoto = Console.ReadLine();

                    Console.Write("Tipo di Manubrio: ");
                    string manubrio = Console.ReadLine();

                    Moto nuovaMoto = new Moto(marcaMoto, modelloMoto, manubrio);
                    veicoli.Add(nuovaMoto);

                    Console.WriteLine("Moto creata:");
                    nuovaMoto.StampaInfo();
                    break;

                case 3:
                    Veicolo.StampaVeicoli(veicoli);
                    break;

                case 0:
                    Console.WriteLine("Uscita dal programma...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

        } while (sceltaVeicolo != 0);
    }

    public static void EssScuola()
    {
        int sceltaCorso;
        List<Corso> corsi = new List<Corso>();

        do
        {
            Console.WriteLine($"Benvenuto nella nostra Scuola, che corso ti interessa ?");
            Console.WriteLine($"1: Aggiungi un corso di Musica");
            Console.WriteLine($"2: Aggiungi un corso di Pittura");
            Console.WriteLine($"3: Aggiungi un corso di Danza");
            Console.WriteLine($"4: Aggiungi uno studente ad un corso");
            Console.WriteLine($"5: Visualizza tutti i corsi");
            Console.WriteLine($"6: Cerca Corsi per nome docente");
            Console.WriteLine($"7: Esegui metodo speciale di un corso");
            Console.WriteLine($"0: Esci");
            Console.WriteLine();

            sceltaCorso = int.Parse(Console.ReadLine());

            switch (sceltaCorso)
            {
                case 1:
                    Console.WriteLine($"Dai un Nome al nuovo Corso di Musica");
                    string nomeMusica = Console.ReadLine();

                    Console.WriteLine($"Dai una Durata al nuovo Corso di Musica");
                    int durataMusica = int.Parse(Console.ReadLine());

                    Console.WriteLine("Assegna un Docente al nuovo Corso di Musica:");
                    string docenteMusica = Console.ReadLine();

                    Console.WriteLine("Aggiungi gli studenti separati da virgola:");
                    string inputStudentiMusica = Console.ReadLine();
                    List<string> studentiMusica = inputStudentiMusica.Split(',').Select(s => s.Trim()).ToList();

                    Console.WriteLine("Inserisci lo strumento principale del corso:");
                    string strumento = Console.ReadLine();

                    CorsoMusica nuovoCorsoMusica = new CorsoMusica(nomeMusica, durataMusica, docenteMusica, studentiMusica, strumento);
                    corsi.Add(nuovoCorsoMusica);

                    break;

                case 2:
                    Console.WriteLine($"Dai un Nome al nuovo Corso di Pittura");
                    string nomePittura = Console.ReadLine();

                    Console.WriteLine($"Dai una Durata al nuovo Corso di Musica");
                    int durataPittura = int.Parse(Console.ReadLine());

                    Console.WriteLine("Assegna un Docente al nuovo Corso di Musica:");
                    string docentePittura = Console.ReadLine();

                    Console.WriteLine("Aggiungi gli studenti separati da virgola:");
                    string inputStudentiPittura = Console.ReadLine();
                    List<string> studentiPittura = inputStudentiPittura.Split(',').Select(s => s.Trim()).ToList();

                    Console.WriteLine("Inserisci la tecnica principale del corso:");
                    string tecnicaPittura = Console.ReadLine();

                    CorsoPittura nuovoCorsoPittura = new CorsoPittura(nomePittura, durataPittura, docentePittura, studentiPittura, tecnicaPittura);
                    corsi.Add(nuovoCorsoPittura);

                    break;

                case 3:
                    Console.WriteLine($"Dai un Nome al nuovo Corso di Danza");
                    string nomeDanza = Console.ReadLine();

                    Console.WriteLine($"Dai una Durata al nuovo Corso di Danza");
                    int durataDanza = int.Parse(Console.ReadLine());

                    Console.WriteLine("Assegna un Docente al nuovo Corso di Danza:");
                    string docenteDanza = Console.ReadLine();

                    Console.WriteLine("Aggiungi gli studenti separati da virgola:");
                    string inputStudentiDanza = Console.ReadLine();
                    List<string> studentiDanza = inputStudentiDanza.Split(',').Select(s => s.Trim()).ToList();

                    Console.WriteLine("Inserisci lo Stile principale del corso:");
                    string stile = Console.ReadLine();

                    CorsoMusica nuovoCorsoDanza = new CorsoMusica(nomeDanza, durataDanza, docenteDanza, studentiDanza, stile);
                    corsi.Add(nuovoCorsoDanza);

                    break;

                case 4:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile!");
                        break;
                    }

                    Console.WriteLine($"inserisci il nome del corso dove aggiungere i nuovo studente.");
                    string nomeCorso = Console.ReadLine();

                    Corso corsoTrovato = corsi.FirstOrDefault(c => c.ToString().Contains(nomeCorso, StringComparison.OrdinalIgnoreCase));

                    if (corsoTrovato != null)
                    {
                        Console.WriteLine("Inserisci il nome dello studente da aggiungere:");
                        string nuovoStudente = Console.ReadLine();
                        corsoTrovato.AggiungiStudente(nuovoStudente);
                        Console.WriteLine($"Studente {nuovoStudente} aggiunto al corso {nomeCorso}!");
                    }
                    else
                    {
                        Console.WriteLine("Corso non trovato!");
                    }


                    break;

                case 5:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile!");
                        break;
                    }

                    Console.WriteLine($"Elenco Corsi:");

                    foreach (Corso corso in corsi)
                    {
                        Console.WriteLine(corso.ToString());
                    }


                    break;

                case 6:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile!");
                        break;
                    }

                    Console.WriteLine($"Inserisci il nome del docente per vedere i suoi corsi");
                    string nomeDocente = Console.ReadLine();

                    Corso CorsoDocenteTrovato = corsi.FirstOrDefault(c => c.ToString().Contains(nomeDocente, StringComparison.OrdinalIgnoreCase));

                    if (CorsoDocenteTrovato == null)
                    {
                        Console.WriteLine($"Nessun corso è  affibbiato a questo docente");
                    }
                    else
                    {
                        Console.WriteLine($"Corsi Trovati:");
                        Console.WriteLine($"{CorsoDocenteTrovato}");
                    }

                    break;

                case 7:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile!");
                        break;
                    }

                    Console.WriteLine($"inserisci il nome del corso per eseguire il Metodo S. P. E. C. I. A. L.");
                    string nomeCorsoSpecial = Console.ReadLine();

                    Corso corsoSpecialTrovato = corsi.FirstOrDefault(c => c.ToString().Contains(nomeCorsoSpecial, StringComparison.OrdinalIgnoreCase));

                    break;

                case 0:
                    Console.WriteLine($"Esco dalla scuola...");
                    break;

                default:
                    Console.WriteLine($"Scelta non valida!");
                    break;
            }

        } while (sceltaCorso != 0);
    }
}