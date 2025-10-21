using System;
using Lezione_W4_D2.EssPrinter;
using Lezione_W4_D2.EssFileUploader;
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
                Console.WriteLine($"Che Esercizio vuoi vedere ?");
                Console.WriteLine($"[1] Setter Injection");
                Console.WriteLine($"[2] Printer");
                Console.WriteLine($"[3] Upload File");

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

        }
    }
}