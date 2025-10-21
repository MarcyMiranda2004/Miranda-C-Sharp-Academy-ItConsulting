using System;
using Lezione_W4_D2.EssPrinter;
using Lezione_W4_D2.EssFileUploader;
using Lezione_W4_D2.EssBookHub;
using Lezione_W4_D2.MethodInjection;
using Lezione_W4_D2.EssAlertService;
using Lezione_W4_D2.EssDataExporter;
using Lezione_W4_D2.ConstructorInjection;
using Lezione_W4_D2.EssEnum;
using System.Text;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int scelta;

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Che Esercizio vuoi vedere ?");
                Console.WriteLine($"[1] Setter Injection");
                Console.WriteLine($"[2] Printer");
                Console.WriteLine($"[3] Upload File");
                Console.WriteLine($"[4] Book Hub");
                Console.WriteLine($"[5] Method Injection");
                Console.WriteLine($"[6] Alert Service");
                Console.WriteLine($"[7] Data Exporter");
                Console.WriteLine($"[8] Constructor Injection");
                Console.WriteLine($"[9] Livelli di Accesso");
                Console.WriteLine($"[10] Transazioni");

                Console.WriteLine($"[0] Esci");
                Console.WriteLine($"Scelta:");
                scelta = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (scelta)
                {
                    case 1:
                        EsempioSetterInjection();
                        break;

                    case 2:
                        EssPrinter();
                        break;

                    case 3:
                        EssFileUpload();
                        break;

                    case 4:
                        EssBookHub();
                        break;

                    case 5:
                        EsempioMethodInjection();
                        break;

                    case 6:
                        EssAlertService();
                        break;

                    case 7:
                        EssDataExporter();
                        break;

                    case 8:
                        EsempioConstructorInjection();
                        break;

                    case 9:
                        EssLvAccesso();
                        break;

                    case 10:
                        EssTransazioni();
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

        public static void EsempioSetterInjection()
        {
            var generator = new ReportGenerator();
            generator.DatabaseService = new SqlDatabaseService();
            generator.GenerateReport();
        }

        public static void EssPrinter()
        {
            var logger = new ConsoleLog();
            var printer = new Printer();

            Console.WriteLine($"Inserisci il testo da loggare:");
            string testo = Console.ReadLine();
            Console.WriteLine();

            // Senza logger
            printer.Print($"No Logger: {testo}");
            Console.WriteLine();

            // Con dipendenza impostata dal set
            printer.logger = new ConsoleLog();
            printer.Print($"(1) SetInjPrint: {testo}");
        }

        public static void EssFileUpload()
        {
            // Scegli la strategia di storage (Disk o Memory)
            IStorageService storage = new MemoryStorageService();
            // Esempio alternativo su disco:
            // IStorageService storage = new DiskStorageService(Path.Combine(Environment.CurrentDirectory, "uploads"));

            var uploader = new FileUploader(storage);

            // File “simulato”
            var fakeBytes = Encoding.UTF8.GetBytes("Contenuto di esempio");
            uploader.Upload("report.txt", fakeBytes);

            Console.WriteLine("\n[Fine Constructor Injection] Premi un tasto per uscire.");
            Console.ReadKey();
        }

        public static void EssBookHub()
        {
            Console.WriteLine($"Che articolo vuoi acquistare ?");

            // Scelta prodotto
            Console.WriteLine("Scegli il tipo di prodotto da acquistare:");
            Console.WriteLine(" - LIBRO");
            Console.WriteLine(" - FUMETTO");
            Console.WriteLine(" - RIVISTA");
            Console.Write("Inserisci il tipo: ");
            string tipoProdotto = Console.ReadLine();

            IProdotto prodotto = ProductFactory.CreaProdotto(tipoProdotto);

            // Prezzo base
            Console.Write("\nInserisci il prezzo base (€): ");
            if (!double.TryParse(Console.ReadLine(), out double prezzoBase))
            {
                Console.WriteLine("Prezzo non valido. Riprova.");
                return;
            }

            // Scelta metodo di pagamento
            Console.WriteLine("\nScegli il metodo di pagamento:");
            Console.WriteLine(" - PAYPAL");
            Console.WriteLine(" - STRIPE");
            Console.Write("Inserisci il metodo: ");
            string metodoPagamento = Console.ReadLine();

            IPaymentProcessor paymentProcessor = GatewayFactory.CreaGateway(metodoPagamento);

            // Creazione servizi obbligatori
            IInventoryService inventoryService = new InventoryService();

            // Constructor Injection
            OrderService ordine = new OrderService(inventoryService, paymentProcessor);

            // Setter Injection (opzionale)
            ordine.NotificationSender = new NotificationService();

            // Invio ordine
            Console.WriteLine("\n--- Elaborazione ordine ---\n");
            ordine.InvioOrdine(prodotto, prezzoBase);

            Console.WriteLine("\nOrdine completato con successo!");

        }

        public static void EsempioMethodInjection()
        {
            INotifier notifier = new EmailNotifier();
            var service = new MethodInjNotificationService();
            service.SendNotification("Luca", notifier);
        }

        public static void EssAlertService()
        {
            var alertService = new AlertService();

            // Metodo SMS
            var smsNotifier = new AlertSmsNotifier();
            alertService.SendAlert("Sistema in manutenzione!", smsNotifier);
        }

        public static void EssDataExporter()
        {
            var data = new Data
            {
                Nome = "Report vendite",
                Contenuto = "Totale vendite: 1200€"
            };

            var exporter = new DataExporter();

            Console.WriteLine("Scegli il formato di esportazione:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            Console.Write("Scelta: ");
            int scelta = int.Parse(Console.ReadLine());

            IExportFormatter formatter = scelta switch
            {
                1 => new ExportJSONStrategy(),
                2 => new ExportXMLStrategy(),
                _ => new ExportJSONStrategy()
            };

            exporter.Export(data, formatter);
        }

        public static void EsempioConstructorInjection()
        {
            ConsInjILogger logger = new ConsoleLogger();
            UserService userService = new UserService(logger);
            userService.CreateUser("Alice");
        }

        public static void EssLvAccesso()
        {
            var accessService = new LvAccesso();

            Console.WriteLine("Scegli il livello di accesso:");
            Console.WriteLine("[1] Guest");
            Console.WriteLine("[2] Utente");
            Console.WriteLine("[3] Moderatore");
            Console.WriteLine("[4] Admin");
            Console.Write("Scelta: ");

            int scelta = int.Parse(Console.ReadLine());

            var livello = scelta switch
            {
                1 => LivelloAccesso.OSPITE,
                2 => LivelloAccesso.USER,
                3 => LivelloAccesso.ADMIN,
                _ => LivelloAccesso.OSPITE
            };

            accessService.Privilegi(livello);
        }

        public static void EssTransazioni()
        {

        }
    }
}