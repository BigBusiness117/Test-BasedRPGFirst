using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class StatHud
    {
        // show the enemy stats if they just hit the player
        public bool enemyStats;
        public bool horizontalEnemyStats;
        public bool stillEnemyStats;
        public StatHud()
        {
            enemyStats = false;
            horizontalEnemyStats = false;
            stillEnemyStats = false;
            
        }
        // shows the hud
    public void ShowHUD(Player player, Enemy enemy, Items healthPack)
    {
            Console.SetCursorPosition(65, 27);

            Console.WriteLine(" Health: " + player.health + " shields: "+ player.shields + " PLX: " + player.X + " PLY " + player.Y + " HLX: " + healthPack.X + " HLY " + healthPack.Y);
            if(enemy.DamageBoost == true)
            {
                Console.SetCursorPosition(90, 27);
                Console.Write(" DamageBoost: 2x");
            }
            Console.SetCursorPosition(65, 31);

            if (enemyStats == true)
            {
                Console.WriteLine(" Enemy Health: " + enemy.health);
            }
            if (horizontalEnemyStats == true)
            {
            //    Console.WriteLine(" HorizontalEnemy Health: " + enemy.HorizontalHealth);
            }
            if (stillEnemyStats == true)
            {
             //   Console.Write(" StillEnemy Health: " + enemy.StillHealth);
            }
            Console.SetCursorPosition(0, 26);
            Console.WriteLine(" E = Enemy: " + " @ = Player: " + " <,> = HorizontalEnemy: " + " S = StillEnemy: ");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine(" P = PowerUp: " + " H = HealthPack: " + " A = Armor: ");
        }

    }
}
