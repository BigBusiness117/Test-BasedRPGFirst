using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Boss : Enemy
    {
        public bool sendEnemy;
        public int enemyCount;
        public Boss()
        {
            X = 20;
            Y = 2;
            health = 100;
            enemyIcon = new string[] { "B" };
            sendEnemy = false;
            enemyCount = 0;
            curpos = true;
            enemyDead = false;
            enemymoving = true;
            EnemyDealDamage = false;
            enemyTakeDamge = false;
            DamageBoost = false;
        }
        public override void drawEnemy(int X, int Y)
        {
            if (curpos)
            {
                this.X = X;
                this.Y = Y;
                curpos = false;
            }
            if (enemyDead == false)
            {
                Console.SetCursorPosition(this.X, this.Y);

                Console.Write(enemyIcon[0]);
            }
        }
        public  void enemyMove(HorizontalEnemy[] horizontalEnemy, Map map, Player player)
        {
            Random rd = new Random();
            int randomNum = rd.Next(1, 3);
            if (enemyDead == false)
            {
                if (Y - 2 == player.Y && X == player.X || Y - 1 == player.Y && X == player.X)
                {
                    sendEnemy = true;
                    if (enemyCount < 9)
                    {
                        enemyCount++;
                    }
                    

                    SendEnemy(horizontalEnemy, map, player);
                    Console.ReadKey();
                }
                if (Y + 2 == player.Y && X == player.X || Y + 1 == player.Y && X == player.X)
                {
                    sendEnemy = true;
                    SendEnemy(horizontalEnemy, map, player);
                    
                    if (enemyCount < 9)
                    {
                        enemyCount++;
                    }


                }
                if (Y == player.Y && X - 2 == player.X || Y == player.Y && X - 1 == player.X)
                {
                    sendEnemy = true;
                    SendEnemy(horizontalEnemy, map, player);
                  
                    if (enemyCount < 9)
                    {
                        enemyCount++;
                    }


                }
                if (Y == player.Y && X + 2 == player.X || Y == player.Y && X + 1 == player.X)
                {
                    sendEnemy = true;

                    SendEnemy(horizontalEnemy, map, player);
                 
                    if (enemyCount < 9)
                    {
                        enemyCount++;
                    }

                }

            }

            if (enemymoving)
                {
                TakeDamge(25);
                EnemyDealDamage = false;
                enemyPushBackX = X;
                enemyPushBackY = Y;
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
            }
                enemymoving = true;

        }
        public void SendEnemy(HorizontalEnemy[] horizontalEnemy,Map map, Player player)
        {
            //horizontalEnemy[3].drawEnemy(X, Y);
           // horizontalEnemy[3].enemyMove(map,player);
        }
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

