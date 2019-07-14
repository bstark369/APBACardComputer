using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class BasesEmpty
    {
        public BasesEmpty()
        {
        }

        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, bool secondColumn, int? strikes = 0, int? balls = 0)
        {
            string returnDescription= "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over right field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 2:
                    returnDescription = "TRIPLE to left center";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    break;
                case 3:
                    returnDescription = "Triple to right";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    break;
                case 4:
                    returnDescription = "DOUBLE over 3rd";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    break;
                case 5:
                    returnDescription = "DOUBLE over 1st";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    break;
                case 6:
                    returnDescription = "DOUBLE to right center";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    break;
                case 7:
                    returnDescription = "SINGLE to right";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    break;
                case 8:
                    if (secondColumn)
                    {
                        returnDescription = "SINGLE to center";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                returnDescription = "Pop fly out PO-3B";
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 'B':
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                                break;
                            default:
                                returnDescription = "SINGLE to center";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    break;
                case 9:
                    switch (pitcherGrade)
                    {
                        case 'A':
                            returnDescription = "Out at 1st; A-SS PO-1B";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 'B':
                            returnDescription = "SINGLE over short";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            break;
                        case 'C':
                            returnDescription = "Pop fly out PO-3B";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 'D':
                            returnDescription = "SINGLE over short";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    break;
                case 10:
                    returnDescription = "SINGLE to center";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    break;
                case 11:
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.SB++;
                    returnDescription = "SINGLE to left; batter steals 2nd on first pitch to next batter; one strike on batter";
                    break;
                case 12:
                    hitter.statsOffensive.AtBats++;
                    returnDescription = "Out at 1st";
                    break;
                case 13:
                    if (pitcherControl.Contains("R") && outs == 2)
                    {
                        returnDescription = "Fly out; PO-CF";
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        returnDescription = "Strikout";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    break;
                case 14:
                    if (pitcherControl.Contains("ZZ") && balls < 2)
                        returnDescription = "2 Balls";
                    else
                    {
                        returnDescription = "Base on balls; batter takes 1st";
                        hitter.statsOffensive.Walks++;
                    }
                    break;
                case 15:
                        switch (fieldingRating)
                        {
                            case 3:
                                returnDescription = "1st and 2nd on error; E-LF";
                                break;
                            case 2:
                                returnDescription = "SINGLE to left";
                                hitter.statsOffensive.Singles++;
                                break;
                            case 1:
                                returnDescription = "Flyout; PO-LF";
                                break;
                        }
                        hitter.statsOffensive.AtBats++;
                        break;
                case 16:
                        switch (fieldingRating)
                        {
                            case 3:
                                returnDescription = "SINGLE; batter to 2nd on error; E-CF";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                break;
                            case 2:
                                returnDescription = "SINGLE to center";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                break;
                            case 1:
                                returnDescription = "Flyout; PO-CF";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    break;
                case 17:
                        switch (fieldingRating)
                        {
                            case 3:
                                returnDescription = "SINGLE; batter to 2nd on error; E-RF";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                break;
                            case 2:
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                returnDescription = "SINGLE to right";
                                break;
                            case 1:
                                returnDescription = "Flyout; PO-RF";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    break;
                case 18:
                     returnDescription = "1st on error; E-SS";
                     hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs != 2)
                                goto default;
                            returnDescription = "Out at 1st; A-3B PO-1B";
                            break;
                        default:
                            returnDescription = "1st on error; E-3B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    returnDescription = "1st on error; E-2B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE down right field line";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            break;
                        default:
                            returnDescription = "1st on error; E-1B";
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 22:
                    switch (fieldingRating)
                    {
                        case 3:
                            returnDescription = "First on error; E-P";
                            break;
                        default:
                            returnDescription = "Out at 1st; A-1B PO-P";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 23:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "1st on error; E-LF";
                            break;
                        case 2:
                            returnDescription = "1st on error; E-CF";
                            break;
                        case 3:
                            returnDescription = "1st on error; E-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 24:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; A-SS PO-1B";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 25:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; A-2B PO-1B";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 26:
                    returnDescription = "Out at 1st, A-2B PO-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; A-3B PO-1B";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 28:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                        returnDescription = "Out at 1st; A-SS PO-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 29:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                        returnDescription = "Out at 1st; A-P PO-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                        returnDescription = "Fly out; PO-LF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 31:
                    returnDescription = "Fly out; PO-CF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 32:
                    if (pitcherControl.Contains("K"))
                    {
                        hitter.statsOffensive.Strikeouts++;
                        returnDescription = "Strikeout; PO-C";
                    }
                    else
                        returnDescription = "Fly out; PO-RF";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 33:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                        returnDescription = "Pop fly out; PO-2B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 34:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                        returnDescription = "Pop fly out; PO-SS";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 35:
                    returnDescription = "Foul out PO-C";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 36:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                        returnDescription = "Ball";
                    break;
                case 37:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.Walks++;
                    }
                    else
                        returnDescription = "Strike";
                    break;
                case 38:
                    returnDescription = "Ball";
                    break;
                case 39:
                    if (pitcherControl.Contains("W"))
                    {
                        hitter.statsOffensive.Walks++;
                        returnDescription = "Base on balls";
                    }
                    else
                        returnDescription = "Strike";
                    break;
                case 40:
                    if (pitcherControl.Contains("W"))
                    {
                        hitter.statsOffensive.Walks++;
                        returnDescription = "Base on balls";
                    }
                    else
                        returnDescription = "Foul";
                    break;
                case 41:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "1st and 2nd on error; E-SS";
                            break;
                        case 2:
                            returnDescription = "1st and 2nd on error; E-P";
                            break;
                        case 3:
                            returnDescription = "1st on error; E-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
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
