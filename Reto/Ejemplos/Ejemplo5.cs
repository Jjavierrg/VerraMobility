namespace Reto.Ejemplos5
{
    public class Door
    {
    }
    public class Window
    {
    }
    public class House
    {
        private Door _door;
        private Window _window;
        public House()
        {
            _door = new Door();
            _window = new Window();
        }
    }

}
