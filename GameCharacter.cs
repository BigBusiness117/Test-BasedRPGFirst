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
        //public int round;
      public GameCharacter()
        {
            //round = 1;
            playerAlive = true;
            enemyAlive = true;
            health = 100;
            moving = true;
            
        }
        // checks if player hits the enemy
        public void CheckEnemy(int playerX, int enemyX, int playerY, int enemyY)
        {
            Map map = new Map();
                if (playerY == enemyY )
                {
                    if (playerX == enemyX)
                    {
                        Console.SetCursorPosition(70, 15);
                        Console.Beep(170, 200);
                        Console.WriteLine("You Have Killed enemy");
                        map.winScreen();
                        enemyAlive = false;
                    }
                }
        }
       
    }
}
