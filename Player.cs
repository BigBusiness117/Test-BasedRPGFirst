using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Player : Map
    {
        public int locationX=3;
        public int locationY=3;
        public bool moving = true;
        public int origWidth;
        public int origHeight;
        public string player1;
        public int playerPos;
        public string[] PlayerOne;
        public string nextPage;
        public List<string> list; 
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
           // if (locationX >= origWidth - 1) { locationX = origWidth - 1; }
            //if (locationX <= 1) { locationX = 1; }
            //if (locationY >= origHeight - 1) { locationY = origHeight - 1; }
            //if (locationY <= 1) { locationY = 1; }

            Console.SetCursorPosition(locationX , locationY);
            



            //Console.WriteLine(locationX + "and" + locationY);
            //Console.WriteLine(origWidth + "and" + origHeight);


        }
        public void movePlayer()
        {
            Console.SetCursorPosition(0, 0);

            border();
            Console.SetCursorPosition(20, 20);

            Console.WriteLine("----" +"X"+ locationX +"-Y"+ locationY +"-----");
            Console.WriteLine(mapE[locationY ,locationX]);
            Console.SetCursorPosition(locationX , locationY );
            Console.Write(player1);
            //string[,] mapE = new string[65,16];
                      //   Console.WriteLine("");
                //Console.WriteLine("hello"+mapE[locationY +1, locationX]+"hello");
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
           
                
            
            
                
            
            if (input.KeyChar == 'w' )
            {
                if (mapE[locationY - 1 , locationX ] == "x")
                {
                    Console.WriteLine(mapE[locationY , locationX]);
                    moving = false;
                    
                }
                else if (mapE[locationY  , locationX ] == "." && moving == true)
                {
                    locationY = locationY - 1;
                    
                }
               // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
               //Console.Write("");
                Console.Clear();
            }
            else if (input.KeyChar == 's')
            {
                if (mapE[locationY +1 , locationX] == "x")
                {
                   
                    moving = false;

                }
                else if (mapE[locationY , locationX] == "." && moving == true)
                {
                    
                    locationY = locationY + 1;

                }

                
               
                // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                 Console.Clear();

            }
            else if (input.KeyChar == 'a')
            {

                if (mapE[locationY , locationX -1 ] == "x")
                {
                    //Console.WriteLine(mapE[locationY + 1, locationX]);
                    moving = false;

                }
                else if (mapE[locationY , locationX] == "." && moving == true)
                {
                    
                    locationX = locationX - 1;

                }
                
                
                // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                // Console.Write("");

                Console.Clear();

            }
            else if (input.KeyChar == 'd')
            {
                if (mapE[locationY  , locationX +1] == "x")
                {
                    //Console.WriteLine(mapE[locationY , locationX ]);
                    moving = false;

                }

                else if (mapE[locationY  , locationX] == "." && moving == true)
                {
                    locationX = locationX + 1;
                    

                }
                //Console.Write("@");
                
                //  Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                //Console.Write("");

                Console.Clear();

            }
            moving = true;

        }
            public void getTile(int x, int y)
            {
           

            //return map[y],[x];
            }   

    }
}
