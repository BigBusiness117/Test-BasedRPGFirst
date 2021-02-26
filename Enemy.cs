using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy : GameCharacter
    {
        // enemy loctation
        public int enemyX;
        public int enemyY;
        // so the enemy does not  get stuck in the player
        private int enemyPushBackX;
        private int enemyPushBackY;
        public int stillEnemyX;
        public int stillEnemyY;
        private int StillEnemyPushBackX;
        private int StillEnemyPushBackY;
        public int horizontalEnemyX;
        public int horizontalEnemyY;
        //enemy health
        public int HorizontalHealth;
        public int StillHealth;

        // enemy icons/ enemy types
        private string[] enemyIcon;
        private string[] horizontalEnemyIcon;
        private string[] StillEnemyIcon;
        //public int count;

        // checks to see if enemy is moving
        public bool enemymoving;
        // check if enemy is dead
        public bool enemyDead;
        // checks if Horizontalenemy is moving left
        public bool movingLeft = true;
        public bool horizontalEnemyDead;
        public bool stillEnemyDead;
        // check to see if enemy deals damage to player
        public bool HorizontalDealDamage;
        public bool StillDealDamage;
        public bool EnemyDealDamage;
        //checks if enemy takes damage
        public bool enemyTakeDamge;
        public bool horizontalTakeDamage;
        public bool stillTakeDamage;
        // check if damage boost is active
        public bool DamageBoost;
        public Enemy()
        {
            //turn = true;
            enemyIcon = new string[] { "E" };
            StillEnemyIcon = new string[] { "S" };
            horizontalEnemyIcon = new string[] { ">","<" };
            enemyX = 20;
            enemyY = 10;
            stillEnemyX = 56;
            stillEnemyY = 8;
            horizontalEnemyX = 1;
            horizontalEnemyY = 4;
            HorizontalHealth = 100;
            StillHealth = 100;
            health = 100;

            enemyDead = false;
            stillEnemyDead = false; 
            enemymoving = true;
            horizontalEnemyDead = false;
            HorizontalDealDamage = false;
            StillDealDamage = false;
            EnemyDealDamage = false;
            stillTakeDamage = false;
            enemyTakeDamge = false;
            horizontalTakeDamage = false;
            DamageBoost = false;

        }
        // draws the enemies
    public void drawEnemy()
        {
            // checks if enemy is alive then draws
            if (enemyDead == false)
            {
                Console.SetCursorPosition(enemyX, enemyY);
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
        // move the enemy if the player 1 or 2 blocks away in the x and y position
        public void stillEnemyMove(Map map, Player player)
        {
            StillEnemyPushBackX = stillEnemyX;
            StillEnemyPushBackY = stillEnemyY;
            //if enemy is dead then stops moving
            if (stillEnemyDead == false)
            {
                // takes damage if conditions are met
                TakeDamge(25);
                // moves the enemy
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
            // moves the enemy
            public void horizontalEnemyMove(Map map, Player player)
            {
                TakeDamge(25);

                if (horizontalEnemyDead == false)
                {
                    if (map.displayMap[horizontalEnemyX - 1, horizontalEnemyY] == 'x')
                    {
                        movingLeft = false;
                    }
                    if (movingLeft == false)
                    {
                        horizontalEnemyX++;
                    }
                    if (map.displayMap[horizontalEnemyX , horizontalEnemyY] == 'x')
                    {
                        movingLeft = true;
                    }
                    if (movingLeft == true)
                    {
                        horizontalEnemyX--;
                    }
                }
            }
            // moves the  in randomly
            public void enemyMove(Map map, Player player)
            {
                TakeDamge(25);
                enemyPushBackX = enemyX;
                enemyPushBackY = enemyY;
                // makes a random number
                Random rd = new Random();
                int randomNum = rd.Next(1, 5);

                Console.SetCursorPosition(enemyX, enemyY);
                HorizontalDealDamage = false;
                StillDealDamage = false;
                EnemyDealDamage = false;
            if (enemyDead == false)
            {
                if (enemymoving)
                {
                    //count = 0;
                    // move the enemy depending n the random number
                    if (randomNum == 1)
                    {


                        if (map.displayMap[enemyX, enemyY - 1] == 'x') { enemymoving = false; }

                        else { enemyY--; }
                    }
                    if (randomNum == 2)
                    {
                        enemymoving = true;
                        if (map.displayMap[enemyX, enemyY + 1] == 'x') { enemymoving = false; }

                        else { enemyY++; }
                    }


                    if (randomNum == 3)
                    {

                        if (map.displayMap[ enemyX - 1, enemyY] == 'x') { enemymoving = false; }

                        else { enemyX--; }
                    }
                    if (randomNum == 4)
                    {

                        if (map.displayMap[ enemyX + 1, enemyY] == 'x') { enemymoving = false; }

                        else { enemyX++; }
                    }
                    //player.turn = true;
                }
                enemymoving = true;
            }
        }
        // checks if enemy hit the player
        public void CheckAllPlayer(Player player)
        {
            if (player.playerY == enemyY)
            {
                if (player.playerX == enemyX)
                {
                    // deals damge to the player and push enemy back to its spot
                    Console.SetCursorPosition(40, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed Player");
                    EnemyDealDamage = true;
                    enemyX = enemyPushBackX;
                    enemyY = enemyPushBackY;

                    //map.winScreen();

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
                    if(movingLeft == false) { horizontalEnemyX--; } else { horizontalEnemyX++; }

                    //map.winScreen();
                    HorizontalDealDamage = true;
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
                    StillDealDamage = true;
                    stillEnemyY = StillEnemyPushBackY;
                    stillEnemyX = StillEnemyPushBackX;
                    //map.winScreen();
                }
            }
        }
        // the enemy takes damage
        private void TakeDamge(int damage)
        {
            // checks if damage boost is active
            if(DamageBoost == true)
            {
                damage = damage * 2;
            }
            if(enemyTakeDamge == true)
            {
                health = health - damage;
                enemyTakeDamge = false;
            }
            if(horizontalTakeDamage == true)
            {
                HorizontalHealth = HorizontalHealth - damage;
                horizontalTakeDamage = false;
            }
            if(stillTakeDamage == true)
            {
                StillHealth = StillHealth - damage;
                stillTakeDamage = false;
            }
             if (StillHealth <= 0)
            {
                StillHealth = 0;
                stillEnemyDead = true;
                stillEnemyX = 0;
                stillEnemyY = 0;
            }
            if (HorizontalHealth <= 0)
            {
                HorizontalHealth = 0;
                horizontalEnemyDead = true;
                horizontalEnemyX = 0;
                horizontalEnemyY = 0;
            }
            if (health <= 0)
            {
                enemyY = 0;
                enemyX = 0;
                health = 0;
                enemyDead = true;
            }
        }
    }
    }

