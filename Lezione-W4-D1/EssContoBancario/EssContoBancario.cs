using System;
using System.Collections.Generic;

namespace Lezione_W4_D1.EssContoBancario
{
    #region SINGLETON - CONTEXT - OBSERVER - STRATEGY
    /// <summary>
    /// Classe principale che rappresenta il contesto dell’applicazione bancaria.
    /// Implementa i pattern Singleton, Strategy e Observer.
    /// </summary>
    public sealed class BankContext
    {
        // Singleton thread-safe e lazy: l’istanza viene creata solo al primo utilizzo
        private static readonly Lazy<BankContext> _lazy = new(() => new BankContext());
        public static BankContext Instance => _lazy.Value;

        // “Finti” database in memoria rappresentati da dizionari
        public readonly Dictionary<int, Cliente> Clienti = new();
        public readonly Dictionary<int, IConto> Conti = new();
        public readonly Dictionary<int, List<Operazione>> OperazioniPerConto = new();

        // Generatori ID incrementali
        private int _nextClienteId = 1;
        private int _nextContoId = 100;

        // Valuta della banca
        public string Valuta { get; set; } = "EUR";

        // Strategy attuale per il calcolo di interessi e commissioni
        public ICalcoloInteressi Strategy { get; private set; } = new StandardStrategy();

        // Lista di observer iscritti (pattern Observer)
        private readonly List<IObserver> _observers = new();

        // Costruttore privato per impedire la creazione esterna (Singleton)
        private BankContext() { }

        // --- Metodi “API” di contesto ---
        public int NuovoClienteId() => _nextClienteId++;
        public int NuovoContoId() => _nextContoId++;

        /// <summary>
        /// Imposta una nuova strategy e notifica il cambiamento agli observer.
        /// </summary>
        public void SetStrategy(ICalcoloInteressi strategy)
        {
            Strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            NotifyAll(new EventoSistema(EventType.StrategyChanged,
                $"Strategy attiva: {strategy.GetType().Name}"));
        }

        /// <summary>
        /// Aggiunge un observer (se non nullo) alla lista di sottoscrittori.
        /// </summary>
        public void Subscribe(IObserver observer)
        {
            if (observer == null) return;
            _observers.Add(observer);
        }

        /// <summary>
        /// Notifica a tutti gli observer un evento del sistema.
        /// </summary>
        public void NotifyAll(EventoSistema ev)
        {
            foreach (var observer in _observers)
                observer.OnNotify(ev);
        }
    }
    #endregion

    #region ENTITÀ DI DOMINIO E FACTORY

    /// <summary>
    /// Classe concreta che rappresenta un cliente.
    /// </summary>
    public class Cliente
    {
        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }

    /// <summary>
    /// Interfaccia base per i conti bancari.
    /// </summary>
    public interface IConto
    {
        int Id { get; }
        int ClienteId { get; }
        string Tipo { get; }
        decimal Saldo { get; }

        void Deposita(decimal importo);
        bool Preleva(decimal importo);
    }

    /// <summary>
    /// Classe astratta base per i conti (usata dal Factory).
    /// </summary>
    public abstract class ContoBaseAbs : IConto
    {
        public int Id { get; }
        public int ClienteId { get; }
        public string Tipo { get; protected set; }
        public decimal Saldo { get; protected set; }

        protected ContoBaseAbs(int id, int clienteId, string tipo, decimal saldoIniziale = 0m)
        {
            Id = id;
            ClienteId = clienteId;
            Tipo = tipo;
            Saldo = saldoIniziale;
        }

        public virtual void Deposita(decimal importo)
        {
            if (importo <= 0) throw new ArgumentException("Importo non valido, Devi depositare almeno 1 euro");

            Saldo += importo;
        }

        public virtual bool Preleva(decimal importo)
        {
            if (importo <= 0 || Saldo < importo) { return false; }

            Saldo -= importo;
            return true;
        }
    }

