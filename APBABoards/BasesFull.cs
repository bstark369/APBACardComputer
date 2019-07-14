using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class BasesFull
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnFirstSpeed, char runnerOnSecondSpeed, char runnerOnThirdSpeed, int? strikes = 0, int? balls = 0, bool? secondcolumn = false, bool? infieldClose = false)
        {

            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over deep center field";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 4;
                    break;
                case 2:
                    returnDescription = "TRIPLE to extreme left field";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 3:
                    returnDescription = "TRIPLE to right field";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 4:
                    if (outs == 2)
                    {
                        returnDescription = "DOUBLE to left center; runners advance 3 bases";
                        hitter.statsOffensive.RBI += 3;
                    }
                    else
                    {
                        returnDescription = "DOUBLE to left center; runners advance 2 bases";
                        hitter.statsOffensive.RBI += 2;
                    }
                    
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    break;
                case 5:
                    returnDescription = "DOUBLE to right; 3 runners scores (S on 1st out at home; A-RF PO-C)";
                    hitter.statsOffensive.RBI += 3;
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    //TODO: Deal with S on 1st out a home
                    break;
                case 6:
                    if ((bool)secondcolumn)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "DOUBLE to left center; runners advance 3 bases";
                            hitter.statsOffensive.RBI += 3;
                        }
                        else
                        {
                            returnDescription = "DOUBLE to left center; runners advance 2 bases";
                            hitter.statsOffensive.RBI += 2;
                        }
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Doubles++;
                    }
                    else
                    {
                        returnDescription = "TRIPLE over third (2nd col., see #4)";
                        hitter.statsOffensive.RBI += 3;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Triples++;
                    }
                    break;
                case 7:
                    returnDescription = "SINGLE over 2nd; 2 runners score; other to 2nd (F to 3rd)";
                    hitter.statsOffensive.RBI += 2;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.AtBats++;
                    //TODO: deal with f to 3rd
                    break;
                case 8:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE thru short; runners advance 2 bases (S on 1st out at 3rd; A-LF PO-3B)";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.RBI += 2;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-RF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; 1 runner scores; others hold; PO-RF";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                            case 'B':
                                if (outs == 2)
                                {
                                    returnDescription = "Strike out; PO-C";
                                    hitter.statsOffensive.AtBats++;
                                    hitter.statsOffensive.Strikeouts++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; 1 runner scores; others hold; PO-CF";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE thru short; runners advance 2 bases (S on 1st out at 3rd; A-LF PO-3B)";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                                //TODO: deal with s on first being out at 3rd
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
                                returnDescription = "Strikeou; PO-C";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Strikeouts++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner scores; others hold; PO-CF *SO PO-C";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 'B':
                        case 'D':
                            if (outs == 2)
                            {
                                returnDescription = "SINGLE over 1st; runners advance 2 bases";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                            }
                            else
                            {
                                returnDescription = "SINGLE over 1st; runners advance 1 base *runners advance 2 bases";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
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
                                returnDescription = "Fly out; runner scores; others hold; PO-LF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    break;
                case 10:
                    returnDescription = "SINGLE over third; runners advance 2 bases; batter steals 2nd on next pitch; 1 ball on batter";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.RBI += 2;
                    hitter.statsOffensive.SB++;
                    //TODO: return 1 ball
                    break;
                case 11:
                    returnDescription = "SINGLE past 2nd; runners advance 2 bases; batter steals 2nd on next pitch; 3 ball on batter";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.RBI += 2;
                    hitter.statsOffensive.SB++;
                    //TODO: return 3 balls
                    break;
                case 12:
                    if ((bool)infieldClose)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Ground out; A-SS PO-1B";
                            hitter.statsOffensive.AtBats++;
                        }
                        else
                        {
                            returnDescription = "Double play; runner out at home; batter out at 1st; A-SS PO-C A-C PO-1B";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.GIDP++;
                        }
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Ground out; A-SS PO-1B";
                            hitter.statsOffensive.AtBats++;
                        }
                        else
                        {
                            returnDescription = "Double play; batter out at 1st; runner out at 2nd; others advance 1 base; A-SS PO-2B A-2B PO-1B";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.GIDP++;
                        }
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
                        returnDescription = "Base on balls (Z or ZZ pitcher; 2 balls)";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Walks++;
                    }
                    break;
                case 15:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE to left; runners advance 2 bases (S on 2nd out at home; A-LF PO-C)";

                            hitter.statsOffensive.RBI += 2;
                            //TODO: Deal with s on 2nd out at home
                            break;
                        case 2:
                            returnDescription = "SINGLE to left; runners advance 1 base; then another on error; E-LF";
                            hitter.statsOffensive.RBI++;
                            break;
                        case 3:
                            returnDescription = "SINGLE to left; runners advance 2 bases (F on 1st scores)";
                            hitter.statsOffensive.RBI += 2;
                            //TODO: deal with f on 1st scoring
                            break;
                    }
                    hitter.statsOffensive.Singles++;
                    hitter.statsOffensive.AtBats++;
                    break;
                case 16:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE to center; runners advance 2 bases; batter out trying for 2nd; A-CF A-1B PO-2B";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI += 2;
                            break;
                        case 2:
                            returnDescription = "1st on error; runners advance 2 bases; batter out trying for 2nd; E-CF A-CF PO-SS";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 3:
                            returnDescription = "SINGLE to right center field; runners advance 2 bases";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI += 2;
                            break;
                    }
                    break;
                case 17:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "SINGLE to right; runners advance 2 bases";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                            }
                            else
                            {
                                returnDescription = "SINGLE to right; runners advance 1 base; *runners advance 2 bases";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "1st on error; runners advance 2 bases; E-RF";
                            }
                            else
                            {
                                returnDescription = "1st on error; runners advance 1 base; *2 bases; E-RF";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 18:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "1st on error; runners advance one base; E-SS";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "1st on error; runners advance 2 bases; E-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Out at 1st; A-3B PO-1B";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Out at 1st; runnres advance 1 base; A-3B PO-1B";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 2:
                            returnDescription = "1st on error; runners advance 2 bases; E-3B (S on 2nd out at home; A-LF PO-C)";
                            hitter.statsOffensive.AtBats++;
                            //TODO: Deal with s on 2nd out at home
                            break;
                        case 3:
                            returnDescription = "1st and 2nd on error; runners advance 2 bases; E-3B";
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    
                    break;
                case 20:
                    returnDescription = "Hit by pitcher; runner advance 1 base";
                    hitter.statsOffensive.HPB++;
                    hitter.statsOffensive.RBI++;
                    break;
                case 21:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "1st on error- fumbled grounder; runners advance 1 base; E-1B";
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 2:
                                returnDescription = "Ball-catcher EJECTED from game for disputing umpire's decision";
                                break;
                            case 3:
                                returnDescription = "Ball-pitcher EJECTED from game for disputing umpire's decision";
                                break;
                        }
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "1st on E-1B; runners advance 1 base";
                                break;
                            case 2:
                                returnDescription = "1st on error; runners advance 1 base; E-SS";
                                break;
                            case 3:
                                returnDescription = "1st on error; runners advance 1 base; E-2B";
                                break;
                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 22:
                    if ((bool)infieldClose)
                    {
                        returnDescription = "Catcher picker runner off 1st; A-C PO-1B";
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Line drive; PO-SS";
                        }
                        else
                        {
                            returnDescription = "Double play; line drive; both PO-SS";
                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 23:
                    if ((bool)infieldClose)
                    {
                        returnDescription = "Hit by pitcher; batter to 1st";
                        hitter.statsOffensive.HPB++;
                        hitter.statsOffensive.RBI++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-1B PO-P";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runners advance 1 base; A-1B PO-P";
                                    hitter.statsOffensive.RBI++;
                                }
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 2:
                                returnDescription = "Stike- batter EJECTED from game for disputing decision on called strike";
                                //TODO: return strike
                                break;
                            case 3:
                                returnDescription = "Foul strike- catcher EJECTED from the game for disputing foul tip";
                                //TODO: return strike
                                break;
                        }
                    }
                    break;
                case 24:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-SS PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Double play; runner out at home; batter out at 1st; A-SS PO-C PO-1B";
                                    hitter.statsOffensive.GIDP++;
                                }
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 3:
                                returnDescription = "Runner out at home; FC; batter safe at 1st; A-SS PO-C";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Batter out at 1st; A-2B PO-1B";
                        }
                        else
                        {
                            if (outs == 1)
                            {
                                returnDescription = "Double play; runner out at 2nd; batter out at 1st; A-2B PO-SS A-SS PO-1B";
                            }
                            else
                            {
                                returnDescription = "Double play; runner out at 2nd; batter out at 1st; others advance 1 base; A-2B PO-SS A-SS PO-1B";
                            }
                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 25:
                    if (outs == 2)
                    {
                        returnDescription = "Out at first; A-P PO-1B";
                    }
                    else
                    {
                        returnDescription = "Double play; runner out at home; batter out at 1st; A-P PO-C A-C PO-1B *A-P PO-1B";
                        hitter.statsOffensive.GIDP++;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Safe at 1st; FC; runner out at home; A-2B PO-C";
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 2:
                                returnDescription = "SINGLE thru 2nd; runners advance 2 bases";
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                                break;
                        }
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs == 2)
                                {
                                    returnDescription = "Batter out at 1st; A-2B PO-1B";
                                }
                                else
                                {
                                    if (outs == 0)
                                    {
                                        returnDescription = "Double play; runner out at 2nd; batter out at 1st; others advance 1 base; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                    }
                                    else
                                    {
                                        returnDescription = "Double play; runner out at 2nd; batter out at 1st; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                    }
                                }
                                break;
                            case 2:
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Batter safe at 1st; FC; runner out at 2nd; A-SS PO-2B";
                                }
                                else
                                {
                                    returnDescription = "Batter safe at 1st; FC; runner out at 2nd; others advance 1 base; A-SS PO-2B";
                                    hitter.statsOffensive.RBI++;
                                }
                                break;

                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 27:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs == 2)
                                {
                                    returnDescription = "FC runner out at 3rd; PO-3B";
                                }
                                else
                                {
                                    returnDescription = "Double play; runner out at home; batter out at 1st; A-3B PO-C A-C PO-1B *PO-3B (X-SO PO-C)";
                                    hitter.statsOffensive.GIDP++;
                                }
                                break;
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Batter safe at 1st; runner out a 3rd; FC; PO-3B";
                                }
                                else
                                {
                                    returnDescription = "Batter safe at 1st; FC; runner forced out at home; others advance 1 base; PO-3B PO-C *PO-3B (X-SO PO-C)";
                                }
                                break;
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Batter safe at 1st; FC; runner on 2nd force out at 3rd; PO-3B (X-SO PO-C)";
                                }
                                else
                                {
                                    returnDescription = "Batter safe at 1st; FC; runner on 2nd force out at 3rd; other advance 1 base; PO-3B (X-SO PO-C)";
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "SINGLE to short; runners advance 1 base";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                                break;
                            case 2:
                                returnDescription = "Safe at 1st; FC; runner out at home; A-SS PO-C";
                                break;
                            case 3:
                                returnDescription = "SINGLE thur SS; runners advance 2 bases";
                                hitter.statsOffensive.RBI += 2;
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Batter safe at 1st; FC; runner out at 2nd; A-SS PO-2B";
                        }
                        else
                        {
                            returnDescription = "Batter safe at 1st; FC; runner out at 2nd; others advance 1 base; A-SS PO-2B";
                            hitter.statsOffensive.RBI++;
                        }
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
                        if (outs == 2)
                        {
                            returnDescription = "Out at first; A-P PO-1B";
                        }
                        else
                        {
                            returnDescription = "Batter safe at 1st; FC; runner force out at home; others advance 1 base; A-P PO-C *A-P PO-1B (Y-SO; PO-C)";
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
                    if (pitcherControl.Contains("X"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Fly out; runners hold PO-LF (X-SO PO-C)";
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runner on 3rd scores; PO-LF (X-SO PO-C)";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                                break;
                        }
                    }
                    break;
                case 31:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runners hold; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner on 3rd scores; PO-CF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    break;
                case 32:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Fly out; PO-RF";
                        }
                        else
                        {
                            returnDescription = "Fly out; runners on 2nd and 3rd advance 1 base; other holds; PO-RF (K-SO PO-C)";
                            hitter.statsOffensive.SF++;
                            hitter.statsOffensive.RBI++;
                        }
                    }
                    break;
                case 33:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Infield fly; PO-1B; runners hold (K-SO)";
                                break;
                            case 2:
                                returnDescription = "Line drive out; runners hold; PO-1B";
                                break;
                        }
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 34:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Fly out; PO-LF";
                            hitter.statsOffensive.AtBats++;
                        }
                        else
                        {
                            returnDescription = "Fly out; one scores; other hold; PO-LF (Y-SO PO-C)";
                            hitter.statsOffensive.SF++;
                            hitter.statsOffensive.RBI++;
                        }
                    }
                    break;
                case 35:
                    if (pitcherControl.Contains("W"))
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Walks++;
                    }
                    returnDescription = "Strikeout; PO-C (W-Base on balls)";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 36:
                    returnDescription = "Wild pitch; runners advance 1 base";
                    break;
                case 37:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; all runners advance 1 base;PO-CF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; all runners advance 1 base; (F on 2nd scores) PO-CF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                                //TODO: F on 2nd scoring
                            }
                            break;
                    }
                    break;
                case 38:
                    if (outs == 2)
                    {
                        returnDescription = "SINGLE; runners advance 1 base; shortstop loses ball in sun";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        returnDescription = "Infield fly; batter out; PO-SS; shortstop loses ball in sun; runners advance 1 base *SINGLE; runners advance 1 base";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.RBI++;
                    }
                    break;
                case 39:
                    returnDescription = "Runner out stealing home; others advance 1 base; PO-C";
                    break;
                case 40:
                    if ((bool)infieldClose)
                    {
                        returnDescription = "SINGLE- pitcher hit by line drive; runners advance 1 base";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        returnDescription = "Base on balls";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Walks++;
                    }
                    break;
                case 41:
                    switch (outs)
                    {
                        case 0:
                            returnDescription = "Triple play; PO-SS PO-SS A-SS PO-3B";
                            break;
                        case 1:
                            returnDescription = "Double play; PO-SS PO-SS";
                            break;
                        case 2:
                            returnDescription = "Line drive out; PO-SS";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; runners advance 1 base";
                    hitter.statsOffensive.HPB++;
                    hitter.statsOffensive.RBI++;
                    break;
            }

            return returnDescription;
        }
    }
}
