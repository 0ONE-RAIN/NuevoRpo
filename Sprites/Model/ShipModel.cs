using System.ComponentModel;
using Sprites;
namespace Sprites.ShipModels
{
    public class ShipModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { }; // Inicialización
        private int _width = 100;
        private int _height = 100; 

        private int playerX;

        public int Width { 
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }
        public int PlayerX
        {
            get => playerX;
            set
            {
                if (playerX != value)
                {
                    playerX = value;
                    OnPropertyChanged(nameof(PlayerX));
                }
            }
        }

        private int playerY;
        public int PlayerY
        {
            get => playerY;
            set
            {
                if (playerY != value)
                {
                    playerY = value;
                    OnPropertyChanged(nameof(PlayerY));
                }
            }
        }

        private string currentDirection = "Idle";
        public string CurrentDirection
        {
            get => currentDirection;
            set
            {
                if (currentDirection != value)
                {
                    currentDirection = value;
                    OnPropertyChanged(nameof(CurrentDirection));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Métodos de movimiento
        public void MoveUp()
        {
            PlayerY -= 10;  // Movimiento hacia arriba
        }

        public void MoveDown()
        {
            PlayerY += 10;  // Movimiento hacia abajo
        }
    }
}