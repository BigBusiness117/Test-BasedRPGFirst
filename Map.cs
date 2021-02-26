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
        public  char[,] displayMap;
        private char tile;
        private string mapLine;

        
        public Map()
        {
            displayMap = new char[60, 16];

        }

        // the map

        // draws the map
        public void DrawBorder()
        {
            // gets the map from a text file and then convert the map string[] to a 2d char array
            worldMap = File.ReadAllLines("map.txt");        // holds the story text
            for (int y = 0; y < 16; y++)
            {
                
                mapLine = worldMap[y];

                for(int x =0; x < 60; x++)
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

