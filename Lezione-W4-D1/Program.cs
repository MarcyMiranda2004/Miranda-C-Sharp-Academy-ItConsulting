using Lezione_W4_D1.EssContoBancario;
// using Lezione_W4_D1.DependecyInjection;
using Lezione_W4_D1.EssDependencyInjection.cs;
using Lezione_W4_D1.EssApp;
class Program
{
    public static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine();
            Console.WriteLine($"Che Esercizio vuoi vedere ?");
            Console.WriteLine($"[1] Conto Bancario");
            Console.WriteLine($"[2] Dependency Injection");
            Console.WriteLine($"[3] Greeter");
            Console.WriteLine($"[4] Payment");
            Console.WriteLine($"[5] Order");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine($"Scelta:");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssContoBancario();
                    break;

                case 2:
                    EssDependencyInjection();
                    break;

                case 3:
                    EssGreeter();
                    break;

                case 4:
                    EssPayment();
                    break;

                case 5:
                    EssOrder();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Errore: scelta non valida!");
                    break;
            }

        } while (scelta != 0);
    }

    public static void EssContoBancario()
    {
        var ctx = BankContext.Instance;
        ctx.Subscribe(new ConsoleLogger()); // Aggiunge observer

        // 1) Creazione clienti
        Console.WriteLine("Nuovi Clienti");
        var alice = BankService.CreaCliente("Alice", "alice@example.com");
        var bob = BankService.CreaCliente("Bob", "bob@example.com");
        var carol = BankService.CreaCliente("Carol", "carol@example.com");

        Console.WriteLine();

        // 2) Creazione conti
        Console.WriteLine("Nuovi Conti");
        var c1 = BankService.CreaConto(alice.Id, "BASE");
        var c2 = BankService.CreaConto(bob.Id, "PREMIUM");
        var c3 = BankService.CreaConto(carol.Id, "STUDENT");

        Console.WriteLine();

        // 3) Movimenti
        Console.WriteLine("Deposito nei conti");
        BankService.Deposita(c1.Id, 500m);
        BankService.Deposita(c2.Id, 1200m);
        BankService.Deposita(c3.Id, 300m);

        Console.WriteLine();

        Console.WriteLine("Prelievi dai conti");
        BankService.Preleva(c1.Id, 100m);

        Console.WriteLine();

        Console.WriteLine("Trasferimenti nei Conti");
        BankService.Trasferisci(c2.Id, c1.Id, 250m);

        Console.WriteLine();

        // 4) Cambio strategy + applicazione interessi
        Console.WriteLine("Cambio di Strategia (ora tutti hanno la stessa promozione ma tipi di conti diversi)");
        ctx.SetStrategy(new PromoStrategy());
        BankService.ApplicaInteressiATutti();

        Console.WriteLine();

        // 5) Consultazioni
        Console.WriteLine("Stampa dei resoconti delle operazioni eseguite");
        BankService.StampaOperazioniConto(c1.Id);
        BankService.StampaOperazioniConto(c2.Id);
        BankService.ReportBanca();

        Console.WriteLine();

        Console.WriteLine("\nFine demo. Premi Invio per uscire.");
        Console.ReadLine();
    }

    public static void EssDependencyInjection()
    {
        // ILogger logger = new ConsoleLogger();
        // UserService userService = new UserService(logger);
        // userService.CreateUser("Alice");
    }

    public static void EssGreeter()
    {
        IGreeter greeter = new ConsoleGreeter();

        var app = new GreeterService(greeter);

        Console.WriteLine($"Inserisci il tuo nome:");
        string nome = Console.ReadLine();

        app.Avvia(nome);
    }

    public static void EssPayment()
    {
        Console.WriteLine("Inserisci il metodo di pagamento (PayPal / Stripe):");
        string paymentMethod = Console.ReadLine();

        IPaymentGateway gateway = paymentMethod.ToUpper() switch
        {
            "PAYPAL" => new PayPalGateway(),
            "STRIPE" => new StripeGateway(),
            _ => throw new ArgumentException("Metodo di pagamento non valido")
        };

        gateway.Paga();
    }

    public static void EssOrder()
    {
        AppConfig config = AppConfig.Instance;
        config.StampaInfo();

        Console.WriteLine();

        ILogger logger = new AppLoggerService(config);
        OrderService orderService = new OrderService(logger);

        orderService.CreaOrdine("Caramelle", 1.99);
        orderService.OrdineCompletato(1);

        Console.WriteLine();

        orderService.CreaOrdine("Patatine", 2.99);
        orderService.OrdineCompletato(2);
    }
}