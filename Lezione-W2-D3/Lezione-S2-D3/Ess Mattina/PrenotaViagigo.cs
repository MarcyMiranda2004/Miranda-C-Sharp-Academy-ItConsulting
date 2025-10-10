using System.Dynamic;

namespace GestionePrenotaViaggio;

public class PrenotaViaggio
{
    private int PostiPrenotati;
    public int postiPrenotati
    {
        get { return PostiPrenotati; }
    }
    public string Destinazione { get; set; }
    public int PostiMax = 20;
    public int PostiDisponibili
    {
        get { return PostiMax - PostiPrenotati; }
    }

    public void PrenotaPosti(int postiDaPrenotare)
    {

        if (postiDaPrenotare <= 0)
        {
            Console.WriteLine($"Inserire un valore valido");
        }

        if (PostiDisponibili >= postiDaPrenotare)
        {
            PostiPrenotati += postiDaPrenotare;
            Console.WriteLine($"{postiDaPrenotare} posti prenotati con successo!");
        }
        else
        {
            Console.WriteLine($"Non ci sono abbastanza posti disponibili");
        }
    }

    public void AnnullaPrenotazione(int prenotazioniDaAnnullare)
    {
        if (prenotazioniDaAnnullare <= 0)
        {
            Console.WriteLine($"Inserire un valore valido");
        }

        if (prenotazioniDaAnnullare <= PostiPrenotati)
        {
            PostiPrenotati -= prenotazioniDaAnnullare;
            Console.WriteLine($"Prenotazioni annullate con successo!");
        }
        else
        {
            Console.WriteLine($"Non ci sono cosi tante prenotazioni da annullare");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Destinazione: {Destinazione}");
        Console.WriteLine($"Posti Prenotati: {PostiPrenotati}");
        Console.WriteLine($"Posti Disponibili: {PostiDisponibili}");
        Console.WriteLine();
    }
}