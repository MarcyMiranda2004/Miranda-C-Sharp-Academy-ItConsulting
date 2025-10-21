using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Lezione_W4_D2.EssBookHub
{
    #region INTERFACCE
    public interface IInventoryService
    {
        void StockStatus();
    }

    public interface IPaymentProcessor
    {
        void Paga(int totale);
    }

    public interface IProdotto
    {
        void TipoProdotto();
    }

    public interface INotificationSender //opzionale 
    {
        void EmailSend();
        void SmsSend();
        void PushSend();
    }

    public interface IPricingStrategy
    {
        double CalcolaPrezzo(double prezzoBase);
    }
    #endregion

    #region CLASSI CONCRETE
    public class Libro : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Libro");

        }
    }

    public class Fumetto : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Fumetto");

        }
    }

    public class Rivista : IProdotto
    {
        public void TipoProdotto()
        {
            Console.WriteLine($"Tipo: Rivista");

        }
    }

    public class PaypalProcessor : IPaymentProcessor
    {
        public void Paga(int totale) => Console.WriteLine($"Pagamento di {totale}€ con PayPal completato.");
    }

    public class StripeProcessor : IPaymentProcessor
    {
        public void Paga(int totale) => Console.WriteLine($"Pagamento di {totale}€ con Stripe completato.");
    }

    public class StrategyPrezzoBase : IPricingStrategy
    {
        public double CalcolaPrezzo(double prezzoBasa) => prezzoBasa;
    }

    public class StrategySconto : IPricingStrategy
    {
        public double CalcolaPrezzo(double prezzoBasa) => prezzoBasa - (prezzoBasa * 10 / 100);
    }
    #endregion

    #region FACTORY
    public class ProductFactory
    {
        public static IProdotto CreaProdotto(string tipo)
        {
            return tipo.ToUpper() switch
            {
                "LIBRO" => new Libro(),
                "FUMETTO" => new Fumetto(),
                "RIVISTA" => new Rivista(),
                _ => throw new ArgumentException("Tipo prodotto non valido.")
            };
        }
    }

    public class GatewayFactory
    {
        public static IPaymentProcessor CreaGateway(string tipo)
        {
            return tipo.ToUpper() switch
            {
                "PAYPAL" => new PaypalProcessor(),
                "STRIVE" => new StripeProcessor(),
                _ => throw new ArgumentException("Metodo di pagamento non valido")
            };
        }
    }
    #endregion

    #region SERVICE
    public class InventoryService : IInventoryService
    {
        public void StockStatus() => Console.WriteLine($"Stock verificato");
    }

    public class NotificationService : INotificationSender
    {
        public void EmailSend() => Console.WriteLine($"Email di conferma inviata");

        public void SmsSend() => Console.WriteLine($"SMS di conferma inviato");

        public void PushSend() => Console.WriteLine($"Notifica Push di conferma inviata");
    }

    public class OrderService
    {
        private readonly IInventoryService _inventoryService;
        private readonly IPaymentProcessor _paymentProcessor;

        // Constructor Injection
        public OrderService(IInventoryService inventoryService, IPaymentProcessor paymentProcessor)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
            _paymentProcessor = paymentProcessor ?? throw new ArgumentNullException(nameof(paymentProcessor));
        }

        // Setter Injection
        public INotificationSender NotificationSender { private get; set; }
        public IPricingStrategy PricingStrategy { private get; set; }

        public void InvioOrdine(IProdotto prodotto, double prezzoBase)
        {
            prodotto.TipoProdotto();
            _inventoryService.StockStatus();

            if (prezzoBase >= 50)
            {
                PricingStrategy = new StrategySconto();
            }
            else
            {
                PricingStrategy = new StrategyPrezzoBase();
            }

            double prezzoFinale = PricingStrategy.CalcolaPrezzo(prezzoBase);
            Console.WriteLine($"Prezzo finale: {prezzoFinale}€");

            _paymentProcessor.Paga((int)prezzoFinale);

            NotificationSender.EmailSend();
        }
    }
    #endregion
}