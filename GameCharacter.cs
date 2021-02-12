using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class GameCharacter
    {
        public int kx;
        public int ky;
        public int health;
        public bool moving;
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
            kx = 3;
            ky = 3;
            moving = true;
            
        }
        public void CheckEnemy(int playerX, int enemyX, int playerY, int enemyY)
        {
                if (playerY == enemyY )
                {
                    if (playerX == enemyX)
                    {
                        Console.SetCursorPosition(50, 10);
                        Console.WriteLine("worked");
                        enemyAlive = false;
                    }
                }
        }
        
    }
}
