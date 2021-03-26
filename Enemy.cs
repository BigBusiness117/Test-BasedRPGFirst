using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy : GameCharacter
    {
        // enemy loctationh
        //public int X;
       // public int Y;
        // so the enemy does not  get stuck in the player
        protected int enemyPushBackX;
        protected int enemyPushBackY;
      //  public int stillEnemyX;
      //  public int stillEnemyY;
      //  private int StillEnemyPushBackX;
      //  private int StillEnemyPushBackY;
       // public int horizontalEnemyX;
       // public int horizontalEnemyY;
        //enemy health
       // public int HorizontalHealth;
       // public int StillHealth;

        // enemy icons/ enemy types
        protected string[] enemyIcon;
        //private string[] horizontalEnemyIcon;
        //private string[] StillEnemyIcon;
        //public int count;

        // checks to see if enemy is moving
        protected bool enemymoving;
        // check if enemy is dead
        public bool enemyDead;
        // checks if Horizontalenemy is moving left
        protected bool movingLeft = true;
       // public bool horizontalEnemyDead;
      //  public bool stillEnemyDead;
        // check to see if enemy deals damage to player
        //public bool HorizontalDealDamage;
        //public bool StillDealDamage;
        public bool EnemyDealDamage;
        //checks if enemy takes damage
        public bool enemyTakeDamge;
        //public bool horizontalTakeDamage;
       // public bool stillTakeDamage;
        // check if damage boost is active
        public bool DamageBoost;
        public Enemy()
        {
            //turn = true;
            enemyIcon = new string[] { "E" };
           // StillEnemyIcon = new string[] { "S" };
           // horizontalEnemyIcon = new string[] { ">","<" };
           // X = 20;
            //Y/ = 10;
            //stillEnemyX = 56;
           // stillEnemyY = 8;
           // horizontalEnemyX = 1;
            //horizontalEnemyY = 4;
           // HorizontalHealth = 100;
           // StillHealth = 100;
            //health = 100;

            enemyDead = false;
            //stillEnemyDead = false; 
            enemymoving = true;
            //horizontalEnemyDead = false;
            //HorizontalDealDamage = false;
            //StillDealDamage = false;
            EnemyDealDamage = false;
           // stillTakeDamage = false;
            enemyTakeDamge = false;
            //horizontalTakeDamage = false;
            DamageBoost = false;

        }

        // draws the enemies
    public virtual void drawEnemy(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            // checks if enemy is alive then draws
            if (enemyDead == false)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(enemyIcon[0]);
            }
            
        }
            public virtual void enemyMove(Map map, Player player)
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

                        if (map.displayMap[ X - 1, Y] == 'x') { enemymoving = false; }

                        else { X--; }
                    }
                    if (randomNum == 4)
                    {

                        if (map.displayMap[ X + 1, Y] == 'x') { enemymoving = false; }

                        else { X++; }
                    }
                    //player.turn = true;
                }
                enemymoving = true;
            }
        }
        // checks if enemy hit the player
        public virtual void CheckAllPlayer(Player player)
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
        //public void CheckhorizontalEnemy(Player player)
       // {
        //    if (player.playerY == horizontalEnemyY)
        //    {
          //      if (player.playerX == horizontalEnemyX)
          //      {

          //          Console.SetCursorPosition(40, 15);
          //          Console.Beep(170, 200);
          //          Console.WriteLine("You Have Killed Player");
          //          if(movingLeft == false) { horizontalEnemyX--; } else { horizontalEnemyX++; }
          //
          //          //map.winScreen();
          //          HorizontalDealDamage = true;
          //      }
          //  }
       // }
       // public void CheckStillEnemy(Player player)
       // {
       //     if (player.playerY == stillEnemyY)
         //   {
          //      if (player.playerX == stillEnemyX)
          //      {
          //          Console.SetCursorPosition(40, 15);
          //          Console.Beep(170, 200);
          //          Console.WriteLine("You Have Killed Player");
          //          StillDealDamage = true;
          //          stillEnemyY = StillEnemyPushBackY;
          //          stillEnemyX = StillEnemyPushBackX;
           //         //map.winScreen();
             //   }
          //  }
      //  }
        // the enemy takes damage
        protected void TakeDamge(int damage)
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
          //  if(horizontalTakeDamage == true)
          //  {
         //       HorizontalHealth = HorizontalHealth - damage;
         //       horizontalTakeDamage = false;
         //   }
         //   if(stillTakeDamage == true)
         //   {
        //        StillHealth = StillHealth - damage;
         //       stillTakeDamage = false;
         //   }
        //     if (StillHealth <= 0)
       //     {
       //         StillHealth = 0;
       //         stillEnemyDead = true;
       //         stillEnemyX = 0;
        //        stillEnemyY = 0;
        //    }
         //   if (HorizontalHealth <= 0)
        //    {
         //       HorizontalHealth = 0;
         //       horizontalEnemyDead = true;
         //       horizontalEnemyX = 0;
         //       horizontalEnemyY = 0;
          //  }
            if (health <= 0)
            {
                Y = 0;
                X = 0;
                health = 0;
                enemyDead = true;
            }
        }
    }
    }

