using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Map map = new Map();
            Enemy enemy = new Enemy();
            GameCharacter gameCharacter = new GameCharacter();

            // game loop
            while (true)
            {
                // draws the map 
                map.DrawBorder();
                // checks if player hit enemy
                gameCharacter.CheckEnemy(player.playerX, enemy.ememyX, player.playerY, enemy.enemyY); 
                // if player hits enemy the enemy dies
                if (gameCharacter.enemyAlive) { enemy.enemyMove();}
                //draws player
                player.drawPlayer();
                //move the player
                player.movePlayer();
                Console.Clear();
            }
        }
    }
}
