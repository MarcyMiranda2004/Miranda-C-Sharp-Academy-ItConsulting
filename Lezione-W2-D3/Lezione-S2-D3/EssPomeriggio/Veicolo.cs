using System.Runtime.Versioning;

namespace GestioneVeicolo;

public class Veicolo
{
    private string _targa;
    public string Targa { get => _targa; set => _targa = value; }

    public Veicolo(string targa)
    {
        _targa = targa;
    }

    public virtual void Ripara()
    {
        Console.WriteLine($"Il veicolo viene controllato");
    }
}