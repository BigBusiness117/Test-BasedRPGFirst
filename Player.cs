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
            if(playerMoving == true) { 
            playerIcon = new string[] { "@" };
            Console.Write(playerIcon[0]);
            }
        }
        // move player
        public void movePlayer(Enemy enemy, Map map)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            
            if (playerMoving == true)
            {
                // takes damage from enemy if conditions are right
                if(enemy.HorizontalDealDamage== true) { TakeDamge(enemy,50); }
                if(enemy.StillDealDamage== true) { TakeDamge(enemy,10); }
                if (enemy.EnemyDealDamage== true) { TakeDamge(enemy,25); }

                PushBackX = playerX;
                PushBackY = playerY;
                // check if player pressed w
                if (input.KeyChar == 'w')
                {
                    Console.SetCursorPosition(playerX, playerY);

                    moving = true;
                    // check to see if there is a border and if so make player cant move that way and plays a sound
                    if (map.displayMap[playerX ,playerY - 1] == 'x') { moving = false; Console.Beep(300, 100); }
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
                    if (map.displayMap[ playerX - 1, playerY] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[ playerX, playerY] == '.' && moving == true) { playerX = playerX - 1; }
                }
                else if (input.KeyChar == 'd')
                {
                    Console.SetCursorPosition(70, 15);
                    moving = true;
                    if (map.displayMap[ playerX + 1, playerY] == 'x') { moving = false; Console.Beep(300, 100); }
                    else if (map.displayMap[ playerX, playerY] == '.' && moving == true) { playerX = playerX + 1; }
                }
            }

        }
        // checks to see if player colided with any game objects 
        public void CheckCollision(Enemy enemy, StatHud statHud, Items items)
        {
            if (playerY == enemy.enemyY)
            {
                if (playerX == enemy.enemyX)
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
            if (playerY == enemy.horizontalEnemyY)
            {
                if (playerX == enemy.horizontalEnemyX)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    Console.WriteLine("You Have Killed horizontal enemy");
                    playerY = PushBackY;
                    playerX = PushBackX;
                    enemy.horizontalTakeDamage = true;
                    statHud.stillEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.horizontalEnemyStats = true;
                    //map.winScreen();
                }
            }
            if (playerY == enemy.stillEnemyY)
            {
                if (playerX == enemy.stillEnemyX)
                {
                    Console.SetCursorPosition(70, 15);
                    Console.Beep(170, 200);
                    playerY = PushBackY;
                    playerX = PushBackX;
                    Console.WriteLine("You Have Killed still enemy");
                    enemy.stillTakeDamage = true;
                    statHud.horizontalEnemyStats = false;
                    statHud.enemyStats = false;
                    statHud.stillEnemyStats = true;

                    //map.winScreen();
                }
            }
            if (playerY == items.HealthPackY)
            {
                if (playerX == items.HealthPackX)
                {
                    if (items.HealthPackUsed == false)
                    {
                        health += 50;
                        if (health >= 100)
                        {
                            health = 100;
                        }
                        items.HealthPackX = 0;
                        items.HealthPackY = 0;
                        items.HealthPackUsed = true;
                    }
                }
            }
            if (playerY == items.ArmorY)
            {
                if (playerX == items.ArmorX)
                {
                    shields += 50;
                    if (shields >= 100)
                    {
                        shields = 100;
                    }
                    items.ArmorX = 0;
                    items.ArmorY = 0;
                    items.ArmorPackUsed = true;
                }
            }
            if (playerY == items.PowerUpY)
            {
                if (playerX == items.PowerUpX)
                {

                    items.PowerUpUsed = true;
                    enemy.DamageBoost = true;
                    items.PowerUpX = 0;
                    items.PowerUpY = 0;
                }
                
            }
        }
        // player takes damage depending on the enemy
        private void TakeDamge(Enemy enemy, int damage)
        {
            
             if (shields == 0)
            {
                
                health -= damage;
               
            }
            if(enemy.HorizontalDealDamage == true)
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
            if (enemy.StillDealDamage == true)
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
