namespace LaboratorioElettronico.Dispositivi
{
    public abstract class DispositivoElettronico
    {
        private string _modello;
        public string Modello
        {
            get { return _modello; }
            set { _modello = value; }
        }

        public abstract void Accendi();
        public abstract void Spegni();
        public virtual void MostraInfo()
        {
            Console.WriteLine($"Dispositivo Modello: {Modello}");
        }
    }
}