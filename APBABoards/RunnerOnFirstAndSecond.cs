using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnFirstAndSecond
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, int? strikes = 0, int? balls = 0, bool? secondcolumn = false, bool? infieldClose = false)
        {
            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over left field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 2:
                    if ((bool)secondcolumn)
                    {
                        goto case 5;
                    }
                    else
                    {
                        returnDescription = "HOMERUN to extreme right field (2nd col; see 5 below)";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Runs++;
                        hitter.statsOffensive.Homeruns++;
                        hitter.statsOffensive.RBI += 3;
                    }
                    break;
                case 3:
                    returnDescription = "DOUBLE to deep center; runners scores; (S on 1st out at home; A-CF A-SS PO-C)";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI += 2;
                    //TODO: Deal with s runner on first out at home
                    break;
                case 4:
                    returnDescription = "HOMERUN over right field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 5:
                    returnDescription = "TRIPLE to right field bull pen";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 6:
                    returnDescription = "DOUBLE to left center; runners scores; (S on 1st out at home; A-LF A-SS PO-C)";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI += 2;
                    //TODO: Deal with s runner on first out at home
                    break;
                case 7:
                    returnDescription = "SINGLE to left; one scores (S out at home & batter to 2nd; A-LF PO-C)' other to 3rd";
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.AtBats++;
                    break;
                case 8:
                    if ((bool)secondcolumn)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "SINGLE over short; one scores; other to 3rd";
                        }
                        else
                        {
                            returnDescription = "SINGLE over short; one scores; other to 2nd; *other to 3rd";
                        }
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.RBI++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                            case 'B':
                                returnDescription = "Out at 1st; runners advance on base; A-3B PO-1B";
                                break;
                            case 'C':
                            case 'D':
                                if (outs == 2)
                                {
                                    returnDescription = "SINGLE over short; one scores; other to 3rd";
                                }
                                else
                                {
                                    returnDescription = "SINGLE over short; one scores; other to 2nd; *other to 3rd";
                                }
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 9:
                    switch (pitcherGrade)
                    {
                        case 'A':
                        case 'C':
                            returnDescription = "Out at 1st; runners advance one base; A-PO PO-1B";
                            break;
                        case 'B':
                        case 'D':
                            returnDescription = "SINGLE - beats out infield hit; fills the bases";
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 10:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE - beast out bunt; fills the bases";
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                returnDescription = "Out at 1st; runners advance one base; PO-1B";
                                break;
                            case 'B':
                                returnDescription = "Out at 1st; runners advance one base; A-PO PO-1B";
                                break;
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE - beast out bunt; fills the bases";
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 11:
                    returnDescription = "SINGLE over 2nd; one runners scores; other to 3rd; batter steals seocnd on next pitch; one ball on batter";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.SB++;
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.Singles++;
                    //TODO: return one ball
                    break;
                case 12:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                    {
                        returnDescription = "Better safe at 1st on FC; one runner out at 2nd; other safe at 3rd; A-SS; PO-2B (W-Base on balls)";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 13:
                    returnDescription = "Strikeout; PO-C";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Strikeouts++;
                    break;
                case 14:
                    if (pitcherControl.Contains("Z") || pitcherControl.Contains("ZZ"))
                    {
                        returnDescription = "2 Balls";
                    }
                else
                    {
                        returnDescription = "Base on balls; fills the bases (Z or ZZ; 2 Balls)";
                        hitter.statsOffensive.Walks++;
                    }
                    break;
                case 15:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE to left; one runner scores; other to 3rd; batter out trying for 2nd; A-LF A-1B PO-2B";
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                        case 2:
                            returnDescription = "Fly out; runners hold; PO-LF";
                            break;
                        case 3:
                            returnDescription = "SINGLE to left; one runner scores; other to 3rd; & batter to 2nd on throw home";
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 16:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "1st on error; runner runner scores; other out at 3rd; batter to 2nd on throw home; E-CF A-CF PO-3B";
                            }
                            else
                            {
                                returnDescription = "1st on error; runner out at home; other to 3rd; batter to 2nd on throw home; E-CF A-CF PO-C; *one runner scores, other out at 3rd; E-CD A-CF PO-3B";
                            }
                            break;
                        case 2:
                            returnDescription = "SINGLE to center; runners advance one base (F on 2nd scores)";
                            hitter.statsOffensive.Singles++;
                            //TODO: Deal with F on second scoring
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 17:
                    returnDescription = "Hit by pitcher; fills the bases";
                    hitter.statsOffensive.HPB++;
                    break;
                case 18:
                    returnDescription = "SINGLE thru short; runners advance 2 bases; (S on 1st out at 3rd; A-CF PO-3B)";
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    returnDescription = "1st on error; runners advance 2 bases; E-3B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    returnDescription = "1st on error; filling the bases; E-2B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Out at 1st; runners advance 1 base; A-3B PO-1B";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "1st on error; filling the bases; A-3B E-1B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 22:
                    returnDescription = "1st on error; filling the bases; A-3B E-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 23:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Foul; strike; catcher injured by foul tip and is unable to play in next 3 games";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "Ball; catcher disputes umpire's decision and is ejected for the remainder of the game";
                            break;
                    }
                    break;
                case 24:
                    if (outs == 2)
                    {
                        returnDescription = "FC; A-2B PO-SS";
                    }
                    else
                    {
                        returnDescription = "Double Play; one runner to 3rd; other out; A-2B PO-SS A-SS PO-1B";
                        hitter.statsOffensive.GIDP++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    if (outs == 2)
                    {
                        returnDescription = "FC; A-SS PO-2B";
                    }
                    else
                    {
                        returnDescription = "Double Play; one runner to 3rd; other out at 2nd; A-SS PO-2B A-2B PO-1B";
                        hitter.statsOffensive.GIDP++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    returnDescription = "Infield fly; PO-2B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                    }
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Ground out; A-3B PO-1B";
                            }
                            else
                            {
                                returnDescription = "Double play; one runner to 2nd; other out at 3rd; PO-3B A-3B PO-1b (K-SO PO-C)";
                                hitter.statsOffensive.GIDP++;
                            }
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Ground out; A-3B PO-2B";
                            }
                            else
                            {
                                returnDescription = "Double play; one runner to 3rd; other out at 2nd; A-3B PO-2B A-2B PO-1B (K-SO PO-C)";
                                hitter.statsOffensive.GIDP++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; A-3B PO-1B (K-SO PO-C)";
                            }
                            else
                            {
                                returnDescription = "Out at 1st; runners advance 1 base; A-3b PO-1B (K-SO PO-C)";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "FC, A-SS PO-2B";
                            }
                            else
                            {
                                returnDescription = "Double play; runner to 3rd; A-SS PO-2B A-2B PO-1B";
                                hitter.statsOffensive.GIDP++;
                            }
                            break;
                        case 2:
                        case 3:
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 29:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; A-P PO-1B";
                            }
                            else
                            {
                                returnDescription = "Double play; one runner to 3rd; A-P PO-SS";
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; A-P PO-1B";
                            }
                            else
                            {
                                returnDescription = "Out at 1st; runners advance 1 base; A-P PO-1B";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                    }
                    else
                    {
                        returnDescription = "Flyout runners hold; PO-LF (K-SO PO-K)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 31:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            returnDescription = "Fly out runners hold; PO-CD";
                            break;
                        case 3:
                            returnDescription = "Fly out; runners hold (F on 2nd to 3rd); PO-CF";
                            //TODO: deal with f going to 3rd
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 32:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "Fly out runners hold; PO-RF (K-SO; PO-C)";
                                break;
                            case 2:
                            case 3:
                                returnDescription = "Fly out; runners hold (F on 2nd to 3rd); PO-RF (K-SO PO-C)";
                                //TODO: deal with f on second going to 3rd
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 33:
                    returnDescription = "Infield fly; PO-SS";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 34:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                    }
                    else
                    {
                        returnDescription = "Infield fly; PO-3B";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 35:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls; fills the bases";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                    {
                        returnDescription = "Foul out; PO-C (W-base on balls)";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 36:
                    returnDescription = "Passed ball; runners advance 1 base";
                    //TODO: return ball I guess
                    break;
                case 37:
                    returnDescription = "Double steal; runners advance 1 base";
                    break;
                case 38:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Out at 1st; runners advance one base; A-1B PO-P; pitcher injured covering 1st; out remainder of game";
                            break;
                        case 2: 
                            returnDescription = "Safe at 1st; one runner to 3rd; other out at 2nd and is injured slidingl out for 3 games; A-3B PO-2B; FC";
                            break;
                        case 3:
                            returnDescription = "Out at 1st; runners advance one base; A-1B PO-P; pitcher injured covering 1st; out next 4 games";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 39:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "FC; A-3B PO-2B";
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF";
                                }
                                else
                                {
                                    returnDescription = "Double play; fly out; PO-CF; runner out at 3rdl other holds; A-CF PO-3B (F safe at 3rd)";
                                    //TODO: deal with f safe at 3rd
                                }
                            }
                            break;
                        case 2:
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "FC; A-3B PO-2B";
                            }
                            else
                            {
                                returnDescription = "Double play; one runner to 3rd; A-3B PO-2B A-2B PO-1B";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                            }
                            else
                            {
                                returnDescription = "Double play; fly out; PO-CF; runner out at 3rd; other holds; A-CF PO-3B (F safe at 3rd)";
                                //TODO: deal with F safe at 3rd
                            }
                            break;
                        case 2:
                        case 3:
                            returnDescription = "1st on error, filling the bases; E-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 41:
                    switch (outs)
                    {
                        case 0:
                            returnDescription = "Triple play; line drive; PO-2B PO-2B A-2B PO-1B";
                            break;
                        case 1:
                            returnDescription = "Double play; line drive; PO-2B PO-2B";
                            break;
                        case 2:
                            returnDescription = "Line drive out; PO-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; fills the bases";
                    hitter.statsOffensive.HPB++;
                    break;
                default:
                    throw (new System.Exception("Invalid board result: " + number.ToString()));
            }
            return returnDescription;
        }
    }
}
