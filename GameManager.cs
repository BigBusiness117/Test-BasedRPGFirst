using System;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class GameManager
    {
        
        public void RunGame()
        {
            Player player = new Player();
            Map map = new Map();
            Enemy enemy = new Enemy();
            RandomEnemy[] randomEnemy = new RandomEnemy[10];
            randomEnemy[0] = new RandomEnemy();
            randomEnemy[1] = new RandomEnemy();
            randomEnemy[2] = new RandomEnemy();
            randomEnemy[3] = new RandomEnemy();
            randomEnemy[4] = new RandomEnemy();
            randomEnemy[5] = new RandomEnemy();
            randomEnemy[6] = new RandomEnemy();
            randomEnemy[7] = new RandomEnemy();
            randomEnemy[8] = new RandomEnemy();
            randomEnemy[9] = new RandomEnemy();
            HorizontalEnemy horizontalEnemy = new HorizontalEnemy();
            StillEnemy stillEnemy = new StillEnemy();
            StatHud statsHUD = new StatHud();
            Items[] healthPack = new Items[5];
            healthPack[0]= new Items("H", "HealthPack", 45, 14);
            healthPack[1]= new Items("H", "HealthPack", 44, 14);
            healthPack[2]= new Items("H", "HealthPack", 43, 14);
            healthPack[3]= new Items("H", "HealthPack", 42, 14);
            healthPack[4]= new Items("H", "HealthPack", 41, 14);

            Items powerUp = new Items("P","PowerUp",15,4);
            Items armor = new Items("A","Armor",15,1);
            GameCharacter gameCharacter = new GameCharacter();

            // game loop
            while (true)
            {



                // draws the map 
                map.DrawBorder(player);
                // showsthe characters Stats
                statsHUD.ShowHUD(player, enemy, healthPack[0]);

                // draws the game objects
                randomEnemy[0].drawEnemy(10,2);
    
                horizontalEnemy.drawEnemy(1,4);
                stillEnemy.drawEnemy(56,8);
               // enemy.drawhorizontalEnemy();
               // enemy.StilldrawEnemy();
                healthPack[1].Draw();
                healthPack[0].Draw();
                healthPack[2].Draw();
                healthPack[3].Draw();
                healthPack[4].Draw();
                powerUp.Draw();
                armor.Draw();
                player.drawPlayer(enemy);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                //moves the player
                player.movePlayer(enemy, map, horizontalEnemy,stillEnemy,randomEnemy);  

                // checks if player had any collision
                if (player.playerMoving == true)
                {
                    player.CheckCollision(enemy,statsHUD,healthPack, powerUp,armor, horizontalEnemy,stillEnemy,randomEnemy);
                }

                


                //moves the enemies
                randomEnemy[0].enemyMove(map, player);
               
                horizontalEnemy.enemyMove(map, player);
                stillEnemy.enemyMove(map, player);
                //enemy.horizontalEnemyMove(map, player);
               // enemy.stillEnemyMove(map, player);
                // check to see if enemy hit player
                if (randomEnemy[0].enemyDead == false) { randomEnemy[0].CheckAllPlayer(player); }
                //if (randomEnemy[1].enemyDead == false) { randomEnemy[1].CheckAllPlayer(player); }
                //if (randomEnemy[2].enemyDead == false) { randomEnemy[2].CheckAllPlayer(player); }
                //if (randomEnemy[3].enemyDead == false) { randomEnemy[3].CheckAllPlayer(player); }
               // if (randomEnemy[4].enemyDead == false) { randomEnemy[4].CheckAllPlayer(player); }
                //if (randomEnemy[5].enemyDead == false) { randomEnemy[5].CheckAllPlayer(player); }
                //if (randomEnemy[6].enemyDead == false) { randomEnemy[6].CheckAllPlayer(player); }
                //if (randomEnemy[7].enemyDead == false) { randomEnemy[7].CheckAllPlayer(player); }
                if (horizontalEnemy.enemyDead == false) { horizontalEnemy.CheckAllPlayer(player); }
                if (stillEnemy.enemyDead == false) { stillEnemy.CheckAllPlayer(player); }
                //if (enemy.horizontalEnemyDead == false) { enemy.CheckhorizontalEnemy(player); }
               // if (enemy.stillEnemyDead == false) { enemy.CheckStillEnemy(player); }

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
