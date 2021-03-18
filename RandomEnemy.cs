using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class RandomEnemy:Enemy
    {
        public RandomEnemy()
        {
            enemyIcon = new string[] { "R" };
            X = 20;
            Y = 10;
            enemyDead = false;
            enemymoving = true;
            EnemyDealDamage = false;
            enemyTakeDamge = false;
            DamageBoost = false;
        }

        public override void drawEnemy()
        {
            // checks if enemy is alive then draws
            if (enemyDead == false)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(enemyIcon[0]);
            }

        }
        public override void enemyMove(Map map, Player player)
        {
            TakeDamge(25);
            enemyPushBackX = X;
            enemyPushBackY = Y;
            // makes a random number
            Random rd = new Random();
            int randomNum = rd.Next(1, 5);

            Console.SetCursorPosition(X, Y);
            // HorizontalDealDamage = false;
            //StillDealDamage = false;
            EnemyDealDamage = false;
            if (enemyDead == false)
            {
                if (enemymoving)
                {
                    //count = 0;
                    // move the enemy depending n the random number
                    if (randomNum == 1)
                    {


                        if (map.displayMap[X, Y - 1] == 'x') { enemymoving = false; }

                        else { Y--; }
                    }
                    if (randomNum == 2)
                    {
                        enemymoving = true;
                        if (map.displayMap[X, Y + 1] == 'x') { enemymoving = false; }

                        else { Y++; }
                    }


                    if (randomNum == 3)
                    {

                        if (map.displayMap[X - 1, Y] == 'x') { enemymoving = false; }

                        else { X--; }
                    }
                    if (randomNum == 4)
                    {

                        if (map.displayMap[X + 1, Y] == 'x') { enemymoving = false; }

                        else { X++; }
                    }
                    //player.turn = true;
                }
                enemymoving = true;
            }
        }
        // checks if enemy hit the player
        public override void CheckAllPlayer(Player player)
        {
            if (player.Y == Y)
            {
                if (player.X == X)
                {
                    // deals damge to the player and push enemy back to its spot
                    Console.SetCursorPosition(40, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed Player");
                    EnemyDealDamage = true;
                    X = enemyPushBackX;
                    Y = enemyPushBackY;

                    //map.winScreen();

                }
            }

        }

       
    }
}
