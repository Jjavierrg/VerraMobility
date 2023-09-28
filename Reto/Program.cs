using Reto.Solucion1;
using Reto.Solucion2;
using System;
using System.Collections.Generic;

namespace Reto
{
    class Program
    {
        static void Main(string[] args)
        {
            // printSolution1();
            printSolution2();
        }

        static void printSolution1()
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

        static void printSolution2()
        {
            IEditorGráfico editor = new EditorGraficoPorConsola();
            var formas = new List<IForma> { new Circulo(), new Rectangulo(), new Cuadrado() };

            formas.ForEach(forma =>
            {
                editor.DibujarForma(forma);
                editor.EditarForma(forma);
                editor.BorrarForma(forma);
            });
        }
    }
}
