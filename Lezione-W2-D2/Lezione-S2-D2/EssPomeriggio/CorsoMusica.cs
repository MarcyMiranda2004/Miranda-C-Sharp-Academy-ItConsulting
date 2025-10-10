using System.Runtime.InteropServices;
using GestioneCorso;

namespace GestioneCorsoMusica;

public class CorsoMusica : Corso
{
    protected string Strumento;

    public CorsoMusica(string nome, int durata, string docente, List<string> studenti, string strumento) : base(nome, durata, docente, studenti)
    {
        Strumento = strumento;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Strumento: {Strumento}";
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Oggi prova pratica dello strumento: {Strumento}");
    }
}