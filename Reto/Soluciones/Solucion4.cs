namespace Reto.Solucion4
{
    using System;

    public interface ITrabajar
    {
        void Trabajar();
    }

    public interface IDescansar
    {
        void Descansar();
    }

    public interface IComer
    {
        void Comer();
    }

    public interface ITrabajador: ITrabajar
    {
    }

    public class TrabajadorPlanta : ITrabajador, IDescansar
    {
        public void Trabajar() => Console.WriteLine("TrabajadorPlanta: Trabaja mucho");
        public void Descansar() => Console.WriteLine("TrabajadorPlanta: Descansa poco");
    }
    public class Desarrollador : ITrabajador, IComer
    {
        public void Trabajar() => Console.WriteLine("Desarrollador: Parece que bastante");
        public void Comer() => Console.WriteLine("Desarrollador: y también beber café");
    }

    public class Robot : ITrabajador
    {
        public void Trabajar() => Console.WriteLine("Robot: Soy el que más trabajo, de eso no cabe duda");
    }

    public class JefeDespota
    {
        //éste no falla...
        private ITrabajador _trabajador;
        public void ElegirTrabajador(ITrabajador trabajador)
        {
            //¿Y si me elige a mí?
            _trabajador = trabajador;
        }
        public void Mandar()
        {
            //¡A ver qué pide ahora!
            _trabajador.Trabajar();
        }
    }
}
