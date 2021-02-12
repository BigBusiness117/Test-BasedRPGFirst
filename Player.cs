using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Player : GameCharacter
    {
        
        public int origWidth;
        public int origHeight;
        public string player1;
        public int playerPos;
        public string[] PlayerOne;
        public string nextPage;
        public List<string> list; 
        public int Px;
        public int Py;
        public int curPy;
        public Player()
        {
            turn = false;

            Px = 3;
            Py = 3;
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

            Console.SetCursorPosition(Px , Py);
            



            //Console.WriteLine(locationX + "and" + locationY);
            //Console.WriteLine(origWidth + "and" + origHeight);


        }
        public void movePlayer()
        {

            Map map = new Map();
            Enemy enemy = new Enemy();
            
            map.border();
            Console.Write(player1);
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);





       
                if (input.KeyChar == 'w')
                {
                    if (map.mapE[Py - 1, Px] == "x")
                    {
                        Console.WriteLine(map.mapE[Py, Px]);
                        moving = false;
                        curPy = Py;


                    }
                    else if (map.mapE[Py, Px] == "." && moving == true)
                    {
                        Py = Py - 1;



                    }
                    // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Console.Write("");
                    Console.Clear();
                }
                else if (input.KeyChar == 's')
                {

                    if (map.mapE[Py + 1, Px] == "x")
                    {


                        moving = false;

                    }
                    else if (map.mapE[Py, Px] == "." && moving == true)
                    {


                        Py = Py + 1;

                    }



                    // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Clear();

                }
                else if (input.KeyChar == 'a')
                {

                    if (map.mapE[Py, Px - 1] == "x")
                    {

                        //Console.WriteLine(mapE[locationY + 1, locationX]);
                        moving = false;

                    }
                    else if (map.mapE[Py, Px] == "." && moving == true)
                    {


                        Px = Px - 1;

                    }


                    // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    // Console.Write("");

                    Console.Clear();

                }
                else if (input.KeyChar == 'd')
                {
                    if (map.mapE[Py, Px + 1] == "x")
                    {

                        //Console.WriteLine(mapE[locationY , locationX ]);
                        moving = false;

                    }

                    else if (map.mapE[Py, Px] == "." && moving == true)
                    {

                        Px = Px + 1;


                    }
                    //Console.Write("@");

                    //  Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Console.Write("");

                    Console.Clear();

                }
            
            
            moving = true;
            
        }

    }
}
