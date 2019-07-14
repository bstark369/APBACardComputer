using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APBABoards
{
    public partial class APBACardAnalyzer : Form
    {
        BasesEmpty basesEmpty = new BasesEmpty();
        RunnerOnFirst runnerOnFirst = new RunnerOnFirst();
        RunnerOnSecond runnerOnSecond = new RunnerOnSecond();
        RunnerOnThird runnerOnThird = new RunnerOnThird();
        RunnerOnFirstAndSecond runnerOnFirstAndSecond = new RunnerOnFirstAndSecond();
        RunnerOnFirstAndThird runnerOnFirstAndThird = new RunnerOnFirstAndThird();
        RunnerOnSecondAndThird runnerOnSecondAndThird = new RunnerOnSecondAndThird();
        BasesFull basesFull = new BasesFull();

        string resultsdescription = "";

        Team homeTeam;
        Dice dice;
        int basesEmptyTotal = 0;
        int runnerOnFirstTotal = 0;
        int runnerOnSecondTotal = 0;
        int runnerOnThirdTotal = 0;
        int runnerOnFirstAndSecondTotal = 0;
        int runnerOnFirstAndThirdTotal = 0;
        int runnerOnSecondAndThirdTotal = 0;
        int basesFullTotal = 0;

        int ATotal = 0;
        int BTotal = 0;
        int CTotal = 0;
        int DTotal = 0;
        int Outs0Total = 0;
        int Outs1Total = 0;
        int Outs2Total = 0;
        int fielding1Total = 0;
        int fielding2Total = 0;
        int fielding3Total = 0;
        int controlW = 0;
        int controlX = 0;
        int controlY = 0;
        int controlZ = 0;
        int controlZZ = 0;
        int controlK = 0;
        int controlR = 0;

        public APBACardAnalyzer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadPossibleResults();
            this.comboBoxBaseSituation.SelectedIndex = 0;
            this.comboBoxFielding.SelectedIndex = 2;
            this.checkBoxRandomizeFielding.Checked = true;
            this.checkBoxRandomizeBaseSituation.Checked = true;
            this.checkBoxRandomizePitchingGrade.Checked = true;
            this.checkBoxRandomizePitchingControl.Checked = true;
            this.comboBoxResult.SelectedIndex = 0;
            this.comboBoxPitchingGrade.SelectedIndex = 3;
            this.comboBoxRunnerSpeed.SelectedIndex = 0;
            homeTeam = new Team("Test team");
            dice = new Dice();
            loadCard();
        }

        private void loadPossibleResults()
        {
            for (int x = 1; x <= 42; x++)
            {
                this.comboBoxResult.Items.Add(x.ToString());
            }
        }

        public void getRandomBaseSituationAndOuts(out int outs, out string baseSituation )
        {
            // move to get random base situation and outs
            Die die = new Die(100000);
            int dieroll = die.Roll();
            baseSituation = "";
            outs = 0;
            if (dieroll >= 1 && dieroll <= 24239)//	0	0
            {
                baseSituation = "Bases Empty";
                outs = 0;
            }
            if (dieroll >= 24240 && dieroll <= 30487)//	1	0
            {
                baseSituation = "Runner on first base";
                outs = 0;
            }
            if (dieroll >= 30488 && dieroll <= 32158)//	2	0
            {
                baseSituation = "Runner on second base";
                outs = 0;
            }
            if (dieroll >= 32159 && dieroll <= 32347)//	3	0
            {
                baseSituation = "Runner on third base";
                outs = 0;
            }
            if (dieroll >= 32348 && dieroll <= 33271)//	12	0
            {
                baseSituation = "Runners on 1st and 2nd";
                outs = 0;
            }
            if (dieroll >= 33272 && dieroll <= 33855)//	13	0
            {
                baseSituation = "Runners on 1st and 3rd";
                outs = 0;
            }
            if (dieroll >= 33856 && dieroll <= 34351)//	23	0
            {
                baseSituation = "Runners on 2nd and 3rd";
                outs = 0;
            }
            if (dieroll >= 34352 && dieroll <= 34584)//	123	0
            {
                baseSituation = "Bases Full";
                outs = 0;
            }
            if (dieroll >= 34585 && dieroll <= 51868)//	0	1
            {
                baseSituation = "Bases Empty";
                outs = 1;
            }
            if (dieroll >= 51869 && dieroll <= 59330)//	1	1
            {
                baseSituation = "Runner on first base";
                outs = 1;
            }
            if (dieroll >= 59331 && dieroll <= 62648)//	2	1
            {
                baseSituation = "Runner on second base";
                outs = 1;
            }
            if (dieroll >= 62649 && dieroll <= 63376)//	3	1
            {
                baseSituation = "Runner on third base";
                outs = 1;
            }
            if (dieroll >= 63377 && dieroll <= 65040)//	12	1
            {
                baseSituation = "Runners on 1st and 2nd";
                outs = 1;
            }
            if (dieroll >= 65041 && dieroll <= 66168)//	13	1
            {
                baseSituation = "Runners on 1st and 3rd";
                outs = 1;
            }
            if (dieroll >= 66169 && dieroll <= 67181)//	23	1
            {
                baseSituation = "Runners on 2nd and 3rd";
                outs = 1;
            }
            if (dieroll >= 67182 && dieroll <= 67696)	//123	1
            {
                baseSituation = "Bases Full";
                outs = 1;
            }
            if (dieroll >= 67697 && dieroll <= 81214)//	0	2
            {
                baseSituation = "Bases Empty";
                outs = 2;
            }
            if (dieroll >= 81215 && dieroll <= 88573)	//1	2
            {
                baseSituation = "Runner on first base";
                outs = 2;
            }
            if (dieroll >= 88574 && dieroll <= 92920)//	2	2
            {
                baseSituation = "Runner on second base";
                outs = 2;
            }
            if (dieroll >= 92921 && dieroll <= 94411)//3	2
            {
                baseSituation = "Runner on third base";
                outs = 2;
            }
            if (dieroll >= 94412 && dieroll <= 96306)//	12	2
            {
                baseSituation = "Runners on 1st and 2nd";
                outs = 2;
            }
            if (dieroll >= 96307 && dieroll <= 98050)//	13	2
            {
                baseSituation = "Runners on 1st and 3rd";
                outs = 2;
            }
            if (dieroll >= 98051 && dieroll <= 99355)//	23	2
            {
                baseSituation = "Runners on 2nd and 3rd";
                outs = 2;
            }
            if (dieroll >= 99356 && dieroll <= 100000)//	123	2
            {
                baseSituation = "Bases Full";
                outs = 2;
            }
        }

        private List<String> getRandomPitchingControl()
        {
            List<string> pitcherControl = new List<string>();

            decimal W = Convert.ToDecimal(textBoxPitchingControl_W.Text) * 100;
            decimal K = Convert.ToDecimal(textBoxPitchingControl_K.Text) * 100;
            decimal X = Convert.ToDecimal(textBoxPitchingControl_X.Text) * 100;
            decimal Y = Convert.ToDecimal(textBoxPitchingControl_Y.Text) * 100;
            decimal Z = Convert.ToDecimal(textBoxPitchingControl_Z.Text) * 100;
            decimal R = Convert.ToDecimal(textBoxPitchingControl_R.Text) * 100;
            decimal ZZ = Convert.ToDecimal(textBoxPitchingControl_ZZ.Text) * 100;

            Die die = new Die(10000);
            int result2 = die.Roll();
            if (result2 > 0 && result2 <= W)
            {
                pitcherControl.Add("W");
                controlW++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= X)
            {
                pitcherControl.Add("X");
                controlX++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= Y)
            {
                pitcherControl.Add("Y");
                controlY++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= Z && !pitcherControl.Contains("W"))
            {
                pitcherControl.Add("Z");
                controlZ++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= ZZ && !pitcherControl.Contains("W"))
            {
                pitcherControl.Add("ZZ");
                controlZZ++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= R && !pitcherControl.Contains("X") && !pitcherControl.Contains("Y") && !pitcherControl.Contains("K"))
            {
                pitcherControl.Add("R");
                controlR++;
            }
            result2 = die.Roll();
            if (result2 > 0 && result2 <= K && !pitcherControl.Contains("K"))
            {
                pitcherControl.Add("K");
                controlK++;
            }
            return pitcherControl;
        }

        private void getSingleResult()
        {

            loadCard();
            clearStats();
            bool secondcolumn = false;
            char grade;
            int result;
            int balls = Convert.ToInt32(this.textBoxBalls.Text);
            int strikes = Convert.ToInt32(this.textBoxStrikes.Text);
            int outs = Convert.ToInt32(this.textBoxOuts.Text);

            //int roll;
            List<string> pitcherControl = new List<string>();

            if (checkBoxRandomizePitchingControl.Checked)
            {
                pitcherControl = getRandomPitchingControl();
            }
            else
            {

                foreach (object itemChecked in checkedListBoxControl.CheckedItems)
                {
                    pitcherControl.Add(itemChecked.ToString());
                }
            }
            if (checkBoxRandomizePitchingGrade.Checked)
                grade = GetRandomPitchingGrade();
            else
                grade = Convert.ToChar(this.comboBoxPitchingGrade.SelectedItem.ToString());

            result = Convert.ToInt32(comboBoxResult.SelectedItem.ToString());

            richTextBoxResult.Text = "Result: " + result.ToString();

            Player hitter = homeTeam.players[0];

            string baseSituation = "";
            if (checkBoxRandomizeBaseSituation.Checked)
            {
                getRandomBaseSituationAndOuts(out outs, out baseSituation);
            }
            else
            {
                baseSituation = this.comboBoxBaseSituation.SelectedItem.ToString();
            }

            int fielding = 2;
            if (checkBoxRandomizeFielding.Checked)
            {
                int oneroll;
                Die die = new Die(10);
                oneroll = die.Roll();
                if (oneroll <= 5)
                {
                    fielding = 2;
                    fielding2Total++;
                }
                if (oneroll > 5 && oneroll <= 8)
                {
                    fielding = 1;
                    fielding1Total++;
                }
                if (oneroll > 8)
                {
                    fielding = 3;
                    fielding3Total++;
                }
            }
            else
            {
                fielding = Convert.ToInt32(this.comboBoxFielding.SelectedItem.ToString());
            }

            switch (baseSituation)
            {
                case "Bases Empty":
                    resultsdescription = basesEmpty.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, secondcolumn, strikes, balls);
                    break;
                case "Runner on first base":
                    resultsdescription = runnerOnFirst.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                    break;
                case "Runner on second base":
                    resultsdescription = runnerOnSecond.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                    break;
                case "Runner on third base":
                    resultsdescription = runnerOnThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                    break;
                case "Runners on 1st and 2nd":
                    resultsdescription = runnerOnFirstAndSecond.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, strikes, balls, secondcolumn);
                    break;
                case "Runners on 1st and 3rd":
                    resultsdescription = runnerOnFirstAndThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                    break;
                case "Runners on 2nd and 3rd":
                    resultsdescription = runnerOnSecondAndThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                    break;
                case "Bases Full":
                    resultsdescription = basesFull.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                    break;
                default:
                    throw new System.Exception("Error, invalid base situation->" + this.comboBoxBaseSituation.SelectedItem.ToString());
            }
            this.richTextBoxResult.Text += " " + resultsdescription;

        }

        private int getRandomFielding()
        {
            int oneroll;
            Die die = new Die(10);
            oneroll = die.Roll();
            int fielding = 0;
            if (oneroll <= 5)
            {
                fielding = 2;
                fielding2Total++;
            }
            if (oneroll > 5 && oneroll <= 8)
            {
                fielding = 1;
                fielding1Total++;
            }
            if (oneroll > 8)
            {
                fielding = 3;
                fielding3Total++;
            }
            return fielding;
        }

        private void getMultipleResult()
        {
            this.richTextBoxResult.Text = "";

            loadCard();

            int balls = Convert.ToInt32(this.textBoxBalls.Text);
            int strikes = Convert.ToInt32(this.textBoxStrikes.Text);
            int outs = Convert.ToInt32(this.textBoxOuts.Text);
            int result;
            char grade;

            bool secondcolumn = false;
            List<string> pitcherControl = new List<string>();
            clearStats();

            int roll;
            for (int x = 0; x < Convert.ToInt32(this.textBoxPlateAppearances.Text); x++)
            {
                if (checkBoxRandomizePitchingControl.Checked)
                {
                    pitcherControl = getRandomPitchingControl();
                }
                else
                {
                    foreach (object itemChecked in checkedListBoxControl.CheckedItems)
                    {
                        pitcherControl.Add(itemChecked.ToString());
                    }
                }

                int fielding = 2;
                if (checkBoxRandomizeFielding.Checked)
                {
                    fielding = getRandomFielding();
                }
                else
                {
                    fielding = Convert.ToInt32(this.comboBoxFielding.SelectedItem.ToString());
                }

                if (checkBoxRandomizePitchingGrade.Checked)
                    grade = GetRandomPitchingGrade();
                else
                    grade = Convert.ToChar(this.comboBoxPitchingGrade.SelectedItem.ToString());

                secondcolumn = false;
                roll = dice.GetRoll();

                result = homeTeam.players[0].GetResult(roll, 1); // first column

                if (result == 0)
                {
                    roll = dice.GetRoll();
                    result = homeTeam.players[0].GetResult(roll, 2); // second column
                    secondcolumn = true;
                }
                Player hitter = homeTeam.players[0];

                string baseSituation = "";
                if (checkBoxRandomizeBaseSituation.Checked)
                {
                    getRandomBaseSituationAndOuts(out outs, out baseSituation);
                }
                else
                {
                    baseSituation = this.comboBoxBaseSituation.SelectedItem.ToString();
                }

                switch (outs)
                {
                    case 0:
                        Outs0Total++;
                        break;
                    case 1:
                        Outs1Total++;
                        break;
                    case 2:
                        Outs2Total++;
                        break;
                }

                switch (baseSituation)
                {
                    case "Bases Empty":
                        resultsdescription = basesEmpty.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, secondcolumn, strikes, balls);
                        basesEmptyTotal++;
                        break;
                    case "Runner on first base":
                        resultsdescription = runnerOnFirst.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                        runnerOnFirstTotal++;
                        break;
                    case "Runner on second base":
                        runnerOnSecondTotal++;
                        resultsdescription = runnerOnSecond.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                        break;
                    case "Runner on third base":
                        resultsdescription = runnerOnThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnThirdTotal++;
                        break;
                    case "Runners on 1st and 2nd":
                        resultsdescription = runnerOnFirstAndSecond.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, strikes, balls, secondcolumn);
                        runnerOnFirstAndSecondTotal++;
                        break;
                    case "Runners on 1st and 3rd":
                        resultsdescription = runnerOnFirstAndThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnFirstAndThirdTotal++;
                        break;
                    case "Runners on 2nd and 3rd":
                        resultsdescription = runnerOnSecondAndThird.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnSecondAndThirdTotal++;
                        break;
                    case "Bases Full":
                        resultsdescription = basesFull.GetResult(result, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        basesFullTotal++;
                        break;
                    //Runners on 1st and 3rd
                    default:
                        throw new System.Exception("Error, invalid base situation->" + this.comboBoxBaseSituation.SelectedItem.ToString());
                }
                if (resultsdescription == "Ball")
                {
                    balls++;
                }
                if (resultsdescription == "2 Balls")
                {
                    balls += 2;
                }
                if (resultsdescription != "Ball" && resultsdescription != "2 Balls")
                {
                    balls = 0;
                }
                pitcherControl.Clear();
            }

        }

        private char getRandomRunnerSpeed()
        {
            char returnValue = 'N';
            Die die = new Die(1000);
            int roll = die.Roll();
            if (roll <= 220)
            {
                returnValue = 'S';
            }
            if (roll > 220 && roll <= 220 + 167)
            {
                returnValue = 'F';
            }
            return returnValue;
        }

        private void loadCard()
        {
            Dictionary<int, int> firstColumn = new Dictionary<int, int>();
            firstColumn.Add(11, Convert.ToInt32(this.textBox11_1.Text));
            firstColumn.Add(12, Convert.ToInt32(this.textBox12_1.Text));
            firstColumn.Add(13, Convert.ToInt32(this.textBox13_1.Text));
            firstColumn.Add(14, Convert.ToInt32(this.textBox14_1.Text));
            firstColumn.Add(15, Convert.ToInt32(this.textBox15_1.Text));
            firstColumn.Add(16, Convert.ToInt32(this.textBox16_1.Text));
            firstColumn.Add(21, Convert.ToInt32(this.textBox21_1.Text));
            firstColumn.Add(22, Convert.ToInt32(this.textBox22_1.Text));
            firstColumn.Add(23, Convert.ToInt32(this.textBox23_1.Text));
            firstColumn.Add(24, Convert.ToInt32(this.textBox24_1.Text));
            firstColumn.Add(25, Convert.ToInt32(this.textBox25_1.Text));
            firstColumn.Add(26, Convert.ToInt32(this.textBox26_1.Text));
            firstColumn.Add(31, Convert.ToInt32(this.textBox31_1.Text));
            firstColumn.Add(32, Convert.ToInt32(this.textBox32_1.Text));
            firstColumn.Add(33, Convert.ToInt32(this.textBox33_1.Text));
            firstColumn.Add(34, Convert.ToInt32(this.textBox34_1.Text));
            firstColumn.Add(35, Convert.ToInt32(this.textBox35_1.Text));
            firstColumn.Add(36, Convert.ToInt32(this.textBox36_1.Text));
            firstColumn.Add(41, Convert.ToInt32(this.textBox41_1.Text));
            firstColumn.Add(42, Convert.ToInt32(this.textBox42_1.Text));
            firstColumn.Add(43, Convert.ToInt32(this.textBox43_1.Text));
            firstColumn.Add(44, Convert.ToInt32(this.textBox44_1.Text));
            firstColumn.Add(45, Convert.ToInt32(this.textBox45_1.Text));
            firstColumn.Add(46, Convert.ToInt32(this.textBox46_1.Text));
            firstColumn.Add(51, Convert.ToInt32(this.textBox51_1.Text));
            firstColumn.Add(52, Convert.ToInt32(this.textBox52_1.Text));
            firstColumn.Add(53, Convert.ToInt32(this.textBox53_1.Text));
            firstColumn.Add(54, Convert.ToInt32(this.textBox54_1.Text));
            firstColumn.Add(55, Convert.ToInt32(this.textBox55_1.Text));
            firstColumn.Add(56, Convert.ToInt32(this.textBox56_1.Text));
            firstColumn.Add(61, Convert.ToInt32(this.textBox61_1.Text));
            firstColumn.Add(62, Convert.ToInt32(this.textBox62_1.Text));
            firstColumn.Add(63, Convert.ToInt32(this.textBox63_1.Text));
            firstColumn.Add(64, Convert.ToInt32(this.textBox64_1.Text));
            firstColumn.Add(65, Convert.ToInt32(this.textBox65_1.Text));
            firstColumn.Add(66, Convert.ToInt32(this.textBox66_1.Text));

            Dictionary<int, int> secondColumn = new Dictionary<int, int>();

            secondColumn.Add(11, Convert.ToInt32(this.textBox11_2.Text));
            secondColumn.Add(12, Convert.ToInt32(this.textBox12_2.Text));
            secondColumn.Add(13, Convert.ToInt32(this.textBox13_2.Text));
            secondColumn.Add(14, Convert.ToInt32(this.textBox14_2.Text));
            secondColumn.Add(15, Convert.ToInt32(this.textBox15_2.Text));
            secondColumn.Add(16, Convert.ToInt32(this.textBox16_2.Text));
            secondColumn.Add(21, Convert.ToInt32(this.textBox21_2.Text));
            secondColumn.Add(22, Convert.ToInt32(this.textBox22_2.Text));
            secondColumn.Add(23, Convert.ToInt32(this.textBox23_2.Text));
            secondColumn.Add(24, Convert.ToInt32(this.textBox24_2.Text));
            secondColumn.Add(25, Convert.ToInt32(this.textBox25_2.Text));
            secondColumn.Add(26, Convert.ToInt32(this.textBox26_2.Text));
            secondColumn.Add(31, Convert.ToInt32(this.textBox31_2.Text));
            secondColumn.Add(32, Convert.ToInt32(this.textBox32_2.Text));
            secondColumn.Add(33, Convert.ToInt32(this.textBox33_2.Text));
            secondColumn.Add(34, Convert.ToInt32(this.textBox34_2.Text));
            secondColumn.Add(35, Convert.ToInt32(this.textBox35_2.Text));
            secondColumn.Add(36, Convert.ToInt32(this.textBox36_2.Text));
            secondColumn.Add(41, Convert.ToInt32(this.textBox41_2.Text));
            secondColumn.Add(42, Convert.ToInt32(this.textBox42_2.Text));
            secondColumn.Add(43, Convert.ToInt32(this.textBox43_2.Text));
            secondColumn.Add(44, Convert.ToInt32(this.textBox44_2.Text));
            secondColumn.Add(45, Convert.ToInt32(this.textBox45_2.Text));
            secondColumn.Add(46, Convert.ToInt32(this.textBox46_2.Text));
            secondColumn.Add(51, Convert.ToInt32(this.textBox51_2.Text));
            secondColumn.Add(52, Convert.ToInt32(this.textBox52_2.Text));
            secondColumn.Add(53, Convert.ToInt32(this.textBox53_2.Text));
            secondColumn.Add(54, Convert.ToInt32(this.textBox54_2.Text));
            secondColumn.Add(55, Convert.ToInt32(this.textBox55_2.Text));
            secondColumn.Add(56, Convert.ToInt32(this.textBox56_2.Text));
            secondColumn.Add(61, Convert.ToInt32(this.textBox61_2.Text));
            secondColumn.Add(62, Convert.ToInt32(this.textBox62_2.Text));
            secondColumn.Add(63, Convert.ToInt32(this.textBox63_2.Text));
            secondColumn.Add(64, Convert.ToInt32(this.textBox64_2.Text));
            secondColumn.Add(65, Convert.ToInt32(this.textBox65_2.Text));
            secondColumn.Add(66, Convert.ToInt32(this.textBox66_2.Text));

            Player player1 = new Player("Brett", firstColumn, secondColumn, getRandomRunnerSpeed());
            homeTeam.AddPlayer(player1);
            homeTeam.players[0].firstColumn = firstColumn;
            homeTeam.players[0].secondColumn = secondColumn;
        }

        private void clearStats()
        {
            homeTeam.players[0].statsOffensive.AtBats = 0;
            homeTeam.players[0].statsOffensive.Singles = 0;
            homeTeam.players[0].statsOffensive.Doubles = 0;
            homeTeam.players[0].statsOffensive.Triples = 0;
            homeTeam.players[0].statsOffensive.Homeruns = 0;
            homeTeam.players[0].statsOffensive.Walks = 0;
            homeTeam.players[0].statsOffensive.Strikeouts = 0;
            homeTeam.players[0].statsOffensive.GIDP = 0;
            homeTeam.players[0].statsOffensive.HPB = 0;
            homeTeam.players[0].statsOffensive.IBB = 0;
            homeTeam.players[0].statsOffensive.SF = 0;
            homeTeam.players[0].statsOffensive.SH = 0;
            homeTeam.players[0].statsOffensive.SB = 0;
            homeTeam.players[0].statsOffensive.Runs = 0;
            homeTeam.players[0].statsOffensive.RBI = 0;

            basesEmptyTotal = 0;
            runnerOnFirstTotal = 0;
            runnerOnSecondTotal = 0;
            runnerOnThirdTotal = 0;
            runnerOnFirstAndSecondTotal = 0;
            runnerOnFirstAndThirdTotal = 0;
            runnerOnSecondAndThirdTotal = 0;
            basesFullTotal = 0;

            ATotal = 0;
            BTotal = 0;
            CTotal = 0;
            DTotal = 0;
            Outs0Total = 0;
            Outs1Total = 0;
            Outs2Total = 0;
            fielding1Total = 0;
            fielding2Total = 0;
            fielding3Total = 0;
            controlW = 0;
            controlX = 0;
            controlY = 0;
            controlZ = 0;
        }

        private void getAllCardNumberResults()
        {
            loadCard();
            clearStats();
            this.richTextBoxResult.Text = "";

            loadCard();

            int balls = Convert.ToInt32(this.textBoxBalls.Text);
            int strikes = Convert.ToInt32(this.textBoxStrikes.Text);
            int outs = Convert.ToInt32(this.textBoxOuts.Text);
            int result;
            char grade;

            bool secondcolumn = false;
            List<string> pitcherControl = new List<string>();
            throw new NotImplementedException("Not implemented yet!!!");

        }

        private void getAllBoardNumberResults()
        {
            this.richTextBoxResult.Text = "";

            loadCard();
            Player hitter = homeTeam.players[0];
            int balls = Convert.ToInt32(this.textBoxBalls.Text);
            int strikes = Convert.ToInt32(this.textBoxStrikes.Text);
            int outs = Convert.ToInt32(this.textBoxOuts.Text);
            char grade;

            bool secondcolumn = false;
            List<string> pitcherControl = new List<string>();
            clearStats();

            for (int boardNumber = 1; boardNumber <= 42; boardNumber++)
            {
                if (checkBoxRandomizePitchingControl.Checked)
                {
                    pitcherControl = getRandomPitchingControl();
                }
                else
                {
                    foreach (object itemChecked in checkedListBoxControl.CheckedItems)
                    {
                        pitcherControl.Add(itemChecked.ToString());
                    }
                }

                int fielding = 2;
                if (checkBoxRandomizeFielding.Checked)
                {
                    fielding = getRandomFielding();
                }
                else
                {
                    fielding = Convert.ToInt32(this.comboBoxFielding.SelectedItem.ToString());
                }

                if (checkBoxRandomizePitchingGrade.Checked)
                    grade = GetRandomPitchingGrade();
                else
                    grade = Convert.ToChar(this.comboBoxPitchingGrade.SelectedItem.ToString());


                string baseSituation = "";
                if (checkBoxRandomizeBaseSituation.Checked)
                {
                    getRandomBaseSituationAndOuts(out outs, out baseSituation);
                }
                else
                {
                    baseSituation = this.comboBoxBaseSituation.SelectedItem.ToString();
                }

                switch (outs)
                {
                    case 0:
                        Outs0Total++;
                        break;
                    case 1:
                        Outs1Total++;
                        break;
                    case 2:
                        Outs2Total++;
                        break;
                }

                switch (baseSituation)
                {
                    case "Bases Empty":
                        resultsdescription = basesEmpty.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, secondcolumn, strikes, balls);
                        basesEmptyTotal++;
                        break;
                    case "Runner on first base":
                        resultsdescription = runnerOnFirst.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                        runnerOnFirstTotal++;
                        break;
                    case "Runner on second base":
                        runnerOnSecondTotal++;
                        resultsdescription = runnerOnSecond.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), secondcolumn, strikes, balls);
                        break;
                    case "Runner on third base":
                        resultsdescription = runnerOnThird.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnThirdTotal++;
                        break;
                    case "Runners on 1st and 2nd":
                        resultsdescription = runnerOnFirstAndSecond.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, strikes, balls, secondcolumn);
                        runnerOnFirstAndSecondTotal++;
                        break;
                    case "Runners on 1st and 3rd":
                        resultsdescription = runnerOnFirstAndThird.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnFirstAndThirdTotal++;
                        break;
                    case "Runners on 2nd and 3rd":
                        resultsdescription = runnerOnSecondAndThird.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        runnerOnSecondAndThirdTotal++;
                        break;
                    case "Bases Full":
                        resultsdescription = basesFull.GetResult(boardNumber, grade, fielding, ref hitter, outs, pitcherControl, getRandomRunnerSpeed(), getRandomRunnerSpeed(), getRandomRunnerSpeed(), strikes, balls, secondcolumn);
                        basesFullTotal++;
                        break;
                    //Runners on 1st and 3rd
                    default:
                        throw new System.Exception("Error, invalid base situation->" + this.comboBoxBaseSituation.SelectedItem.ToString());
                }
                if (resultsdescription == "Ball")
                {
                    balls++;
                }
                if (resultsdescription == "2 Balls")
                {
                    balls += 2;
                }
                if (resultsdescription != "Ball" && resultsdescription != "2 Balls")
                {
                    balls = 0;
                }
                pitcherControl.Clear();
            }
        }

        private void buttonGetResult_Click(object sender, EventArgs e)
        {
            try
            {
                decimal normizedRatio = 1;
                if (checkBoxUsePlateAppearances.Checked)
                {
                    getMultipleResult();

                    this.richTextBoxResult.Text = "Base situations used:\nEmpty: " + basesEmptyTotal.ToString() + " 1st: " + runnerOnFirstTotal.ToString() + " 2nd: " + runnerOnSecondTotal.ToString() + " 3rd: " + runnerOnThirdTotal.ToString() +
                    " 1st & 2nd: " + runnerOnFirstAndSecondTotal.ToString() +
                    " 1st & 3rd: " + runnerOnFirstAndThirdTotal.ToString() +
                    " 2nd & 3rd: " + runnerOnSecondAndThirdTotal.ToString() +
                    " Bases Full: " + basesFullTotal.ToString() +
                    "\n\n" +
                    "Pitching grades used:\nA: " + ATotal.ToString() + " B: " + BTotal.ToString() + " C: " + CTotal.ToString() + " D: " + DTotal.ToString() + "\n" +
                    "\nOuts used:\nOuts0: " + Outs0Total.ToString() + " Outs1: " + Outs1Total.ToString() + " Outs2: " + Outs2Total.ToString() + "\n" +
                    "\nFielding used:\nFielding1: " + fielding1Total.ToString() + " Fielding2: " + fielding2Total.ToString() + " Fielding3: " + fielding3Total.ToString() + "\n" +
                    "\nControl used:\nControlZ: " + controlZ.ToString() + " ControlY: " + controlY.ToString() + " ControlW: " + controlW.ToString() + " ControlX: " + controlX.ToString();
                }
                if (checkBoxUseAllCardNumbersOnce.Checked)
                {
                    getAllCardNumberResults();
                }
                if (!checkBoxUseAllCardNumbersOnce.Checked && !checkBoxUsePlateAppearances.Checked)
                {
                    getSingleResult();
                }
                if (checkBoxAllBoardNumbers.Checked)
                {
                    getAllBoardNumberResults();
                }

                this.labelAVG.Text = Convert.ToString(homeTeam.players[0].GetAverage());
                this.labelOBP.Text = Convert.ToString(homeTeam.players[0].GetOBP());
                this.labelSLGPCTStat.Text = Convert.ToString(homeTeam.players[0].GetSLG());
                normizedRatio = Convert.ToDecimal(this.textBoxNormalizedPA.Text) / Convert.ToDecimal(this.textBoxPlateAppearances.Text);

                this.labelAB.Text = homeTeam.players[0].statsOffensive.AtBats.ToString();
                this.labelHits.Text = homeTeam.players[0].statsOffensive.Hits.ToString();
                this.labelRuns.Text = homeTeam.players[0].statsOffensive.Runs.ToString();
                this.labelDoubles.Text = homeTeam.players[0].statsOffensive.Doubles.ToString();
                this.labelTriples.Text = homeTeam.players[0].statsOffensive.Triples.ToString();
                this.labelHomeruns.Text = homeTeam.players[0].statsOffensive.Homeruns.ToString();
                this.labelWalks.Text = homeTeam.players[0].statsOffensive.Walks.ToString();
                this.labelStrikeouts.Text = homeTeam.players[0].statsOffensive.Strikeouts.ToString();
                this.labelSBs.Text = homeTeam.players[0].statsOffensive.SB.ToString();
                this.labelRBI.Text = homeTeam.players[0].statsOffensive.RBI.ToString();

                this.labelNormalized_AB.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.AtBats * normizedRatio));
                this.labelNormalized_Hits.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Hits * normizedRatio));
                this.labelNormalized_Runs.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Runs * normizedRatio));
                this.labelNormalized_Doubles.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Doubles * normizedRatio));
                this.labelNormalized_Triples.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Triples * normizedRatio));
                this.labelNormalized_Homeruns.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Homeruns * normizedRatio));
                this.labelNormalized_Walks.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Walks * normizedRatio));
                this.labelNormalized_Strikeouts.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.Strikeouts * normizedRatio));
                this.labelNormalized_SBs.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.SB * normizedRatio));
                this.labelNormalized_RBI.Text = Convert.ToString(Math.Round(homeTeam.players[0].statsOffensive.RBI * normizedRatio));
            }
            catch (Exception _e)
            {
                MessageBox.Show("Error in buttonGetResult_Click: " + _e.Message);
            }
        }



        private void checkBoxRandomizeFielding_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRandomizeFielding.Checked)
                comboBoxFielding.Enabled = false;
            else
                comboBoxFielding.Enabled = true;
        }

        private void checkBoxRandomizePitchingGrade_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRandomizePitchingGrade.Checked)
            {
                comboBoxPitchingGrade.Enabled = false;
                textBoxA_PCT.Enabled = true;
                textBoxB_PCT.Enabled = true;
                textBoxC_PCT.Enabled = true;
                textBoxD_PCT.Enabled = true;
            }
            else
            {
                comboBoxPitchingGrade.Enabled = true;
                textBoxA_PCT.Enabled = false;
                textBoxB_PCT.Enabled = false;
                textBoxC_PCT.Enabled = false;
                textBoxD_PCT.Enabled = false;
            }
        }

        private void checkBoxRandomizePitchingControl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRandomizePitchingControl.Checked)
                checkedListBoxControl.Enabled = false;
            else
                checkedListBoxControl.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is how many PA's you want to use to show in normalized stats column, i.e. AVG season is around 700. If you choose the PA that actual card has you should get realistic extra base numbers for the card");
        }

        private void checkBoxUsePlateAppearances_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxUsePlateAppearances.Checked)
            {
                comboBoxResult.Enabled = false;
                textBoxPlateAppearances.Enabled = true;
                textBoxNormalizedPA.Enabled = true;

                checkBoxUseAllCardNumbersOnce.Enabled = false;
                checkBoxAllBoardNumbers.Enabled = false;
            }
            else
            {
                comboBoxResult.Enabled = true;
                textBoxPlateAppearances.Enabled = false;
                textBoxNormalizedPA.Enabled = false;

                checkBoxAllBoardNumbers.Enabled = true;
                checkBoxUseAllCardNumbersOnce.Enabled = true;
            }
        }

        private char GetRandomPitchingGrade()
        {
            if (Convert.ToDecimal(textBoxA_PCT.Text) + Convert.ToDecimal(textBoxB_PCT.Text) + Convert.ToDecimal(textBoxC_PCT.Text) + Convert.ToDecimal(textBoxD_PCT.Text) != 100)
            {
                throw (new System.Exception("For random pitching grades the text boxes A,B,C & D must at up to 100. Current value: " + Convert.ToString(Convert.ToDecimal(textBoxA_PCT.Text) + Convert.ToDecimal(textBoxB_PCT.Text) + Convert.ToDecimal(textBoxC_PCT.Text) + Convert.ToDecimal(textBoxD_PCT.Text)) ));
            }

            Die die = new Die(10000);
            int oneroll = die.Roll();

            decimal A = Math.Round(Convert.ToDecimal(textBoxA_PCT.Text) * 100);
            decimal B = Math.Round(Convert.ToDecimal(textBoxB_PCT.Text) * 100);
            decimal C = Math.Round(Convert.ToDecimal(textBoxC_PCT.Text) * 100);
            decimal D = Math.Round(Convert.ToDecimal(textBoxD_PCT.Text) * 100);

            char returnGrade = 'A';
            if (oneroll > 0 && oneroll <= A)
            {
                returnGrade = 'A';
            }
            if (oneroll > A && oneroll <= A+B)
            {
                returnGrade = 'B';
            }
            if (oneroll > A+B && oneroll <= A+B+C)
            {
                returnGrade = 'C';
            }
            if (oneroll > A + B + C)
            {
                returnGrade = 'D';
            }

            switch (returnGrade)
            {
                case 'A':
                    ATotal++;
                    break;
                case 'B':
                    BTotal++;
                    break;
                case 'C':
                    CTotal++;
                    break;
                case 'D':
                    DTotal++;
                    break;
            }

            return returnGrade;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("APBA Hitting Card analyzer beta 1 (bstark369@gmail.com)\n\nSo what the heck does this do? It attempts to simulate APBA baseball card performance with the basic boards (2009 version).\n\nKnown issues:\nInfield currently always plays deep\nAll base runners are normal speed\n\nPlease email me if you notice any strange results or have additional ideas or requests. Brad Stark. 66's");
        }

        private void checkBoxUseAllCardNumbersOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxUseAllCardNumbersOnce.Checked)
            {
                comboBoxResult.Enabled = false;
                checkBoxUsePlateAppearances.Enabled = false;
                checkBoxAllBoardNumbers.Enabled = false;
            }
            else
            {
                comboBoxResult.Enabled = true;
                checkBoxUsePlateAppearances.Enabled = true;
                checkBoxAllBoardNumbers.Enabled = true;
            }
        }

        private void checkBoxAllBoardNumbers_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAllBoardNumbers.Checked)
            {
                comboBoxResult.Enabled = false;
                checkBoxUsePlateAppearances.Enabled = false;
                checkBoxUseAllCardNumbersOnce.Enabled = false; 
            }
            else
            {
                comboBoxResult.Enabled = true;
                checkBoxUsePlateAppearances.Enabled = true;
                checkBoxUseAllCardNumbersOnce.Enabled = true; 
            }
        }

        private void checkBoxRandomizeSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRandomizeSpeed.Checked)
            {
                comboBoxRunnerSpeed.Enabled = false;
                textBoxSpeedSlowPct.Enabled = true;
                textBoxSpeedFastPct.Enabled = true;
            }
            else
            {
                comboBoxRunnerSpeed.Enabled = true;
                textBoxSpeedSlowPct.Enabled = false;
                textBoxSpeedFastPct.Enabled = false;
            }
        }

        private void cardTextboxEntered(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
        }

        private void checkBoxSimulateInnings_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSimulateInnings.Checked)
            {
               // comboBoxBaseSituation.Enabled = false;
                textBoxOuts.Enabled = false;
                this.checkBoxRandomizeBaseSituation.Checked = false;
                this.comboBoxBaseSituation.Enabled = false;
            }
            else
            {
                comboBoxBaseSituation.Enabled = true;
                textBoxOuts.Enabled = true;
            }
        }

        private void checkBoxRandomizeBaseSituation_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRandomizeBaseSituation.Checked)
            {
                //comboBoxBaseSituation.Enabled = false;
                textBoxOuts.Enabled = false;
                comboBoxBaseSituation.Enabled = false;
                checkBoxSimulateInnings.Checked = false;
            }
            else
            {
                comboBoxBaseSituation.Enabled = true;
                textBoxOuts.Enabled = true;
            }
        }

    }
}
