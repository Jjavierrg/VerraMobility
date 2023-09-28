using Reto.Solucion1;
using System;

namespace Reto
{
    class Program
    {
        static void Main(string[] args)
        {
            printSolution1();
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
    }
}
