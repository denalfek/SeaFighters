using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class VShip : Ship
    {
        public VShip(int size)
        {
            this.Size = size;
            this.IsHorizontal = false;
            this.ship = new Cell[this.Size];

            for (int i = 0; i < this.Size; i++)
            {
                this.ship[i].state = Cell.Condition.fillCell;
            }
        }

        public void VShipCoordinator(int x, int y)
        {
            for (int i = 0; i < this.Size; i++)
            {
                this.ship[i].X = x;
                this.ship[i].Y = y + i;
            }
        }
    }
}