    // Implementazioni concrete dei vari tipi di conto
    public class ContoBase : ContoBaseAbs
    {
        public ContoBase(int id, int clienteId) : base(id, clienteId, "Base") { }
    }

    public class ContoPremium : ContoBaseAbs
    {
        public ContoPremium(int id, int clienteId) : base(id, clienteId, "Premium") { }
    }

    public class ContoStudent : ContoBaseAbs
    {
        public ContoStudent(int id, int clienteId) : base(id, clienteId, "Student") { }
    }

    /// <summary>
    /// Factory per la creazione di conti bancari.
    /// </summary>
    public static class ContoFactory
    {
        public static IConto Crea(string tipo, int clienteId)
        {
            var ctx = BankContext.Instance;
            int id = ctx.NuovoContoId();

            return tipo.ToUpper() switch
            {
                "BASE" => new ContoBase(id, clienteId),
                "PREMIUM" => new ContoPremium(id, clienteId),
                "STUDENT" => new ContoStudent(id, clienteId),
                _ => throw new ArgumentException("Tipo conto non supportato.")
            };
        }
    }

    #endregion

    #region STRATEGY - INTERESSI E COMMISSIONI

    /// <summary>
    /// Interfaccia della Strategy per il calcolo interessi e commissioni.
    /// </summary>
    public interface ICalcoloInteressi
    {
        decimal CalcolaDeltaInteressi(IConto conto);
        decimal CalcolaCommissioneTrasferimento(IConto from, decimal importo);
    }

    /// <summary>
    /// Strategy standard con interessi bassi e commissione fissa.
    /// </summary>
    public class StandardStrategy : ICalcoloInteressi
    {
        public decimal CalcolaDeltaInteressi(IConto conto)
        {
            // +0.1% su tutti i conti
            return Math.Round(conto.Saldo * 0.001m, 2);
        }

        public decimal CalcolaCommissioneTrasferimento(IConto from, decimal importo)
        {
            // Commissione fissa di 0.50 €
            return 0.50m;
        }
    }

    /// <summary>
    /// Strategy promozionale con interessi più alti e commissioni ridotte.
    /// </summary>
    public class PromoStrategy : ICalcoloInteressi
    {
        public decimal CalcolaDeltaInteressi(IConto conto)
        {
            decimal rate = conto.Tipo switch
            {
                "Premium" => 0.0025m,
                "Student" => 0.0020m,
                _ => 0.0015m
            };
            return Math.Round(conto.Saldo * rate, 2);
        }

        public decimal CalcolaCommissioneTrasferimento(IConto from, decimal importo)
        {
            if (importo < 100m) return 0m;
            var c = Math.Round(importo * 0.003m, 2);
            return c < 0.20m ? 0.20m : c;
        }
    }

    #endregion

    #region OBSERVER - EVENTI DI SISTEMA

    public enum EventType
    {
        ClienteCreato,
        ContoCreato,
        Deposito,
        Prelievo,
        Trasferimento,
        StrategyChanged,
        InteressiApplicati,
        Errore
    }

    /// <summary>
    /// Record che rappresenta un evento di sistema.
    /// </summary>
    public record EventoSistema(EventType Tipo, string Messaggio);

    /// <summary>
    /// Interfaccia per i listener del sistema.
    /// </summary>
    public interface IObserver
    {
        void OnNotify(EventoSistema ev);
    }

