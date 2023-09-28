namespace Reto.Solucion2
{
    using System;

    public interface IForma
    {
        abstract void DibujarForma();
        void BorrarForma();
        void EditarForma();
    }

    public abstract class Forma: IForma {
        protected readonly string nombreFigura;
        protected Forma(string nombreFigura) => this.nombreFigura = nombreFigura;

        public abstract void DibujarForma();
        public virtual void BorrarForma() => Console.WriteLine($"Borrando Figura {nombreFigura} desde clase base");
        public virtual void EditarForma() => Console.WriteLine($"Editando Figura {nombreFigura} desde clase base");

    }

    public class Rectangulo : Forma
    {
        public Rectangulo() : base("Rectángulo") { }

        public override void DibujarForma() => Console.WriteLine("Dibujando un Rectángulo");
    }

    public class Circulo : Forma
    {
        public Circulo() : base("Círculo") { }
        public override void DibujarForma() => Console.WriteLine("Dibujando un Círculo");
        public override void EditarForma() => Console.WriteLine($"Editando forma círculo desde clase derivada");

    }

    public class Cuadrado : Forma
    {
        public Cuadrado() : base("Cuadrado") { }
        public override void DibujarForma() => Console.WriteLine("Dibujando un Cuadrado");
        public override void BorrarForma() => Console.WriteLine($"Borrando forma cuadrado desde clase derivada");
    }

    public interface IEditorGráfico
    {
        void DibujarForma(IForma forma);
        void EditarForma(IForma forma);
        void BorrarForma(IForma forma);
    }

    public class EditorGraficoPorConsola : IEditorGráfico
    {
        public void DibujarForma(IForma forma) => forma?.DibujarForma();
        public void EditarForma(IForma forma) => forma?.EditarForma();
        public void BorrarForma(IForma forma) => forma?.BorrarForma();
    }
}
