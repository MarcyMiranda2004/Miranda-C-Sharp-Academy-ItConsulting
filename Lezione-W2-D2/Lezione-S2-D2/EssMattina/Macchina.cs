using GestioneUtente;

namespace GestioneMacchina;

class Macchina
{
    public string Motore;
    public float VelMac;
    public int SosMax;
    public int NrMod;

    public Macchina(string motore, float velMac, int sosMax, int nrMod)
    {
        Motore = motore;
        VelMac = velMac;
        SosMax = sosMax;
        NrMod = nrMod;
    }

    public void StampaCaratteristiche()
    {
        Console.WriteLine($"Motore: {Motore}, VelocitàMac: {VelMac}, Sospensioni: {SosMax}, Modifiche: {NrMod}");
    }

    public static void GestisciModifiche(Utente utente, Macchina macchina)
    {
        bool continua = true;

        while (continua && utente.Crediti > 0)
        {
            Console.WriteLine($"\nCrediti disponibile: {utente.Crediti}");
            Console.WriteLine("Scegli la modifica da effettuare:");
            Console.WriteLine("1 - Aumenta velocità di 10");
            Console.WriteLine("2 - Cambia tipo motore");
            Console.WriteLine("3 - Aumenta sospensioni di 1");
            Console.WriteLine("0 - Termina modifiche");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    if (utente.Crediti >= 1)
                    {
                        macchina.VelMac += 10;
                        macchina.NrMod++;
                        utente.Crediti--;
                    }
                    else
                        Console.WriteLine("Crediti insufficiente!");
                    break;

                case 2:
                    if (utente.Crediti >= 1)
                    {
                        Console.Write("Inserisci nuovo tipo di motore: ");
                        string nuovoMotore = Console.ReadLine();
                        macchina.Motore = nuovoMotore;
                        macchina.NrMod++;
                        utente.Crediti--;
                    }
                    else
                        Console.WriteLine("Crediti insufficiente!");
                    break;

                case 3:
                    if (utente.Crediti >= 1)
                    {
                        macchina.SosMax += 1;
                        macchina.NrMod++;
                        utente.Crediti--;
                    }
                    else
                        Console.WriteLine("Crediti insufficiente!");
                    break;

                case 0:
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }

        Console.WriteLine($"\nModifiche terminate per {utente.Nome}");
        macchina.StampaCaratteristiche();
    }
}