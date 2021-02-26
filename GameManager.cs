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
            StatHud statsHUD = new StatHud();
            Items items = new Items();
            GameCharacter gameCharacter = new GameCharacter();

            // game loop
            while (true)
            {



                // draws the map 
                map.DrawBorder();
                // showsthe characters Stats
                statsHUD.ShowHUD(player, enemy);

                // draws the game objects
                enemy.drawEnemy(); 
                enemy.drawhorizontalEnemy();
                enemy.StilldrawEnemy();
                items.DrawHealthPack();
                items.DrawArmor();
                items.DrawPowerUp();
                player.drawPlayer(enemy); 
                //moves the player
                player.movePlayer(enemy, map);  
                // checks if player had any collision
                if (player.playerMoving == true)
                {
                    player.CheckCollision(enemy,statsHUD,items);
                }

                


                //moves the enemies
                enemy.enemyMove(map, player); 
                enemy.horizontalEnemyMove(map, player);
                enemy.stillEnemyMove(map, player);
                // check to see if enemy hit player
                if (enemy.enemyDead == false) { enemy.CheckAllPlayer(player); }
                if (enemy.horizontalEnemyDead == false) { enemy.CheckhorizontalEnemy(player); }
                if (enemy.stillEnemyDead == false) { enemy.CheckStillEnemy(player); }
               
                Console.Clear();
            }
        }
    }
}
