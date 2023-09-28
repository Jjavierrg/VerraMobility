using System;

namespace Reto.Solucion1
{
    public interface IContenidoMail
    {
        string GetContenidoCodificado();
    }

    public interface ICorreoElectronico
    {
        void SetEmisor(string emisor);
        void SetReceptor(string receptor);
        void SetContenido(IContenidoMail contenido);
    }

    public class ContenidoSinLetrasA: IContenidoMail
    {
        private readonly string _contenido;

        public ContenidoSinLetrasA(string contenido) => _contenido = contenido;

        public string GetContenidoCodificado() => _contenido?.Replace("a", "");
    }

    public class ContenidoConAdjunto : IContenidoMail
    {
        private readonly string _nombreAdjunto;

        public ContenidoConAdjunto(string nombreAdjunto) => _nombreAdjunto = nombreAdjunto;

        public string GetContenidoCodificado() => $"Adjuntado fichero con nombre {_nombreAdjunto}";
    }

    public class CorreoElectronico : ICorreoElectronico
    {
        public void SetEmisor(string emisor)
        {

        }
        public void SetReceptor(string receptor)
        {

        }
        public void SetContenido(IContenidoMail contenido)
        {

        }
    }
}