using System;

namespace Lezione_W4_D4.Delegate
{
    // Classe per simulare un pulsante
    public class Pulsante
    {
        public event Action Premuto;

        public void SimulaClick()
        {
            Console.WriteLine("Pulsante cliccato");
            Premuto?.Invoke(); // Invoca l'evento se ci sono subscriber
        }
    }

    public class EsempioDelegate
    {
        // 🔹 Delegate personalizzato: accetta una stringa e non restituisce nulla
        delegate void Saluto(string nome);

        // 🔹 Metodi compatibili con il delegate
        static void Ciao(string nome) => Console.WriteLine($"Ciao, {nome}!");
        static void Benvenuto(string nome) => Console.WriteLine($"Benvenuto, {nome}!");

        // 🔹 Delegate che restituisce un valore
        public delegate int Calcolo(int n, int m);
        static int EseguiSomma(int n, int m) => n + m;

        // 🔹 Metodo principale
        // public static void Main()
        // {
        //     // ===== DELEGATE PERSONALIZZATO =====
        //     Saluto s = Ciao;
        //     s("Luca"); // Output: Ciao, Luca!

        //     s += Benvenuto;
        //     s("Marco");
        //     // Output:
        //     // Ciao, Marco!
        //     // Benvenuto, Marco!

        //     // ===== DELEGATE CON VALORE DI RITORNO =====
        //     Calcolo calcolo = EseguiSomma;
        //     Console.WriteLine($"Somma delegate: {calcolo(1, 2)}"); // Output: 3

        //     Console.WriteLine(); // Separatore visivo

        //     // ===== ACTION =====
        //     Action<string> saluta = nome => Console.WriteLine($"Ciao, {nome}!");
        //     saluta("Andrea");

        //     // ===== FUNC =====
        //     Func<int, int, int> somma = (a, b) => a + b;
        //     Console.WriteLine($"La somma è: {somma(3, 4)}");

        //     // ===== PREDICATE =====
        //     Predicate<int> isPari = numero => numero % 2 == 0;
        //     Console.WriteLine($"4 è pari? {isPari(4)}");
        //     Console.WriteLine($"7 è pari? {isPari(7)}");

        //     // ===== EVENTI =====
        //     Pulsante p = new Pulsante();
        //     p.Premuto += () => Console.WriteLine("Evento ricevuto");
        //     p.SimulaClick();
        // }
    }
}
