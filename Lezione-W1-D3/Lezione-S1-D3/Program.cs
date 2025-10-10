using Utils;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Avvio programma...");
        int scelta;

        do
        {
            Console.WriteLine("\nChe operazione vuoi effettuare ?");
            Console.WriteLine("1: Somma");
            Console.WriteLine("2: Analizza");
            Console.WriteLine("0: Esci");

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    int sceltaSomma;
                    do
                    {
                        Console.WriteLine("\nChe somma vuoi effettuare ?");
                        Console.WriteLine("1: 2 int");
                        Console.WriteLine("2: 2 double");
                        Console.WriteLine("3: 3 int");
                        Console.WriteLine("0: Torna al menu principale");

                        sceltaSomma = int.Parse(Console.ReadLine());

                        switch (sceltaSomma)
                        {
                            case 1:
                                Console.WriteLine("Inserisci il primo int da sommare:");
                                int a1 = int.Parse(Console.ReadLine());

                                Console.WriteLine("Inserisci il secondo int da sommare:");
                                int b1 = int.Parse(Console.ReadLine());

                                int sommaInt1;
                                Ess1.Somma(ref a1, b1, out sommaInt1);
                                Console.WriteLine($"La somma è: {sommaInt1}");
                                break;

                            case 2:
                                Console.WriteLine("Inserisci il primo double da sommare:");
                                double a2 = double.Parse(Console.ReadLine());

                                Console.WriteLine("Inserisci il secondo double da sommare:");
                                double b2 = double.Parse(Console.ReadLine());

                                double sommaDouble;
                                Ess1.Somma(ref a2, b2, out sommaDouble);
                                Console.WriteLine($"La somma è: {sommaDouble}");
                                break;

                            case 3:
                                Console.WriteLine("Inserisci il primo int da sommare:");
                                int a3 = int.Parse(Console.ReadLine());

                                Console.WriteLine("Inserisci il secondo int da sommare:");
                                int b3 = int.Parse(Console.ReadLine());

                                Console.WriteLine("Inserisci il terzo int da sommare:");
                                int c = int.Parse(Console.ReadLine());

                                int sommaInt2;
                                Ess1.Somma(ref a3, b3, c, out sommaInt2);
                                Console.WriteLine($"La somma è: {sommaInt2}");
                                break;

                            case 0:
                                Console.WriteLine("Tornando al menu principale...");
                                break;

                            default:
                                Console.WriteLine("Scelta non valida!");
                                break;
                        }

                    } while (sceltaSomma != 0);
                    break;

                case 2:
                    int sceltaAnalisi;
                    do
                    {
                        Console.WriteLine("\nChe analisi vuoi effettuare ?");
                        Console.WriteLine("1: Conta Caratteri");
                        Console.WriteLine("2: Conta Carattere Specifico");
                        Console.WriteLine("3: Conta Vocali o Consonanti");
                        Console.WriteLine("0: Torna al menu principale");

                        sceltaAnalisi = int.Parse(Console.ReadLine());

                        switch (sceltaAnalisi)
                        {
                            case 1:
                                Console.WriteLine("Scrivi il testo da analizzare:");
                                string testo1 = Console.ReadLine();
                                int sommaCaratteri;
                                string messaggio = Ess2.Analizza(ref testo1, out sommaCaratteri);
                                Console.WriteLine(messaggio);
                                break;

                            case 2:
                                Console.WriteLine("Scrivi il testo da analizzare:");
                                string testo2 = Console.ReadLine();

                                Console.WriteLine("Quale carattere vuoi trovare?");
                                char carattere = Console.ReadLine()[0];

                                int sommaCarattere;
                                string messaggio2 = Ess2.Analizza(ref testo2, carattere, out sommaCarattere);
                                Console.WriteLine(messaggio2);
                                break;

                            case 3:
                                Console.WriteLine("Inserisci il testo da analizzare:");
                                string testo3 = Console.ReadLine();

                                Console.WriteLine("Vuoi contare le Vocali o le Consonanti? (v/c)");
                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                char sceltaCV = keyInfo.KeyChar;
                                Console.WriteLine();

                                bool contaVocali = false;
                                bool contaConsonanti = false;

                                if (char.ToLower(sceltaCV) == 'v')
                                    contaVocali = true;
                                else if (char.ToLower(sceltaCV) == 'c')
                                    contaConsonanti = true;
                                else
                                {
                                    Console.WriteLine("Errore: inserisci una scelta valida (v/c)");
                                    break;
                                }

                                int risultato = Ess2.Analizza(ref testo3, contaVocali, contaConsonanti);

                                if (contaVocali)
                                    Console.WriteLine($"Numero di vocali: {risultato}");
                                else
                                    Console.WriteLine($"Numero di consonanti: {risultato}");
                                break;

                            case 0:
                                Console.WriteLine("Tornando al menu principale...");
                                break;

                            default:
                                Console.WriteLine("Scelta non valida!");
                                break;
                        }

                    } while (sceltaAnalisi != 0);
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
}
