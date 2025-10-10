namespace GestionePagamenti.IPagamento
{
    public interface IPagamento
    {
        void EseguiPagamento(decimal importo);
        void MostraMetodo();
    }
}