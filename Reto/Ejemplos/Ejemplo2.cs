namespace Reto.Ejemplos2
{
    public interface IForma
    {
        int GetTipo();
    }
    public class Rectangulo : IForma
    {
        public int GetTipo()
        {
            return 1;
        }
    }

    public class Circulo : IForma
    {
        public int GetTipo()
        {
            return 2;
        }
    }

    public class EditorGrafico
    {
        public void DibujarForma(IForma forma)
        {
            switch(forma.GetTipo())
            {
                case 1:
                    DibujaUnRectangulo((Rectangulo)forma);
                    break;
                case 2:
                    DibujaUnCirculo((Circulo)forma);
                    break;
            }
        }

        private void DibujaUnCirculo(Circulo c)
        {
            //pinta un círculo
        }

        private void DibujaUnRectangulo(Rectangulo c)
        {
            //pinta un rectángulo
        }
    }
}
