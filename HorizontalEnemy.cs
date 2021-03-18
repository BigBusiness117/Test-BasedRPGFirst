using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class HorizontalEnemy : Enemy
    {
        public HorizontalEnemy()
        {
            enemyIcon = new string[] { ">", "<" };
            X = 1;
            Y = 4;

        }
        public override void drawEnemy()
        {
            if (enemyDead == false)
            {
                Console.SetCursorPosition(X, Y);
                if (movingLeft == true)
                {
                    Console.Write(enemyIcon[1]);
                }
                if (movingLeft == false)
                {
                    Console.Write(enemyIcon[0]);
                }

            }
        }
        public override void enemyMove(Map map, Player player)
        {
            TakeDamge(25);
            Console.SetCursorPosition(X, Y);
            if (enemyDead == false)
                {
                  if (map.displayMap[X - 1, Y] == 'x')
                  {
                       movingLeft = false;
                  }
                  if (movingLeft == false)
                 {
                     X++;
                 }
                 if (map.displayMap[X , Y] == 'x')
                  {
                    movingLeft = true;
                }
                if (movingLeft == true)
                {
                     X--;
                  }
                }
                EnemyDealDamage = false;

        }
        public override void CheckAllPlayer(Player player)
        {
            if (player.Y == Y)
            {
              if (player.X == X)
              {

                          Console.SetCursorPosition(40, 15);
                          Console.Beep(170, 200);
                          Console.WriteLine("You Have Killed Player");
                          if(movingLeft == false) { X--; } else { X++; }

                    //map.winScreen();
                    EnemyDealDamage = true;
              }
            }
                
        }
    }
}

