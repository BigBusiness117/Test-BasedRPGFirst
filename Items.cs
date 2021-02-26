using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class Items
    {
        // items types/names
        private string PowerUp;
        private string HealthPack;
        private string Armor;
        // items location
        public int PowerUpX;
        public int PowerUpY;
        public int HealthPackX;
        public int HealthPackY;
        public int ArmorX;
        public int ArmorY;
        // checks to see if the items has been used
        public bool HealthPackUsed;
        public bool ArmorPackUsed;
        public bool PowerUpUsed;

        public Items()
        {
            PowerUp = "P";
            HealthPack = "H";
            Armor = "A";
            HealthPackX = 45;
            HealthPackY = 14;
            ArmorX = 15;
            ArmorY = 1;
            PowerUpX = 15;
            PowerUpY = 4;
            HealthPackUsed = false;
            ArmorPackUsed = false;
            PowerUpUsed = false;

        }
        public void DrawHealthPack()
        {
            if (HealthPackUsed == false)
            {
                Console.SetCursorPosition(HealthPackX, HealthPackY);
                Console.Write(HealthPack);
            }
        }
        public void DrawArmor()
        {
            if (ArmorPackUsed == false)
            {
                Console.SetCursorPosition(ArmorX, ArmorY);
                Console.Write(Armor);
            }
        }
        public void DrawPowerUp()
        {
            if(PowerUpUsed == false)
            {

            Console.SetCursorPosition(PowerUpX, PowerUpY);
            Console.Write(PowerUp);
            }
        }

    }
}
