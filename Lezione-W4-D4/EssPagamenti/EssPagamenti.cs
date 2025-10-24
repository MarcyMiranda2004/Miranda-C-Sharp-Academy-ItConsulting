using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D4.EssPagamenti
{
    #region ENUM
    public enum PaymentType
    {
        CARD,
        PAYPAL,
        BONIFICO
    }
    #endregion

    #region INTERFACCE
    public interface IPayment
    {
        void Pay(decimal amount, string currency);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public interface IDiscountPolicy
    {
        decimal Discount(decimal amount);
    }
    #endregion

    #region CLASSI CONCRETE
    public class CardPayment : IPayment
    {
        public void Pay(decimal amount, string currency) => Console.WriteLine($"[PAGAMENTO] Il tuo pagamento tramite Carta di {amount}{currency} è andato a buon fine");
    }

    public class PayPalPayment : IPayment
    {
        public void Pay(decimal amount, string currency) => Console.WriteLine($"[PAGAMENTO] Il tuo pagamento tramite PayPal di {amount}{currency} è andato a buon fine");
    }

    public class BonificoPayment : IPayment
    {
        public void Pay(decimal amount, string currency) => Console.WriteLine($"[PAGAMENTO] Il tuo pagamento tramite Bonifico di {amount}{currency} è andato a buon fine");
    }

    public class Logger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"[LOG] {message}");
    }

    public class DiscountPolicy
    {
        public decimal Discount(decimal amount)
        {
            if (amount > 50) { return amount -= amount * 50 / 100; }
            return amount;
        }
    }
    #endregion

    #region FACTORY
    public class PaymentFactory
    {
        public static IPayment CreaPagamento(PaymentType type)
        {
            return type switch
            {
                PaymentType.CARD => new CardPayment(),
                PaymentType.PAYPAL => new PayPalPayment(),
                PaymentType.BONIFICO => new BonificoPayment(),
                _ => new CardPayment()
            };
        }
    }
    #endregion

    #region SERVICE - DELEGATE
    public class PaymentService
    {
        private IPayment _payment;
        private ILogger _logger;
        private IDiscountPolicy _discountPolicy;

        public PaymentService(IPayment payment, ILogger logger, IDiscountPolicy discountPolicy)
        {
            _payment = payment;
            _logger = logger;
            _discountPolicy = discountPolicy;
        }

        public delegate void PaymentCompleteHandler(string id, decimal amount);

        public event PaymentCompleteHandler OnPaymentComplete;

        public void CompletePayment(string paymentId, decimal amount, string currency)
        {
            decimal finalAmount = _discountPolicy != null ? _discountPolicy.Discount(amount) : amount;

            _payment.Pay(finalAmount, currency);

            _logger?.Log($"Pagamento {paymentId} completato: {finalAmount}{currency}");

            OnPaymentComplete?.Invoke(paymentId, finalAmount);
        }
    }
    #endregion


}