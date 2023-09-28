namespace Reto.Solucion3
{
    public interface IFiguraRectangular
    {
        int GetArea();
    }

    public class Rectangulo : IFiguraRectangular
    {
        private readonly int _alto;
        private readonly int _ancho;

        public Rectangulo(int alto, int ancho)
        {
            _alto = alto;
            _ancho = ancho;
        }

        public int GetArea() => _alto * _ancho;
    }

    public class Cuadrado : IFiguraRectangular
    {
        private readonly int _lado;

        public Cuadrado(int lado) => _lado = lado;

        public int GetArea() => _lado * _lado;
    }

}
