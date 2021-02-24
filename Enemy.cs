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
        public int stillEnemyX;
        public int stillEnemyY;
        public int horizontalEnemyX;
        public int horizontalEnemyY;
        string[] enemyIcon;
        string[] horizontalEnemyIcon;
        public int count;
        public bool enemymoving;
        public bool enemyallDead;
        public bool movingLeft = true;
        public bool horizontalEnemyDead;
        public bool stillEnemyDead;
        string[] StillEnemyIcon;
        public Enemy()
        {
            turn = true;
            enemyIcon = new string[] { "E" };
            StillEnemyIcon = new string[] { "S" };
            horizontalEnemyIcon = new string[] { ">","<" };
            enemymoving = true;
            ememyX = 10;
            enemyY = 10;
            stillEnemyX = 21;
            stillEnemyY = 8;
            horizontalEnemyX = 6;
            horizontalEnemyY = 6;
            enemyallDead = false;
            stillEnemyDead = false; 
            horizontalEnemyDead = false;
        }

    public void drawEnemy()
        {
            if (enemyallDead == false)
            {
                Console.SetCursorPosition(ememyX, enemyY);
                Console.Write(enemyIcon[0]);
            }
            
        }
        public void StilldrawEnemy()
        {
            if (stillEnemyDead == false)
            {
                Console.SetCursorPosition(stillEnemyX, stillEnemyY);
                Console.Write(StillEnemyIcon[0]);
            }

        }
        public void drawhorizontalEnemy()
        {
            if (horizontalEnemyDead == false)
            {
                Console.SetCursorPosition(horizontalEnemyX, horizontalEnemyY);
                if (movingLeft == true)
                {
                    Console.Write(horizontalEnemyIcon[1]);
                }
                if (movingLeft == false)
                {
                    Console.Write(horizontalEnemyIcon[0]);
                }
            }
        }
        public void stillEnemyMove(Map map, Player player)
        {
            if (stillEnemyDead == false)
            {
                if (stillEnemyY - 2 == player.playerY && stillEnemyX == player.playerX || stillEnemyY - 1 == player.playerY && stillEnemyX == player.playerX)
                {

                    stillEnemyY = stillEnemyY - 1;
                }
                if (stillEnemyY + 2 == player.playerY && stillEnemyX == player.playerX || stillEnemyY + 1 == player.playerY && stillEnemyX == player.playerX)
                {

                    stillEnemyY = stillEnemyY + 1;
                }
                if (stillEnemyY == player.playerY && stillEnemyX - 2 == player.playerX || stillEnemyY == player.playerY && stillEnemyX - 1 == player.playerX)
                {

                    stillEnemyX = stillEnemyX - 1;
                }
                if (stillEnemyY == player.playerY && stillEnemyX + 2 == player.playerX || stillEnemyY == player.playerY && stillEnemyX + 1 == player.playerX)
                {

                    stillEnemyX = stillEnemyX + 1;
                }
            }
        }
            public void horizontalEnemyMove(Map map, Player player)
        {
            if (horizontalEnemyDead == false)
            {
                if (map.worldMap[horizontalEnemyY, horizontalEnemyX - 1] == "x")
                {
                    movingLeft = false;
                }
                if (movingLeft == false)
                {
                    horizontalEnemyX++;
                }
                if (map.worldMap[horizontalEnemyY, horizontalEnemyX] == "x")
                {
                    movingLeft = true;
                }
                if (movingLeft == true)
                {
                    horizontalEnemyX--;
                }
            }
        }
            public void enemyMove(Map map, Player player)
        {

            // makes a random number
            Random rd = new Random();
            int randomNum = rd.Next(1, 5);


            map.border();
            // put cursor position based on enemy position
            //Console.SetCursorPosition(70, 15);
             
            // checks to see if player is one step away and if so then attacks
            // if (enemyY -1 == player.playerY && ememyX == player.playerX)
                //{
                //enemymoving = false;
                //enemyY = enemyY - 1;
                //}
            
                Console.SetCursorPosition(ememyX, enemyY);
            if (enemyallDead == false)
            {
                if (enemymoving)
                {
                    count = 0;
                    // move the enemy depending n the random number
                    if (randomNum == 1)
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
        public void CheckhorizontalEnemy(Player player)
        {
            if (player.playerY == horizontalEnemyY)
            {
                if (player.playerX == horizontalEnemyX)
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
        public void CheckStillEnemy(Player player)
        {
            if (player.playerY == stillEnemyY)
            {
                if (player.playerX == stillEnemyX)
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

