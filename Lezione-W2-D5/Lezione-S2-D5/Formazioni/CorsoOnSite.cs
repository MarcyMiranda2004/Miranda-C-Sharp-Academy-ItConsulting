namespace Formazioni.CorsoOnSite
{
    using Formazioni.Corso;
    public class CorsoOnSite : Corso
    {
        private string _aula;
        public string Aula { get { return _aula; } set { _aula = value; } }

        private int _postiDisponibili;
        public int PostiDisponibili
        {
            get { return _postiDisponibili; }
            set
            {
                _postiDisponibili = value;

                if (_postiDisponibili < 1)
                {
                    Console.WriteLine($"Deve esserci almeno 1 posto disponibile nel corso");
                }
            }
        }

        public override void ErogaCorso()
        {
            Console.WriteLine($"Il corso: '{NomeCorso}' verrà erogato");
        }

        public override void MostraDettagli()
        {
            Console.WriteLine($"Il corso: '{NomeCorso}' della categoria: {CategoriaCorso} ha una durata di: {DurataOre} ore, si terrà in aula: {Aula} e ha {PostiDisponibili} posti disponibili");
        }
    }
}