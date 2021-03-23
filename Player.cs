using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Test_BasedRPGFirst
{
    class Player : GameCharacter
    {

        // player icon
        private string[] playerIcon;
        // 
        public int X;
        public int Y;
        public bool playerMoving = true;

        public int remainingShields;
        public int PushBackX;
        public int PushBackY;

        public Player()
        {

            shields = 50;
            X = 17;
            Y = 1;
            remainingShields = shields;

        }
        // draws player to screen
        public void drawPlayer(Enemy enemy)
        {
            Console.SetCursorPosition(X, Y);
            if (playerMoving == true) {
                playerIcon = new string[] { "@" };
                Console.Write(playerIcon[0]);
            }
        }
        // move player
        public void movePlayer(Enemy enemy, Map map, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy, RandomEnemy[] randomEnemy)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            if (playerMoving == true)
            {
                // takes damage from enemy if conditions are right
                //if (enemy.HorizontalDealDamage == true) { TakeDamge(enemy, 50); }
                //if (enemy.StillDealDamage == true) { TakeDamge(enemy, 10); }
                for (int d = 0; d < 10; d++)
                {
                    if (randomEnemy[d].EnemyDealDamage == true || horizontalEnemy.EnemyDealDamage == true || stillEnemy.EnemyDealDamage == true) 
                    { TakeDamge(enemy, 0, horizontalEnemy, stillEnemy, randomEnemy[d]); }
                }
                PushBackX = X;
                PushBackY = Y;
                // check if player pressed w
                if (input.KeyChar == 'w')
                {
                    Console.SetCursorPosition(X, Y);

                    moving = true;
                    // check to see if there is a border and if so make player cant move that way and plays a sound
                    if (map.displayMap[X, Y - 1] == 'x') { moving = false; Console.Beep(300, 100); }
                    // makes the player move depending on the key pressed
                    else if (map.displayMap[X, Y] == '.' && moving == true)
                    {

                        Y = Y - 1;
                    }
                }
                else if (input.KeyChar == 's')
                {
                    Console.SetCursorPosition(X, Y);
                    moving = true;
                    if (map.displayMap[X, Y + 1] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[X, Y] == '.' && moving == true) { Y = Y + 1; }
                }
                else if (input.KeyChar == 'a')
                {
                    moving = true;
                    if (map.displayMap[X - 1, Y] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[X, Y] == '.' && moving == true) { X = X - 1; }
                }
                else if (input.KeyChar == 'd')
                {
                    Console.SetCursorPosition(70, 15);
                    moving = true;
                    if (map.displayMap[X + 1, Y] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[X, Y] == '.' && moving == true) { X = X + 1; }
                }
            }

        }
        // checks to see if player colided with any game objects 
        public void CheckCollision(Enemy enemy, StatHud statHud, Items[] healthPack, Items powerUp, Items armor, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy,RandomEnemy[] randomEnemy)
        {
            for (int r = 0; r < 10; r++) {
                if (Y == randomEnemy[r].Y)
                {
                    if (X == randomEnemy[r].X)
                    {
                        Console.SetCursorPosition(70, 15);
                        Console.Beep(170, 200);
                        //map.winScreen();

                        Y = PushBackY;
                        X = PushBackX;
                        statHud.horizontalEnemyStats = false;
                        statHud.stillEnemyStats = false;
                        statHud.enemyStats = true;
                        randomEnemy[r].enemyTakeDamge = true;
                    }
                }
            }
            if (Y == horizontalEnemy.Y)
            {
                if (X == horizontalEnemy.X)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.WriteLine("You Have Killed horizontal enemy");
                    Y = PushBackY;
                    X = PushBackX;
                    horizontalEnemy.enemyTakeDamge = true;
                    statHud.stillEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.horizontalEnemyStats = true;
                    //map.winScreen();
                }
            }
            if (Y == stillEnemy.Y)
            {
                if (X == stillEnemy.X)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    Y = PushBackY;
                    X = PushBackX;
                    Console.WriteLine("You Have Killed still enemy");
                    stillEnemy.enemyTakeDamge = true;
                    statHud.horizontalEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.stillEnemyStats = true;

                }
            }
            //map.winScreen();
            //    }
            //  
            for (int i = 0; i < 5; i++)
            {
                if (Y == healthPack[i].Y)
                {
                    if (X == healthPack[i].X)
                    {
                        if (healthPack[i].Used == false)
                        {
                            health += 50;
                            if (health >= 100)
                            {
                                health = 100;
                            }
                            healthPack[i].X = 0;
                            healthPack[i].Y = 0;
                            healthPack[i].Used = true;
                        }
                    }
                }
            }
            if (Y == armor.Y)
            {
                if (X == armor.X)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.WriteLine("tryx" + X);
                    if (armor.Used == false)
                    {
                        shields += 50;
                        if (shields >= 100)
                        {
                            shields = 100;
                        }
                        armor.X = 0;
                        armor.Y = 0;
                        armor.Used = true;
                    }
                }
            }
                    if (Y == powerUp.Y)
                    {
                        if (X == powerUp.X)
                        {
                            if (powerUp.Used == false)
                            {

                                enemy.DamageBoost = true;
                                powerUp.X = 0;
                                powerUp.Y = 0;
                                powerUp.Used = true;
                            }
                        }
                    }

        }
                // player takes damage depending on the enemy
            private void TakeDamge(Enemy enemy, int damage, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy,RandomEnemy randomEnemy)
            {
                if(horizontalEnemy.EnemyDealDamage == true)
                {
                    damage = 50;
                }
                if (randomEnemy.EnemyDealDamage == true)
                {
                        damage = 1;
                }
                if (stillEnemy.EnemyDealDamage == true)
                {
                    damage = 1;
                }
                if (shields == 0)
                {

                    health -= damage;

                }
                    if (horizontalEnemy.EnemyDealDamage == true)
                    {
                        if (shields > 0)
                        {
                            shields = shields - damage;

                        }
                horizontalEnemy.EnemyDealDamage = false;
                    }
                    if (randomEnemy.EnemyDealDamage == true)
                    {
                        if (shields > 0)
                        {
                            shields = shields - damage;

                        }
                    }
                    if (stillEnemy.EnemyDealDamage == true)
                    {
                        if (shields > 0)
                        {
                            shields = shields - damage;
                        }
                stillEnemy.EnemyDealDamage = false;
                    }
                    if (shields > 0)
                    {
                        remainingShields -= damage;
                    }
                    if (shields < 0)
                    {

                        shields = 0;
                        health += remainingShields;
                        remainingShields = 0;
                    }
                    if (health <= 0)
                    {
                        health = 0;
                        playerMoving = false;
                    }
                }
    }
}

