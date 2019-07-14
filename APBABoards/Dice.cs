using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class Dice
    {
        Die RedDie;
        Die WhiteDie;

        public Dice()
        {
            RedDie = new Die(7);
            WhiteDie = new Die(7);
        }

        public int GetRoll()
        {
            int roll = RedDie.Roll() * 10;
            roll += WhiteDie.Roll();
            return roll;
        }
    }
}
