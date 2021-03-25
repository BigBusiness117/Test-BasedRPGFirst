using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class GameCharacter
    {
        // player and enemy health 
        public int health;
        public int shields;
        protected bool moving;
        public bool playerAlive;
        public bool enemyAlive;
        public int X;
        public int Y;
        public bool curpos;
        
        public GameCharacter()
        {
            playerAlive = true;
            enemyAlive = true;
            health = 100;
            moving = true;
            
        }
        
      
    }
}
