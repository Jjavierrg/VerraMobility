using Reto.Solucion1;
using Reto.Solucion2;
using Reto.Solucion3;
using Reto.Solucion4;
using System;
using System.Collections.Generic;

namespace Reto
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrintSolution1();
            // PrintSolution2();
            // PrintSolution3();
            PrintSolution4();
        }

        static void PrintSolution1()
        {
            ICorreoElectronico mail = new CorreoElectronico();
            mail.SetEmisor("jjavierrg@gmail.com");
            mail.SetReceptor("hello@verramobility.com");

            IContenidoMail contenido1 = new ContenidoSinLetrasA("Texto de prueba. Esta cadena no debería contener letras a");
            mail.SetContenido(contenido1);
            Console.WriteLine($"El contenido 1 del mensaje se establece como: {contenido1.GetContenidoCodificado()}");

            IContenidoMail contenido2 = new ContenidoConAdjunto("Fichero de prueba");
            Console.WriteLine($"El contenido 2 del mensaje se establece como: {contenido2.GetContenidoCodificado()}");
            mail.SetContenido(contenido2);

        }

        static void PrintSolution2()
        {
            IEditorGráfico editor = new EditorGraficoPorConsola();
            var formas = new List<IForma> { new Circulo(), new Solucion2.Rectangulo(), new Solucion2.Cuadrado() };

            formas.ForEach(forma =>
            {
                editor.DibujarForma(forma);
                editor.EditarForma(forma);
                editor.BorrarForma(forma);
            });
        }

        static void PrintSolution3()
        {
            IFiguraRectangular forma = new Solucion3.Rectangulo(5, 2);
            PrintShapeArea(forma);

            forma = new Solucion3.Cuadrado(4);
            PrintShapeArea(forma);
        }

        static void PrintShapeArea(IFiguraRectangular forma) => Console.WriteLine($"El área de la forma rectangular es es: {forma.GetArea()}");

        static void PrintSolution4()
        {
            var trabajadores = new List<ITrabajador> { new TrabajadorPlanta(), new Desarrollador(), new Robot() };
            var jefe = new JefeDespota();

            trabajadores.ForEach(trabajador =>
            {
                jefe.ElegirTrabajador(trabajador);
                jefe.Mandar();
            });
        }

    }
}