    /// <summary>
    /// Implementazione di Observer che scrive gli eventi sulla console.
    /// </summary>
    public class ConsoleLogger : IObserver
    {
        public void OnNotify(EventoSistema ev)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {ev.Tipo}: {ev.Messaggio}");
        }
    }

    #endregion

    #region SERVIZI DI BUSINESS (BANK SERVICE)

    /// <summary>
    /// Classe statica che gestisce le operazioni bancarie (CRUD e movimenti).
    /// </summary>
    public static class BankService
    {
        private static BankContext Ctx => BankContext.Instance;

        // === CLIENTI ===
        public static Cliente CreaCliente(string nome, string email)
        {
            int id = Ctx.NuovoClienteId();
            var nuovoCliente = new Cliente(id, nome, email);
            Ctx.Clienti.Add(id, nuovoCliente);
            Ctx.NotifyAll(new EventoSistema(EventType.ClienteCreato, $"Cliente {nome} (Id {id})"));
            return nuovoCliente;
        }

        // === CONTI ===
        public static IConto CreaConto(int clienteId, string tipo)
        {
            if (!Ctx.Clienti.ContainsKey(clienteId))
                throw new ArgumentException("Cliente inesistente.");

            var nuovoConto = ContoFactory.Crea(tipo, clienteId);
            Ctx.Conti.Add(nuovoConto.Id, nuovoConto);
            Ctx.OperazioniPerConto[nuovoConto.Id] = new List<Operazione>();
            Ctx.NotifyAll(new EventoSistema(EventType.ContoCreato,
                $"nuovoConto {nuovoConto.Tipo} Id {nuovoConto.Id} per cliente {clienteId}"));
            return nuovoConto;
        }

        // === OPERAZIONI ===
        private static void AggiungiOperazione(int contoId, string tipo, decimal importo, string descrizione)
        {
            Ctx.OperazioniPerConto[contoId].Add(new Operazione
            {
                Tipo = tipo,
                Importo = importo,
                Descrizione = descrizione
            });
        }

        public static void Deposita(int contoId, decimal importo)
        {
            if (!Ctx.Conti.TryGetValue(contoId, out var conto))
                throw new ArgumentException("Conto inesistente.");

            conto.Deposita(importo);
            AggiungiOperazione(contoId, "DEPOSITO", importo, "Versamento");
            Ctx.NotifyAll(new EventoSistema(EventType.Deposito,
                $"Conto {contoId}: +{importo:0.00} {Ctx.Valuta} (saldo {conto.Saldo:0.00})"));
        }

        public static bool Preleva(int contoId, decimal importo)
        {
            if (!Ctx.Conti.TryGetValue(contoId, out var conto))
                throw new ArgumentException("Conto inesistente.");

            bool ok = conto.Preleva(importo);
            if (ok)
            {
                AggiungiOperazione(contoId, "PRELIEVO", importo, "Prelievo");
                Ctx.NotifyAll(new EventoSistema(EventType.Prelievo,
                    $"Conto {contoId}: -{importo:0.00} {Ctx.Valuta} (saldo {conto.Saldo:0.00})"));
            }
            else
            {
                Ctx.NotifyAll(new EventoSistema(EventType.Errore,
                    $"Prelievo rifiutato su conto {contoId} (saldo insufficiente o importo non valido)"));
            }
            return ok;
        }

        public static bool Trasferisci(int fromId, int toId, decimal importo)
        {
            if (!Ctx.Conti.TryGetValue(fromId, out var from) || !Ctx.Conti.TryGetValue(toId, out var to))
                throw new ArgumentException("Conto sorgente/destinazione inesistente.");

            decimal commissione = Ctx.Strategy.CalcolaCommissioneTrasferimento(from, importo);
            decimal totale = importo + commissione;

            if (!from.Preleva(totale))
            {
                Ctx.NotifyAll(new EventoSistema(EventType.Errore,
                    $"Trasferimento fallito: saldo insufficiente su {fromId}"));
                return false;
            }

            to.Deposita(importo);
            AggiungiOperazione(fromId, "TRANSFER_OUT", totale, $"A {toId} (incl. comm {commissione:0.00})");
            AggiungiOperazione(toId, "TRANSFER_IN", importo, $"Da {fromId}");

            Ctx.NotifyAll(new EventoSistema(EventType.Trasferimento,
                $"Da {fromId} a {toId}: {importo:0.00} (+comm {commissione:0.00})"));
            return true;
        }

        // === INTERESSI ===
        public static void ApplicaInteressiATutti()
        {
            foreach (var keyValue in Ctx.Conti)
            {
                var conto = keyValue.Value;
                var delta = Ctx.Strategy.CalcolaDeltaInteressi(conto);
                if (delta != 0)
                {
                    conto.Deposita(delta);
                    AggiungiOperazione(conto.Id, "INTERESSI", delta, Ctx.Strategy.GetType().Name);
                    Ctx.NotifyAll(new EventoSistema(EventType.InteressiApplicati,
                        $"Conto {conto.Id}: +{delta:0.00} {Ctx.Valuta} (saldo {conto.Saldo:0.00})"));
                }
            }
        }

        // === REPORT ===
        public static void StampaOperazioniConto(int contoId)
        {
            if (!Ctx.OperazioniPerConto.ContainsKey(contoId))
            {
                Console.WriteLine($"Nessuna operazione per conto {contoId}");
                return;
            }

            Console.WriteLine($"\n== Operazioni conto {contoId} ==");
            foreach (var operazione in Ctx.OperazioniPerConto[contoId])
                Console.WriteLine($"{operazione.Timestamp:yyyy-MM-dd HH:mm:ss} | {operazione.Tipo,-12} | {operazione.Importo,8:0.00} | {operazione.Descrizione}");
        }

        public static void ReportBanca()
        {
            Console.WriteLine("\n== Report banca ==");
            decimal totale = 0m;
            foreach (var conto in Ctx.Conti.Values)
            {
                totale += conto.Saldo;
                Console.WriteLine($"Conto {conto.Id} ({conto.Tipo}) Cliente {conto.ClienteId} -> Saldo: {conto.Saldo:0.00} {Ctx.Valuta}");
            }
            Console.WriteLine($"Totale saldi: {totale:0.00} {Ctx.Valuta}");
        }
    }

    #endregion

    #region MODELLO OPERAZIONE

    /// <summary>
    /// Rappresenta un’operazione bancaria con data, tipo, importo e descrizione.
    /// </summary>
    public class Operazione
    {
        public DateTime Timestamp { get; init; } = DateTime.Now;
        public string Tipo { get; init; } = "";
        public decimal Importo { get; init; }
        public string Descrizione { get; init; } = "";
    }

    #endregion

    #region DEMO APPLICAZIONE

    /// <summary>
    /// Programma di esempio che dimostra l’uso dei pattern implementati.
    /// </summary>
    // public class Program
    // {
    //     public static void Main()
    //     {
    //         var ctx = BankContext.Instance;
    //         ctx.Subscribe(new ConsoleLogger()); // Aggiunge observer

    //         // 1) Creazione clienti
    //         var alice = BankService.CreaCliente("Alice", "alice@example.com");
    //         var bob = BankService.CreaCliente("Bob", "bob@example.com");
    //         var carol = BankService.CreaCliente("Carol", "carol@example.com");

    //         // 2) Creazione conti
    //         var c1 = BankService.CreaConto(alice.Id, "BASE");
    //         var c2 = BankService.CreaConto(bob.Id, "PREMIUM");
    //         var c3 = BankService.CreaConto(carol.Id, "STUDENT");

    //         // 3) Movimenti
    //         BankService.Deposita(c1.Id, 500m);
    //         BankService.Deposita(c2.Id, 1200m);
    //         BankService.Deposita(c3.Id, 300m);

    //         BankService.Preleva(c1.Id, 100m);
    //         BankService.Trasferisci(c2.Id, c1.Id, 250m);

    //         // 4) Cambio strategy + applicazione interessi
    //         ctx.SetStrategy(new PromoStrategy());
    //         BankService.ApplicaInteressiATutti();

    //         // 5) Consultazioni
    //         BankService.StampaOperazioniConto(c1.Id);
    //         BankService.StampaOperazioniConto(c2.Id);
    //         BankService.ReportBanca();

    //         Console.WriteLine("\nFine demo. Premi Invio per uscire.");
    //         Console.ReadLine();
    //     }
    // }

    #endregion
}
