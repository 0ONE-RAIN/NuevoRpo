using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sprites.ViewModels;

namespace Sprites
{
    public partial class Form1 : Form
    {
        private readonly ShipViewModel viewModel;

        public Form1()
        {
            InitializeComponent();
            viewModel = new ShipViewModel();

            // Configurar eventos
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            DoubleBuffered = true; // Para evitar parpadeo

            // Suscribirse a cambios
            viewModel.Ship.PropertyChanged += Ship_PropertyChanged;
        }

        private void Ship_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.Ship.PlayerX) ||
                e.PropertyName == nameof(viewModel.Ship.PlayerY) ||
                e.PropertyName == nameof(viewModel.Ship.CurrentSprite))
            {
                Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    viewModel.MoveUp();
                    break;
                case Keys.Down:
                    viewModel.MoveDown();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            viewModel.StopMovement();
        }

        private void PaintEvent(object sender, PaintEventArgs e)
        {
            var sprite = viewModel.Ship.CurrentSprite;
            if (sprite != null)
            {
                e.Graphics.DrawImage(sprite,
                    viewModel.Ship.PlayerX,
                    viewModel.Ship.PlayerY,
                    viewModel.Ship.Width,
                    viewModel.Ship.Height);
            }
        }
    }
}