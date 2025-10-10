using System;
using System.Collections.Generic;
using Astrattismo;
using LaboratorioElettronico;
using LaboratorioElettronico.Computer;
using LaboratorioElettronico.Dispositivi;
using GestionePagamenti.IPagamento;
using GestionePagamenti.PagamentoCarta;
using GestionePagamenti.PagamentoContanti;
using GestionePagamenti.PagamentoPayPal;

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
            Console.WriteLine($"[3] Pagamenti");
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

                case 3:
                    EssPagamenti();
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

    public static void EssPagamenti()
    {
        List<IPagamento> metodiPagamento = new List<IPagamento>
        {
            new PagamentoCarta { Circuito = "Visa"},
            new PagamentoCarta { Circuito = "Mastercard"},
            new PagamentoContanti{ },
            new PagamentoPayPal { EmailUtente = "marcellomiranda2004@gmail.com" }
        };

        int sceltaPagamento;

        do
        {
            Console.WriteLine($"Cosa vuoi fare ?");
            Console.WriteLine($"[1] Mostra Pagamento");
            Console.WriteLine($"[2] Esegui un Pagamento");
            Console.WriteLine($"[0] Esci");
            Console.Write("Scelta: ");
            sceltaPagamento = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (sceltaPagamento)
            {
                case 1:
                    foreach (IPagamento p in metodiPagamento)
                    {
                        EseguiOperazione(p, "mostra");
                        Console.WriteLine();
                    }

                    break;

                case 2:
                    Console.WriteLine("Scegli il metodo di pagamento:");
                    for (int i = 0; i < metodiPagamento.Count; i++)
                    {
                        Console.Write($"[{i + 1}] ");
                        EseguiOperazione(metodiPagamento[i], "mostra");
                    }

                    Console.Write("Scelta: ");
                    int metodo = int.Parse(Console.ReadLine() ?? "1") - 1;

                    if (metodo < 0)
                    {
                        Console.WriteLine("Seleziona un metodo valido");
                        break;
                    }

                    Console.Write("Inserisci l'importo da pagare: ");
                    decimal importo = decimal.Parse(Console.ReadLine());

                    if (importo <= 0)
                    {
                        Console.WriteLine($"L'importo da pagare deve essere superiore a 0,00€");
                    }

                    if (metodo >= 0 && metodo < pagamenti.Count)
                    {
                        EseguiOperazione(pagamenti[metodo], "paga", importo);
                    }
                    else
                    {
                        Console.WriteLine("Metodo non valido.");
                    }

                    Console.WriteLine();
                    break;

                case 0:
                    Console.WriteLine($"Esco dal programma...");
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine($"Inserire un valore valido!");
                    break;
            }

        } while (sceltaPagamento != 0);
    }

    public static void EseguiOperazione(IPagamento pagamento, string azione, decimal importo = 0)
    {
        if (azione == "mostra")
        {
            pagamento.MostraMetodo();
        }
        else if (azione == "paga")
        {
            pagamento.EseguiPagamento(importo);
        }
        else
        {
            Console.WriteLine("Azione non riconosciuta.");
        }
    }
}