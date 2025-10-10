namespace Formazioni.CorsoOnLine
{
    using Formazioni.Corso;
    public class CorsoOnLine : Corso
    {
        private string _piattaforma;
        public string Piattaforma { get { return _piattaforma; } set { _piattaforma = value; } }

        private string _linkAccesso;
        public string LinkAccesso { get { return _linkAccesso; } set { _linkAccesso = value; } }

        public override void ErogaCorso()
        {
            Console.WriteLine($"Il corso: '{NomeCorso}' verrà erogato");
        }

        public override void MostraDettagli()
        {
            Console.WriteLine($"Il corso: '{NomeCorso}' della categoria: {CategoriaCorso} ha una durata di: {DurataOre} ore, si terrà sulla piattaforma: {Piattaforma} raggiungibile tramite il Link di accesso: {LinkAccesso}");
        }
    }
}