using System;
using System.ComponentModel;
using Sprites.ShipModels; // Asegúrate de usar el espacio de nombres correcto

namespace Sprites.ViewModels
{
    public class ShipViewModel
    {
        public ShipModel Ship { get; private set; }

        public ShipViewModel()
        {
            Ship = new ShipModel();  // Usar ShipModel de la carpeta Model
        }

        public void MoveUp()
        {
            Ship.MoveUp(); // Llamada al método MoveUp de ShipModel
        }

        public void MoveDown()
        {
            Ship.MoveDown(); // Llamada al método MoveDown de ShipModel
        }

        public void StopMovement()
        {
            
        }
    }
}
