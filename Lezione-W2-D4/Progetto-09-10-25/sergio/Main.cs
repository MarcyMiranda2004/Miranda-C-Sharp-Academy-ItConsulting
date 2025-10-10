// class Program
// {
//     static List<Materiale> magazzino = new List<Materiale>();

//     const double CmPerVestito = 200;

//     static void Main(string[] args)
//     {
//         Console.WriteLine($"Gestione fabbrica");

//         bool continua = true;
//         while (continua)
//         {
//             MostraMenu(); // metodo da fare ok
//             string scelta = Console.ReadLine();

//             switch (scelta)
//             {
//                 case "1":
//                     AggiungiMaterile(); // metodo da fare ok
//                     break;
//                 case "2":
//                     MostraMateriali(); // metodo da fare
//                     break;
//                 case "3":
//                     CalcolaVestiti(); // metodo da fare
//                     break;
//                 case "4":
//                     continua = false;
//                     Console.WriteLine($"Arrivederci");
//                     break;
//                 default:
//                     Console.WriteLine($"\nScelta non valida, riporva");
//                     break;
//             }
//             if (continua)
//             {
//                 Console.WriteLine($"\nPrime invio prima di continuare");
//                 Console.ReadLine();
//                 Console.Clear();
//             }



//         }

//     }

//     // metodo per mostrare il menu MostraMenu


//     static void MostraMenu()
//     {
//         Console.WriteLine($"===MENU===");
//         Console.WriteLine($"[1]Aggiungi materiale");
//         Console.WriteLine($"[2]Visualizza materiali disponibili");
//         Console.WriteLine($"[3]Calcola vestiti producibili");
//         Console.WriteLine($"[4]Esci");


//     }

// }
class Program
{
    static List<Materiale> magazzino = new List<Materiale>();

    const double CmPerVestito = 200;

    static void Main(string[] args)
    {
        Console.WriteLine($"Gestione fabbrica");

        bool continua = true;
        while (continua)
        {
            MostraMenu(); // metodo da fare ok
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    AggiungiMaterile(); // metodo da fare ok
                    break;
                case "2":
                    MostraMateriali(); // metodo da fare
                    break;
                case "3":
                    CalcolaVestiti(); // metodo da fare
                    break;
                case "4":
                    continua = false;
                    Console.WriteLine($"Arrivederci");
                    break;
                default:
                    Console.WriteLine($"\nScelta non valida, riporva");
                    break;
            }
            if (continua)
            {
                Console.WriteLine($"\nPrime invio prima di continuare");
                Console.ReadLine();
                Console.Clear();
            }



        }

    }

    // metodo per mostrare il menu MostraMenu


    Static void MostraMenu()
    {
        Console.WriteLine($"===MENU===");
        Console.WriteLine($"[1]Aggiungi materiale");
        Console.WriteLine($"[2]Visualizza materiali disponibili");
        Console.WriteLine($"[3]Calcola vestiti producibili");
        Console.WriteLine($"[4]Esci");


    }

}