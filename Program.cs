using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Program
    {
        static int count;
        static void Main(string[] args)
        {
            
            Player player = new Player();
            Map map = new Map();
            Enemy enemy = new Enemy();

            GameCharacter gameCharacter = new GameCharacter();

            // game loop
            while (true)
            {
                bool turn = true;
                bool Check = false;
                if(gameCharacter.playerAlive == false)
                {
                   Check = false; 
                }

                // draws the map 
                map.DrawBorder();
               // if (Check == false) { gameCharacter.CheckEnemy(player.playerX, enemy.ememyX, player.playerY, enemy.enemyY); Check = true; }
                //Check = false;
                //if (Check == false) { gameCharacter.CheckEnemy(player.playerX, enemy.ememyX, player.playerY, enemy.enemyY); Check = true; }

                if (gameCharacter.enemyAlive){ enemy.drawEnemy(); }
                enemy.drawhorizontalEnemy();
                enemy.StilldrawEnemy();
                //Check = false;
                //if (Check == false && turn == true && gameCharacter.enemyAlive) { gameCharacter.CheckPlayer(player.playerX, enemy.ememyX, player.playerY, enemy.enemyY); Check = true; turn = false; }

                if (gameCharacter.playerAlive) { player.drawPlayer(enemy); }
                if (gameCharacter.playerAlive) { player.movePlayer(enemy, map); Check = false; }
                if (player.playerMoving == true) 
                { 
                    player.CheckAllEnemy(enemy);  
                }
                
                Check = false;
               // if (Check == false && turn == false && gameCharacter.playerAlive == true) { gameCharacter.CheckEnemy(player.playerX, enemy.ememyX, player.playerY, enemy.enemyY); Check = true; }

                // checks if player hit enemy
                // if player hits enemy the enemy dies
                // draws player





                if (gameCharacter.enemyAlive  && gameCharacter.playerAlive ) { enemy.enemyMove(map,player); count = 0; Check = false; }
                enemy.horizontalEnemyMove(map,player);
                enemy.stillEnemyMove(map, player);
                //Console.ReadKey();
                //move the player
                if (enemy.enemyallDead == false) { enemy.CheckAllPlayer(player); }
                if (enemy.horizontalEnemyDead == false) { enemy.CheckhorizontalEnemy(player); }
                if (enemy.horizontalEnemyDead == false) { enemy.CheckStillEnemy(player); }
                if ( gameCharacter.playerAlive == false)
                {
                    Console.ReadKey();
                }
            Console.Clear();
            }
        }
    }
}
