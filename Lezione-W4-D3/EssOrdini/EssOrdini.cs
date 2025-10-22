using System.Data.Common;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lezione_W4_D3.EssOrdini.Domain
{
    #region RECORD
    // record delle varie entity, uso il report per ridurre la boilerplate delle classi che hanno solo dati
    public record Product(Guid Id, string Name, decimal Price, int Stock);

    public record Customer(Guid Id, string Name, string Email);

    public record OrderItem(Product product, int quantity)
    {
        public decimal total => product.Price * quantity; // calcolo del totale
    }
    #endregion

    #region ENUM
    // Enum per gestire i vari status degli ordini
    public enum OrderStatus
    {
        CREATED,
        PAYED,
        SHIPPED,
        DELIVERED,
        CANCELLED
    }
    #endregion

    #region CLASSI
    public class Order
    {
        // vado ad usare delle proprietà al posto di semplici dati cosi che siano gestibili in caso di implementazioni future
        public Guid IdOrder { get; init; }
        public Guid IdCustomer { get; init; }
        public List<OrderItem> _items { get; } = new();
        public OrderStatus Status { get; private set; }
        public decimal SubTotal => _items.Sum(i => i.total); // uso il metodo sum delle list per sommare i vari totali di tutti i prodotti nella list

        public Order(Guid idCustomer) => IdCustomer = idCustomer; //costruttore

        public void AddItem(Product p, int quantity)
        {
            // svolgo i vari controlli all'aggiunta del prodotto alla lista _items dell'ordine creando un OrderItem del prodotto con la quantita desiderata
            if (Status != OrderStatus.CREATED) throw new InvalidOperationException("L'ordine è gia stato pagato, spedito o consegnato, non puoi aggiungere altri prodotti");
            if (quantity > p.Stock) throw new InvalidOperationException("Il Prodotto non è sufficiente nelle quantità desiderate");
            if (quantity <= 0) throw new ArgumentException("La quantita del prodotto eve essere almeno di 1");
            _items.Add(new OrderItem(p, quantity));
        }

    }
    #endregion

    #region INTERFACCE
    // interfaccia repository che serve nella gestione "Esterna" della memoria dei vari prodotti, cosi ch si possa richiamare anche altrove
    public interface IOrderRepository
    {
        Order? GetById(Guid Id); // prende il prodotto tramite l'id
        void Add(Order order); // aggiunge un ordine
        void Update(Order order); // modifica un ordine
        void Delete(Guid Id); // elimina un ordine
        IEnumerable<Order> List(); // restituisce una lista enumerabile degli ordini presenti nella repository
    }

    // Replico il Repository di Order per gestire anche i Product
    public interface IProductRepository
    {
        Product? GetById(Guid Id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        IEnumerable<Product> List();
    }

    public interface INotification
    {
        void EmailNotify(string email, string message);
    }

    public interface IConfiguration
    {
        decimal Iva { get; }
        string Valuta { get; }
    }
    #endregion

    #region SINGLETON
    public sealed class Configuration : IConfiguration
    {
        public decimal Iva { get; }
        public string Valuta { get; }
        private Configuration(decimal iva, string valuta)
        {
            Iva = iva;
            Valuta = valuta;
        }
        private static readonly Lazy<Configuration> _config = new(() => new Configuration(0.22m, "EUR"));

        public static Configuration Instance = _config.Value;
    }
    #endregion
}