using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssEnum
{
    public enum TipoTransazione
    {
        ACQUISTO,
        RIMBORSO,
        TRASFERIMENTO
    }

    public class Transazione
    {
        public void EffettuaTransazione(double importoBase, TipoTransazione tt)
        {
            double totaleConCommissioni = tt switch
            {
                TipoTransazione.ACQUISTO => importoBase + (importoBase / 100),
                TipoTransazione.RIMBORSO => importoBase + (importoBase * 2 / 100),
                TipoTransazione.TRASFERIMENTO => importoBase + (importoBase * 3 / 100),
                _ => importoBase
            };

            Console.WriteLine($"\n[TIPO TRANSAZIONE: {tt}] Importo base: {importoBase}");
            Console.WriteLine($"Commissioni applicate: {totaleConCommissioni - importoBase}");
            Console.WriteLine($"Totale con commissioni: {totaleConCommissioni}\n");

        }
    }
}