namespace GestioneLibro;

class Libro
{
    private string Titolo;
    private string Autore;
    private int AnnoPubblicazione;

    public Libro(string titolo, string autore, int annoPubblicazione)
    {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = annoPubblicazione;
    }


    public override string ToString()
    {
        return $"{Titolo} di {Autore}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Libro l1)
        {
            return this.Titolo == l1.Titolo && this.Autore == l1.Autore;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore);
    }
}

