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
            
            EnemyManager enemyManager = new EnemyManager();
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
            //HorizontalEnemy[] horizontalEnemy = new HorizontalEnemy[10];
            enemyManager.horizontalEnemy[0] = new HorizontalEnemy(100);
            enemyManager.horizontalEnemy[1] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[2] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[3] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[4] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[5] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[6] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[7] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[8] = new HorizontalEnemy(25);
            enemyManager.horizontalEnemy[9] = new HorizontalEnemy(25);
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
                statsHUD.ShowHUD(player,enemyManager.enemy, healthPack[0]);

                // draws the game objects
                randomEnemy[0].drawEnemy(10,2);
                enemyManager.boss.drawEnemy(16,20);
                enemyManager.horizontalEnemy[0].drawEnemy(1,4);
                if (enemyManager.boss.sendEnemy)
                {
                    enemyManager.horizontalEnemy[enemyManager.boss.enemyCount].drawEnemy(enemyManager.boss.X, enemyManager.boss.Y);

                }
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
                player.drawPlayer(enemyManager.enemy);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                //moves the player
                player.movePlayer(enemyManager.enemy, map, enemyManager.horizontalEnemy,stillEnemy,randomEnemy, enemyManager.boss);  

                // checks if player had any collision
                if (player.playerMoving == true)
                {
                    player.CheckCollision(enemyManager.enemy,statsHUD,healthPack, powerUp,armor, enemyManager.horizontalEnemy,stillEnemy,randomEnemy, enemyManager.boss);
                }

                


                //moves the enemies
                randomEnemy[0].enemyMove(map, player);
                enemyManager.boss.enemyMove(enemyManager.horizontalEnemy, map,player);
                enemyManager.horizontalEnemy[0].enemyMove(map, player);
                enemyManager.horizontalEnemy[1].enemyMove(map, player);
                enemyManager.horizontalEnemy[2].enemyMove(map, player);
                enemyManager.horizontalEnemy[3].enemyMove(map, player);
                enemyManager.horizontalEnemy[4].enemyMove(map, player);
                enemyManager.horizontalEnemy[5].enemyMove(map, player);
                enemyManager.horizontalEnemy[6].enemyMove(map, player);
                enemyManager.horizontalEnemy[7].enemyMove(map, player);
                enemyManager.horizontalEnemy[8].enemyMove(map, player);
                enemyManager.horizontalEnemy[9].enemyMove(map, player);
                for (int b = 1; b < enemyManager.boss.enemyCount; b++)
                {
                    enemyManager.horizontalEnemy[b].enemyMove(map, player);
                }
                
                stillEnemy.enemyMove(map, player);
                //enemy.horizontalEnemyMove(map, player);
               // enemy.stillEnemyMove(map, player);
                // check to see if enemy hit player
                if (randomEnemy[0].enemyDead == false) { randomEnemy[0].CheckAllPlayer(player); }

                 if (enemyManager.horizontalEnemy[0].enemyDead == false) { enemyManager.horizontalEnemy[0].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[1].enemyDead == false) { enemyManager.horizontalEnemy[1].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[2].enemyDead == false) { enemyManager.horizontalEnemy[2].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[3].enemyDead == false) { enemyManager.horizontalEnemy[3].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[4].enemyDead == false) { enemyManager.horizontalEnemy[4].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[5].enemyDead == false) { enemyManager.horizontalEnemy[5].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[6].enemyDead == false) { enemyManager.horizontalEnemy[6].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[7].enemyDead == false) { enemyManager.horizontalEnemy[7].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[8].enemyDead == false) { enemyManager.horizontalEnemy[8].CheckAllPlayer(player); }
                 if (enemyManager.horizontalEnemy[9].enemyDead == false) { enemyManager.horizontalEnemy[9].CheckAllPlayer(player); }
                 if (enemyManager.boss.enemyDead == false) { enemyManager.boss.CheckAllPlayer(player); }
                 if (stillEnemy.enemyDead == false) { stillEnemy.CheckAllPlayer(player); }

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
