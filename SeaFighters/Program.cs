using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class Program
     {
        static void Main(string[] args)
        {

            //Field myOwnShipsField = new Field();
            //Field myOwnShipsField2 = new Field();
            //Random randForShipYard = new Random();
            //Shipyard testYard = new Shipyard(randForShipYard);
            //ShipAdder.ShipManager(ref myOwnShipsField, testYard);
            //ShipAdder.ShipManager(ref myOwnShipsField2, testYard);
            //myOwnShipsField.PrintField();
            //myOwnShipsField2.PrintField();

            //Player aPlayer = new Player();

            Game testGame = new Game();
            testGame.Battle();


            
            // Delay
            //Console.ReadKey();
        }
    }
}