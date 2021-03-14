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
        protected string avatar;
        protected string itemType;

        // items location
        public int X;
        public int Y;
        // checks to see if the items has been used
        public bool Used;


        public Items(string avatar, string itemType, int X, int Y)
        {
            this.itemType = itemType;
            this.avatar = avatar;
            this.X = X;
            this.Y = Y;

        }
        public void Draw()
        {
            if (Used == false)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(avatar);
            }
        }


    }
}
