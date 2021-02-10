using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Player
    {
        public int locationX;
        public int locationY;
        private bool moving;
        public int origWidth;
        public int origHeight;
        public string player1;
        public int playerPos;
        public string[] PlayerOne;
        public Player()
        {

            locationX = 3;
            locationY = 3;
            moving = true;
            origHeight = Console.WindowHeight;
            origWidth = Console.WindowWidth;
            player1 = "@";

        }
        public void drawPlayer()
        {

            PlayerOne = new string[] { "@" };
            if (locationX >= origWidth - 1) { locationX = origWidth - 1; }
            if (locationX <= 1) { locationX = 1; }
            if (locationY >= origHeight - 1) { locationY = origHeight - 1; }
            if (locationY <= 1) { locationY = 1; }
            Console.SetCursorPosition(locationX, locationY);
            Console.Write(PlayerOne[0]);
           

            //Console.WriteLine(locationX + "and" + locationY);
            //Console.WriteLine(origWidth + "and" + origHeight);


        }
        public void movePlayer()
        {
                Console.WriteLine("");
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            if (input.KeyChar == 'w')
            {
                locationY = locationY - 1;
                Console.Clear();
            }
            else if (input.KeyChar == 's')
            {
                locationY = locationY + 1;
                Console.Clear();

            }
            else if (input.KeyChar == 'a')
            {
                locationX = locationX - 1;
                Console.Clear();

            }
            else if (input.KeyChar == 'd')
            {
                locationX = locationX + 1;
                Console.Clear();

            }

        }

    }
}
