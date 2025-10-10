using GestioneVeicolo;

namespace GestioneMoto;

public class Moto : Veicolo
{
    protected string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
    {
        TipoManubrio = tipoManubrio;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Tipo Manubrio: {TipoManubrio}";
    }


    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"\n Tipo Manubrio: {TipoManubrio}");
    }
}