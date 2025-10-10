using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        // ESS BASE
        /* Console.WriteLine("Somma");
      Console.WriteLine("Inserisci il primo numero");
      int n1 = int.Parse(Console.ReadLine());
      Console.WriteLine("inserisci il secondo numero: ");
      int n2 = int.Parse(Console.ReadLine());
      int somma = n1 + n2;
      Console.WriteLine("la Somma è: " + somma);



      Console.WriteLine("Prezzo Scontato");
      Console.WriteLine("inserisci un prezzo");
      double prezzo = double.Parse(Console.ReadLine());
      Console.WriteLine("inserisci lo sconto");
      double sconto = double.Parse(Console.ReadLine());
      double prezzoScontato = prezzo - (prezzo * sconto / 100);
      Console.WriteLine("il prezzo scontato è: " + prezzoScontato);



      Console.WriteLine("è positivo ?");
      Console.WriteLine("inserisci un numero");
      float n3 = float.Parse(Console.ReadLine());
      bool positivo = n3 > 0;
      Console.WriteLine("Il numero è positivo? " + positivo);



      Console.WriteLine("Somma intero e float");
      Console.Write("Inserisci un intero: ");
      int n4 = int.Parse(Console.ReadLine());
      Console.Write("Inserisci un float: ");
      float n5 = float.Parse(Console.ReadLine());
      float somma2 = n4 + n5;
      Console.WriteLine("La somma è: " + somma2);



      Console.WriteLine("somma eta e altezza");
      Console.WriteLine("inserisci la tua eta");
      int eta = int.Parse(Console.ReadLine());
      Console.WriteLine("inserisci la tua altezza in metri");
      float altezza = float.Parse(Console.ReadLine());
      int somma3 = eta + (int)altezza;
      Console.WriteLine("la somma è: " + somma3); 




      Console.WriteLine("maggiorenne o minorenne ?");
      Console.Write("Inserisci la tua età: ");
      int eta = int.Parse(Console.ReadLine());
      if (eta >= 18)
      {
          Console.WriteLine("maggiorenne");
      }
      else
      {
          Console.WriteLine("minorenne");
      }*/

        // --------------------------------------------------------------------------------------

        // ESS IF
        /* Console.WriteLine("sconto");
        Console.WriteLine("inserisci il prezzo");
        double prezzo = double.Parse(Console.ReadLine());
        double sconto = 10;
        if (prezzo > 100)
        {
            double prezzoScontato = prezzo - (prezzo * sconto / 100);
            Console.WriteLine("il prezzo scontato è: " + prezzoScontato);
        }
        else
        {
            Console.WriteLine("Il prezzo è: " + prezzo);
        }

        Console.Write("Inserisci il primo numero intero: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero intero: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il terzo numero intero: ");
        int n3 = int.Parse(Console.ReadLine());

        double media = (double)(n1 + n2 + n3) / 3;

        if (media >= 60)
        {
            Console.WriteLine("Hai superato la prova!");
        }
        else
        {
            Console.WriteLine("Prova fallita.");
        }
        Console.WriteLine("La media è: {0:F2}", media);

        Console.WriteLine("pari o dispari");
        Console.Write("Inserisci un numero intero: ");
        string input = Console.ReadLine();
        int n4 = int.Parse(input);

        if (n4 % 2 == 0)
        {
            Console.WriteLine("Il numero è pari.");
        }
        else
        {
            Console.WriteLine("Il numero è dispari.");
        }

        Console.WriteLine("accesso con password");
        const int PASSWORD_CORRETTA = 1234;

        Console.Write("Inserisci la password numerica: ");
        string n5 = Console.ReadLine();
        int passwordInserita = int.Parse(n5);

        if (passwordInserita == PASSWORD_CORRETTA)
        {
            Console.WriteLine("Accesso consentito");
        }
        else
        {
            Console.WriteLine("Accesso negato");
        }

        Console.WriteLine("calcolatrice");
        Console.Write("Inserisci il primo numero: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Inserisci un operatore (+ oppure -): ");
        string operatore = Console.ReadLine();

        Console.Write("Inserisci il secondo numero: ");
        double num2 = double.Parse(Console.ReadLine());

        double risultato;

        if (operatore == "+")
        {
            int sommaInt = (int)num1 + (int)num2;
            risultato = num1 + num2;
            Console.WriteLine("Risultato: " + risultato);
            Console.WriteLine("Somma come interi (cast esplicito): " + sommaInt);
        }
        else if (operatore == "-")
        {
            risultato = num1 - num2;
            Console.WriteLine("Risultato: " + risultato);
        }
        else
        {
            Console.WriteLine("Operatore non valido!");
        } */

        // --------------------------------------------------------------------------------------

        // ESS WHILE
        /* Console.WriteLine("stop al negativo");
        int n1 = 0;
        while (n1 >= 0)
        {
            Console.WriteLine("inserisci un numero");
            n1 = int.Parse(Console.ReadLine());

            if (n1 >= 0)
            {
                Console.WriteLine("Hai inserito: " + n1);
            }
        }
        Console.WriteLine("Hai inserito un numero negativo. Programma terminato!");



        Console.WriteLine("Indovina il numero");
        const int N = 7;

        int n2 = 0;

        while (n2 != 7)
        {
            Console.WriteLine("inserisci un numero");
            n2 = int.Parse(Console.ReadLine());
            if (n2 > N)
            {
                Console.WriteLine("il numero è più grande di quello segreto");
            }
            else if (n2 < N)
            {
                Console.WriteLine("il numero è più piccolo di quello segreto");
            }
            else
            {
                Console.WriteLine("Bravo! Hai indovinato il numero segreto");
            }
        }



        Console.WriteLine("Bancomat");
        double saldo = 0;
        int scelta = 0;

        while (scelta != 4) // finché non si sceglie 4 (Esci)
        {
            Console.WriteLine("\n--- Menu Bancomat ---");
            Console.WriteLine("1: Visualizza saldo");
            Console.WriteLine("2: Deposita denaro");
            Console.WriteLine("3: Preleva denaro");
            Console.WriteLine("4: Esci");
            Console.Write("Seleziona un'opzione: ");

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1: // Visualizza saldo
                    Console.WriteLine("Il tuo saldo è: {0:F2} euro", saldo);
                    break;

                case 2: // Deposita denaro
                    Console.Write("Inserisci l'importo da depositare: ");
                    double deposito = double.Parse(Console.ReadLine());
                    if (deposito > 0)
                    {
                        saldo += deposito;
                        Console.WriteLine("Hai depositato {0:F2} euro. Saldo attuale: {1:F2} euro", deposito, saldo);
                    }
                    else
                    {
                        Console.WriteLine("Importo non valido!");
                    }
                    break;

                case 3: // Preleva denaro
                    Console.Write("Inserisci l'importo da prelevare: ");
                    double prelievo = double.Parse(Console.ReadLine());
                    if (prelievo > saldo)
                    {
                        Console.WriteLine("Errore: saldo insufficiente!");
                    }
                    else if (prelievo > 0)
                    {
                        saldo -= prelievo;
                        Console.WriteLine("Hai prelevato {0:F2} euro. Saldo attuale: {1:F2} euro", prelievo, saldo);
                    }
                    else
                    {
                        Console.WriteLine("Importo non valido!");
                    }
                    break;

                case 4: // Esci
                    Console.WriteLine("Uscita dal programma. Arrivederci!");
                    break;

                default: // Scelta non valida
                    Console.WriteLine("Opzione non valida. Riprova!");
                    break;
            }
        } */

        // --------------------------------------------------------------------------------------

        // ESS DO WHILE
        /* Console.Write("Accesso con 3 tentativi");
        const int PASSWORD_CORRETTA = 1234;
        int tentativi = 3;
        bool accesso = false;

        while (tentativi > 0 && !accesso)
        {
            Console.Write("Inserisci la password numerica: ");
            int inserita = int.Parse(Console.ReadLine());

            if (inserita == PASSWORD_CORRETTA)
            {
                Console.WriteLine("Accesso consentito!");
                accesso = true;
            }
            else
            {
                tentativi--;
                Console.WriteLine("Password errata! Tentativi rimasti: " + tentativi);
            }
        }

        if (!accesso)
        {
            Console.WriteLine("Accesso negato. Tentativi esauriti.");
        }



        Console.Write("somma tutti i numeri");
        int numero;
        int somma = 0;
        int conteggio = 0;

        Console.WriteLine("Inserisci numeri interi (0 per terminare):");

        do
        {
            numero = int.Parse(Console.ReadLine());
            if (numero != 0)
            {
                somma += numero;
                conteggio++;
            }
        } while (numero != 0);

        Console.WriteLine("Hai inserito {0} numeri. La somma è {1}.", conteggio, somma);



        Console.Write("Calcolatrice");
        bool continua = true;

        while (continua)
        {
            Console.Write("Inserisci il primo numero: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Inserisci il secondo numero: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Inserisci l'operatore (+, -, *, /): ");
            string op = Console.ReadLine();

            double risultato = 0;
            bool valido = true;

            switch (op)
            {
                case "+":
                    risultato = num1 + num2;
                    break;
                case "-":
                    risultato = num1 - num2;
                    break;
                case "*":
                    risultato = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        risultato = num1 / num2;
                    else
                    {
                        Console.WriteLine("Errore: divisione per zero!");
                        valido = false;
                    }
                    break;
                default:
                    Console.WriteLine("Operatore non valido!");
                    valido = false;
                    break;
            }

            if (valido)
            {
                Console.WriteLine("Risultato: {0}", risultato);
            }

            Console.Write("Vuoi eseguire un'altra operazione? (s/n): ");
            string scelta = Console.ReadLine().ToLower();
            if (scelta != "s")
            {
                continua = false;
                Console.WriteLine("Programma terminato.");
            }
        } */
    }

}