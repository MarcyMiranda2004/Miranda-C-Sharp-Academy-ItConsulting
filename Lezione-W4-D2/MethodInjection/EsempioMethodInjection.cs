namespace Lezione_W4_D2.MethodInjection
{
    public interface INotifier
    {
        void Notify(string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Invio email: {message}");
        }
    }

    public class MethodInjNotificationService
    {
        public void SendNotification(string user, INotifier notifier)
        {
            notifier.Notify($"Ciao {user}, hai una nuova notifica!");
        }
    }

    public class EsempioMethodInjection
    {
        public static void Run()
        {
            INotifier notifier = new EmailNotifier();
            var service = new MethodInjNotificationService();
            service.SendNotification("Luca", notifier);
        }
    }
}
