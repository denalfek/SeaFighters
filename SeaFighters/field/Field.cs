using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class Field
    {
        private int W = 12;
        private int H = 12;

        public Cell[,] WorkField { get; set; } 

        //public List<Cell> celList = new List<Cell>();
        
        public Field() // constructor, playField initialization
        {   
            WorkField = new Cell[H, W];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (i == 0 || i == H - 1 || j == 0 || j == W - 1)
                    {
                        WorkField[i, j].state = Cell.Condition.emptyBorder;
                    }
                    else WorkField[i, j].state = Cell.Condition.emptyCell;
                    WorkField[i, j].X = j;
                    WorkField[i, j].Y = i;
                    
                }
            }
        }

        public void PrintField()
        {
            for (int i = 0; i < H; i++)
            {
                Console.Write(' ');
                for (int j = 0; j < W; j++)
                {
                    if ((i == 0) && (j > 0) && (j < W - 1)) { Console.Write((char)('A' + j - 1)); }
                    else if ((j == W - 1) && (i < H - 1) && (i > 0)) { Console.Write(i); }
                    // ancillary code show x coordinates
                    //else if ((i == H -1) && (j > 0) && (j < W - 1)) { Console.Write(j); }
                    //--------------------------------------------------------------------
                    else if (WorkField[i, j].state == Cell.Condition.emptyCell) { Console.Write('~'); }
                    else if (WorkField[i, j].state == Cell.Condition.damageCell) { Console.Write('X'); }
                    else if (WorkField[i, j].state == Cell.Condition.missCell) { Console.Write('.'); }
                    else if (WorkField[i, j].state == Cell.Condition.fillCell) { Console.Write('O'); }
                    Console.Write(' ');
                }
                Console.WriteLine();
                
            }
        }

        public void Sweeper (ref Cell[,] PlayField)
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (PlayField[i, j].state != Cell.Condition.emptyCell &&
                        PlayField[i, j].state != Cell.Condition.emptyBorder)
                    {
                        PlayField[i, j].state = Cell.Condition.emptyCell;
                    }
                }
            }
        }

        private bool StateChecker (Cell shot)
        {
            return shot.state == Cell.Condition.fillCell ? true : false;
        }

        private bool IsDamageCell(Cell currentShot)
        {
            if (WorkField[currentShot.Y, currentShot.X].state == Cell.Condition.fillCell)
            {
                return true;
            }
            else return false;
        }

        public bool StateChanger (Cell shot)
        {
            if (IsDamageCell(shot))
            {
                WorkField[shot.Y, shot.X].state = Cell.Condition.damageCell;
                return true;
            }
            else
            {
                WorkField[shot.Y, shot.X].state = Cell.Condition.missCell;
                return false;
            }
        }
        
        public int GetHorizontalSize()
        {
            return W - 2;
        }

        public bool IsShipConsistChecker()
        {
            for (int i = 1; i < W; i++)
            {
                for (int j = 1; j < H; j++)
                {
                    if (WorkField[i, j].state == Cell.Condition.fillCell) { return true; }
                }
            }
            return false;
        }
    }
}