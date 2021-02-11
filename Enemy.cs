using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy 
    {
        int EloctaionX;
        int EloctaionY;
        string[] EnemyOne;
        bool turn = true;
        public Enemy()
        {
            EnemyOne = new string[] { "E" };
            EloctaionX = 10;
            EloctaionY = 10;
        }
        public void enemyMove()
        {
            
            Random rd = new Random();
            int num = rd.Next(10, 12);
            if (turn)
            {
                Console.SetCursorPosition(EloctaionX, EloctaionY);
                Console.Write(EnemyOne[0]);
                EloctaionX++;    
                
                
            }
        }
    }
}
