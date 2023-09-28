using System;

namespace Reto.Ejemplos3
{
    public class Rectangulo
    {
        public virtual int Alto { get; set; }
        public virtual int Ancho { get; set; }
        public int GetArea()
        {
            return Alto * Ancho;
        }
    }
    public class Cuadrado : Rectangulo
    {
        public override int Alto
        {
            get { return base.Alto; }
            set { base.Alto = base.Ancho = value; }
        }
        public override int Ancho
        {
            get { return base.Ancho; }
            set { base.Ancho = base.Alto = value; }
        }
    }
    public class Prueba
    {
        private Rectangulo GetNewRectangulo()
        {
            //Podría ser cualquier objeto que también sea un rectángulo...
            //por ejemplo un cuadrado...¿No?
            return new Cuadrado();
        }
        public void Main()
        {
            var r = GetNewRectangulo();

            //El usuario "sabe" que r es un rectángulo
            //y asume que puede darle valor al alto y al ancho....
            r.Alto = 2;
            r.Ancho = 3;

            Console.WriteLine(r.GetArea());
                //Y al ver la consola el usuario dice: WTF!
        }
    }

   
}
