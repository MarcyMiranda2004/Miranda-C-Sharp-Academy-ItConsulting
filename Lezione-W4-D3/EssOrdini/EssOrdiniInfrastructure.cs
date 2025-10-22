using System.Data.Common;
using Lezione_W4_D3.EssOrdini.Domain;

namespace Lezione_W4_D3.Infrastructure
{
    #region In Memory
    public class OrderInMemory : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _orders = new();
        public IEnumerable<Order> List() => _orders.Values;
        public Order GetById(Guid id) => _orders.TryGetValue(id, out var order) ? order : null;
        public void Add(Order order) => _orders[order.Id] = order;
        public void Update(Order order)
        {
            if (_orders.ContainsKey(order.Id))
            {
                _orders[order.Id] = order;
            }
            else throw new ArgumentException($"L'ordine con id {order.Id} non è stato trovato");
        }

        public void Delete(Guid id) => _orders.Remove(id);

    }

    public class ProductInMemory : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _products = new();
        public IEnumerable<Product> List() => _products.Values;
        public Product GetById(Guid id) => _products.TryGetValue(id, out var product) ? product : null;
        public void Add(Product product) => _products[product.Id] = product;
        public void Update(Product product)
        {
            if (_products.ContainsKey(product.Id))
            {
                _products[product.Id] = product;
            }
            else throw new ArgumentNullException($"Prodotto {product} con id {product.Id} non presente nell'ordine");
        }
        public void Delete(Guid id) => _products.Remove(id);
    }

    #endregion

    #region Notification
    public class Notification : INotification
    {
        public void EmailNotify(string email, string message)
        {
            Console.WriteLine($"[EMAIL] destinatario: {email} | {message}");
        }
    }
    #endregion
}