namespace GestionePagamenti.PagamentoContanti
{
    using GestionePagamenti.IPagamento;
    public class PagamentoContanti : IPagamento
    {
        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} pagati in Contanti.");
        }

        public void MostraMetodo()
        {
            Console.WriteLine($"Metodo: Contanti");
        }
    }
}