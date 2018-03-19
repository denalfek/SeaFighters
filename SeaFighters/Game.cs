using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SeaFighters
{
    class Game
    {
        Player aPlayer;
        Player bPlayer;
        
        bool hit;
        bool isHitted;
        bool showMustGoOn;

        public Game()
        {
            aPlayer = new Player();
            bPlayer = new Player();
            
            hit = true;
        }

        public void Battle()
        {
            do
            {
                if (hit)
                {
                    isHitted = bPlayer.ShotHandler(aPlayer.ShotEvent());
                }
                else
                {
                    isHitted = aPlayer.ShotHandler(bPlayer.ShotEvent());
                }

                //Console.WriteLine(isHitted);
                if (!isHitted)
                {
                    PlayerChanger();
                }


                //ancillary code: prints the events

                Console.Clear();
                PrintEvent();
                //Thread.Sleep(3000);

                if (aPlayer.FieldChecker()) { showMustGoOn = true; }
                else if (bPlayer.FieldChecker()) { showMustGoOn = true; }
                else { showMustGoOn = false; }
                
            } while (showMustGoOn);
        }

        private void PlayerChanger()
        {
            hit = !hit;
        }
        
        private void PrintEvent()
        {
            aPlayer.PrintHit();
            bPlayer.PrintHit();
        }
    }
}