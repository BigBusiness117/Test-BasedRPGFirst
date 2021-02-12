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

            
            while (true)
            {
                map.DrawBorder();
                gameCharacter.CheckEnemy(player.Px, enemy.Ex, player.Py, enemy.Ey); 
                if (gameCharacter.enemyAlive) { enemy.enemyMove();}
                player.drawPlayer();
                player.movePlayer();
                Console.Clear();
            }
        }
    }
}
