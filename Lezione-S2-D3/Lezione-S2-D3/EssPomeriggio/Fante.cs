using System.Runtime.Intrinsics.Arm;
using GestioneSoldato;

namespace GestioneFante;

public class Fante : Soldato
{
    private string arma;
    public string Arma { get; set; }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine($" ed ha in dotazione l'arma {Arma}");
        Console.WriteLine();
    }
}