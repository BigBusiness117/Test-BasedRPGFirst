using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Enemy : GameCharacter
    {

        public int ememyX;
        public int enemyY;
        string[] enemyIcon;
        public Enemy()
        {
            turn = true;
            enemyIcon = new string[] { "E" };
            moving = true;
            ememyX = 10;
            enemyY = 10;

        }
        public void enemyMove()
        {

                // makes a random number
                Random rd = new Random();
                int randomNum = rd.Next(1, 5);
                Player player = new Player();
                Map map = new Map();

                map.border();
                // put cursor position based on enemy position
                Console.SetCursorPosition(ememyX, enemyY);
                Console.Write(enemyIcon[0]);

                if (moving )
                {
                    // move the enemy depending n the random number
                    if (randomNum == 1)
                    {
                        if (map.worldMap[enemyY - 2, ememyX] == "x"){moving = false;}

                        else{enemyY--;}
                    }
                    if (randomNum == 2)
                    {
                        if (map.worldMap[enemyY + 1, ememyX] == "x"){moving = false;}

                        else{enemyY++;}
                    }


                    if (randomNum == 3)
                    {
                        if (map.worldMap[enemyY, ememyX - 2] == "x"){moving = false;}

                        else{ememyX--;}
                    }
                    if (randomNum == 4)
                    {
                        if (map.worldMap[enemyY, ememyX + 2] == "x"){moving = false;}

                        else{ememyX++;}
                    }
                    moving = true;
                    //player.turn = true;
                }
                }

            
        }
    }

