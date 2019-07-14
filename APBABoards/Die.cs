using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class Die
    {
        private int sides;
        private static readonly Random random = new Random();
        private static readonly object synchLock = new object();

        public Die(int inSides)
        {
            this.sides = inSides;
        }

        public int Roll()
        {
            lock (synchLock)
            {
                return random.Next(1, sides);
            }
        }
    }
}
