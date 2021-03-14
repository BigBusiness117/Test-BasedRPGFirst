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
        public int playerX;
        public int playerY;
        public bool playerMoving = true;

        public int remainingShields;
        public int PushBackX;
        public int PushBackY;

        public Player()
        {

            shields = 50;
            playerX = 17;
            playerY = 1;
            remainingShields = shields;

        }
        // draws player to screen
        public void drawPlayer(Enemy enemy)
        {
            Console.SetCursorPosition(playerX, playerY);
            if (playerMoving == true) {
                playerIcon = new string[] { "@" };
                Console.Write(playerIcon[0]);
            }
        }
        // move player
        public void movePlayer(Enemy enemy, Map map, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (playerMoving == true)
            {
                // takes damage from enemy if conditions are right
                //if (enemy.HorizontalDealDamage == true) { TakeDamge(enemy, 50); }
                //if (enemy.StillDealDamage == true) { TakeDamge(enemy, 10); }
                if (enemy.EnemyDealDamage == true || horizontalEnemy.EnemyDealDamage == true || stillEnemy.EnemyDealDamage == true) { TakeDamge(enemy, 25, horizontalEnemy, stillEnemy); }

                PushBackX = playerX;
                PushBackY = playerY;
                // check if player pressed w
                if (input.KeyChar == 'w')
                {
                    Console.SetCursorPosition(playerX, playerY);

                    moving = true;
                    // check to see if there is a border and if so make player cant move that way and plays a sound
                    if (map.displayMap[playerX, playerY - 1] == 'x') { moving = false; Console.Beep(300, 100); }
                    // makes the player move depending on the key pressed
                    else if (map.displayMap[playerX, playerY] == '.' && moving == true)
                    {

                        playerY = playerY - 1;
                    }
                }
                else if (input.KeyChar == 's')
                {
                    Console.SetCursorPosition(playerX, playerY);
                    moving = true;
                    if (map.displayMap[playerX, playerY + 1] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[playerX, playerY] == '.' && moving == true) { playerY = playerY + 1; }
                }
                else if (input.KeyChar == 'a')
                {
                    moving = true;
                    if (map.displayMap[playerX - 1, playerY] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[playerX, playerY] == '.' && moving == true) { playerX = playerX - 1; }
                }
                else if (input.KeyChar == 'd')
                {
                    Console.SetCursorPosition(70, 15);
                    moving = true;
                    if (map.displayMap[playerX + 1, playerY] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[playerX, playerY] == '.' && moving == true) { playerX = playerX + 1; }
                }
            }

        }
        // checks to see if player colided with any game objects 
        public void CheckCollision(Enemy enemy, StatHud statHud, Items healthPack, Items powerUp, Items armor, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy)
        {
            if (playerY == enemy.Y)
            {
                if (playerX == enemy.X)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    //map.winScreen();

                    playerY = PushBackY;
                    playerX = PushBackX;
                    statHud.horizontalEnemyStats = false;
                    statHud.stillEnemyStats = false;
                    statHud.enemyStats = true;
                    enemy.enemyTakeDamge = true;
                }
            }
            if (playerY == horizontalEnemy.Y)
            {
                if (playerX == horizontalEnemy.X)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.WriteLine("You Have Killed horizontal enemy");
                    playerY = PushBackY;
                    playerX = PushBackX;
                    horizontalEnemy.enemyTakeDamge = true;
                    statHud.stillEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.horizontalEnemyStats = true;
                    //map.winScreen();
                }
            }
            if (playerY == stillEnemy.X)
            {
                if (playerX == stillEnemy.Y)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    playerY = PushBackY;
                    playerX = PushBackX;
                    Console.WriteLine("You Have Killed still enemy");
                    stillEnemy.enemyTakeDamge = true;
                    statHud.horizontalEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.stillEnemyStats = true;

                    //map.winScreen();
                    //    }
                    //  }
                    if (playerY == healthPack.Y)
                    {
                        if (playerX == healthPack.X)
                        {
                            if (healthPack.Used == false)
                            {
                                health += 50;
                                if (health >= 100)
                                {
                                    health = 100;
                                }
                                healthPack.X = 0;
                                healthPack.Y = 0;
                                healthPack.Used = true;
                            }
                        }
                    }
                    if (playerY == armor.Y)
                    {
                        if (playerX == armor.X)
                        {
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
                    if (playerY == powerUp.Y)
                    {
                        if (playerX == powerUp.X)
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

            }
        }
                // player takes damage depending on the enemy
                private void TakeDamge(Enemy enemy, int damage, HorizontalEnemy horizontalEnemy, StillEnemy stillEnemy)
                {

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
                    }
                    if (enemy.EnemyDealDamage == true)
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

