using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BasedRPGFirst
{
    class EnemyManager
    {
        
            public HorizontalEnemy[] horizontalEnemy = new HorizontalEnemy[10];
            protected StillEnemy stillEnemy = new StillEnemy();
            public Enemy enemy = new Enemy();
            public Boss boss = new Boss();



    }
}
