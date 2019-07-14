using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APBABoards
{
    class RunnerOnSecondAndThird
    {
        public string GetResult(int number, char pitcherGrade, int fieldingRating, ref Player hitter, int outs, List<string> pitcherControl, char runnerOnSecondSpeed, char runnerOnThirdSpeed, int? strikes = 0, int? balls = 0, bool? secondcolumn = false, bool? infieldClose = false)
        {

            string returnDescription = "";
            switch (number)
            {
                case 1:
                    returnDescription = "HOMERUN over center field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 2:
                    returnDescription = "TRIPLE to extreme left field";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2; ;
                    break;
                case 3:
                    returnDescription = "DOUBLE to deep center; runners scores; batter out trying for 3rd; A-CD A-2B PO-3B";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 4:
                    returnDescription = "HOMERUN over left field fence";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Runs++;
                    hitter.statsOffensive.Homeruns++;
                    hitter.statsOffensive.RBI += 3;
                    break;
                case 5:
                    returnDescription = "TRIPLE to deep left";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Triples++;
                    hitter.statsOffensive.RBI += 2; ;
                    break;
                case 6:
                    returnDescription = "DOUBLE to right; cleans the bases";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.Doubles++;
                    hitter.statsOffensive.RBI += 2;
                    break;
                case 7:
                    if (pitcherGrade == 'A' && !(bool)secondcolumn)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Fly out; PO-LF";
                            hitter.statsOffensive.AtBats++;
                        }
                        else
                        {
                            returnDescription = "Fly out; on runner scores; other holds; PO-LF";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.SF++;
                        }
                    }
                    else
                    {
                        returnDescription = "SINGLE to left center; runners score; batter to 2nd on throw home";
                        hitter.statsOffensive.RBI += 2;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                    }
                    break;
                case 8:
                    if ((bool)secondcolumn)
                    {
                        returnDescription = "SINGLE over 1st; runners score; (S on 2nd out at home; A-RF PO-C; batter to 2nd)";
                        hitter.statsOffensive.RBI += 2;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                            case 'C':
                            case 'D':
                                returnDescription = "SINGLE over 1st; runners score; (S on 2nd out at home; A-RF PO-C; batter to 2nd)";
                                hitter.statsOffensive.RBI += 2;
                                hitter.statsOffensive.AtBats++;
                                hitter.statsOffensive.Singles++;
                                //TODO: S runner out at home
                                break;
                            case 'B':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; runners advance 1 base; PO-CF";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
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
                                returnDescription = "Strikout; PO-C";
                                hitter.statsOffensive.Strikeouts++;
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Flyout; PO-CF; one scores; other holds; *SO; PO-C";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 'B':
                            if (outs == 2)
                            {
                                returnDescription = "Strikout; PO-C";
                                hitter.statsOffensive.Strikeouts++;
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Flyout; runners advance 1 base; PO-RF *SO; PO-C";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 'C':
                            if (outs == 2)
                            {
                                returnDescription = "Flyout; PO-RF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Flyout; runners advance 1 base; PO-RF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 'D':
                            returnDescription = "SINGLE beats out infield hit; one runners scores; other to 3rd";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    break;
                case 10:
                    if ((bool)secondcolumn)
                    {
                        if (outs == 2)
                        {
                            returnDescription = "SINGLE over 3rd; both runners score";
                            hitter.statsOffensive.RBI += 2;
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                        }
                        else
                        {
                            returnDescription = "SINGLE over 3rd; one runners scores, other to 3rd; *both runners score";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                        }
                    }
                    else
                    {
                        switch (pitcherGrade)
                        {
                            case 'A':
                                if (outs == 2)
                                {
                                    returnDescription = "Strikout; PO-C";
                                    hitter.statsOffensive.Strikeouts++;
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; PO-RF; one scores; other holds; *SO; PO-C";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 'B':
                            case 'D':
                                if (outs == 2)
                                {
                                    returnDescription = "SINGLE over 3rd; both runners score";
                                    hitter.statsOffensive.RBI += 2;
                                    hitter.statsOffensive.AtBats++;
                                    hitter.statsOffensive.Singles++;
                                }
                                else
                                {
                                    returnDescription = "SINGLE over 3rd; one runners scores, other to 3rd; *both runners score";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.AtBats++;
                                    hitter.statsOffensive.Singles++;
                                }
                                break;
                            case 'C':
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-CF";
                                }
                                else
                                {
                                    returnDescription = "Fly out; runners advance one base; PO-CF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                        }
                    }
                    break;
                case 11:
                    if (outs == 2)
                    {
                        returnDescription = "SINGLE to left; both score; batter steals second; 1 ball and 1 strike on batter";
                        hitter.statsOffensive.RBI += 2;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.SB++;
                    }
                    else
                    {
                        returnDescription = "SINGLE to left; runners advance 1 base (* both score); batter steals second; 1 ball and 1 strike on batter";
                        hitter.statsOffensive.RBI += 2;
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Singles++;
                        hitter.statsOffensive.SB++;
                    }
                    break;
                case 12:
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
                                returnDescription = "Double play; Fly out; runner out at home; other to 3rd; PO-LF A-LF PO-C";
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 2:
                        case 3:
                            returnDescription = "Strikeout; PO-C";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Strikeouts++;
                            break;
                    }
                    break;
                case 13:
                    if (pitcherControl.Contains("R"))
                    {
                        returnDescription = "Pop fly out; runners hold; PO-3B";
                    }
                    else
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    hitter.statsOffensive.AtBats++;
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
                                returnDescription = "1st on error; E-LF; both runners score; batter to 2nd on throw home";
                            }
                            else
                            {
                                returnDescription = "1st on error; E-LF; runners advance 1 base; batter to 2nd on throw home; *both runners score";
                            }
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 2:
                            if (outs != 2 && runnerOnThirdSpeed == 'F')
                            {
                                returnDescription = "Fly out; runners on third scores; PO-LF";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runners hold; PO-LF";
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 3:
                            returnDescription = "SINGLE to left; runners advance 1 base; other runner scores & batter to 2nd on error; E-LF";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.Singles++;
                            break;
                    }
                    break;
                case 16:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out to deep center field; PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out to deep center field; PO-CF; bother runners advance 1 base after catch";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                        case 2:
                        case 3:
                            returnDescription = "SINGLE to center; one runner scores; other scores & batter to 2nd on wild throw; E-CF";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.Singles++;
                            break;
                        
                    }
                    break;
                case 17:
                    returnDescription = "SINGLE to right; one runner scores; other out at home, A-RF PO-C batter to 2nd on throw home (F safe at home)";
                    hitter.statsOffensive.AtBats++;
                    hitter.statsOffensive.RBI++;
                    hitter.statsOffensive.Singles++;
                    //TODO: Deal with f safe at home
                    break;
                case 18:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Pop fly out; PO-SS; runners hold";
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "1st on error; runners advance 1 base; E-SS";
                            }
                            else
                            {
                                returnDescription = "1st on error; runners hold; E-SS; *runners advance 1 base";
                            }
                            break;
                        case 3:
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 19:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            returnDescription = "SINGLE; runners advance 1 base";
                            hitter.statsOffensive.RBI++;
                            hitter.statsOffensive.Singles++;
                            break;
                        case 3:
                            returnDescription = "1st on error; runners advance 1 base (F on 2nd scores) E-3B";
                            //TODO: deal with f on 2nd scoring
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 20:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "Pop fly out, PO-2B; runners hold";
                            break;
                        case 2:
                        case 3:
                            returnDescription = "1st on error; runners advance 1 base; E-2B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 21:
                    returnDescription = "Hit by pitcher; filling the bases";
                    hitter.statsOffensive.HPB++;
                    break;
                case 22:
                    switch (fieldingRating)
                    {
                        case 1:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Runner picked off 3rd; A-C PO-3B";
                            }
                        else
                            {
                                returnDescription = "SINGLE - runner on 2nd hit by batted ball; other holds 3rd; PO-SS";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 2:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "Out at 1st; runners hold; A-3B PO-1B";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-3B PO-1B";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runners advance 1 base; A-3B PO-2B";
                                    hitter.statsOffensive.AtBats++;
                                    hitter.statsOffensive.RBI++;
                                }
                                
                            }
                            break;
                        case 3:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "1st on error; runners hold; E-3B";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-3B PO-1B";
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runners advance 1 base; A-3B PO-1B";
                                    hitter.statsOffensive.RBI++;
                                }
                                hitter.statsOffensive.AtBats++;
                            }
                            break;

                    }
                    break;
                case 23:
                    switch (outs)
                    {
                        case 2:
                            returnDescription = "Fly out; rightfielder makes shoestring catch; PO-RF";
                            break;
                        case 1:
                            returnDescription = "Double play; rightfielder makes shoestring catch; PO-RF A-RF PO-2B";
                            break;
                        case 0:
                            returnDescription = "Triple play; rightfielder makes shoestring catch; PO-RF A-RF PO-2B A-2B PO-3B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 24:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Foul out; back of 1st; PO-2B";
                            }
                            else
                            {
                                returnDescription = "Double play; foul out; back of 1st; runner out trying for home; other runner to 3rd; PO-2B A-2B PO-3B";
                            }
                            break;
                        case 2:
                        case 3:
                            returnDescription = "High fly out; runners hold; PO-3B";
                            break;
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 25:
                    if (outs == 2)
                    {
                        returnDescription = "Line drive; PO-1B";
                    }
                    else
                    {
                    returnDescription = "Double play; line drive; runner doubled off 2nd; other holds 3rd; PO-1B A-1B PO-SS";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 26:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                                returnDescription = "SINGLE thur second; runners advance 1 base";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI++;
                                break;
                            case 2:
                                returnDescription = "Safe at 1st; FC; runner out at home; other to 3rd; A-2b A-C PO-3B, batter to 2nd on rundown";
                                break;
                            case 3:
                                returnDescription = "SINGLE thur second; both runners score";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                                break;
                        }
                    }
                    else // deep
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Out at 1st on grounder to 2nd; A-2b PO-1B";
                        }
                        else
                        {
                            returnDescription = "Out at 1st on grounder to 2nd; runners advance 1 base; A-2b PO-1B";
                            hitter.statsOffensive.RBI++;
                        }
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
                        returnDescription = "Out at 1st; runners hold; A-2B PO-1B (K-SO)";
                    }
                    hitter.statsOffensive.AtBats++;
                    break;
                case 28:
                    if ((bool)infieldClose)
                    {
                        switch (fieldingRating)
                        {
                            case 1:
                            case 3:
                                returnDescription = "Out at 1st; runners hold; A-SS PO-1B";
                                break;
                            case 2:
                                returnDescription = "SINGLE thru short; both runners score";
                                hitter.statsOffensive.Singles++;
                                hitter.statsOffensive.RBI += 2;
                                break;
                        }
                    }
                    else
                    {
                        if (outs == 2)
                        {
                            returnDescription = "Out at 1st; A-SS PO-1B";
                        }
                        else
                        {
                            returnDescription = "Out at 1st; runners advance one base; A-SS PO-1B";
                            hitter.statsOffensive.RBI++;
                        }
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
                        returnDescription = "Out at 1st; runners hold; A-P PO-1B (K-SO)";
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
                            case 3:
                                if (outs == 2)
                                {
                                    returnDescription = "Fly out; PO-LF";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; one scores; other holds; PO-LF (K-SO)";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                }
                                break;
                            case 2:
                                returnDescription = "Fly out; runners hold; PO-LF";
                                hitter.statsOffensive.AtBats++;
                                break;
                        }
                    }
                    break;
                case 31:
                    switch (fieldingRating)
                    {
                        case 1:
                        case 2:
                            returnDescription = "Fly out; ruunners hold; PO-CF";
                            hitter.statsOffensive.AtBats++;
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out;  PO-CF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Fly out; runner on 3rd scores; other holds; PO-CF";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.SF++;
                            }
                            break;
                    }
                    break;
                case 32:
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
                                returnDescription = "Fly out; runners hold; PO-RF (X-SO PO-C)";
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
                                    returnDescription = "Fly out; runner on 3rd scores; other holds (F on 2nd goes to 3rd) PO-RF";
                                    hitter.statsOffensive.RBI++;
                                    hitter.statsOffensive.SF++;
                                    //TODO: deal with f on 2nd going to 3rd
                                }
                                break;
                        }
                    }
                    break;
                case 33:
                    if (outs == 2)
                    {
                        returnDescription = "Fly out; PO-RF";
                        hitter.statsOffensive.AtBats++;
                    }
                    else
                    {
                        returnDescription = "Fly out; one score; other holds; PO-RF";
                        hitter.statsOffensive.RBI++;
                        hitter.statsOffensive.SF++;
                    }
                    break;
                case 34:
                    if (pitcherControl.Contains("K"))
                    {
                        returnDescription = "Strikeout; PO-C";
                        hitter.statsOffensive.Strikeouts++;
                    }
                    else
                    {
                        returnDescription = "High fly out; runners hold; PO-SS (K-SO)";
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
                        returnDescription = "Foul out; PO-1B (W-base on balls)";
                        hitter.statsOffensive.AtBats++;
                    }
                    break;
                case 36:
                    returnDescription = "Passed ball; runners advance 1 base";
                    break;
                case 37:
                    switch (fieldingRating)
                    {
                        case 1:
                            returnDescription = "SINGLE; beats out infield hit and spikes firstbaseman who is out next 4 games; runners advance 1 base";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                        case 2:
                            returnDescription = "SINGLE; line driver hits thirdbaseman who is injured; out for 3 games; runners advance 1 base";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                        case 3:
                            returnDescription = "SINGLE; best out bunt; runners advance 1 base";
                            hitter.statsOffensive.AtBats++;
                            hitter.statsOffensive.Singles++;
                            hitter.statsOffensive.RBI++;
                            break;
                    }
                    break;
                case 38:
                    if (outs == 2)
                    {
                    }
                    else
                    {
                        returnDescription = "Stikeout; catcher drops 3rd stike; batter out at 1st; A-C PO-1B; runners advance 1 base";
                        hitter.statsOffensive.AtBats++;
                        hitter.statsOffensive.Strikeouts++;
                        hitter.statsOffensive.RBI++; // IS this correct
                    }
                    break;
                case 39:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Pop fly out; shortstop and leftfielder collide and are injured; shortstop unable to play remainder of game; leftfield continues";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Pop fly out; runners advance 1 base; PO-SS; shortstop and leftfielder collide and are injured; shortstop unable to play remainder of game; leftfield continues";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 2:
                            if (outs == 2)
                            {
                                returnDescription = "Pop fly out; PO-SS; shortstop and leftfielder collide and are injured; shortstop unable to play next 3 games; leftfielder out for 2 games";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Pop fly out; runners advance 1 base; PO-SS; shortstop and leftfielder collide and are injured; shortstop unable to play next 3 games; leftfielder out for 2 games";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                        case 3:
                            if (outs == 2)
                            {
                                returnDescription = "Pop fly out; PO-SS; shortstop and leftfielder collide and are injured; shortstop unable to play next 3 games; leftfielder out for 2 games";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Pop fly out; runners advance 1 base; PO-SS; shortstop and leftfielder collide and are injured; shortstop unable to play next 2 games; leftfielder out for 4 games";
                                hitter.statsOffensive.SF++;
                                hitter.statsOffensive.RBI++;
                            }
                            break;
                    }
                    break;
                case 40:
                    switch (fieldingRating)
                    {
                        case 1:
                            if (outs == 2)
                            {
                                returnDescription = "Fly out; PO-RF";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (runnerOnThirdSpeed == 'S')
                                {
                                    returnDescription = "DP; Fly out; PO-RF; runner out at home, other to 3rd; A-RF PO-C; DP";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Fly out; PO-RF; runners advance 1 base after catch (S on 3rd out at home; A-RF PO-C; DP)";
                                    hitter.statsOffensive.SF++;
                                    hitter.statsOffensive.RBI++;
                                }
                            }          
                            break;
                        case 2:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "1st on error; runners score; E-2B";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                returnDescription = "Out at 1st; runners advance 1 base; A-2B PO-1B";
                                hitter.statsOffensive.RBI++;
                                hitter.statsOffensive.AtBats++;
                            }
                            break;
                        case 3:
                            if ((bool)infieldClose)
                            {
                                returnDescription = "1st and 2nd on error; runners score; E-SS";
                                hitter.statsOffensive.AtBats++;
                            }
                            else
                            {
                                if (outs == 2)
                                {
                                    returnDescription = "Out at 1st; A-SS PO-1B";
                                    hitter.statsOffensive.AtBats++;
                                }
                                else
                                {
                                    returnDescription = "Out at 1st; runners advance 1 base; A-SS PO-1B";
                                    hitter.statsOffensive.AtBats++;
                                    hitter.statsOffensive.RBI++;
                                }
                            }
                            break;
                    }
                    break;
                case 41:
                    returnDescription = "Balk; runners advance one base";
                    break;
                case 42:
                    returnDescription = "Hit by pitcher; filling the bases";
                    break;
            }
            return returnDescription;
        }
    }
}
