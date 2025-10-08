using System.ComponentModel.DataAnnotations;

namespace GestioneVoloAereo;

public class VoloAereo
{
    private int postiOccupati;
    private const int maxPosti = 150;
    public string CodiceVolo { get; set; }
    public int PostiOccupati
    {
        get { return postiOccupati; }
    }
    public int PostiLiberi
    {
        get { return maxPosti - postiOccupati; }
    }

    public VoloAereo(string codiceVolo, int postiIniziali = 0)
    {
        CodiceVolo = codiceVolo;
        if (postiIniziali >= 0 && postiIniziali <= maxPosti)
            postiOccupati = postiIniziali;
        else
            postiOccupati = 0;
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero posti non valido.");
            return;
        }

        if (postiOccupati + numeroPosti <= maxPosti)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"Prenotazione effettuata: {numeroPosti} posti aggiunti.");
        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti disponibili!");
        }
    }

    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine($"Numero Posti non valido");
            return;
        }

        if (postiOccupati <= 0)
        {
            Console.WriteLine($"non ci sono prenotazioni da annullare");
            return;
        }

        if (numeroPosti <= postiOccupati)
        {
            postiOccupati -= numeroPosti;
            Console.WriteLine($"Prenotazione annullata: {numeroPosti} posti rimossi");
        }
        else
        {
            Console.WriteLine($"Non ci sono abbastanza posti da annullare");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Stato del volo");
        Console.WriteLine($"\n Codice Volo: {CodiceVolo} \n Posti Occupati: {postiOccupati}\n Posti Liberi: {PostiLiberi}");
    }
}