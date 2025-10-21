using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssEnum
{
    #region ENUM 
    public enum TipoNotifica
    {
        EMAIL,
        SMS,
        PUSH
    }
    #endregion

    #region INTERFACCE
    public interface INNotifier
    {
        void Invia(string messaggio);
    }
    #endregion

    #region CLASSI CONCRETE
    public class EmailNNotifier : INNotifier
    {
        public void Invia(string messaggio) => Console.WriteLine($"[EMAIL] {messaggio}");
    }

    public class SmsNNotifier : INNotifier
    {
        public void Invia(string messaggio) => Console.WriteLine($"[SMS] {messaggio}");
    }

    public class PushNNotifier : INNotifier
    {
        public void Invia(string messaggio) => Console.WriteLine($"[PUSH] {messaggio}");
    }
    #endregion

    #region FACTORY
    public class NNotifyFactory
    {
        public static INNotifier CreaNotifica(TipoNotifica tipo)
        {
            return tipo switch
            {
                TipoNotifica.EMAIL => new EmailNNotifier(),
                TipoNotifica.SMS => new SmsNNotifier(),
                TipoNotifica.PUSH => new PushNNotifier(),
                _ => new EmailNNotifier()
            };
        }
    }
    #endregion

    #region SERVICE
    public class MessaggioService
    {
        private readonly INNotifier _notifier;
        public MessaggioService(INNotifier notifier)
        {
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }

        public void InviaMessaggio(string messaggio)
        {
            _notifier.Invia(messaggio);
        }
    }
    #endregion
}