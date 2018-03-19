using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighters
{
    class Shipyard
    {
        /*
        int oneDecked;
        int doubleDeck;
        int tripleDeck;
        int fourDeck;
        */

        public Ship[] shipList = new Ship[10];

        public Shipyard(Random someRandom)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    if (H_or_V(someRandom)) { shipList[i] = new HShip(4); }
                    else { shipList[i] = new VShip(4); }
                }
                else if (i > 0 && i < 3)
                {
                    if (H_or_V(someRandom)) { shipList[i] = new HShip(3); }
                    else { shipList[i] = new VShip(3); }
                }
                else if (i > 2 && i < 6)
                {
                    if (H_or_V(someRandom)) { shipList[i] = new HShip(2); }
                    else { shipList[i] = new VShip(2); }
                }
                else if (i > 5 && i < 10) { shipList[i] = new HShip(1); }
                
            }
        }

        private bool H_or_V(Random r2)
        {
            int assume = r2.Next(1, 6);
            
            if (assume % 2 == 0) { return true; }
            else { return false; }
        }

        public void PrintShipList() // Ship[] shipList
        {
            for(int i = 0; i < this.shipList.GetLength(0); i++)
            {
                Console.WriteLine(shipList[i].Size);
            }
        }
    }
}