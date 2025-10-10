namespace GestioneCorso;

public class Corso
{
    protected string Nome;
    protected int Durata;
    protected string Docente;
    protected List<string> Studenti;

    public Corso(string nome, int durata, string docente, List<string> studenti)
    {
        Nome = nome;
        Durata = durata;
        Docente = docente;
        Studenti = studenti;
    }

    public virtual string ToString()
    {
        string elencoStudenti = string.Join(", ", Studenti);
        return $"Nome Corso: {Nome}, Durata: {Durata} ore, Docente: {Docente}, Studenti: [{elencoStudenti}]";
    }

    public void AggiungiStudente(string nomeStudente)
    {
        Studenti.Add(nomeStudente);
    }

    public virtual void MetodoSpeciale()
    {
        Console.WriteLine($"S. P. E. C. I. A. L.");
    }
}