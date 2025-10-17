#region SINGLETON - CONTEXT
public sealed class AppContext
{
    private static AppContext _instance;
    public static AppContext Instance => _instance ??= new AppContext();

    public decimal IVA { get; set; } = 0.22m;
    public string Valuta { get; set; } = "€";

    public event Action<string> EventBus;

    private AppContext() { }

    public void Notify(string messaggio)
    {
        EventBus?.Invoke(messaggio);
    }
}
#endregion

#region CLASSI BASE ASTRATTE
public abstract class ProductAbs
{
    public string Nome { get; set; }
    public decimal PrezzoBase { get; set; }
    public virtual decimal GetPrezzo() => PrezzoBase;
}
#endregion

#region CLASSI BASE CONCRETE
public class TShirt : ProductAbs
{
    public TShirt()
    {
        Nome = "T-Shirt";
        PrezzoBase = 15;
    }
}

public class Mug : ProductAbs
{
    public Mug()
    {
        Nome = "Mug";
        PrezzoBase = 8;
    }
}

public class Skin : ProductAbs
{
    public Skin()
    {
        Nome = "Skin";
        PrezzoBase = 6;
    }
}
#endregion

#region FACTORY 
public class ProductFactory
{
    public static ProductAbs CreaProdotto(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "tshirt":
                return new TShirt();

            case "mug":
                return new Mug();

            case "skin":
                return new Skin();

            default:
                Console.WriteLine($"errore: prodotto inesistente");
                return null;
        }
    }
}
#endregion

#region DECORATOR
public abstract class ProductDecorator : ProductAbs
{
    protected ProductAbs _product;
    public ProductDecorator(ProductAbs product)
    {
        _product = product;
    }

    public override decimal GetPrezzo()
    {
        return _product.GetPrezzo();
    }
}

public class GiftWrap : ProductDecorator
{
    public GiftWrap(ProductAbs product) : base(product)
    {
        Nome = product.Nome + " + Confezione Regalo";
    }
    public override decimal GetPrezzo()
    {
        return _product.GetPrezzo() + 3;
    }
}

public class FrontPrint : ProductDecorator
{
    public FrontPrint(ProductAbs product) : base(product)
    {
        Nome = product.Nome + " + Stampa Frontale";
    }
    public override decimal GetPrezzo()
    {
        return _product.GetPrezzo() + 5;
    }
}

public class DigitalWaranty : ProductDecorator
{
    public DigitalWaranty(ProductAbs product) : base(product)
    {
        Nome = product.Nome + " + Garanzia Digitale";
    }

    public override decimal GetPrezzo()
    {
        return _product.GetPrezzo() + 3;
    }
}
#endregion

#region STRATEGY
public interface IPriceStrategy
{
    decimal CalcolaPrezzo(ProductAbs product);
}

public class StandardPrice : IPriceStrategy
{
    public decimal CalcolaPrezzo(ProductAbs product)
    {
        return product.GetPrezzo() * (1 + AppContext.Instance.IVA);
    }
}


public class PromoPricing : IPriceStrategy
{
    public decimal CalcolaPrezzo(ProductAbs product) => product.GetPrezzo() * 0.8m * (1 + AppContext.Instance.IVA);
}

public class WholesalePricing : IPriceStrategy
{
    public decimal CalcolaPrezzo(ProductAbs product) => product.GetPrezzo() * 0.5m * (1 + AppContext.Instance.IVA);
}

public class DynamicPricing : IPriceStrategy
{
    public decimal CalcolaPrezzo(ProductAbs product)
    {
        // aumenta prezzo del 10% se base < 10
        var price = product.GetPrezzo();
        if (price < 10) price *= 1.1m;
        return price * (1 + AppContext.Instance.IVA);
    }
}
#endregion








