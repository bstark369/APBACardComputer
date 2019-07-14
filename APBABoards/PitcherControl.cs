using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class PitcherControl
    {
        char[] Ratings;

        public PitcherControl(char[] inRatings)
        {
            Ratings = inRatings;
        }

        public bool CheckForRating(char rating)
        {
            return Ratings.Contains(rating);
        }
    }

}
