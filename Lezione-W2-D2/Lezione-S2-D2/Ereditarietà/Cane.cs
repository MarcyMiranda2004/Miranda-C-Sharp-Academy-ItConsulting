using GestioneAnimale;

namespace GestioneCane;

public class Cane : Animale
{
    public void Scodinzola()
    {
        Console.WriteLine($"*Scodinzola*");
    }

    public override void FaiVerso()
    {
        Console.WriteLine($"*Wof Wof*");
    }
}