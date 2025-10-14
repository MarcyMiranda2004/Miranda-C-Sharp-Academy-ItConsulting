using EssSistemaConfSis;
using EssFabbricaVeicolo;
using EssFabbricaVeicolo.Auto;
using EssFabbricaVeicolo.Moto;
using EssFabbricaVeicolo.Camion;
using EssFabbricaVeicolo.VeicoloFactory;

public class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine($"Che esercizio vuoi vedere ?");
            Console.WriteLine($"[1] Sistema");
            Console.WriteLine($"[2] Fabbrica Veicoli");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssSistema();
                    break;

                case 2:
                    EssFabbricaVeicoli();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Inserire una scelta valida!");
                    break;
            }

        } while (scelta != 0);
    }

    public static void EssSistema()
    {
        int sceltaModulo;

        do
        {
            Console.WriteLine($"che Modulo Vuoi Testare?");
            Console.WriteLine($"[1] ModuloA: Tema Scuro");
            Console.WriteLine($"[2] ModuloB: Tema Chiaro");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            sceltaModulo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (sceltaModulo)
            {
                case 1:
                    ModuloA();
                    break;

                case 2:
                    ModuloB();
                    break;

                case 0:
                    Console.WriteLine($"Esco dall'esercizio");
                    break;

                default:
                    Console.WriteLine($"Inserire una scelta valida");
                    break;
            }
        } while (sceltaModulo != 0);
    }

    public static void ModuloA()
    {
        ConfigurazioneSistema config = ConfigurazioneSistema.Instance;
        config.Imposta("Tema", "Scuro");
        Console.WriteLine("ModuloA - Imposta Tema = Scuro");
    }

    public static void ModuloB()
    {
        ConfigurazioneSistema config = ConfigurazioneSistema.Instance;
        config.Imposta("Tema", "Chiaro");
        Console.WriteLine("ModuloB - Imposta Tema = Chiaro");
    }

    public static void EssFabbricaVeicoli()
    {
        bool continua = true;
        string tipoVeicolo;

        do
        {
            Console.WriteLine();
            Console.WriteLine($"Inserisci il tipo di veicolo da creare o scrivi Esci per uscire:");
            tipoVeicolo = Console.ReadLine();
            Console.WriteLine();

            if (tipoVeicolo == "Esci") { continua = false; }

            IVeicolo nuovoVeicolo = VeicoloFactory.CreaVeicolo(tipoVeicolo);

            if (nuovoVeicolo != null)
            {
                nuovoVeicolo.Avvia();
                nuovoVeicolo.MostraTipo();
            }
            else
            {
                Console.WriteLine($"Errore: tipo non errato o non presente");
            }
        } while (continua);


    }
}