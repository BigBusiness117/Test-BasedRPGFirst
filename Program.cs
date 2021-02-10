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
            
            while (true)
            {
                

                map.border();
                enemy.enemyMove();
                player.drawPlayer();
                player.movePlayer();
                
            }
            Console.ReadKey();

        }
    }
}
