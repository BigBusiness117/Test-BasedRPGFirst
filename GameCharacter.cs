using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class GameCharacter
    {
        
        protected int health;
        protected bool moving;
        public bool turn;
        public bool playerAlive;
        public bool enemyAlive;
        public int round;
      public GameCharacter()
        {
            round = 1;
            playerAlive = true;
            enemyAlive = true;
            health = 100;
            moving = true;
            
        }
        // checks if player hits the enemy
        public void CheckEnemy(int playerX, int enemyX, int playerY, int enemyY )
        {
            Console.SetCursorPosition(70, 15);
            //Console.WriteLine("EX: "+ enemyX + "EY: " + enemyY + "PX: " + playerX + "PY: " + playerY);
            if (playerY == enemyY && enemyAlive  )
                {
                    if (playerX == enemyX)
                    {
                        Console.SetCursorPosition(70, 15);
                        Console.Beep(170, 200);
                        Console.WriteLine("You Have Killed enemy");
                    //map.winScreen();
                    //enemyX = 0;
                   // enemyY = 0;
                        enemyAlive = false;
                    }
                }
        }
        public void CheckPlayer(int playerX, int enemyX, int playerY, int enemyY)
        {
            Console.SetCursorPosition(70, 15);
            //Console.WriteLine("EX: " + enemyX + "EY: " + enemyY + "PX: " + playerX + "PY: " + playerY);
            if (playerY == enemyY && enemyAlive)
            {
                if (playerX == enemyX)
                {
                    Console.SetCursorPosition(100, 30);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Died");
                    //map.winScreen();
                    playerAlive = false;
                    //playerX = 0;
                    //playerY = 0;
                }
            }
        }
    }
}
