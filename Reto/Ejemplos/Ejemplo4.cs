namespace Reto.Ejemplos4
{
    public interface ITrabajador
    {
        void Trabajar();
        void Descansar();
        void Comer();
    }

    public class TrabajadorPlanta : ITrabajador
    {
        public void Trabajar()
        {
            //Trabaja mucho
        }
        public void Descansar()
        {
            //Descansa poco
        }

        public void Comer()
        {
            //Nada, como en casa y aquí no se contempla que un trabajador de planta pueda comer...
            //¿Para qué?
        }       
        
    }
    public class Desarrollador : ITrabajador
    {
        public void Trabajar()
        {
            //Parece que bastante
        }
        public void Descansar()
        {
            //"... es que estoy compilando el código..."
        }
        public void Comer()
        {
            //y también beber café
        }
    }

    public class Robot : ITrabajador
    {
        public void Trabajar()
        {
            //Soy el que más trabajo, de eso no cabe duda
        }
        public void Descansar()
        {
            //¿Descansar yo?
        }
        public void Comer()
        {
            //¿?
        }
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
