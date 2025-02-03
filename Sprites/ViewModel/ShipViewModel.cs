using Sprites.ShipModels;
using System.Media;

namespace Sprites.ViewModels
{
    public class ShipViewModel
    {
        public ShipModel Ship { get; }
        private readonly SoundPlayer _soundPlayer;
        private readonly Image _idleSprite;
        private readonly Image _jumpSprite;
        private readonly Image _slideSprite;

        public ShipViewModel()
        {
            Ship = new ShipModel();
            _soundPlayer = new SoundPlayer("sound.wav");

            // Cargar sprites desde recursos
            _idleSprite = Images.Resource1.Idle;
            _jumpSprite = Images.Resource1.Jump;
            _slideSprite = Images.Resource1.Slide;

            Ship.CurrentSprite = _idleSprite;
        }

        public void MoveUp()
        {
            Ship.CurrentSprite = _jumpSprite;
            Ship.MoveUp();
            PlaySound();
        }

        public void MoveDown()
        {
            Ship.CurrentSprite = _slideSprite;
            Ship.MoveDown();
            PlaySound();
        }

        public void StopMovement()
        {
            Ship.CurrentSprite = _idleSprite;
        }

        private void PlaySound()
        {
            try
            {
                _soundPlayer.Play();
            }
            catch { /* Manejar errores de sonido si es necesario */ }
        }
    }
}