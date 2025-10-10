namespace GestioneFilm;

class Film
{
    public string Titolo;
    public string Regista;
    public int Anno;
    public string Genere;

    public Film(string titolo, string regista, int anno, string genere)
    {
        Titolo = titolo;
        Regista = regista;
        Anno = anno;
        Genere = genere;
    }

    public static void NoleggiaFilm(List<Film> film)
    {
        if (film.Count == 0)
        {
            Console.WriteLine("Nessun film disponibile per il noleggio.");
            return;
        }

        List<Film> filmSelezionati = new List<Film>();
        bool continua = true;

        Console.WriteLine("\nSeleziona il film da noleggiare (inserisci 0 per terminare):");

        for (int i = 0; i < film.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {film[i].Titolo} ({film[i].Anno}) - {film[i].Genere}");
        }

        while (continua)
        {

            Console.Write("\nNumero del film: ");
            string input = Console.ReadLine();
            int scelta;

            if (int.TryParse(input, out scelta))
            {
                if (scelta == 0)
                {
                    continua = false;
                }
                else if (scelta >= 1 && scelta <= film.Count)
                {
                    Film filmScelto = film[scelta - 1];
                    if (!filmSelezionati.Contains(filmScelto))
                    {
                        filmSelezionati.Add(filmScelto);
                        Console.WriteLine($"Aggiunto '{filmScelto.Titolo}' al noleggio.");
                    }
                    else
                    {
                        Console.WriteLine("Hai già selezionato questo film.");
                    }
                }
                else
                {
                    Console.WriteLine("Numero non valido!");
                }
            }
            else
            {
                Console.WriteLine("Input non valido!");
            }
        }

        if (filmSelezionati.Count > 0)
        {
            Console.WriteLine("\nHai noleggiato i seguenti film:");
            foreach (var f in filmSelezionati)
            {
                Console.WriteLine($"{f.Titolo} ({f.Anno}) - {f.Genere}");
            }
        }
        else
        {
            Console.WriteLine("Non hai selezionato nessun film.");
        }
    }


    public static void StampaElencoFilm(List<Film> film)
    {
        Console.WriteLine($"Film Disponibili: ");
        foreach (var f in film)
        {
            Console.WriteLine($"\n Titolo: {f.Titolo}; \n Regista: {f.Regista} \n Anno: {f.Anno} \n Genere: {f.Genere}");
            Console.WriteLine();
        }
    }

    public static void CercaGenereFilm(List<Film> film)
    {

    }
}