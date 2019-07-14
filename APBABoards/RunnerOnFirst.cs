using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnFirst
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnFirstSpeed, bool secondColumn, int? strikes = 0, int? balls = 0)
        {
            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over left field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI+=2;
                    break;
                case 2:
                    returnDescription = "TRIPLE along right field foul line";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 3:
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    if (runnerOnFirstSpeed == 'S' && outs != 2)
                    {
                        returnDescription = "DOUBLE to center; runner out at home; A-CF PO-C)";
                    }
                    else
                    {
                        returnDescription = "DOUBLE to center; runner scores";
                        hitter.statsOffensive.RBI++;
                    }
                    break;
                case 4:
                    returnDescription = "TRIPLE to left";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 5:
                    returnDescription = "HOMERUN over right center field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI+=2;
                    break;
                case 6:
                    returnDescription = "DOUBLE over 1st; runner to 3rd (F scores); *any runner scores";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    if (outs == 2 || runnerOnFirstSpeed == 'F')
                        hitter.statsOffensive.RBI++;
                    break;
                case 7:
                    if (secondColumn)
                    {
                        returnDescription = "Single to right; runner to 3rd";
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        if (pitcherGrade == 'A')
                        {
                            returnDescription = "Out at 1st; runner to 2nd; A-3B PO-1B";
                        }
                        else
                        {
                            returnDescription = "Single to right; runner to 3rd";
                            hitter.statsOffensive.Singles++;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 8:
                    if (secondColumn)
                    {
                        if (outs == 2)
                            returnDescription = "SINGLE to center; runner to 2nd";
                        else
                            returnDescription = "SINGLE to center; runner to 3rd";
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        if (pitcherGrade == 'A' || pitcherGrade == 'B')
                        {
                            returnDescription = "Out at 1st; runner to 2nd; A-3B PO-1B";
                        }
                        else
                        {
                            if (outs == 2)
                                returnDescription = "SINGLE to center; runner to 2nd";
                            else
                                returnDescription = "SINGLE to center; runner to 3rd";
                            hitter.statsOffensive.Singles++;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 9:
                    if (pitcherGrade == 'C')
                    {
                        returnDescription = "Out at 1st; runner to 2nd; A-3B PO-1B";
                    }
                    else
                    {
                        returnDescription = "SINGLE; beats out infield hit; runner to 2nd";
                        hitter.statsOffensive.Singles++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 10:
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.SB++;
                    returnDescription = "SINGLE to right center; runner to 3rd; batter steals 2nd on second pitch; two strikes on batter";
                    break;
                case 11:
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.SB++;
                    returnDescription = "SINGLE over 1st; runner to 3rd; batter steals 2nd on third pitch; tow balls, one strike on batter";
                    break;
                case 12:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                    {
                        if (fieldingRating == 3)
                        {
                            hitter.statsOffensive.AtBats++;
                            returnDescription = "Safe at 1st; runner out, FC; A-2B PO-SS (W-Base on balls)";
                        }
                        else
                        {
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.GIDP++;
                            returnDescription = "Double play; A-SS PO-2b A-2B PO-1B";
                        }
                    }
                    break;
                case 13:
                    if (pitcherControl.Contains("R"))
                    {
                        returnDescription = "R-Pop fly out; PO-SS";
                    }
                    else
                    {
                        returnDescription = "Stikeout; PO C (R-Pop fly out; PO-SS)";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 14:
                    if (pitcherControl.Contains("Z") || pitcherControl.Contains("ZZ"))
                    {
                        if (balls >= 2)
                        {
                            returnDescription = "Base on balls, runner to 2nd; batter to 1st";
                            hitter.statsOffensive.Walks++;
                        }
                        else
                        {
                            returnDescription = "2 balls";
                        }
                        //TODO: fix if balls is 1
                    }
                    else
                    {
                        hitter.statsOffensive.Walks++;
                        returnDescription = "Base on balls; runner to 2nd; batter to 1st (Z or ZZ Pitcher: 2 balls)";
                    }
                    break;
                case 15:
                    returnDescription = "Hit by pitcher; batter to 1st; runner to 2nd";
                    hitter.statsOffensive.HPB++;
                    break;
                case 16:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE to center; runner to 2nd";
                            hitter.statsOffensive.Singles++;
                            break;
                        case 2:
                            returnDescription = "Fly out; runner holds; PO-CF";
                            break;
                        case 3:
                            if (outs == 2 || runnerOnFirstSpeed == 'F')
                                returnDescription = "1st on error; runner to 3rd; E-CF";
                            else
                                returnDescription = "1st on error; runner to 2nd; E-CF";   
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 17:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE to right; runner out at 3rd; A-RF PO-3B; batter to 2nd on throw to 3rd";
                            hitter.statsOffensive.Singles++;
                            break;
                        case 2:
                            returnDescription = "Fly out; runners hold; PO-RF";
                            break;
                        case 3:
                            returnDescription = "SINGLE to right; runner to 3rd batter to 2nd on throw to 3rd";
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 18:
                    if (fieldingRating == 1)
                    {
                        returnDescription = "Out at first; runner to 2nd; A-SS; PO-1B";
                    }
                    else
                    {
                        returnDescription = "1st on error; runner to 3rd; E-SS";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Out at 1st; runner to 2nd; A-3B PO-1B";
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; A-3B PO-1B";
                            }
                            else
                            {
                                returnDescription = "SINGLE to left; runner to 2nd; *out at 1st; A-3B PO-1B";
                                hitter.statsOffensive.Singles++;
                            }
                            break;
                        case 3:
                            returnDescription = "SINGLE to left; runner to 2nd";
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    if (fieldingRating == 1)
                    {
                        returnDescription = "Out at 1st; runner to 2nd; A-2B PO-1B";
                    }
                    else
                    {
                        returnDescription = "1st on error; runner to 3rd; E-2B";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            returnDescription = "1st & 2nd on error; runner to 3rd; A-SS E-1B";
                            break;
                        case 3:
                            if (runnerOnFirstSpeed == 'F')
                                returnDescription = "1st & 2nd on error; runner scores; A-SS E-1B";
                            else
                                returnDescription = "1st & 2nd on error; runner to 3rd; A-SS E-1B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;   
                    break;
                case 22:
                    returnDescription = "Hit by pitcher; batter to 1stl runner to 2nd";
                    hitter.statsOffensive.HPB++;
                    break;
                case 23:
                    if (outs == 2)
                    {
                        returnDescription = "Balk-runner to 2nd";
                    }
                    else
                    {
                        returnDescription = "Runner out stealing and is EJECTED from game; A-C PO-SS; *Balk-runner to 2nd";
                    }
                    break;
                case 24:
                    returnDescription = "Double play; A-SS PO-2B A-2B PO-1B";
                    hitter.statsOffensive.GIDP++;
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B (K-SO PO-C)";
                        hitter.statsOffensive.GIDP++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    returnDescription = "Batter safe at 1st on FC; runner out at 2nd; A-2B PO-SS";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "Double Play A-3B PO-2B A-2B PO-1B (X-SO; PO-C)";
                                hitter.statsOffensive.GIDP++;
                                break;
                            case 2:
                                returnDescription = "Batter safe at first; FC; runner out at 2nd; A-3B PO-2B (X-SO; PO-C)";
                                break;
                            case 3:
                                returnDescription = "Out at 1st; runner to 2nd; A-3B PO-1B (X-SO; PO-C)";
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    if (fieldingRating == 1)
                    {
                        returnDescription = "Safe at 1st; runner out; FC; A-SS PO-2B";
                    }
                    else
                    {
                        returnDescription = "Out at first; runner to 2nd; A-SS PO-1B";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 29:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        if (fieldingRating == 2)
                        {
                            if (outs == 2)
                            {
                                returnDescription = "Out at first; A-P PO-1B";
                            }
                            else
                            {
                                returnDescription = "Safe at 1st; runner out; FC; A-P PO-SS; *A-P PO-1B (Y-SO; PO-C)";
                            }
                        }
                        else
                        {
                            returnDescription = "Out at 1st; runner to 2nd; A-P PO-1B (Y-SO)";
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    returnDescription = "Flyout, runner holds; PO-RF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 31:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Flyout, runner holds; PO-CF";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 32:
                    returnDescription = "Fly out runner holds; PO-RF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 33:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        if (fieldingRating == 2)
                        {
                            returnDescription = "High fly out; PO-3B (K-SO; PO-C)";
                        }
                        else
                        {
                            returnDescription = "Pop fly out; PO-3B (K-SO; PO-C)";
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 34:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        if (fieldingRating == 2)
                        {
                            returnDescription = "Pop fly out; PO-3B (Y-SO; PO-C)";
                        }
                        else
                        {
                            returnDescription = "High fly out; PO-3B (Y-SO; PO-C)";
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 35:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                    {
                        returnDescription = "Foul out; PO-C (W-base on balls)";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 36:
                    returnDescription = "Wild pitch, runner to second";
                    //TODO: Add ball
                    break;
                case 37:
                    returnDescription = "Runner caught off 1st; A-P PO-1B";
                    break;
                case 38:
                    if (runnerOnFirstSpeed == 'S')
                        returnDescription = "Pitcher looks runner back to first";
                    else
                        returnDescription = "Runner steals 2nd (S holds 1st)";
                    break;
                case 39:
                    returnDescription = "Runner out stealing; A-C PO-2B";
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner out stealing; A-C PO-SS";
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Ground out; PO-1B";
                            }
                            else
                            {
                                returnDescription = "Safe at 1st; runner out; FC; A-1B PO-SS; *PO-1B";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 3:
                            returnDescription = "Out at 1st; runner to 2nd; A-1B (F to 3rd)";
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    
                    break;
                case 41:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Double Play; A-2B PO-SS A-SS PO-1B; runner out at 2nd is injured; unable to play in next 3 games";
                            hitter.statsOffensive.GIDP++;
                            break;
                        case 2:
                            returnDescription = "Batter safe at 1st; FC; runner out at 2nd is injured; unable to play n next 2 games; A-SS PO-2B";
                            break;
                        case 3:
                            returnDescription = "Double Play; A-3B PO-2B A-2B PO-1B; runner out at 2nd is injured; unable to play in next 4 games";
                            hitter.statsOffensive.GIDP++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; batter to 1st, runner to 2nd";
                    hitter.statsOffensive.HPB++;
                    break;
                default:
                    throw (new System.Exception("Invalid board result: " + number.ToString()));
            }
            return returnDescription;
        }
    }
}
