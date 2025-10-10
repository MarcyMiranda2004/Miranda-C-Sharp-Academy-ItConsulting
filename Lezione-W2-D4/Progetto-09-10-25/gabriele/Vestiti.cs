using GestioneMateriale;
using System;
using System.Collections.Generic;

namespace GestioneVestiti;

public class Vestiti : Materiale
{
    public string TipoVestito { get; set; }
    public double CmPerVestito { get; set; }
    public decimal PrezzoVendita { get; set; }
    public string Nome { get; set; }

    public Vestiti(string tipoMateriale, double quantitaCm, decimal costoMateriale, string tipoVestito, double cmPerVestito, string nome)
        : base(tipoMateriale, quantitaCm, costoMateriale)
    {
        TipoVestito = tipoVestito;
        CmPerVestito = cmPerVestito;
        Nome = nome;
    }

    // To string sovrascritto 
    public override string ToString()
    {
        return $"{TipoVestito} '{Nome}' - Prezzo di vendita: {PrezzoVendita:F2}€";
    }

    // Metodo che calcola il costo di produzione di un singolo vestito
    public static decimal CalcolaCostoProduzione(double cmPerVestito, decimal costoMetroMateriale)
    {
        return (decimal)cmPerVestito * costoMetroMateriale;
    }

    //Metodo che calcola il prezzo di vendita aggiungendo un margine
    public static decimal CalcolaPrezzoVendita(double cmPerVestito, decimal costoMetroMateriale, decimal marginePercentuale)
    {
        decimal costo = CalcolaCostoProduzione(cmPerVestito, costoMetroMateriale);
        return costo + (costo * marginePercentuale / 100);
    }

    //Metodo che calcola quanti vestiti si possono creare con il materiale disponibile
    public static int CalcolaQuantitaVestiti(double quantitaCm, double cmPerVestito)
    {
        return (int)(quantitaCm / cmPerVestito);
    }

    //Metodo Crea vestito che legge i dati da console
    public static void CreaVestito(List<Materiale> magazzino)
    {
        if (magazzino.Count == 0)
        {
            Console.WriteLine("Non ci sono materiali in magazzino!");
            return;
        }

        Console.WriteLine("Scegli il materiale da usare:");
        for (int i = 0; i < magazzino.Count; i++)
            Console.WriteLine($"[{i + 1}] {magazzino[i].TipoMateriale}");

        int scelta;
        if (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > magazzino.Count)
        {
            Console.WriteLine("Scelta non valida.");
            return;
        }

        Materiale materialeScelto = magazzino[scelta - 1];

        Console.WriteLine("Tipo di vestito da creare:");
        string tipoVestito = Console.ReadLine();

        Console.WriteLine("Nome del vestito:");
        string nome = Console.ReadLine();

        Console.WriteLine("Cm necessari per un vestito:");
        if (!double.TryParse(Console.ReadLine(), out double cmPerVestito) || cmPerVestito <= 0)
        {
            Console.WriteLine("Valore non valido.");
            return;
        }

        Console.WriteLine("Margine di profitto (%):");
        if (!decimal.TryParse(Console.ReadLine(), out decimal margine))
        {
            Console.WriteLine("Valore non valido.");
            return;
        }

        // Creo l'istanza di vestito
        Vestiti vestito = new Vestiti(materialeScelto.TipoMateriale, materialeScelto.QuantitaCm,
                                      materialeScelto.CostoMetroMateriale, tipoVestito, cmPerVestito, nome);

        // Calcolo quantità producibile e prezzo di vendita usando i metodi statici
        int quantita = Vestiti.CalcolaQuantitaVestiti(materialeScelto.QuantitaCm, cmPerVestito);
        decimal prezzo = Vestiti.CalcolaPrezzoVendita(cmPerVestito, materialeScelto.CostoMetroMateriale, margine);
        decimal costoProduzione = Vestiti.CalcolaCostoProduzione(cmPerVestito, materialeScelto.CostoMetroMateriale);

        Console.WriteLine($"\nPuoi creare {quantita} '{vestito.Nome}' (tipo: {tipoVestito}) usando '{materialeScelto.TipoMateriale}'.");
        Console.WriteLine($"Costo di produzione: {costoProduzione:F2} € per vestito");
        Console.WriteLine($"Prezzo di vendita suggerito: {prezzo:F2} €");
    }

}
