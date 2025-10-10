namespace Utils
{
    public class Ess1
    {
        public static int Somma(ref int a, int b, out int somma)
        {
            somma = a + b;
            return somma;
        }

        public static double Somma(ref double a, double b, out double somma)
        {
            somma = a + b;
            return somma;
        }

        public static int Somma(ref int a, int b, int c, out int somma)
        {
            somma = a + b + c;
            return somma;
        }
    }

    public class Ess2
    {
        public static string Analizza(ref string testo, out int sommaCaratteri)
        {
            testo = testo.Replace(" ", "");
            sommaCaratteri = testo.Length;
            return $"Il testo contiene {sommaCaratteri} caratteri.";
        }

        public static string Analizza(ref string testo, char carattere, out int sommaCarattere)
        {
            sommaCarattere = 0;
            foreach (char c in testo)
            {
                if (c == carattere)
                    sommaCarattere++;
            }
            return $"Il testo contiene il carattere '{carattere}' {sommaCarattere} volte.";
        }

        public static int Analizza(ref string testo, bool contaVocali, bool contaConsonanti)
        {
            int conteggio = 0;
            testo = testo.ToLower();

            foreach (char c in testo)
            {
                if (char.IsLetter(c))
                {
                    if (contaVocali && "aeiou".Contains(c))
                        conteggio++;
                    else if (contaConsonanti && !"aeiou".Contains(c))
                        conteggio++;
                }
            }

            return conteggio;
        }
    }
}
