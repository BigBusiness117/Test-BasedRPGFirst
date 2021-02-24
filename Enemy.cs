using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy : GameCharacter
    {

        public int ememyX;
        public int enemyY;
        public int horizontalEnemyX;
        public int horizontalEnemyY;
        string[] enemyIcon;
        string[] horizontalEnemyIcon;
        public int count;
        public bool enemymoving;
        public bool enemyallDead; 
        public Enemy()
        {
            turn = true;
            enemyIcon = new string[] { "E" };
            horizontalEnemyIcon = new string[] { ">" };
            enemymoving = true;
            ememyX = 10;
            enemyY = 10;
            horizontalEnemyX = 6;
            horizontalEnemyY = 6;
            enemyallDead = false;

    }

    public void drawEnemy()
        {
            Console.SetCursorPosition(ememyX, enemyY);
            Console.Write(enemyIcon[0]);
            
        }
        public void drawhorizontalEnemy()
        {

            Console.SetCursorPosition(horizontalEnemyX, horizontalEnemyY);
            Console.Write(horizontalEnemyIcon[0]);
        }
        public void horizontalEnemyMove(Map map, Player player)
        {
           // if()
        }
            public void enemyMove(Map map, Player player)
        {

            // makes a random number
            Random rd = new Random();
            int randomNum = rd.Next(1, 5);


            map.border();
            // put cursor position based on enemy position
            //Console.SetCursorPosition(70, 15);
                if (enemyY -1 == player.playerY && ememyX == player.playerX)
                {
                enemymoving = false;
                enemyY = enemyY - 1;
                }
            
                Console.SetCursorPosition(ememyX, enemyY);
            if (enemyallDead == false)
            {
                if (enemymoving)
                {
                    count = 0;
                    // move the enemy depending n the random number
                    if (randomNum == 10)
                    {


                        if (map.worldMap[enemyY - 1, ememyX] == "x") { enemymoving = false; }

                        else { enemyY--; }
                    }
                    if (randomNum == 2)
                    {
                        enemymoving = true;
                        if (map.worldMap[enemyY + 1, ememyX] == "x") { enemymoving = false; }

                        else { enemyY++; }
                    }


                    if (randomNum == 3)
                    {

                        if (map.worldMap[enemyY, ememyX - 1] == "x") { enemymoving = false; }

                        else { ememyX--; }
                    }
                    if (randomNum == 4)
                    {

                        if (map.worldMap[enemyY, ememyX + 1] == "x") { enemymoving = false; }

                        else { ememyX++; }
                    }
                    //player.turn = true;
                }
                enemymoving = true;
            }
        }
        public void CheckAllPlayer(Player player)
        {
            if (player.playerY == enemyY)
            {
                if (player.playerX == ememyX)
                {
                    Console.SetCursorPosition(40, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed Player");
                    //map.winScreen();
                    //enemyX = 0;
                    // enemyY = 0;
                    player.playerMoving = false;
                    
                }
            }
        }

    }
    }

