using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class Team
    {
        string name;
        public List<Player> players;

        public Team(string name)
        {
            players = new List<Player>();
            this.name = name;
        }

        public void AddPlayer(Player card)
        {
            players.Add(card);
        }
    }
}
