using GestioneVeicolo;

namespace GestioneMoto;

public class Moto : Veicolo
{
    public Moto(string targa) : base(targa) { }
    public override void Ripara()
    {
        Console.WriteLine($"Controllo catena, freni e gomme della moto");
    }
}