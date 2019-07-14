using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnSecond
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnSecondSpeed, bool secondcolumn, int? strikes = 0, int? balls = 0)
        {
            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over center field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI+=2;
                    break;
                case 2:
                    returnDescription = "TRIPLE to deep center";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 3:
                    returnDescription = "HOMERUN to deep right field";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI+=2;
                    break;
                case 4:
                    returnDescription = "TRIPLE to right center";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 5:
                    returnDescription = "HOMERUN over left center field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI+=2;
                    break;
                case 6:
                    returnDescription = "DOUBLE to left center; runner scores";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 7:
                    returnDescription = "SINGLE to right; runner scores";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 8:
                    if (pitcherGrade == 'A' || pitcherGrade == 'B' && !secondcolumn)
                    {
                        returnDescription = "Out at 1st; runner to 3rd; A-P PO-1B";
                    }
                    else // C & D
                    {
                        hitter.statsOffensive.Singles++;
                       
                        if (runnerOnSecondSpeed == 'S')
                        {
                            returnDescription = "SINGLE over 2nd; runner out at home; A-CF PO-C; batter to 2nd";
                        }
                        else
                        {
                            returnDescription = "SINGLE over 2nd; runner scores";
                            hitter.statsOffensive.RBI++;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 9:
                    switch (pitcherGrade)
                    {
                        case 'A':
                            returnDescription = "Out at 1st; runner to 3rd; A-SS PO-1B";
                            break;
                        case 'C':
                            returnDescription = "Out at 1st; PO-1B";
                            break;
                        case 'B':
                        case 'D':
                            hitter.statsOffensive.Singles++;
                            if (runnerOnSecondSpeed == 'S')
                            {
                                returnDescription = "SINGLE thru short; runner out at home, A-LF PO-C; batter to 2nd";
                            }
                            else
                            {
                                hitter.statsOffensive.RBI++;
                                returnDescription = "SINGLE thru short; runner scores";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 10:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE - infield hit; reunner to 3rd";
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                returnDescription = "Out at 1st; PO-1B";
                                break;
                            case 'B':
                                returnDescription = "Out at 1st; A-3B PO-1B";
                                break;
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE - infield hit; reunner to 3rd";
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 11:
                    if (outs == 2)
                    {
                        returnDescription = "SINGLE to left; runner scores; batters steals 2nd on first pitch; 1 strike on next batter";
                    }
                    else
                    {
                        if (runnerOnSecondSpeed == 'F' || outs == 2)
                        {
                            returnDescription = "SINGLE to left; runner scores; batters steals 2nd on first pitch; 1 strike on next batter";
                            hitter.statsOffensive.RBI++;
                        }
                        else
                        {
                            returnDescription = "SINGLE to left; runner out at home; batters steals 2nd on first pitch; 1 strike on next batter";
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.SB++;
                    hitter.statsOffensive.Singles++;
                    break;
                case 12:
                    returnDescription = "Strikeout; PO-C";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Strikeouts++;
                    break;
                case 13:
                    if (pitcherControl.Contains("R"))
                    {
                        returnDescription = "Out at 1st; runner holds; A-SS PO-1B";
                    }
                    else
                    {
                        returnDescription = "Strikeout; PO-C (R-Out at 1st; runner holds; A-SS PO-1B)";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 14:
                    returnDescription = "Base on balls; batter takes 1st";
                    hitter.statsOffensive.Walks++;
                    break;
                case 15:
                    if (fieldingRating == 1)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "SINGLE to left; Runner scores";
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                        }
                        else
                        {
                            returnDescription = "SINGLE to left; runner to 3rd; *Runner score";
                            hitter.statsOffensive.Singles++;
                        }
                    }
                    else
                    {
                        returnDescription = "1st on error; runner scores; E-LF";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 16:
                    if (fieldingRating == 3)
                    {
                        returnDescription = "SINGLE to center; runner scores; batter to 2nd on throw home";
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.RBI++;
                    }
                    else // fielding 1 & 2
                    {
                        returnDescription = "SINGLE to center; runner out at home; batter to 2nd on throw; A-CF PO-C";
                        hitter.statsOffensive.Singles++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 17:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (runnerOnSecondSpeed == 'F')
                                returnDescription = "Fly out; runner to 3rd; PO-RF";
                            else
                                returnDescription = "Fly out; runner holds; PO-RF";
                            break;
                        case 2:
                            if (runnerOnSecondSpeed == 'F' || outs == 2)
                                returnDescription = "1st on error; runner scores";
                            else
                                returnDescription = "1st on error; runner to 3rd";
                            break;
                        case 3:
                            returnDescription = "SINGLE to right; runner scores";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 18:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                                returnDescription = "1st on error; runner runner out at 3rd; E-SS; A-SS PO-3B";
                            else
                                returnDescription = "1st on error; runner holds; E-SS";
                            break;
                        case 2:
                            returnDescription = "Out at 1st; runner to 3rd (F scores); A-SS PO-1B";
                            break;
                        case 3:
                            if (outs == 2)
                                returnDescription = "1st on error; runner to third; E-SS";
                            else
                                returnDescription = "1st on error; runner holds; E-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    returnDescription = "Hit by pitcherl batter takes 1st";
                    hitter.statsOffensive.HPB++;
                    break;
                case 20:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE thru second; runner to 3rd";
                            hitter.statsOffensive.Singles++;
                            break;
                        case 2:
                            returnDescription = "Out at first; runner to 3rd; A-2B PO-1B";
                            break;
                        case 3:
                            returnDescription = "1st & 2nd on error; runner scores; E-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Out at 1st; runner to 3rd; A-1B PO-P";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "SINGLE to deep 1st; runner to 3rd";
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 22:
                    if (runnerOnSecondSpeed == 'S')
                        returnDescription = "Runner bluffs tword third but does not try to steal";
                    else
                        returnDescription = "Runner steals 3rd";
                    break;
                case 23:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner out stealing 3rd; A-C PO-3B; thirdbasemen is injured; unable to play in next 3 games";
                            break;
                        case 2:
                            returnDescription = "Runner out stealing 3rd; A-C PO-3B; thirdbasemen is injured; unable to play in next 4 games";
                            break;
                        case 3:
                            returnDescription = "Runner out stealing 3rd; A-C PO-3B; thirdbasemen is injured; unable to play in next 6 games";
                            break;
                    }
                    break;
                case 24:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Pop fly out; PO-SS (K-SO; PO-C)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Double Play; line drive; PO-SS A-SS PO-2B";
                            hitter.statsOffensive.GIDP++; // TODO: is this correct?
                            break;
                        case 2:
                        case 3:
                            returnDescription = "Line drive out; PO-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st runner to 3rd; A-2B PO-1B (K-SO)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; runner holds; A-3B PO-1B (Y-SO)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    returnDescription = "Out at 1st; runner to 3rd; A-SS PO-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 29:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; runner to 3rd; A-1B PO-P (K-SO)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    returnDescription = "Flyout; runner holds; PO-LF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 31:
                    returnDescription = "Flyout; runner holds; PO-CF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 32:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "Fly out; runner holds; PO-RF (K-SO; PO-C)";
                                break;
                            case 2:
                                if (runnerOnSecondSpeed == 'F')
                                    returnDescription = "Fly out; runner to 3rd; PO-RF";
                                else
                                    returnDescription = "Fly out; runner holds; PO-RF";
                                break;
                            case 3:
                                returnDescription = "Fly out runner to 3rd; PO-RF (K-SO; PO-C)";
                                break;
                        }
                    }
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
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Pop fly out; PO-SS";
                                break;
                            case 2:
                                returnDescription = "High fly out; PO-SS";
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 34:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "High fly out; PO-2B";
                                break;
                            case 2:
                                returnDescription = "Pop fly out; PO-2B";
                                break;
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
                        returnDescription = "Foul out; PO-3B (W-base on balls)";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 36:
                    returnDescription = "Wild pitch; runner to 3rd";
                    //TODO: Deal with ball
                    break;
                case 37:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Double Play; fly out; runner out trying for 3rd, PO-RF A-RF PO-3B";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 2:
                            returnDescription = "Runner caught of 2nd; A-P PO-SS";
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Out at first; A-SS PO-1B";
                            }
                            else
                            {
                                returnDescription = "Safe at 1st; runner out; FC; A-SS PO-3B; *A-SS PO-1B";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 38:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE; line drive hits pitcher; runner to 3rd; pitcher injured; unable to play in next 7 games";
                            hitter.statsOffensive.Singles++;
                            break;
                        case 2:
                            if (outs == 2)
                                returnDescription = "1st on error; runner to 3rd; E-SS";
                            else
                                returnDescription = "1st on error; runner holds; E-SS";
                            break;
                        case 3:
                            if (outs == 2)
                                returnDescription = "1st on error; runner goes to 3rd on error; E-SS";
                            else
                                returnDescription = "1st on error; runner holds; E-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 39:
                    returnDescription = "Runner out stealing 3rd; A-C PO-3B";
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                                returnDescription = "Out at first; A-2B PO-1B";
                            else
                                returnDescription = "Safe at 1st; FC; runner out at 3rd; A-2B PO-3B; *A-2B PO-1B";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 2:
                            if (runnerOnSecondSpeed == 'S')
                                returnDescription = "DP; Fly out to RF; runner out at 3rd; PO-RF; A-RF PO-3B";
                            else
                                returnDescription = "Fly out to RF; runner to 3rd on catch; PO-RF";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 3:
                            returnDescription = "Catcher fumbles plate bouncher; batter safe at 1st; runner to 3rd; E-C";
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 41:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner picked off 2nd; A-C PO-2B";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "Runner steals 3rd; goes home on wild throw by catcher; E-C";
                            break;
                    }
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; batter takes 1st";
                    hitter.statsOffensive.HPB++;
                    break;
                default:
                    throw (new System.Exception("Invalid board result: " + number.ToString()));
            }
            return returnDescription;
        }
    }
}
