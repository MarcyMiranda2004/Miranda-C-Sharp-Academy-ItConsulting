using GestioneCorso;

namespace GestioneCorsoPittura;

public class CorsoPittura : Corso
{
    protected string Tecnica;

    public CorsoPittura(string nome, int durata, string docente, List<string> studenti, string tecnica) : base(nome, durata, docente, studenti)
    {
        Tecnica = tecnica;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Tecnica: {Tecnica}";
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Oggi tela bianca con tecnica: {Tecnica}");
    }
}