using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(String[] args)
    {
        // FOR
        /* Console.Write("Tabellina");
        Console.WriteLine(" inserisci un numero");

        int n1 = int.Parse(Console.ReadLine());

        Console.WriteLine("La tabellina di " + n1 + " è:");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(n1 + " * " + i + " = " + (n1 * i));
        }



        Console.WriteLine("Calcolo Media");
        Console.WriteLine("Quanti numeri vuoi inserire ?");
        int n2 = int.Parse(Console.ReadLine());
        int n3 = 0;

        for (int i = 0; i < n2; i++)
        {
            Console.WriteLine("Inserisci un numero: ");
            n3 = n3 + int.Parse(Console.ReadLine());
        }

        int media = n3 / n2;
        Console.WriteLine("La media dei tuoi numeri  è: " + media);



        Console.WriteLine("Calcolo fattoriale");
        Console.WriteLine("inserisci un numero:");

        int n4 = int.Parse(Console.ReadLine());
        int fattoriale = 1;

        if (n4 < 0)
        {
            Console.WriteLine("Errore: inserisci un numero positivo");
        }
        else if (n4 == 0)
        {
            Console.WriteLine("il fattoriale di 0 è 1");
        }
        else
        {
            for (int i = 1; i <= n4; i++)
            {
                fattoriale *= i;
            }
            Console.WriteLine("il fattoriale di " + n4 + " è: " + fattoriale);
        } */

        //----------------------------------------------

        /* FOREACH
        Console.WriteLine("Conta i numeri");
        Console.WriteLine("inserisci una frase");

        string frase1 = Console.ReadLine();
        int counter1 = 0;

        foreach (char c in frase1)
        {
            if (char.IsDigit(c))
            {
                counter1++;
            }
        }

        Console.WriteLine("nella tua frase ci sono " + counter1 + " cifre");



        Console.WriteLine("Togli gli spazzi");
        Console.WriteLine("inserisci una frase");

        string frase2 = Console.ReadLine();
        string fraseNoSpace = "";

        foreach (char c in frase2)
        {
            if (!char.IsWhiteSpace(c))
            {
                fraseNoSpace += c;
            }
        }

        Console.WriteLine(fraseNoSpace);



        Console.WriteLine("Conta le vocali");
        Console.WriteLine("Inserisci una frase:");

        string frase3 = Console.ReadLine();
        int counter2 = 0;

        foreach (char c in frase3)
        {
            if ("aAeEiIoOuU".Contains(c))
            {
                counter2++;
            }
        }

        Console.WriteLine("Nella frase ci sono " + counter2 + " vocali");



        Console.WriteLine("Valida password");
        Console.WriteLine("Inserisci la password");

        string password = Console.ReadLine();

        bool haMaiuscola = false;
        bool haNumero = false;
        bool senzaSpazi = true;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
                haMaiuscola = true;

            if (char.IsDigit(c))
                haNumero = true;

            if (c == ' ')
                senzaSpazi = false;
        }

        if (haMaiuscola && haNumero && password.Length >= 8 && senzaSpazi)
        {
            Console.WriteLine("Password accettata");
        }
        else
        {
            Console.WriteLine("Errore, la password deve contenere:");
            if (!haMaiuscola) Console.WriteLine("- almeno una lettera maiuscola");
            if (!haNumero) Console.WriteLine("- almeno una cifra");
            if (password.Length < 8) Console.WriteLine("- almeno 8 caratteri");
            if (!senzaSpazi) Console.WriteLine("- nessuno spazio");
        } */

        //----------------------------------------------

        int scelta;

        do
        {
            Console.WriteLine("\nScegli l'operazione (0 per uscire):");
            Console.WriteLine("1: Stampa Saluto");
            Console.WriteLine("2: Pari o Dispari");
            Console.WriteLine("3: Calcolo Potenza");
            Console.WriteLine("4: Raddoppia");
            Console.WriteLine("5: Aggiusta Data");
            Console.WriteLine("6: Dividi");
            Console.WriteLine("7: Analizza Frase");
            Console.WriteLine("8: Aggiorna Punteggio");
            Console.WriteLine("9: Elabora Studente");


            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il tuo nome:");
                    string nome = Console.ReadLine();
                    stampaSaluto(nome);
                    break;

                case 2:
                    Console.WriteLine("Inserisci un numero:");
                    int n1 = int.Parse(Console.ReadLine());
                    pariDispari(n1);
                    break;

                case 3:
                    Console.WriteLine($"Calcolo Potenza");
                    Console.WriteLine($"inserisci un numero di base");
                    int baseNum = int.Parse(Console.ReadLine());

                    Console.WriteLine($"inserisci un esponente");
                    int esponente = int.Parse(Console.ReadLine());

                    calcoloPotenza(baseNum, esponente);
                    break;

                case 4:
                    Console.WriteLine($"Raddoppia");
                    Console.WriteLine($"Inserisci il numero da raddoppiare");
                    int n2 = int.Parse(Console.ReadLine());
                    raddoppio(ref n2);
                    break;

                case 5:
                    Console.WriteLine($"Aggiusta Data");
                    Console.WriteLine($"inserisci il giorno in numeri");
                    int giorno = int.Parse(Console.ReadLine());

                    Console.WriteLine($"inserisci il mese in numeri");
                    int mese = int.Parse(Console.ReadLine());

                    Console.WriteLine($"inserisci l'anno in numeri");
                    int anno = int.Parse(Console.ReadLine());

                    aggiustaData(ref giorno, mese, anno);

                    break;

                case 6:
                    Console.WriteLine($"Dividi");
                    Console.WriteLine($"inserisci il primo numero");
                    int dividendo = int.Parse(Console.ReadLine());

                    Console.WriteLine($"inserisci il secondo numero");
                    int divisore = int.Parse(Console.ReadLine());

                    int quoziente, resto;

                    dividi(ref dividendo, divisore, out quoziente, out resto);

                    Console.WriteLine($"Quoziente = {quoziente}, Resto = {resto}");

                    break;

                case 7:
                    Console.WriteLine($"Analizza Frase");
                    Console.WriteLine($"Scrivi la parola da Frase");
                    string frase = Console.ReadLine();
                    int nVocali, nConsonanti, nSpazzi;

                    analizzaParola(ref frase, out nVocali, out nConsonanti, out nSpazzi);
                    Console.WriteLine($"Nella frase ci sono {nVocali} vocali, {nConsonanti} consonanti e {nSpazzi} spazi.");

                    break;

                case 8:
                    Console.WriteLine($"Aggiorna Punteggio");
                    break;

                case 9:
                    Console.WriteLine($"Elabora Studente");
                    break;

                case 0:
                    Console.WriteLine("Uscita dal programma...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

        } while (scelta != 0);
    }

    public static void stampaSaluto(string nome)
    {
        Console.WriteLine($"ciao {nome}");
    }

    public static void pariDispari(int n1)
    {
        if (n1 % 2 == 0)
        {
            Console.WriteLine($"Il numero è pari");

        }
        else
        {
            Console.WriteLine($"Il numero è dispari");
        }
    }

    public static void calcoloPotenza(int baseNum, int esponente)
    {
        double risultato = Math.Pow(baseNum, esponente);
        Console.WriteLine($"il risultato è: {risultato}");

    }

    public static void raddoppio(ref int n2)
    {
        Console.WriteLine($"il tuo numero è {n2}");
        n2 = n2 * 2;
        Console.WriteLine($"ma ora è {n2}");
    }

    public static void aggiustaData(ref int giorno, int mese, int anno)
    {
        if (giorno > 31)
        {
            giorno = 1;
            mese++;

            if (mese > 12)
            {
                mese = 1;
                anno++;
                Console.WriteLine($"data aggiustata: {giorno}/{mese}/{anno}");
            }
            else
            {
                Console.WriteLine($"data aggiustata: {giorno}/{mese}/{anno}");
            }

        }
        else if (mese > 12)
        {
            mese = 1;
            anno++;
            Console.WriteLine($"data aggiustata: {giorno}/{mese}/{anno}");
        }
        else
        {
            Console.WriteLine($"data aggiustata: {giorno}/{mese}/{anno}");
        }


    }

    public static void dividi(ref int dividendo, int divisore, out int quoziente, out int resto)
    {
        if (divisore == 0)
        {
            Console.WriteLine("Errore: divisione per zero!");
            quoziente = 0;
            resto = 0;
            return;
        }

        quoziente = dividendo / divisore;
        resto = dividendo % divisore;
    }

    public static void analizzaParola(ref string frase, out int nVocali, out int nConsonanti, out int nSpazzi)
    {
        nVocali = 0;
        nConsonanti = 0;
        nSpazzi = 0;

        foreach (char c in frase)
        {
            if ("aAeEiIoOuU".Contains(c))
            {
                nVocali++;
            }
            else if (char.IsWhiteSpace(c))
            {
                nSpazzi++;
            }
            else if (char.IsLetter(c))
            {
                nConsonanti++;
            }
        }
    }
}
