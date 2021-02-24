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
        public bool playerMoving = true;

        public Player()
        {
            //turn = false;
            playerX = 3;
            playerY = 3;
            //can player move or not

            origHeight = Console.WindowHeight;
            origWidth = Console.WindowWidth;
        }
        // draws player to screen
        public void drawPlayer(Enemy enemy)
        {
            //Console.SetCursorPosition(70, 15);
            // Console.WriteLine(enemy.enemyY - 1 + " " + playerY + " " + playerX + " hi");
            Console.SetCursorPosition(playerX, playerY);
            if(playerMoving == true) { 
            playerIcon = new string[] { "@" };
            Console.Write(playerIcon[0]);
            }
        }
        // move player
        public void movePlayer(Enemy enemy, Map map)
        {

            
            //ap map = new Map();

            map.border();
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            
            if (playerMoving == true)
            {

                // check if player pressed w
                if (input.KeyChar == 'w')
                {

                    moving = true;
                    // check to see if there is a border and if so make player cant move that way and plays a sound
                    if (map.worldMap[playerY - 1, playerX] == "x") { moving = false; Console.Beep(300, 100); }
                    // makes the player move depending on the key pressed
                    else if (map.worldMap[playerY, playerX] == "." && moving == true) { playerY = playerY - 1; }
                }
                else if (input.KeyChar == 's')
                {
                    moving = true;
                    if (map.worldMap[playerY + 1, playerX] == "x") { moving = false; Console.Beep(300, 100); }
                    else if (map.worldMap[playerY, playerX] == "." && moving == true) { playerY = playerY + 1; }
                }
                else if (input.KeyChar == 'a')
                {
                    moving = true;
                    if (map.worldMap[playerY, playerX - 1] == "x") { moving = false; Console.Beep(300, 100); }
                    else if (map.worldMap[playerY, playerX] == "." && moving == true) { playerX = playerX - 1; }
                }
                else if (input.KeyChar == 'd')
                {
                    moving = true;
                    if (map.worldMap[playerY, playerX + 1] == "x") { moving = false; Console.Beep(300, 100); }
                    else if (map.worldMap[playerY, playerX] == "." && moving == true) { playerX = playerX + 1; }
                }
            }

        }
        public void CheckAllEnemy(Enemy enemy)
        {
            if (playerY == enemy.enemyY)
            {
                if (playerX == enemy.ememyX)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed enemy");
                    //map.winScreen();
                    //enemyX = 0;
                    // enemyY = 0;
                    enemy.enemyAlive = false;
                    enemy.enemyallDead = true;
                }
            }
            if (playerY == enemy.horizontalEnemyY)
            {
                if (playerX == enemy.horizontalEnemyX)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed horizontal enemy");
                    //map.winScreen();
                    //enemyX = 0;
                    // enemyY = 0;
                    enemy.horizontalEnemyDead = true;
                }
            }
            if (playerY == enemy.stillEnemyY)
            {
                if (playerX == enemy.stillEnemyX)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed still enemy");
                    //map.winScreen();
                    //enemyX = 0;
                    // enemyY = 0;
                    enemy.stillEnemyDead = true;
                }
            }
        }
    }

}
