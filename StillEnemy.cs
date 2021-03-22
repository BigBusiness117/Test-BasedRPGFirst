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
        public override void drawEnemy(int X, int Y)
        {
            X = this.X;
            Y = this.Y;
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
                 if (Y - 2 == player.Y && X == player.X || Y - 1 == player.Y && X == player.X)
               {

                    Y = Y - 1;
               }
               if (Y + 2 == player.Y && X == player.X || Y + 1 == player.Y && X == player.X)
               {
            
                   Y = Y + 1;
               }
               if (Y == player.Y && X - 2 == player.X || Y == player.Y && X - 1 == player.X)
               {

                   X = X - 1;
               }
               if (Y == player.Y && X + 2 == player.X || Y == player.Y && X + 1 == player.X)
               {
            
                     X = X + 1;
               }
                EnemyDealDamage = false;

               }

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
                    EnemyDealDamage = true;
                    Y = enemyPushBackY;
                    X = enemyPushBackX;
                    //map.winScreen();
                }
        }

        }
    }

}


