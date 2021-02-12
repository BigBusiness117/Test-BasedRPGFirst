using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy : GameCharacter
    {

        public int Ex;
        public int Ey;
        string[] EnemyOne;
        public string eOne;
        public bool Ealive = true ;
        public int direction;
        public Enemy()
        {
         turn = true;
            EnemyOne = new string[] { "E" };
            moving = true;
            Ex = 10;
            Ey = 10;
            eOne = "E";

        }
        public void enemyMove()
        {
            if (Ealive)
            {
                Random rd = new Random();
                int num = rd.Next(1, 5);
                Player player = new Player();
                Map map = new Map();
                map.border();
                Console.SetCursorPosition(Ex, Ey);
                Console.Write(eOne);

                if (moving )
                {
                    Console.SetCursorPosition(50, 20);
                    Console.Write(num);

                    if (num == 1){
                    if (map.mapE[Ey - 2, Ex] == "x")
                    {
                        moving = false;
                        }
                        else
                        {
                         Ey--;

                        }

                    }
                    if (num == 2)
                    {
                        if (map.mapE[Ey + 1, Ex] == "x")
                        {
                        moving = false;

                        }
                        else 
                        {
                            Ey++;
                            
                        }
                    }


                    if (num == 3)
                    {
                        if (map.mapE[Ey, Ex - 2] == "x")
                        {
                        moving = false;
                        }
                        else
                        {
                        Ex--;
                        }
                    }
                    if (num == 4)
                    {
                    if (map.mapE[Ey, Ex + 2] == "x")
                    {

                        //Console.WriteLine(mapE[locationY , locationX ]);
                        moving = false;

                    }
                        else
                        {
                        Ex++;

                        }
                    }
                    moving = true;
                    player.turn = true;
                    //check();

                }
                }

            }
        }
    }

