using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sprites.ViewModels; // Agregar el espacio de nombres de ViewModel
using Sprites.ShipModels; // Asegúrate de que este using esté presente

namespace Sprites
{
    public partial class Form1 : Form
    {
        private ShipViewModel viewModel;

        public Form1()
        {
            InitializeComponent();
            viewModel = new ShipViewModel();

            // Permitir que el formulario capture las teclas
            this.KeyPreview = true;

            // Suscribirse a cambios en el modelo
            viewModel.Ship.PropertyChanged += Ship_PropertyChanged;
        }

        private void Ship_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.Ship.PlayerX) ||
                e.PropertyName == nameof(viewModel.Ship.PlayerY) ||
                e.PropertyName == nameof(viewModel.Ship.CurrentDirection))
            {
                Invalidate(); // Redibujar cuando haya cambios
            }
        }

        private new void KeyUp(object sender, KeyEventArgs e)  // Añadir 'new'
        {
            // Detener animación cuando no se presiona una tecla
            viewModel.StopMovement();
        }

        private new void KeyDown(object sender, KeyEventArgs e)  // Añadir 'new'
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

        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Image sprite = viewModel.Ship.CurrentDirection;
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
