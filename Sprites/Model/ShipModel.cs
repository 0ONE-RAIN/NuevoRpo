using System.ComponentModel;
using System.Drawing;

namespace Sprites.ShipModels
{
    public class ShipModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int _width = 100;
        private int _height = 100;
        private int _playerX = 100;
        private int _playerY = 100;
        private Image _currentSprite;

        public int Width => _width;
        public int Height => _height;

        public int PlayerX
        {
            get => _playerX;
            set
            {
                if (_playerX != value)
                {
                    _playerX = value;
                    OnPropertyChanged(nameof(PlayerX));
                }
            }
        }

        public int PlayerY
        {
            get => _playerY;
            set
            {
                if (_playerY != value)
                {
                    _playerY = value;
                    OnPropertyChanged(nameof(PlayerY));
                }
            }
        }

        public Image CurrentSprite
        {
            get => _currentSprite;
            set
            {
                if (_currentSprite != value)
                {
                    _currentSprite = value;
                    OnPropertyChanged(nameof(CurrentSprite));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MoveUp() => PlayerY -= 10;
        public void MoveDown() => PlayerY += 10;
    }
}