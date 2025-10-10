
using System;

public class Vestiti : Materiale
{
    // Proprietà specifiche per Vestiti
    public string TipoVestito { get; set; }
    public double CostoPerVestitoCm { get; set; }
    public double Costo { get; set; }
    public string Nome { get; set; }

    // Costruttore che richiama il costruttore base di Materiale
    public Vestiti(string tipoMateriale, double quantitaCm, decimal costoMateriale, string tipoVestito, double costoPerVestitoCm, string nome)
                    : base(tipoMateriale, quantitaCm, costoMateriale)
    {
        TipoVestito = tipoVestito;
        CostoPerVestitoCm = costoPerVestitoCm;
        Nome = nome;
    }

    // ToString per rappresentare il vestito come stringa
    public override string ToString()
    {
        return $"{TipoVestito} - {Nome} - Prezzo di vendita: {Costo:F2}";
    }

    // Metodo per calcolare la quantità di vestiti in base alla quantità di cm
    public int CalcolaQuantitaVestiti(double quantitaCm)
    {
        if (CostoPerVestitoCm <= 0)
            throw new InvalidOperationException("Costo per vestito (cm) non valido o zero.");
        return (int)(quantitaCm / CostoPerVestitoCm);
    }

    // Metodo per calcolare il prezzo di creazione del vestito
    // public double CalcoloPrezzoCreazione()
    // {
    //     if (CostoMetroMateriale <= 0)
    //         throw new InvalidOperationException("Costo per metro del materiale non valido o zero.");
    //     Costo = CostoPerVestitoCm * (double)CostoMetroMateriale;
    //     return Costo;
    // }
}
