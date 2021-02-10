using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Map : Player
    {
        public Map()
        {
            
            
        }

        public void border()
        {
            string[,] map = new string[,] {
        {"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"x                                                                x",},
        {"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",},
        };
            int MaxI = map.GetLength(0) - 1;
            int MaxJ = map.GetLength(1) - 1;
            for (int i = 0; i <= MaxI; i++)
            {

                Console.WriteLine("|");
                for (int j = 0; j <= MaxJ; j++)
                {
                    Console.Write(map[i, j]);
                }

            }
        }
    }
}
