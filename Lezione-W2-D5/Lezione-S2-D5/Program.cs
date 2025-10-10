using System;
using System.Collections.Generic;
using Astrattismo;
using LaboratorioElettronico;
using LaboratorioElettronico.Computer;
using LaboratorioElettronico.Dispositivi;

public class Programma
{
    public static void Main()
    {
        int scelta;

        do
        {
            Console.WriteLine($"Che Esercizio Vuoi Vedere ?");
            Console.WriteLine($"[1] Astrattismo");
            Console.WriteLine($"[2] Laboratorio di Elettronica");
            Console.WriteLine($"[0] Esci");
            scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    EssAstrattismo();
                    break;

                case 2:
                    EssLaboratorioElettronica();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    break;

                default:
                    Console.WriteLine($"Scelta Non Valida");
                    break;
            }

        } while (scelta != 0);

    }

    public static void EssAstrattismo()
    {
        Veicolo miaAuto = new Auto();
        miaAuto.Avvia();

        Console.WriteLine();

        IVeicoloElettrico mioScooter = new ScooterElettrico();
        mioScooter.Ricarica();

        Console.WriteLine();
    }

    public static void EssLaboratorioElettronica()
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>
            {
                new Computer { Modello = "MSI Katara 2500" },
                new Stampante { Modello = "HP DeskJet 3250" }
            };

        foreach (DispositivoElettronico d in dispositivi)
        {
            EseguiOperazioni(d);
            Console.WriteLine();
        }
    }

    // Metodo Polimorfico
    public static void EseguiOperazioni(DispositivoElettronico d)
    {
        d.Accendi();
        d.MostraInfo();
        d.Spegni();
        Console.WriteLine();
    }
}