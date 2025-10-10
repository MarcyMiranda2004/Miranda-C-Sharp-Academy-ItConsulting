using GestioneAnimale;

namespace GestioneGatto;

public class Gatto : Animale
{
    public void FaLeFusa()
    {
        Console.WriteLine($"*Prr Prr*");
    }

    public new void FaiVerso()
    {
        Console.WriteLine($"*Meow*");
    }
}