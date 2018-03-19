using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    abstract class Ship
    {
        public int Size { get; set; }
        public bool IsHorizontal { get; set; }
        protected Cell[] ship;
    }
}
