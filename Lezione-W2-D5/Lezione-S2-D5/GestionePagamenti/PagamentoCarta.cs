namespace GestionePagamenti.PagamentoCarta
{
    using GestionePagamenti.IPagamento;
    public class PagamentoCarta : IPagamento
    {
        private string _circuito;
        public string Circuito { get { return _circuito; } set { _circuito = value; } }

        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} pagati con carta {Circuito}.");
        }

        public void MostraMetodo()
        {
            Console.WriteLine($"Metodo: Carta");
        }
    }
}