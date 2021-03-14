using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class StillEnemy : Enemy
    {
        public StillEnemy()
        {
            enemyIcon = new string[] { "S" };
            X = 56;
            Y = 8;
        }
        public override void drawEnemy()
        {
            if (enemyDead == false)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(enemyIcon[0]);
            }
        }
        public override void enemyMove(Map map, Player player)
        {
              enemyPushBackX = X;
              enemyPushBackY = Y;
            //if enemy is dead then stops moving
               if (enemyDead == false)
              {
            // takes damage if conditions are met
                 TakeDamge(25);
            // moves the enemy
                 if (Y - 2 == player.playerY && X == player.playerX || Y - 1 == player.playerY && X == player.playerX)
               {

                    Y = Y - 1;
               }
               if (Y + 2 == player.playerY && X == player.playerX || Y + 1 == player.playerY && X == player.playerX)
               {
            
                   Y = Y + 1;
              }
               if (Y == player.playerY && X - 2 == player.playerX || Y == player.playerY && X - 1 == player.playerX)
               {

                   X = X - 1;
               }
               if (Y == player.playerY && X + 2 == player.playerX || Y == player.playerY && X + 1 == player.playerX)
                {
            
                     X = X + 1;
                }
               }
               }
        public override void CheckAllPlayer(Player player)
        {
            if (player.playerY == Y)
            {
                if (player.playerX == X)
                {
                    Console.SetCursorPosition(40, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed Player");
                    EnemyDealDamage = true;
                    Y = enemyPushBackY;
                    X = enemyPushBackX;
                    //map.winScreen();
                }
        }

        }
    }

}


