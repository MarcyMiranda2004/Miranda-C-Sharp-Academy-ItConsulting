namespace GestioneMateriale;

public class Materiale
{
    private string _tipoMateriale;
    public string TipoMateriale { get => _tipoMateriale; set => _tipoMateriale = value; }

    private double _quantitaCm;
    public double QuantitaCm { get => _quantitaCm; set => _quantitaCm = value; }

    private decimal _costoMetroMateriale;
    public decimal CostoMetroMateriale { get => _costoMetroMateriale; set => _costoMetroMateriale = value; }

    public Materiale(string tipoMateriale, double quantitaCm, decimal costoMateriale)
    {
        _tipoMateriale = tipoMateriale;
        _quantitaCm = quantitaCm;
        _costoMetroMateriale = costoMateriale;
    }

    // Metodo ToString Sovrascritto
    public override string ToString()
    {
        return $"{TipoMateriale} - {QuantitaCm} - {CostoMetroMateriale}";
    }

    // Metodo che stampa le info dei materiali
    public void MostraInfo()
    {
        Console.WriteLine($"\nTipo Materiale: {TipoMateriale} \nQuantità in Cm in Magazzino: {QuantitaCm} \n Costo Del Materiale al Cm {CostoMetroMateriale}");
    }

    // Metodo per aggiungere i materiali
    public static void AggiungiMateriale(List<Materiale> magazzino)
    {
        Console.WriteLine($"Che tipo di materiale vuoi aggiungere ?");
        string tipoMateriale = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine($"quanti cm di materiale vuoi aggiungere ?");
        double cmMateriale = double.Parse(Console.ReadLine());

        if (cmMateriale <= 0) { Console.WriteLine($"Errore: aggiungi più di 0 cm di materiale."); }
        Console.WriteLine();

        Console.WriteLine($"quanto costa il materiale ?");
        decimal costoMateriale = decimal.Parse(Console.ReadLine());

        if (costoMateriale <= 0) { Console.WriteLine($"Errore: il materiale deve costare piu di 0.00 euro."); }
        Console.WriteLine();

        Materiale nuovoMateriale = new Materiale(tipoMateriale, cmMateriale, costoMateriale);

        var materialeEsistente = magazzino.FirstOrDefault(m => m.TipoMateriale.Equals(nuovoMateriale.TipoMateriale, StringComparison.OrdinalIgnoreCase));

        if (materialeEsistente != null)
        {
            materialeEsistente.QuantitaCm += nuovoMateriale.QuantitaCm;
            Console.WriteLine($"Aggiornato '{materialeEsistente.TipoMateriale}' → ora ha {materialeEsistente.QuantitaCm} cm totali.");
        }
        else
        {
            magazzino.Add(nuovoMateriale);
            Console.WriteLine($"Aggiunto nuovo materiale: {nuovoMateriale.TipoMateriale}");
        }

        Console.WriteLine();
        nuovoMateriale.MostraInfo();
    }

    // Metodo che mostra tutti i materiali contenuti in magazzino
    public static void MostraMateriali(List<Materiale> magazzino)
    {

        Console.WriteLine($"Elenco Materiali:");

        if (magazzino.Count == 0)
        {
            Console.WriteLine($"Il Magazzino è vuoto !");
        }

        foreach (Materiale m in magazzino)
        {
            m.MostraInfo();
        }
    }
}