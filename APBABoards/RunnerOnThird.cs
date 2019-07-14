using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnThird
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnThirdSpeed, int? strikes = 0, int? balls = 0, bool? secondcolumn = false, bool? infieldClose = false)
        {

            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over left field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 2:
                    returnDescription = "TRIPLE along left field foul line";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI++;;
                    break;
                case 3:
                    returnDescription = "HOMERUN over right center field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 4:
                    returnDescription = "Double to right; runner scores; batter out trying for 3rd; A-RF A-2B PO-3B";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI++;;
                    break;
                case 5:
                    returnDescription = "Double to right; runner scores";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 6:
                    if ((bool)secondcolumn)
                    {
                        goto case 5;
                    }
                    else
                    {
                        returnDescription = "HOMERUN to left field (2nd Col, see #5)";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Runs++;
                        hitter.statsOffensive.Homeruns++;
                        hitter.statsOffensive.RBI += 2;
                    }
                    break;
                case 7:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE to left; runner scores";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                if (outs < 2)
                                {
                                    returnDescription = "Fly out; runner scores; PO-LF";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                break;
                            case 'B':
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE to left; runner scores";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    }
                    break;
                case 8:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE over 2nd; runner scores";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'B':
                                if (outs < 2)
                                {
                                    returnDescription = "Fly out; runner scores; PO-RF";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; PO-RF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                break;
                            case 'A':
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE over 2nd; runner scores";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    break;
                case 9:
                    switch (pitcherGrade)
                    {
                        case 'A':
                            if (outs == 2)
                            {
                                returnDescription = "Strikeout; PO-C";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Strikeouts++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runner scores; PO-CF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                            }
                            break;
                        case 'C':
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-LF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                    returnDescription = "Fly out; runner scores; PO-CF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                            }
                            break;
                        case 'B':
                        case 'D':
                            returnDescription = "SINGLE thru short; runner scores; batter out trying for 2nd; A-LF PO-SS";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 10:
                    returnDescription = "SINGLE to right; runners scores; batter steals 2nd on third pitch; one ball two strike on batter";
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.SB++;
                    hitter.statsOffensive.AtBats++;
                    //TODO: return 1 ball and 2 strikes
                    break;
                case 11:
                    returnDescription = "SINGLE to right; runners scores; batter steals 2nd on first pitch; one strike on batter";
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.SB++;
                    hitter.statsOffensive.AtBats++;
                    //TODO: return 1 strikes
                    break;
                case 12:
                    if (outs == 2)
                    {
                        returnDescription = "Fly out; PO-RF";
                    }
                    else
                    {
                        returnDescription = "Double Play; fly out; runner out at home; PO-RF A-RF PO-C";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 13:
                    if (pitcherControl.Contains("R"))
                    {
                        returnDescription = "Fly out; runner holds; PO-CF";
                    }
                    else
                    {
                        returnDescription = "Strikeout; PO-C (R-fly out; runner holds; PO-CF)";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 14:
                    returnDescription = "Base on balls; batter takes 1st";
                    hitter.statsOffensive.Walks++;
                    break;
                case 15:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "1st and 2nd on error; runner scores; E-LF";
                            break;
                        case 2:
                            returnDescription = "SINGLE to left; runner scores; batter to 2nd on wild throw; E-LF";
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "SINGLE to left; runner scores";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                            }
                            else
                            {
                                returnDescription = "SINGLE to left; runner scores; batter to 2nd on thow home; *batter holds 1st";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 16:
                    returnDescription = "Hit by pitcher; batter takes 1st";
                    hitter.statsOffensive.HPB++;
                    break;
                case 17:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 3:
                            returnDescription = "1st on error; runners scores; E-RF";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-RF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner scores after catch; PO-RF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    break;
                case 18:
                    returnDescription = "1st on error; runner scores; E-SS";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    switch (fieldingRating)
                    {
                        case 3:
                        case 2:
                            returnDescription = "1st on error; runner scores; E-3B";
                            break;
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "E-3B runner scores";
                            }
                            else
                            {
                                returnDescription = "FC; runner escapes rundown on dropped throw; batter out at 2nd; runner remains on 3rd; A 3-B A-C E-3B A-3B PO-2B; *E-3B runner scores";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if ((bool)infieldClose)
                            {
                                if (runnerOnThirdSpeed == 'F')
                                {
                                    returnDescription = "SINGLE to 2nd runner scores";
                                    hitter.statsOffensive.RBI++;
                                }
                                else
                                    returnDescription = "SINGLE to 2nd Runner holds";
                                hitter.statsOffensive.Singles++;
                            }
                            else
                            {
                                returnDescription = "SINGLE to 2nd D-runner scores";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 3:
                            {
                                returnDescription = "1st on error; runner scores; E-1B";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; PO-1B";
                            }
                            else
                            {
                                returnDescription = "Out at 1st; runner scores; PO-1B";
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 3:
                            returnDescription = "1st and 2nd on error; runner scores; E-1B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 22:
                    if (outs == 2)
                    {
                        returnDescription = "Out at first; A-SS PO-1B";
                    }
                    else
                    {
                        returnDescription = "Safe at 1st; runner scores on error; A-SS E-C; *A-SS PO-1B no score";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 23:
                    if (outs == 2)
                    {
                        returnDescription = "Balk runner scores";
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "Single - Pop fly falls safe; runnes scores; secondbaseman and rightfielder collide and one is injured; secondbaseman unable to play in next 3 games; *Balk runner scores";
                                break;
                            case 2:
                                returnDescription = "Single - Pop fly falls safe; runner scores; secondbaseman and rightfielder collide and one is injured; rightfielder unable to play in next 3 games; *Balk runner scores";
                                break;
                            case 3:
                                returnDescription = "Single - Pop fly falls safe; runner scores; secondbaseman and rightfielder collide and one is injured; secondbaseman unable to play in next 4 games; *Balk runner scores";
                                break;
                        }
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.AtBats++;
                    } 
                    break;
                case 24:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Double Play; fly out; runner out trying for home; PO-SS A-SS PO-C";
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Out at first; A-SS PO-1B";
                            }
                            else
                            {
                                returnDescription = "Better safe at 1st; FC; runner out at home; A-SS PO-C; *A-SS PO-1B";
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Out at first; A-SS PO-1B";
                            }
                            else
                            {
                                returnDescription = "Safe at 1st; FC, runner out at home; A-SS A-C PO-3B; batter to 2nd on rundown; *A-SS PO-1B";
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Double play- line driver; PO-2B A-2B PO-3B";
                            break;
                        case 2:
                            returnDescription = "Double play; line drive; both PO-3B";
                            break;
                        case 3:
                            returnDescription = "Line drive out; PO-P";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    switch (fieldingRating)
                    {
                        case 1:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "SINGLE thru 2nd runner scores";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-2B PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-2B PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                        case 2:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Runner out at home; batter to 2nd on rundown; A-2B A-C PO-3B";
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-2B PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-2B PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                        case 3:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "SINGLE thru 2nd runner scores";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-2B PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-2B PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "Out at 1st; runner holds; A-3B PO-1B (K-SO; PO-C)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    switch (fieldingRating)
                    {
                        case 1:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Safe at 1st; runner out at home; A-SS PO-C";
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-SS PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-SS PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                        case 2:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "SINGLE thru shortstop; runner scores";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-SS PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-SS PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                        case 3:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Out at 1st; runner holds; A-SS PO-1B";
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st;  A-SS PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runner scores; A-SS PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                    }
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
                        returnDescription = "Out at 1st; runner holds; A-P PO-1B (K-SO; PO-C)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs != 2 && runnerOnThirdSpeed == 'F')
                                {
                                    returnDescription = "Fly out; runner scores; PO-LF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                break;
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    if (runnerOnThirdSpeed == 'S')
                                    {
                                        returnDescription = "DP: Fly out; runners out at home; PO-LF; A-LF PO-C";
                                        hitter.statsOffensive.AtBats++;
                                    }
                                    else
                                    {
                                        returnDescription = "Fly out; runners scores; PO-LF";
                                        hitter.statsOffensive.SF++;
                                        hitter.statsOffensive.RBI++;
                                    }
                                    //TODO; deal with K strikeout
                                }
                                break;
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                {
                                    returnDescription = "Fly out; runners scores; PO-LF (K-SO PO-C)";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                        }
                    }
                    break;
                case 31:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs != 2 && runnerOnThirdSpeed == 'F')
                                {
                                    returnDescription = "Fly out; runner scores; PO-CF (F scores)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runner holds; PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                break;
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out;  PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    if (runnerOnThirdSpeed == 'S')
                                    {
                                        returnDescription = "DP; Fly out; runner out at home; PO-CF; A-LF PO-C (K-SO PO-C)";
                                        hitter.statsOffensive.AtBats++;
                                    }
                                    else
                                    {
                                        returnDescription = "Fly out; runners scores; PO-CF (K-SO PO-C)";
                                        hitter.statsOffensive.SF++;
                                        hitter.statsOffensive.RBI++;
                                    }
                                }
                                break;
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out;  PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runners scores; PO-CF (K-SO PO-C)";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                                // DEAL WITH K Strikeout
                        }
                    }
                    break;
                case 32:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs != 2 && runnerOnThirdSpeed == 'F')
                            {
                                returnDescription = "Fly out; runner scores; PO-RF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner holds; PO-RF (F-Scores)";
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out;  PO-RF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (runnerOnThirdSpeed == 'S')
                                {
                                    returnDescription = "DP; Fly out; runner out at home; PO-RF; A-RF PO-C";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runner scores";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                            }
                            break;
                    }
                    break;
                case 33:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Fly out; PO-CF";
                            hitter.statsOffensive.AtBats++;
                        }
                        else
                        {
                            returnDescription = "Fly out; runner scores; PO-CF";
                            hitter.statsOffensive.SF++;
                            hitter.statsOffensive.RBI++;
                        }
                    }
                    break;
                case 34:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "High infield fly out; PO-1B (K-SO)";
                                break;
                            case 2:
                            case 3:
                                returnDescription = "Pop fly out; PO-1B (K-SO)";
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
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Foul out; PO-SS (W-base on balls)";
                                break;
                            case 2:
                                returnDescription = "High fly out behind 3rd base; PO-SS (W-base on balls)";
                                break;

                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 36:
                    returnDescription = "Wild pitch; runner scores";
                    break;
                case 37:
                    returnDescription = "Pop fly out; PO-1B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 38:
                    switch (fieldingRating)
                    {
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-RF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner scores; PO-RF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 1:
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-LF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner scores; PO-LF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    break;
                case 39:
                    returnDescription = "Pop fly out; PO-P";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            returnDescription = "Pop fly out; PO-SS";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Safe at 1st on error; runner holds; shorstop drops pop fly; E-SS; runner scores";
                            }
                            else
                            {
                                returnDescription = "Safe at 1st on error; runner holds; shorstop drops pop fly; E-SS; *runner scores";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 41:

                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "Runner steals home; catcher is INJURED, unable to play in next 7 games";
                                break;
                            case 2:
                                returnDescription = "Runner steals home; catcher is INJURED, unable to play in next 6 games";
                                break;
                            case 3:
                                returnDescription = "Runner steals home; catcher is INJURED, unable to play in next 3 games";
                                break;
                        }
                    }
                    else
                    {
                        returnDescription = "Runner caught off 3rd; A-C PO-3B";
                    }
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; batter takes first";
                    hitter.statsOffensive.HPB++;
                    break;
                default:
                    throw (new System.Exception("Invalid board result: " + number.ToString()));

            }
            return returnDescription;
        }
    }
}
