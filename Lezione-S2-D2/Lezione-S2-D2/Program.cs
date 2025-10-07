using GestioneLibro;
using GestioneMacchina;
using GestioneUtente;
using GestioneFilm;

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

}