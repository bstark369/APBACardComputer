using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class Player
    {
        //string firstName;
        //string middleName;
        //string nickName;
        string lastName;
        //string bats;
        //string throws;
        //string height;
        //int weight;
        //DateTime born;
        //string bornLocation;
        //positions
        int positionInBattingOrder;


        public Dictionary<int, int> firstColumn;
        public Dictionary<int, int> secondColumn;
        public StatsOffensive statsOffensive = new StatsOffensive();
        char speed;

        public Player(string lastName, Dictionary<int, int> firstColumn, Dictionary<int, int> secondColumn, char speed)
        {
            this.lastName = lastName;
            this.firstColumn = firstColumn;
            this.secondColumn = secondColumn;
            this.speed = speed;
        }

        public Player(string lastName, Dictionary<int, int> firstColumn)
        {
            this.lastName = lastName;
            this.firstColumn = firstColumn;
        }

        public int GetResult(int dieRoll, int column)
        {
            int returnResult;

            if (column == 1)
                returnResult = firstColumn[dieRoll];
            else
                returnResult = secondColumn[dieRoll];

            return returnResult;
        }

        public decimal GetAverage()
        {
            if (statsOffensive.AtBats == 0)
            {
                return 0;
            }
            return Math.Round(Convert.ToDecimal(statsOffensive.Hits) / Convert.ToDecimal(statsOffensive.AtBats), 4);
        }

        public decimal GetOBP()
        {
            if (statsOffensive.AtBats == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(Convert.ToDecimal(statsOffensive.Hits + statsOffensive.Walks + statsOffensive.HPB) / Convert.ToDecimal(statsOffensive.AtBats + statsOffensive.Walks + statsOffensive.HPB + statsOffensive.SF), 4);
            }
        }

        public decimal GetSLG()
        {
            if (statsOffensive.AtBats == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(Convert.ToDecimal((statsOffensive.Singles + (statsOffensive.Doubles * 2) + (statsOffensive.Triples * 3) + (statsOffensive.Homeruns * 4)) / Convert.ToDecimal(statsOffensive.AtBats)), 4);
            }
        }

        public int PositionInBattingOrder
        {
            get { return positionInBattingOrder; }
            set {
                if (value > 9)
                    throw new ArgumentOutOfRangeException("positionInBattingOrder");
                else
                    positionInBattingOrder = value; 
                }
        }
    }
}
