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
using Formazioni.Corso;
using Formazioni.CorsoOnLine;
using Formazioni.CorsoOnSite;

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
            Console.WriteLine($"[4] Formazione");
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
                    // EssPagamenti();
                    break;

                case 4:
                    EssFormazione();
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

    // public static void EssPagamenti()
    // {
    //     List<IPagamento> metodiPagamento = new List<IPagamento>
    //     {
    //         new PagamentoCarta { Circuito = "Visa"},
    //         new PagamentoCarta { Circuito = "Mastercard"},
    //         new PagamentoContanti{ },
    //         new PagamentoPayPal { EmailUtente = "marcellomiranda2004@gmail.com" }
    //     };

    //     int sceltaPagamento;

    //     do
    //     {
    //         Console.WriteLine($"Cosa vuoi fare ?");
    //         Console.WriteLine($"[1] Mostra Pagamento");
    //         Console.WriteLine($"[2] Esegui un Pagamento");
    //         Console.WriteLine($"[0] Esci");
    //         Console.Write("Scelta: ");
    //         sceltaPagamento = int.Parse(Console.ReadLine());
    //         Console.WriteLine();
    //         switch (sceltaPagamento)
    //         {
    //             case 1:
    //                 foreach (IPagamento p in metodiPagamento)
    //                 {
    //                     EseguiOperazione(p, "mostra");
    //                     Console.WriteLine();
    //                 }

    //                 break;

    //             case 2:
    //                 Console.WriteLine("Scegli il metodo di pagamento:");
    //                 for (int i = 0; i < metodiPagamento.Count; i++)
    //                 {
    //                     Console.Write($"[{i + 1}] ");
    //                     EseguiOperazione(metodiPagamento[i], "mostra");
    //                 }

    //                 Console.Write("Scelta: ");
    //                 int metodo = int.Parse(Console.ReadLine() ?? "1") - 1;

    //                 if (metodo < 0)
    //                 {
    //                     Console.WriteLine("Seleziona un metodo valido");
    //                     break;
    //                 }

    //                 Console.Write("Inserisci l'importo da pagare: ");
    //                 decimal importo = decimal.Parse(Console.ReadLine());

    //                 if (importo <= 0)
    //                 {
    //                     Console.WriteLine($"L'importo da pagare deve essere superiore a 0,00€");
    //                 }

    //                 if (metodo >= 0 && metodo < pagamenti.Count)
    //                 {
    //                     EseguiOperazione(pagamenti[metodo], "paga", importo);
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Metodo non valido.");
    //                 }

    //                 Console.WriteLine();
    //                 break;

    //             case 0:
    //                 Console.WriteLine($"Esco dal programma...");
    //                 Console.WriteLine();
    //                 break;

    //             default:
    //                 Console.WriteLine($"Inserire un valore valido!");
    //                 break;
    //         }

    //     } while (sceltaPagamento != 0);
    // }

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

    public static void EssFormazione()
    {
        List<Corso> corsi = new List<Corso>();

        int sceltaCorso;

        do
        {
            Console.WriteLine();
            Console.WriteLine("=== MENU FORMAZIONE ===");
            Console.WriteLine("[1] Crea un Corso");
            Console.WriteLine("[2] Mostra i dettagli di tutti i Corsi");
            Console.WriteLine("[3] Eroga un Corso");
            Console.WriteLine("[4] Elimina un Corso");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            sceltaCorso = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (sceltaCorso)
            {
                case 1:
                    Console.WriteLine("Che tipo di corso vuoi creare?");
                    Console.WriteLine("[1] Corso Online");
                    Console.WriteLine("[2] Corso In Presenza (OnSite)");
                    Console.Write("Scelta: ");
                    int tipo = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Corso nuovoCorso = null;

                    if (tipo == 1)
                    {
                        CorsoOnLine cOnline = new CorsoOnLine();

                        Console.Write("Nome corso: ");
                        cOnline.NomeCorso = Console.ReadLine();

                        Console.Write("Categoria corso: ");
                        cOnline.CategoriaCorso = Console.ReadLine();

                        Console.Write("Durata in ore: ");
                        cOnline.DurataOre = int.Parse(Console.ReadLine());

                        Console.Write("Piattaforma (es: Zoom, Teams...): ");
                        cOnline.Piattaforma = Console.ReadLine();

                        Console.Write("Link accesso: ");
                        cOnline.LinkAccesso = Console.ReadLine();

                        nuovoCorso = cOnline;
                    }
                    else if (tipo == 2)
                    {
                        CorsoOnSite cOnSite = new CorsoOnSite();

                        Console.Write("Nome corso: ");
                        cOnSite.NomeCorso = Console.ReadLine();

                        Console.Write("Categoria corso: ");
                        cOnSite.CategoriaCorso = Console.ReadLine();

                        Console.Write("Durata in ore: ");
                        cOnSite.DurataOre = int.Parse(Console.ReadLine());

                        Console.Write("Aula: ");
                        cOnSite.Aula = Console.ReadLine();

                        Console.Write("Posti disponibili: ");
                        cOnSite.PostiDisponibili = int.Parse(Console.ReadLine());

                        nuovoCorso = cOnSite;
                    }

                    if (nuovoCorso != null)
                    {
                        corsi.Add(nuovoCorso);
                        Console.WriteLine($"Corso '{nuovoCorso.NomeCorso}' creato con successo!");
                    }

                    break;

                case 2:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile.");
                    }
                    else
                    {
                        Console.WriteLine("Elenco corsi:");
                        foreach (Corso c in corsi)
                        {
                            c.MostraDettagli();
                            Console.WriteLine();
                        }
                    }
                    break;

                case 3:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso da erogare.");
                        break;
                    }

                    Console.WriteLine("Quale corso vuoi erogare?");
                    for (int i = 0; i < corsi.Count; i++)
                        Console.WriteLine($"[{i + 1}] {corsi[i].NomeCorso}");

                    Console.Write("Scelta: ");
                    int indiceEroga = int.Parse(Console.ReadLine());

                    if (indiceEroga >= 1 && indiceEroga <= corsi.Count)
                    {
                        corsi[indiceEroga - 1].ErogaCorso();
                    }
                    else
                    {
                        Console.WriteLine("Indice non valido.");
                    }

                    break;

                case 4:
                    if (corsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso da eliminare.");
                        break;
                    }

                    Console.WriteLine("Quale corso vuoi eliminare?");
                    for (int i = 0; i < corsi.Count; i++)
                        Console.WriteLine($"[{i + 1}] {corsi[i].NomeCorso}");

                    Console.Write("Scelta: ");
                    int indiceElimina = int.Parse(Console.ReadLine());

                    if (indiceElimina >= 1 && indiceElimina <= corsi.Count)
                    {
                        Console.WriteLine($"Corso '{corsi[indiceElimina - 1].NomeCorso}' eliminato.");
                        corsi.RemoveAt(indiceElimina - 1);
                    }
                    else
                    {
                        Console.WriteLine("Indice non valido.");
                    }

                    break;

                case 0:
                    Console.WriteLine("Uscita dal programma Formazione...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    break;
            }

        } while (sceltaCorso != 0);
    }
}