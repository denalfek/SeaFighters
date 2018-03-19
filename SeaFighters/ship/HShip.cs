using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class HShip : Ship
    {
        public HShip(int size)
        {
            this.Size = size;
            this.IsHorizontal = true;
            this.ship = new Cell[this.Size];
            
            for (int i = 0; i < this.Size; i++)
            {
                this.ship[i].state = Cell.Condition.fillCell;
            }
        }

        public void HShipCoordinator(int x, int y)
        {
            for (int i = 0; i < this.Size; i++)
            {
                this.ship[i].X = x + i;
                this.ship[i].Y = y;
            }
        }
    }
}