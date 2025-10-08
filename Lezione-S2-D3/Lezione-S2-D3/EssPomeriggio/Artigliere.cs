using GestioneSoldato;

namespace GestioneArtigliere;

public class Artigliere : Soldato
{
    private int calibro;
    public int Calibro
    {
        get { return calibro; }
        set
        {
            if (calibro < 0)
            {
                Console.WriteLine($"Inserire un calibro valido!");
            }
        }
    }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine($" ed è specializzato nel calibro {Calibro}");
        Console.WriteLine();
    }
}