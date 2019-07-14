using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnFirstAndThird
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnFirstSpeed, char runnerOnThirdSpeed, int? strikes = 0, int? balls = 0, bool? secondcolumn = false, bool? infieldClose = false)
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
                    returnDescription = "TRIPLE to extreme right";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2; ;
                    break;
                case 3:
                    returnDescription = "TRIPLE over third";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2; ;
                    break;
                case 4:
                    returnDescription = "TRIPLE to left";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2; ;
                    break;
                case 5:
                    returnDescription = "HOMERUN over right field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 6:
                    returnDescription = "DOUBLE clears the bases";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 7:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE to left; one runner scores; other to 2nd";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE to left; one runner scores; other to 2nd";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 'B':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one runner scores; other holds; PO-CF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                        }
                    }
                    break;
                case 8:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE to right; one runner scores; other to 3rd; (S out at 3rd; A-RF PO-3B)";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                            case 'C':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-RF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one runners scores; other holds; PO-RF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 'B':
                            case 'D':
                                returnDescription = "SINGLE to right; one runner scores; other to 3rd; (S out at 3rd; A-RF PO-3B)";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                //TODO: deal with s out at third
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
                                returnDescription = "Fly out; PO-LF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; one runners scores; other holds; PO-RF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 'B':
                        case 'C':
                        case 'D':
                            if (outs == 2)
                            {
                                returnDescription = "SINGLE over short; one runner scores; other to third";
                            }
                            else
                            {
                                returnDescription = "SINGLE over short; one runner scores; other to 2nd; *other to third";
                            }
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    break;
                case 10:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE over 2nd; one runner scores; other out at 3rd; batter to 2nd; A-CF PO-3B";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one runners scores; other holds; PO-RF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 'B':
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE over 2nd; one runner scores; other out at 3rd; batter to 2nd; A-CF PO-3B";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                break;
                        }
                    }
                    break;
                case 11:
                    returnDescription = "SINGLE to left; one runner scores; other to 2nd (F to 3rd)";
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    //TODO: handle F going to third.
                    break;
                case 12:
                    if ((bool)infieldClose)
                    {
                        returnDescription = "Safe at 1st; FC; runner out at home; other to 2nd; A-2B PO-C";
                    }
                    else
                    {
                        switch (outs)
                        {
                            case 0:
                                returnDescription = "Double play; runner scores; A-1B PO-SS A-SS PO-1B";
                                hitter.statsOffensive.GIDP++;
                                break;
                            case 1:
                                hitter.statsOffensive.GIDP++;
                                returnDescription = "Double play; A-1B PO-SS A-SS PO-1B";
                                break;
                            case 2:
                                returnDescription = "Ground out; A-SS PO-1B";
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 13:
                    returnDescription = "Strikeout; PO-C";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Strikeouts++;
                    break;
                case 14:
                    returnDescription = "Base on balls; filling the bases";
                    hitter.statsOffensive.Walks++;
                    break;
                case 15:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-LF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; one scores, other holds; PO-LF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 2:
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "1st on error; runners advance two bases; E-LF";
                            }
                            else
                            {
                                returnDescription = "1st on error; runners advance one base *two bases; E-LF";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                    }
                    break;
                case 16:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (runnerOnThirdSpeed == 'S')
                                {
                                    returnDescription = "DP; Fly out; runner on their out at home, other to 2nd on throw; PO-CF;A-CF PO-C";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one scores, other holds; PO-CF (S out at home, A-CF PO-C; DP; other to 2nd on throw)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                            }
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; one scores, other holds; PO-CF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 3:
                            returnDescription = "SINGLE to center; runners advance 1 base; (F on 1st advances to 3rd)";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            //TODO: deal with f runner on first
                            break;
                    }
                    break;
                case 17:
                    returnDescription = "SINGLE to right; one runner scores; other scores and batter to 2nd on error; E-RF";
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Singles++;
                    break;
                case 18:
                    returnDescription = "Hit by pitcher; filling the bases";
                    hitter.statsOffensive.HPB++;
                    break;
                case 19:
                    returnDescription = "1st on error; ones scores; other to 3rd; E-3B";
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    switch (fieldingRating)
                    {
                        case 2:
                            returnDescription = "1st on error; one runner scores; other out at 3rd; batter to 2nd on throw; E-2B A-RF PO-3B (F safe at 3rd)";
                            hitter.statsOffensive.AtBats++;
                            //TODO: deal with f safe at 3rd
                            break;
                        case 1:
                        case 3:
                            returnDescription = "SINGLE thru 2nd; one runner scores; other out at 3rd; batter to 2nd on throw; A-RF PO-3B (F safe at 3rd)";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            //TODO: deal with f safe at 3rd
                            break;
                    }
                    break;
                case 21:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Ball- catcher throws wild to 3rd; one runner scores; oether to 2nd; E-C";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "SINGLE in front of the plate; runners advance one base";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                    }
                    break;
                case 22:
                    returnDescription = "Balk; runners advance one base";
                    break;
                case 23:
                    returnDescription = "Game called because of rain";
                    break;
                case 24:
                    switch (fieldingRating)
                    {
                        case 1:
                            if ((bool)infieldClose)
                            {
                                switch (outs)
                                {
                                    case 0:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B; runner scores, if not third out; defense may choose to play for one out at home (A-2B PO-C)";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 1:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 2:
                                        returnDescription = "Ground out; A-2B PO-1B";
                                        break;
                                }
                            }
                            else
                            {
                                switch (outs)
                                {
                                    case 0:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B; runner scores";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 1:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 2:
                                        returnDescription = "Ground out; A-2B PO-1B";
                                        break;
                                }

                            }
                            break;
                        case 2:
                        case 3:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Safe at 1st; FC; runner out at home; other to 2nd; A-2B PO-C";
                            }
                            else
                            {
                                switch (outs)
                                {
                                    case 0:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B; runner scores";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 1:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 2:
                                        returnDescription = "Ground out; A-2B PO-1B";
                                        break;
                                }
                            }
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    if ((bool)infieldClose)
                    {
                        returnDescription = "Safe at 1st; FC; runner out at home; other to 2nd";
                    }
                    else
                    {
                        switch (outs)
                        {
                            case 0:
                                returnDescription = "Double play; A-2B PO-SS A-SS PO-1B; runner on 3rd scores";
                                hitter.statsOffensive.GIDP++;
                                break;
                            case 1:
                                returnDescription = "Double play; A-2B PO-SS A-SS PO-1B";
                                hitter.statsOffensive.GIDP++;
                                break;
                            case 2:
                                returnDescription = "Out at first; A-2B PO-1B";
                                break;
                        }
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
                                returnDescription = "Out at 1st; runner holds 3rd; other to 2nd; A-2B PO-1B";
                                break;
                            case 2:
                                returnDescription = "SINGLE to right; one runner scores; other to 2nd";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                                break;
                        }
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 2:
                                switch (outs)
                                {
                                    case 0:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B; runner on 3rd scores";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 1:
                                        returnDescription = "Double play; A-2B PO-SS A-SS PO-1B";
                                        hitter.statsOffensive.GIDP++;
                                        break;
                                    case 2:
                                        returnDescription = "Out at first; A-2B PO-1B";
                                        break;
                                }
                                break;
                            case 3:
                                returnDescription = "Safe at 1st; FC; runner out at 2nd; other scores; A-2B PO-SS; attempted double play fails";
                                hitter.statsOffensive.RBI++;
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 27:
                    if (pitcherControl.Contains("Y"))
                    {
                        returnDescription = "Strikeout; PO-C";
                    }
                    else
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                if (outs == 2)
                                {
                                    returnDescription = "Fielders choice; A-3B PO-2B";
                                }
                                else
                                {
                                    returnDescription = "Double play; one runner holds 3rd; other out at 2nd; A-3B PO-2B A-2B PO-1B (Y-SO)";
                                    hitter.statsOffensive.GIDP++;
                                }
                                break;
                            case 2:
                            case 3:
                                returnDescription = "Out at 1st; runner to 2nd; other holds; A-2B PO-1B";
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    switch (fieldingRating)
                    {
                        case 1:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "SINGLE to left; one runner scores; other to 2nd";
                                
                                hitter.statsOffensive.Singles++; 
                                hitter.statsOffensive.RBI++;
                            }
                            else
                            {
                                switch (outs)
                                {
                                    case 0:
                                        returnDescription = "Double play A-2B PO-SS A-SS PO-1B; runner on 3rd scores";
                                        break;
                                    case 1:
                                        returnDescription = "Double play A-2B PO-SS A-SS PO-1B";
                                        break;
                                    case 2:
                                        returnDescription = "Fielders choice, A-2B PO-SS";
                                        break;
                                }

                            }
                            break;
                        case 2:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Out at 1st; runner holds 3rd, other to 2nd; A-SS PO-1B";
                            }
                            else
                            {
                                if (outs < 2)
                                {
                                    returnDescription = "Safe at 1st; FC, runner out at 2nd; other scores; A-SS PO-2B; attempted double play fails";
                                    hitter.statsOffensive.RBI++;
                                }
                                else
                                {
                                    returnDescription = "Safe at 1st; FC, runner out at 2nd";
                                }
                            }
                            break;
                        case 3:
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
                        returnDescription = "Out at 1st; runner to 2nd; other holds; A-P PO-1B (K-SO)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 30:
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
                                returnDescription = "Fly out; runners hold; PO-LF (X-SO; PO-C)";
                                hitter.statsOffensive.AtBats++;
                                break;
                            case 2:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF (X-SO; PO-C)";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    if (runnerOnThirdSpeed == 'S')
                                    {
                                        returnDescription = "DP; Fly out; runner out at home; PO-LF; A-LF PO-C";
                                        hitter.statsOffensive.AtBats++;
                                    }
                                    else
                                    {
                                        returnDescription = "Fly out; one scores; other holds; PO-LF";
                                        hitter.statsOffensive.RBI++;
                                        hitter.statsOffensive.SF++;
                                    }
                                }
                                break;
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF (X-SO; PO-C)";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one scores; other holds; PO-LF (X-SO; PO-C)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                        }
                    }
                    break; 
                case 31:
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
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF (K-SO; PO-C)";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one scores; other holds; PO-CF (K-SO; PO-C)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 2:
                                returnDescription = "Fly out; runners hold; PO-CF (K-SO; PO-C)";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    }
                    break;
                case 32:
                    returnDescription = "Fly out; runners hold; PO-RF";
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
                                returnDescription = "Pop fly out; PO-2B (K-SO)";
                                break;
                            case 2:
                                returnDescription = "High fly out; PO-2B (K-SO)";
                                break;
                        }
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 34:
                       if (pitcherControl.Contains("Y"))
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
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF (Y-SO; PO-C)";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one scores; other holds; PO-LF (Y-SO; PO-C)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 2:
                                returnDescription = "Fly out; runners hold; PO-LF (Y-SO; PO-C)";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    }
                    break;
                case 35:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Foul out in short right field; PO-2B";
                            break;
                        case 2:
                            returnDescription = "Foul out back of 1st base; PO-2B";
                            break;
                        case 3:
                            returnDescription = "Foul out; PO-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 36:
                    switch (fieldingRating)
                    {
                        case 2:
                            returnDescription = "Runner on 1st steals 2nd; other holds 3rd (S runner on 1st holds)";
                            //TODO: Deal with s runner on 1st
                            break;
                        case 1:
                        case 3:
                            returnDescription = "Runner on 1st steals 2nd; other holds 3rd";
                            break;
                    }
                    break;
                case 37:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner on 1st out stealing; A-C PO-SS; other holds";
                            break;
                        case 2:
                            returnDescription = "Runner on 3rd out; A-C PO-3B; other to 2nd (Double steal fails)";
                            break;
                        case 3:
                            returnDescription = "Runnre on 1st steals 2nd; other holds 3rd (S runner on 1st holds)";
                            //TODO: deal with s runner on first holding
                            break;
                    }
                    break;
                case 38:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner on 1st steals 2nd; toerh hodls 3rd (S runner on first holds)";
                            //TODO: Deal with s runner on first holding
                            break;
                        case 2:
                        case 3:
                            returnDescription = "Runner on 1st steals 2nd; other holds";
                            break;
                    }
                    break;
                case 39:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Runner on 3rd picked off; A-C PO-3B; other to 2nd";
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Runner on 2nd out stealing; A-C PO-2B";
                            }
                            else
                            {
                                returnDescription = "Runner on 3rd out; A-C PO-3B; other to 2nd (double steal fails) *A-C PO-2B";
                            }
                            break;
                        case 3:
                            returnDescription = "Runner on 1st steals 2nd; other holds 3rd (S runner on 1st holds)";
                            //TODO: Deal with s runner
                            break;
                    }
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Runner out stealing 2nd; A-C PO-2B";
                            }
                            else
                            {
                                returnDescription = "Runner out stealing home; other to 2nd; A-C A-2B PO-C";
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
                                if (runnerOnThirdSpeed == 'S')
                                {
                                    returnDescription = "DP; Fly out; runner on 3rd out at home; PO-CF A-CF PO-C";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one runner scores; other holds PO-CF (S out at home; A-CF PO-C)";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                    }
                    break;
                case 41:
                    returnDescription = "Double steal; one runner scores; other to 2nd";
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; filling the bases";
                    break;
            }
            return returnDescription;
        }
    }
}
