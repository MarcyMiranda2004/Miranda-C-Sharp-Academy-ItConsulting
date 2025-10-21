namespace Lezione_W4_D2.EssAlertService
{
    #region INTERFACCE
    public interface IAlertNotifier
    {
        void Notify(string messaggio);
    }
    #endregion

    #region CLASSI CONCRETE
    public class AlertSmsNotifier : IAlertNotifier
    {
        public void Notify(string messaggio)
        {
            Console.WriteLine($"[SMS] {messaggio}");
        }
    }

    public class AlertService
    {
        public void SendAlert(string messaggio, IAlertNotifier notifier)
        {
            notifier.Notify($"[AlertService] {messaggio}");
        }
    }

    #endregion
}