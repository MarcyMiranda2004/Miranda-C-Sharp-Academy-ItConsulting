using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D1.EssDependencyInjection.cs
{
    #region INTERFACCIA
    public interface IPaymentGateway
    {
        void Paga()
        {
            Console.WriteLine();
            Console.WriteLine($"Pagamento Effettuato!");
        }
    }
    #endregion

    #region CLASSI CONCRETE
    public class PayPalGateway : IPaymentGateway
    {
        public void Paga()
        {
            Console.WriteLine();
            Console.WriteLine($"Pagamento tramite PayPal Effettuato!");
        }
    }

    public class StripeGateway : IPaymentGateway
    {
        public void Paga()
        {
            Console.WriteLine();
            Console.WriteLine($"Pagamento tramite Stripe Effettuato!");
        }
    }
    #endregion

    #region PROCESSOR
    public class PaymentProcessor
    {
        private readonly IPaymentGateway _payment;

        public PaymentProcessor(IPaymentGateway payment)
        {
            _payment = payment ?? throw new ArgumentNullException(nameof(payment));
        }

        public void Paga()
        {
            _payment.Paga();
        }
    }
    #endregion
}