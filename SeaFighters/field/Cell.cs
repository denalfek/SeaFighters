using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    struct Cell
    {
        public enum Condition : int
        {
            fillCell,
            emptyCell,
            damageCell,
            missCell,
            emptyBorder,
        }

        public Condition state;

        public int X { get; set; } // j
        public int Y { get; set; } // i
    }
}