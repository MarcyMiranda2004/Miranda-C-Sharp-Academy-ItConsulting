using GestioneCorso;

namespace GestioneCorsoDanza;

public class CorsoDanza : Corso
{
    protected string Stile;

    public CorsoDanza(string nome, int durata, string docente, List<string> studenti, string stile) : base(nome, durata, docente, studenti)
    {
        Stile = stile;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Stile: {Stile}";
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Oggi coreografia in stile: {Stile}");
    }
}