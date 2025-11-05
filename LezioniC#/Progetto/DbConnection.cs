using System;
using MySql.Data.MySqlClient;

public class DbConnection
{
    private readonly string _connString;

    // Colors
    private ConsoleColor entityColor = ConsoleColor.Magenta;
    private ConsoleColor errorColor = ConsoleColor.Red;
    private ConsoleColor warningColor = ConsoleColor.Yellow;
    private ConsoleColor successColor = ConsoleColor.Green;

    public DbConnection(string connString)
    {
        _connString = connString;
    }

    public void ReadDB()
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))
        {
            try
            {
                conn.Open();
                Console.ForegroundColor = entityColor;
                Console.Write("[DATABASE] ");
                Console.ForegroundColor = successColor;
                Console.WriteLine("[OK] Connessione riuscita!");
                Console.ResetColor();

                string query = "SELECT * FROM contatti";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== Elenco contatti ===");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, Telefono: {reader["telefono"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = entityColor;
                Console.Write("[DATABASE] ");
                Console.ForegroundColor = errorColor;
                Console.WriteLine($"[ERRORE LETTURA DB] {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    public void InsertDB(string nome, string telefono)
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO contatti (nome, telefono) VALUES (@nome, @telefono)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@telefono", telefono);

                int rows = cmd.ExecuteNonQuery();
                Console.ForegroundColor = entityColor;
                Console.Write("[DATABASE] ");
                Console.ForegroundColor = successColor;
                Console.WriteLine($"[OK] {rows} contatto/i Inserito/1 con successo!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = entityColor;
                Console.Write("[DATABASE] ");
                Console.ForegroundColor = errorColor;
                Console.WriteLine($"[ERRORE INSERIMENTO] {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    public void DeleteDB(string nome)
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM contatti WHERE nome = @nome";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.ForegroundColor = entityColor;
                    Console.Write("[DATABASE] ");
                    Console.ForegroundColor = successColor;
                    Console.WriteLine($"[OK] Eliminato {rows} contatto/i con nome '{nome}'");
                }
                else
                {
                    Console.ForegroundColor = entityColor;
                    Console.Write("[DATABASE] ");
                    Console.ForegroundColor = warningColor;
                    Console.WriteLine($"[!] Nessun contatto trovato con nome '{nome}'");
                }

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = entityColor;
                Console.Write("[DATABASE] ");
                Console.ForegroundColor = errorColor;
                Console.WriteLine($"[ERRORE ELIMINAZIONE] {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
