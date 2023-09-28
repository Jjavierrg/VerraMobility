namespace Reto.Solucion5
{
    public interface ICanOpen
    {
        void OnOpen();
    }

    public interface ICanClose
    {
        void OnClose();
    }

    public interface IDoor: ICanOpen, ICanClose
    {
        string GetColor();
    }

    public interface IWindow : ICanOpen, ICanClose
    {
        string GetSize();
    }

    public class WhiteDoor : IDoor
    {
        public string GetColor() => "Blanca";

        public void OnClose() { }

        public void OnOpen() { }
    }

    public class RedDoor : IDoor
    {
        public string GetColor() => "Roja";

        public void OnClose() { }

        public void OnOpen() { }
    }

    public class BigWindow : IWindow
    {
        public string GetSize() => "Grande";

        public void OnClose() { }

        public void OnOpen() { }
    }

    public class SmallWindow : IWindow
    {
        public string GetSize() => "Pequeña";

        public void OnClose() { }

        public void OnOpen() { }
    }

    public class House
    {
        private readonly IDoor _door;
        private readonly IWindow _window;

        public House(IWindow window, IDoor door)
        {
            _window = window;
            _door = door;
        }

        public string getDescription() => $"El color de la puerta es {_door.GetColor()} y el tamaño de la ventana es {_window.GetSize()}";
    }
}
