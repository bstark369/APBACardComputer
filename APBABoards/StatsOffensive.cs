using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class StatsOffensive
    {
        public int AtBats = 0;
        public int Singles = 0;
        public int Doubles = 0;
        public int Triples = 0;
        public int Homeruns = 0;
        public int Walks = 0;
        public int Strikeouts = 0;
        public int GIDP = 0;
        public int HPB = 0;
        public int IBB = 0;
        public int SF = 0;
        public int SH = 0;
        public int SB = 0;
        public int Runs = 0;
        public int RBI = 0;

        public int Hits
        {
            get { return Singles + Doubles + Triples + Homeruns; }
        }

        public StatsOffensive()
        {
        }
    }

}
