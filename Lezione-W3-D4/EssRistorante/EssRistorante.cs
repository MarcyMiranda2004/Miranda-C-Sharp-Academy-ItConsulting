using System;

namespace Lezione_W3_D4.EssRistorante
{
    #region INTERFACCE
    // Interfaccia di base comune per tutti i piatti
    // È il cuore dei tre pattern (Factory, Decorator, Strategy)
    public interface IPiatto
    {
        string Descrizione();  // Ritorna la descrizione del piatto
        string Prepara();      // Ritorna la modalità di preparazione
    }
    #endregion

    #region CLASSI ASTRATTE
    // Classe astratta di base che rappresenta un piatto generico
    // Implementa l'interfaccia IPiatto e funge da punto di partenza per la Factory
    public abstract class PiattoAbs : IPiatto
    {
        // Descrizione base, sovrascrivibile nelle sottoclassi
        public virtual string Descrizione()
        {
            return $"Squisit";
        }

        // Metodo di preparazione base, sovrascrivibile dalle strategie
        public virtual string Prepara()
        {
            return $"Sto cucinando il piatto...";
        }
    }
    #endregion

    #region CLASSI CONCRETE (PIATTI BASE)
    // Classe concreta di piatto: Pizza
    public class Pizza : PiattoAbs
    {
        public override string Descrizione()
        {
            return base.Descrizione() + "a pizza appena sfornata";
        }
    }

    // Classe concreta di piatto: Hamburger
    public class Hamburger : PiattoAbs
    {
        public override string Descrizione()
        {
            return base.Descrizione() + "o hamburger appena grigliato";
        }
    }

    // Classe concreta di piatto: Insalata
    public class Insalata : PiattoAbs
    {
        public override string Descrizione()
        {
            return base.Descrizione() + "a fresca insalata di stagione";
        }
    }
    #endregion

    #region DECORATOR
    // Classe astratta Decorator: consente di aggiungere dinamicamente ingredienti extra
    public abstract class IngredienteExtra : IPiatto
    {
        protected IPiatto _piatto; // contiene il piatto da decorare

        protected IngredienteExtra(IPiatto piatto)
        {
            _piatto = piatto;
        }

        // restituisce la descrizione del piatto decorato
        public virtual string Descrizione()
        {
            return _piatto.Descrizione();
        }

        // il metodo Prepara() rimanda al piatto sottostante
        public virtual string Prepara()
        {
            return _piatto.Prepara();
        }
    }

    // Decoratore concreto: aggiunge Formaggio
    public class ConFormaggio : IngredienteExtra
    {
        public ConFormaggio(IPiatto piatto) : base(piatto) { }

        public override string Descrizione()
        {
            return base.Descrizione() + " con aggiunta di formaggio";
        }
    }

    // Decoratore concreto: aggiunge Bacon
    public class ConBacon : IngredienteExtra
    {
        public ConBacon(IPiatto piatto) : base(piatto) { }

        public override string Descrizione()
        {
            return base.Descrizione() + " con croccante bacon";
        }
    }

    // Decoratore concreto: aggiunge Salsa
    public class ConSalsa : IngredienteExtra
    {
        public ConSalsa(IPiatto piatto) : base(piatto) { }

        public override string Descrizione()
        {
            return base.Descrizione() + " con salsa speciale dello chef";
        }
    }
    #endregion

    #region FACTORY METHOD
    // Classe statica Factory che crea piatti base in base alla scelta dell'utente
    public static class PiattoFactory
    {
        public static IPiatto Crea(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "pizza":
                    return new Pizza();

                case "hamburger":
                    return new Hamburger();

                case "insalata":
                    return new Insalata();

                default:
                    return null;
            }
        }
    }
    #endregion

    #region STRATEGY
    // Interfaccia per la strategia di preparazione (Strategy Pattern)
    public interface IPreparazioneStrategia
    {
        string Prepara(string nomePiatto);
    }

    // Strategia concreta: Fritto
    public class Fritto : IPreparazioneStrategia
    {
        public string Prepara(string nomePiatto)
        {
            return $"{nomePiatto} preparato FRITTO in olio bollente!";
        }
    }

    // Strategia concreta: Al forno
    public class AlForno : IPreparazioneStrategia
    {
        public string Prepara(string nomePiatto)
        {
            return $"{nomePiatto} cotto AL FORNO a 180°.";
        }
    }

    // Strategia concreta: Alla griglia
    public class AllaGriglia : IPreparazioneStrategia
    {
        public string Prepara(string nomePiatto)
        {
            return $"{nomePiatto} cucinato ALLA GRIGLIA per un gusto affumicato.";
        }
    }

    // Classe "Chef" che usa una strategia per preparare un piatto
    public class Chef
    {
        private IPreparazioneStrategia _strategia;

        // Metodo per impostare la strategia scelta
        public void ImpostaStrategia(IPreparazioneStrategia strategia)
        {
            _strategia = strategia;
        }

        // Applica la strategia al piatto e ritorna il risultato
        public string PreparaPiatto(IPiatto piatto)
        {
            return _strategia.Prepara(piatto.Descrizione());
        }
    }
    #endregion
}