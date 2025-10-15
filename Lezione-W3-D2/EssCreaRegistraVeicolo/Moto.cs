namespace EssCreaRegistraVeicolo.Moto
{
    public class Moto : Veicolo
    {
        public override void Avvia()
        {
            Console.WriteLine($"Avvio Della Moto");
        }

        public override void MostraTipo()
        {
            Console.WriteLine($"Tipo: Moto");
        }
    }
}

/* 
Decorator


Decorator incapsula un
IComponent e la sua Operation()
di default lo delega
internamente.


ConcreteDecoratorA e
ConcreteDecoratorB estendono
Decorator, override Operation()
per infiocchettare logica custom
prima/dopo la chiamata interna.


In Program.Main si vede come
costruire catene di decorator,
applicando più comportamenti in
cascata.
 */