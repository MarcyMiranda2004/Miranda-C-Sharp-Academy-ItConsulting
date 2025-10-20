using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D1.EssApp
{
    #region CONFIG
    public sealed class AppConfig
    {
        public string nomeApp;
        public string valuta { get; set; } = "EUR";
        public double aliquotaIVA;

        private static readonly Lazy<AppConfig> _lazy = new(() => new AppConfig());
        public static AppConfig Instance => _lazy.Value;

        private AppConfig()
        {
            nomeApp = "MyApp";
            valuta = "EUR";
            aliquotaIVA = 0.22;
        }

        public void StampaInfo()
        {
            Console.WriteLine($"\n Nome dell'app: {nomeApp} \n Valuta Usata: {valuta} \n IVA applicata: {aliquotaIVA * 100}%");
        }
    }
    #endregion

    #region INTERFACCE
    public interface ILogger
    {
        public void OrderStatus(string status);
    }
    #endregion


    #region SERVICE
    public class AppLoggerService : ILogger
    {
        private readonly AppConfig _config;

        public AppLoggerService(AppConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
        }

        public void OrderStatus(string status)
        {
            Console.WriteLine($"{_config.nomeApp} {DateTime.Now:HH:mm:ss} - {status}");
        }
    }

    public class OrderService
    {
        private readonly ILogger _logger;
        private int _nextId = 1;

        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreaOrdine(string product, double price)
        {
            int orderId = _nextId++;
            _logger.OrderStatus($"Ordine {orderId} contenente {product} dal prezzo totale di {price:0.00} EUR");
        }

        public void OrdineCompletato(int orderId)
        {
            _logger.OrderStatus($"l'ordine {orderId} è stato completato!");
        }
    }
    #endregion
}