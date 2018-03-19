using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class Player
    {
        Cell firstStep;
        Field myOwnShipsField;
        Field enemyShipsField;
        Random randForShipYard;
        Shipyard testYard;
        List<Cell> CellList;
        
        public Player()
        {
            myOwnShipsField = new Field();
            enemyShipsField = new Field();
            randForShipYard = new Random();
            firstStep = new Cell { X = 1, Y = 1 };
            testYard = new Shipyard(randForShipYard);
            ShipAdder.ShipManager(ref myOwnShipsField, testYard);

            //myOwnShipsField.PrintField();
            //enemyShipsField.PrintField();
            
        }
        
        public Cell ShotEvent ()
        {
            Cell test = new Cell { X = firstStep.X, Y = firstStep.Y };

            if (firstStep.X == myOwnShipsField.GetHorizontalSize())
            {
                firstStep.X = 1;
                firstStep.Y++;
            }
            else
            {
                firstStep.X++;
            }
            
            return test;
        }

        public bool ShotHandler (Cell currentCell)
        {
            return (myOwnShipsField.StateChanger(currentCell)) ? true : false;   
        }
        
        public bool FieldChecker()
        {
            return myOwnShipsField.IsShipConsistChecker();
        }

        public void PrintHit()
        {
            myOwnShipsField.PrintField();
        }
    }
}