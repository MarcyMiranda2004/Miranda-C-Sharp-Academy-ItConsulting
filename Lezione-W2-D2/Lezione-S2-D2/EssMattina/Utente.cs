namespace GestioneUtente;

class Utente
{
    public string Nome;
    public string Cognome;
    public int Crediti;

    public Utente(string nome, string cognome, int crediti)
    {
        Nome = nome;
        Cognome = cognome;
        Crediti = crediti;
    }
}