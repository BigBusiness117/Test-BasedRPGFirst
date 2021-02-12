using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Player : GameCharacter
    {
        
        private int origWidth;
        private int origHeight;
        private string[] playerIcon; 
        public int playerX;
        public int playerY;
        public Player()
        {
            //turn = false;
            playerX = 3;
            playerY = 3;
            //can player move or not
            moving = true;
            origHeight = Console.WindowHeight;
            origWidth = Console.WindowWidth;
        }
        // draws player to screen
        public void drawPlayer()
        {
            playerIcon = new string[] { "@" };
            Console.SetCursorPosition(playerX , playerY);
        }
        // move player
        public void movePlayer()
        {
            Map map = new Map();
             
            map.border();
            Console.Write(playerIcon[0]);
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
       
            // check if player pressed w
            if (input.KeyChar == 'w')
            {
                // check to see if there is a border and if so make player cant move that way and plays a sound
                if (map.worldMap[playerY - 1, playerX] == "x"){moving = false; Console.Beep(300, 100); }
                // makes the player move depending on the key pressed
                else if (map.worldMap[playerY, playerX] == "." && moving == true){playerY = playerY - 1;}
            }
            else if (input.KeyChar == 's')
            {
                
                if (map.worldMap[playerY + 1, playerX] == "x"){moving = false; Console.Beep(300, 100); }
                else if (map.worldMap[playerY, playerX] == "." && moving == true){playerY = playerY + 1;}
            }
            else if (input.KeyChar == 'a')
            {
                if (map.worldMap[playerY, playerX - 1] == "x"){ moving = false; Console.Beep(300, 100); }
                else if (map.worldMap[playerY, playerX] == "." && moving == true){playerX = playerX - 1;}
            }
            else if (input.KeyChar == 'd')
            {
                if (map.worldMap[playerY, playerX + 1] == "x"){moving = false; Console.Beep(300, 100); }
                else if (map.worldMap[playerY, playerX] == "." && moving == true){playerX = playerX + 1; }
            }
            moving = true;
            
        }

    }
}
