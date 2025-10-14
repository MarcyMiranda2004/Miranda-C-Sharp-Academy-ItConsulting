using EssSistemaConfSis;

// using EssFabbricaVeicolo;
// using EssFabbricaVeicolo.Auto;
// using EssFabbricaVeicolo.Moto;
// using EssFabbricaVeicolo.Camion;
// using EssFabbricaVeicolo.VeicoloFactory;

using EssDraw;
using EssDraw.ShapeCreator;

using EssCreaRegistraVeicolo;
using EssCreaRegistraVeicolo.Auto;
using EssCreaRegistraVeicolo.Moto;
using EssCreaRegistraVeicolo.Camion;
using EssCreaRegistraVeicolo.RegistraVeicoli;
using EssCreaRegistraVeicolo.VeicoloFactory;
using EssConfigSis.Modulo1;
using EssConfigSis.Modulo2;

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
            Console.WriteLine($"[3] Draw");
            Console.WriteLine($"[4] Crea e Registra Veicolo");
            Console.WriteLine($"[5] Configura Sistema");
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
                    // EssFabbricaVeicoli();
                    break;

                case 3:
                    EssDraw();
                    break;

                case 4:
                    EssCreaRegistraVeicolo();
                    break;

                case 5:
                    EssConfig();
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

    // public static void EssFabbricaVeicoli()
    // {
    //     bool continua = true;
    //     string tipoVeicolo;

    //     do
    //     {
    //         Console.WriteLine();
    //         Console.WriteLine($"Inserisci il tipo di veicolo da creare o scrivi Esci per uscire:");
    //         tipoVeicolo = Console.ReadLine();
    //         Console.WriteLine();

    //         if (tipoVeicolo == "Esci") { continua = false; }

    //         IVeicolo nuovoVeicolo = VeicoloFactory.CreaVeicolo(tipoVeicolo);

    //         if (nuovoVeicolo != null)
    //         {
    //             nuovoVeicolo.Avvia();
    //             nuovoVeicolo.MostraTipo();
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Errore: tipo non errato o non presente");
    //         }
    //     } while (continua);
    // }

    public static void EssDraw()
    {
        bool cont = true;
        string drawType;

        do
        {
            Console.WriteLine();
            Console.WriteLine($"Write the shape do you want to draw or Esc for closing de program");
            drawType = Console.ReadLine();
            Console.WriteLine();

            if (drawType == "Esc") { cont = false; }

            IShape newShape = ShapeCreator.CreateShape(drawType);

            if (newShape != null)
            {
                newShape.Draw();
            }
            else
            {
                Console.WriteLine($"Error: Shape type uncorrected or not exist");
            }
        } while (cont);
    }

    public static void EssCreaRegistraVeicolo()
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

            Veicolo nuovoVeicolo = VeicoloFactory.CreaVeicolo(tipoVeicolo);

            RegistraVeicoli rv = RegistraVeicoli.GetInstance();

            if (nuovoVeicolo != null)
            {
                rv.Registra(nuovoVeicolo);
                rv.StampaVeicoli();
            }
            else
            {
                Console.WriteLine($"Errore: tipo non errato o non presente");
            }
        } while (continua);
    }

    public static void EssConfig()
    {
        var modulo1 = new Modulo1();
        var modulo2 = new Modulo2();

        modulo1.Esegui();
        modulo2.Esegui();

        Console.WriteLine($"Modulo 1 e Modulo 2 sono la stessa istanza ? " + Object.ReferenceEquals(ConfigurazioneSistema.Instance, ConfigurazioneSistema.Instance));
        Console.WriteLine();

        ConfigurazioneSistema.Instance.StampaTutte();
        Console.WriteLine();
    }
}