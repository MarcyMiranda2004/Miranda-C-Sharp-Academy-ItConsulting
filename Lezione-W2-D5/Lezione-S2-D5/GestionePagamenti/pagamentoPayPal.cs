namespace GestionePagamenti.PagamentoPayPal
{
    using GestionePagamenti.IPagamento;
    public class PagamentoPayPal : IPagamento
    {
        private string _emailUtente;
        public string EmailUtente { get { return _emailUtente; } set { _emailUtente = value; } }

        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} pagati con PayPal da {EmailUtente}.");
        }

        public void MostraMetodo()
        {
            Console.WriteLine($"Metodo: PayPal");
        }
    }
}