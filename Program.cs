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
            // runs the game loop
            GameManager gameManager = new GameManager();
            gameManager.RunGame();
            
        }
    }
}
