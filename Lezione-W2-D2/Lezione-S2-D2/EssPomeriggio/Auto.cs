using GestioneVeicolo;

namespace GestioneAuto;

public class Auto : Veicolo
{
    protected int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
    {
        NumeroPorte = numeroPorte;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Numero Porte: {NumeroPorte}";
    }


    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"\n Numero Porte: {NumeroPorte}");
    }
}