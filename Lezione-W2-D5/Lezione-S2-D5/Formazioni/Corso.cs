namespace Formazioni.Corso
{
    public abstract class Corso
    {
        private string _nomeCorso;
        public string NomeCorso { get { return _nomeCorso; } set { _nomeCorso = value; } }

        private string _categoriaCorso;
        public string CategoriaCorso { get { return _categoriaCorso; } set { _categoriaCorso = value; } }

        private int _durataOre;
        public int DurataOre
        {
            get { return _durataOre; }
            set
            {
                _durataOre = value;

                if (_durataOre < 1)
                {
                    Console.WriteLine($"il corso deve durare almeno 1 ora");
                }
            }

        }

        public abstract void ErogaCorso();
        public abstract void MostraDettagli();
    }
}