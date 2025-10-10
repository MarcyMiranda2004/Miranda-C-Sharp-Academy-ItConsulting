namespace GestioneContoBancario;

public class ContoBancario
{
    public string Nome { get; set; }

    private string password;
    public string Password
    {
        set
        {
            if (password.Length < 8)
            {
                Console.WriteLine($"La password deve avere almeno 8 caratteri");
            }
        }
    }

    private decimal saldo;
    public decimal OttieniSaldo()
    {
        return saldo;
    }

    public void Deposita(decimal importo)
    {
        if (importo > 0)
        {
            saldo += importo;
        }
        else
        {
            Console.WriteLine($"inserisci un importo valido");
        }
    }

}