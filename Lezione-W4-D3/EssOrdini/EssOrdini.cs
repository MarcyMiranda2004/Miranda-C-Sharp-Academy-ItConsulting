using System.Data.Common;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lezione_W4_D3.EssOrdini.Domain
{
    #region RECORD
    // record delle varie entity, uso il report per ridurre la boilerplate delle classi che hanno solo dati
    public record Product(Guid Id, string Name, decimal Price);

    public record Customer(Guid Id, string Name, string Email);

    public record OrderItem(Product product, int quantity)
    {
        public decimal total => product.Price * quantity;
    }
    #endregion

    #region ENUM
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
        public Guid IdOrder { get; init; }
        public Guid IdCustomer { get; init; }
        public List<OrderItem> _items { get; } = new();
        public OrderStatus Status { get; private set; }
        public decimal SubTotal => _items.Sum(i => i.total); // uso il metodo sum delle list per sommare i vari totali di tutti i prodotti nella list

        public Order(Guid idCustomer) => IdCustomer = idCustomer;

    }
    #endregion
}