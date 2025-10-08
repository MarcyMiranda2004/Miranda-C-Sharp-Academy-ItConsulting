namespace GestioneSoldato;

public class Soldato
{
    private string nome;
    public string Nome { get; set; }

    private string grado;
    public string Grado { get; set; }

    private int anniServizio;
    public int AnniServizio
    {
        get { return anniServizio; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Il soldato non può avere meno di 0 anni di servizio");
            }
            else
            {
                anniServizio = value;
            }
        }
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Il soldato {Nome} di grado {Grado} ha {AnniServizio} di servizio.");
    }
}