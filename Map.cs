using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_BasedRPGFirst
{
     class  Map
    {
        
        private string[] worldMap;
        private string[] clearMap;
        public  char[,] displayMap;
        public char[,] blankMap;
        private char tile;
        private char blanktile;
        private string mapLine;
        private string blankmapLine;
        public int camera;
        public int mCamera;
        
        public Map()
        {
            camera = 81;
            mCamera = 0;
            displayMap = new char[120, 28];
            blankMap = new char[120, 28];
        }

        // the map

        // draws the map
        public void DrawBorder(Player player)
        {
            worldMap = File.ReadAllLines("map.txt");        // holds the story text
           // if(player.X >= 58)
            //{
                //hiding for now

               // camera++;
               // mCamera++;
           // }
            // gets the map from a text file and then convert the map string[] to a 2d char array
         //   clearMap = File.ReadAllLines("blankmap.txt");
         //   for (int n = 0; n < 16; n++)
         //   {

            //    blankmapLine = clearMap[n];
//
             //   for (int m = 0; m < 60; m++)
            //    {
           //         blanktile = blankmapLine[m];
            //        blankMap[m, n] = blanktile;
           //         Console.Write(blanktile);
         //       }
           //     Console.WriteLine("");
          //  }
            for (int y = 0; y < 26; y++)
            {
                
                mapLine = worldMap[y];

                for(int x =mCamera; x < camera; x++)
                {
                    tile = mapLine[x];
                    displayMap[x, y] = tile;
                    Console.Write(tile);
                }
                Console.WriteLine("");
            }


            
        }
        public void winScreen(){
            string[] winTextArt = new string[] // shows You win ASCII text art
            {
            "                                                         ",
            " ▓██   ██▓ ▒█████   █    ██      █     █░  ██▓ ███▄    █ ",
            "  ▒██  ██▒▒██▒  ██▒ ██  ▓██▒    ▓█░ █ ░█░▒▓██▒ ██ ▀█   █ ",
            "   ▒██ ██░▒██░  ██▒▓██  ▒██░    ▒█░ █ ░█ ▒▒██▒▓██  ▀█ ██▒",
            "   ░ ▐██▓░▒██   ██░▓▓█  ░██░    ░█░ █ ░█ ░░██░▓██▒  ▐▌██▒",
            "   ░ ██▒▓░░ ████▓▒░▒▒█████▓     ░░██▒██▓ ░░██░▒██░   ▓██░",
            "    ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ░ ▓░▒ ▒   ░▓  ░ ▒░   ▒ ▒ ",
            "  ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░       ▒ ░ ░  ░ ▒ ░░ ░░   ░ ▒░",
            " ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░       ░   ░  ░ ▒ ░   ░   ░ ░  ",
            " ░ ░         ░ ░     ░             ░      ░           ░  ",




            };
        foreach (var sub in winTextArt)                          // shows the wintext ACSII art 
        {
            Console.WriteLine(sub);

        }
        }

        
    }
}

