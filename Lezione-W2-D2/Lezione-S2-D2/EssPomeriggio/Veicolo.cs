namespace GestioneVeicolo;

public class Veicolo
{
    protected string Marca;
    protected string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public override string ToString()
    {
        return $"Marca: {Marca}, Modello: {Modello}";
    }


    public virtual void StampaInfo()
    {
        Console.WriteLine($"\n Marca: {Marca} \n Modello: {Modello}");
    }

    public static void StampaVeicoli(List<Veicolo> veicoli)
    {
        if (veicoli.Count == 0)
        {
            Console.WriteLine("Nessun veicolo presente nel garage!");
            return;
        }

        Console.WriteLine("\n--- Lista Veicoli ---");
        for (int i = 0; i < veicoli.Count; i++)
        {
            Console.WriteLine($"\nVeicolo {i + 1}:");
            veicoli[i].StampaInfo();
        }
    }
}