using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lezione_W4_D2.EssEnum
{

    public enum LivelloAccesso
    {
        OSPITE,
        USER,
        ADMIN
    }
    public class LvAccesso
    {
        public void Privilegi(LivelloAccesso LvA)
        {
            string permessi = LvA switch
            {
                LivelloAccesso.OSPITE => $"Puoi visualizzare i vari contenuti con limitazioni",
                LivelloAccesso.USER => $"Puoi visualizzare tutti i contenuti e modificare quelli da te creati",
                LivelloAccesso.ADMIN => $"Puoi visualizzare e modificare i contenuti di tutti gli utenti",

                _ => $"livello di Accesso non riconosciuto"
            };

            Console.WriteLine($"\n[Livello: {LvA}] → Diritti: {permessi}");
        }
    }
}