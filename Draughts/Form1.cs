using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Draughts
{
    public partial class Form1 : Form , IDisposable
    {
        private DatabaseContext db = new DatabaseContext();
        public bool GameStarted = false;
        CheckerBoardArray currentGame = new CheckerBoardArray();

        public Form1()
        {
            InitializeComponent();
            //AddInitalSetupTemp();

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            GameStarted = true;

            currentGame = SetupInital(currentGame);
          
            if (rdbtnAllAI.Checked == true)
            {
                Random random = new Random();
                AI ai = new AI();
                int callingplayer = 1;
                List<CheckerBoardArray> possiblemoves = new List<CheckerBoardArray>();

                while (true)
                {

                    possiblemoves = ai.GetPossibleMoves(currentGame, callingplayer);
                    if (possiblemoves.Count != 0)
                    {
                        int P = random.Next(0, possiblemoves.Count);
                        if (possiblemoves.Count > 0)
                        {
                            currentGame = possiblemoves[P];
                            if (callingplayer == 1)
                                callingplayer = -1;
                            else
                                callingplayer = 1;

                            LinkToGUI(currentGame);

                                this.Update();
                        }
                        }
                    else
                    {
                        currentGame = SetupInital(currentGame);
                        GC.Collect();
                        GC.WaitForFullGCComplete(-1);
                       }

                } 
                


            }
            else if (rdbtn2player.Checked == true)
            {
                LinkToGUI(currentGame);

            }
            else
            {

            }
        }
        
        public CheckerBoardArray SetupInital(CheckerBoardArray currentGame)
        {
            GameInfo initalSetup = (from S in db.gameInfo where S.gameInfoId == 1 select S).FirstOrDefault();
            currentGame = currentGame.serialization(initalSetup);
            var maxValue = db.gameInfo.Max(x => x.gameNumber);
            currentGame.turn = 0;
            currentGame.gameID = maxValue + 1;

            return currentGame;
        }


        public void AddInitalSetupTemp()
        {
            GameInfo currentGame = new GameInfo();
            currentGame.turn = 0;
            currentGame.square1 = 1;
            currentGame.square3 = 1;
            currentGame.square5 = 1;
            currentGame.square7 = 1;
            currentGame.square10 = 1;
            currentGame.square12 = 1;
            currentGame.square14 = 1;
            currentGame.square16 = 1;
            currentGame.square17 = 1;
            currentGame.square19 = 1;
            currentGame.square21 = 1;
            currentGame.square23 = 1;
            currentGame.square42 = -1;
            currentGame.square44 = -1;
            currentGame.square46 = -1;
            currentGame.square48 = -1;
            currentGame.square49 = -1;
            currentGame.square51 = -1;
            currentGame.square53 = -1;
            currentGame.square55 = -1;
            currentGame.square58 = -1;
            currentGame.square60 = -1;
            currentGame.square62 = -1;
            currentGame.square64 = -1;


            var database = db.Set<GameInfo>();
            database.Add(currentGame);

            db.SaveChanges();

        }

        public void HumanMoveInfo(int clickedRow, int clickedCol)
        {
            if (GameStarted == true)
            {
                int FirstClickedRow = 0;
                int FirstClickedCol = 0;

                string eval = clickedRow.ToString() + clickedCol.ToString();

                bool trigger = false;
                for (int i = 0; i < 8; i++)
                {
                    for (int ii = 0; ii < 8; ii++)
                    {
                        string III = i.ToString() + ii.ToString();
                        if (currentGame.SelectedStatus[i][ii] && III != eval)
                        {
                            trigger = true;
                            FirstClickedRow = i;
                            FirstClickedCol = ii;
                        }
                    }
                }

                if (trigger)
                {
                    trigger = false;
                    HumanMoveEval(FirstClickedRow, FirstClickedCol, clickedRow, clickedCol);
                }
                else
                {
                    HumanMoveHighlight(clickedRow, clickedCol);
                }

            }
        }

        public void HumanMoveHighlight(int firstRow, int firstCol)
        {
            List<List<int>> Spots = new List<List<int>>();



            if (currentGame.CheckerBoard[firstRow][firstCol] > 0)
            {
                //diagonal right unpromoted or king
                if (firstRow <= 6 && firstCol <= 6 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol + 1);
                    Spots.Add(Spot);
                }
                //diagonal left Unpromoted or promoted
                if (firstRow <= 6 && firstCol >= 1 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal right back  king
                if (firstRow >= 1 && firstCol <= 6 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal left back king 
                if (firstRow >= 1 && firstCol >= 1 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal Jump right Unpromoted or promoted
                if (firstRow <= 5 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal jump left Unpromoted or promoted
                if (firstRow <= 5 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);

                }

                //diagonal Jump right king back
                if (firstRow >= 2 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal jump left king back                                                       
                if (firstRow >= 2 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right Unpromoted or promoted
                if (firstRow <= 3 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol + 4] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left Unpromoted or promoted
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol - 4] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right then middle Unpromoted or promoted
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left then middle Unpromoted or promoted
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right back king
                if (firstRow >= 4 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow - 4][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left back king
                if (firstRow >= 4 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow - 4][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal double Jump right then middle back king
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left then middle back king
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right front sideways King
                if (firstRow <= 5 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left right sideways king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {

                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);

                }

                //diagonal double Jump right back sideways King
                if (firstRow >= 2 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {

                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);

                }

                //diagonal double Jump left back sideways king
                if (firstRow >= 2 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {

                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);

                }
            }
            else if (currentGame.CheckerBoard[firstRow][firstCol] < 0)
            {

                //diagonal blue right unpromoted or king
                if (firstRow >= 1 && firstCol <= 6 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow - 1);
                    Spot.Add(firstCol + 1);
                    Spots.Add(Spot);
                }
                //diagonal blue left Unpromoted or promoted
                if (firstRow >= 1 && firstCol >= 1 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal blue right back  king
                if (firstRow <= 6 && firstCol <= 6 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal blue left back king 
                if (firstRow <= 6 && firstCol >= 1 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal blue Jump right Unpromoted or promoted
                if (firstRow >= 2 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal jump left Unpromoted or promoted
                if (firstRow >= 2 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal Jump right king back
                if (firstRow <= 5 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal jump left king back                                                       
                if (firstRow <= 5 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right Unpromoted or promoted
                if (firstRow >= 4 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol + 4] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left Unpromoted or promoted
                if (firstRow >= 4 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol - 4] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right then middle Unpromoted or promoted
                if (firstRow >= 4 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left then middle Unpromoted or promoted
                if (firstRow >= 4 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol] == 0)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }


                //diagonal double Jump right back king
                if (firstRow <= 3 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left back king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
                //diagonal double Jump right then middle back king
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left then middle back king
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right front sideways King
                if (firstRow <= 5 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left right sideways king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump right back sideways King
                if (firstRow >= 2 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }

                //diagonal double Jump left back sideways king
                if (firstRow >= 2 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2)
                {
                    List<int> Spot = new List<int>();
                    Spot.Add(firstRow + 1);
                    Spot.Add(firstCol - 1);
                    Spots.Add(Spot);
                }
            }

           
        }


        public void HumanMoveEval(int firstRow, int firstCol, int secondRow, int secondCol)
        {
            CheckerBoardArray PossibleMove = currentGame.ShallowCopy();

            if (currentGame.CheckerBoard[firstRow][firstCol] > 0)
            {
                //diagonal right unpromoted or king
                if (firstRow <= 6 && firstCol <= 6 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] == 0 && firstRow + 1 == secondRow && firstCol + 1 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal left Unpromoted or promoted
                if (firstRow <= 6 && firstCol >= 1 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] == 0 && firstRow + 1 == secondRow && firstCol - 1 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal right back  king
                if (firstRow >= 1 && firstCol <= 6 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 1 == secondRow && firstCol + 1 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal left back king 
                if (firstRow >= 1 && firstCol >= 1 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 1 == secondRow && firstCol - 1 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal Jump right Unpromoted or promoted
                if (firstRow <= 5 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && firstRow + 2 == secondRow && firstCol + 2 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal jump left Unpromoted or promoted
                if (firstRow <= 5 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && firstRow + 2 == secondRow && firstCol - 2 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal Jump right king back
                if (firstRow >= 2 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 2 == secondRow && firstCol + 2 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal jump left king back                                                       
                if (firstRow >= 2 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 2 == secondRow && firstCol - 2 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump right Unpromoted or promoted
                if (firstRow <= 3 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol + 4] == 0 && firstRow + 4 == secondRow && firstCol + 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left Unpromoted or promoted
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol - 4] == 0 && firstRow + 4 == secondRow && firstCol - 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump right then middle Unpromoted or promoted
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && firstRow + 4 == secondRow && firstCol == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left then middle Unpromoted or promoted
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && firstRow + 4 == secondRow && firstCol == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump right back king
                if (firstRow >= 4 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow - 4][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 4 == secondRow && firstCol + 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 3][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow - 4][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left back king
                if (firstRow >= 4 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow - 4][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow - 1 == secondRow && firstCol - 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }
                //diagonal double Jump right then middle back king
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left then middle back king
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow + 4 == secondRow && firstCol == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump right front sideways King
                if (firstRow <= 5 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow == secondRow && firstCol + 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left right sideways king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow == secondRow && firstCol - 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump right back sideways King
                if (firstRow >= 2 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol + 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow == secondRow && firstCol + 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }

                //diagonal double Jump left back sideways king
                if (firstRow >= 2 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] < 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol - 3] < 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == 2 && firstRow == secondRow && firstCol - 4 == secondCol)
                {

                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;

                }
            }
            else if (currentGame.CheckerBoard[firstRow][firstCol] < 0)
            {

                //diagonal blue right unpromoted or king
                if (firstRow >=1 && firstCol <= 6 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] == 0 && firstRow - 1 == secondRow && firstCol + 1 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal blue left Unpromoted or promoted
                if (firstRow >= 1 && firstCol >= 1 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] == 0 && firstRow - 1 == secondRow && firstCol - 1 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal blue right back  king
                if (firstRow <= 6 && firstCol <= 6 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 1 == secondRow && firstCol + 1 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal blue left back king 
                if (firstRow <= 6 && firstCol >= 1 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 1 == secondRow && firstCol - 1 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal blue Jump right Unpromoted or promoted
                if (firstRow >= 2 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && firstRow - 2 == secondRow && firstCol + 2 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal jump left Unpromoted or promoted
                if (firstRow >= 2 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && firstRow - 2 == secondRow && firstCol - 2 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal Jump right king back
                if (firstRow <= 5 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 2 == secondRow && firstCol + 2 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal jump left king back                                                       
                if (firstRow <= 5 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 2 == secondRow && firstCol - 2 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump right Unpromoted or promoted
                if (firstRow >= 4 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol + 4] == 0 && firstRow - 4 == secondRow && firstCol + 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 3][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow - 4][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left Unpromoted or promoted
                if (firstRow >= 4 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol - 4] == 0 && firstRow - 4 == secondRow && firstCol - 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 3][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow - 4][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump right then middle Unpromoted or promoted
                if (firstRow >= 4 && firstCol <= 5 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol] == 0 && firstRow - 4 == secondRow && firstCol == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 3][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left then middle Unpromoted or promoted
                if (firstRow >= 4 && firstCol >= 2 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 3][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 4][firstCol] == 0 && firstRow - 4 == secondRow && firstCol == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 3][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }


                //diagonal double Jump right back king
                if (firstRow <= 3 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 4 == secondRow && firstCol + 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left back king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 1 == secondRow && firstCol - 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
                //diagonal double Jump right then middle back king
                if (firstRow <= 3 && firstCol <= 5 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 4 == secondRow && firstCol == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left then middle back king
                if (firstRow <= 3 && firstCol >= 2 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 3][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 4][firstCol] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow + 4 == secondRow && firstCol == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 3][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 4][firstCol] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump right front sideways King
                if (firstRow <= 5 && firstCol <= 3 && currentGame.CheckerBoard[firstRow + 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow == secondRow && firstCol + 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left right sideways king
                if (firstRow <= 3 && firstCol >= 4 && currentGame.CheckerBoard[firstRow + 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow + 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow + 1][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow == secondRow && firstCol - 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow + 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow + 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstRow - 4] = PossibleMove.CheckerBoard[firstRow][firstRow];
                    PossibleMove.CheckerBoard[firstRow][firstRow] = 0;
                }

                //diagonal double Jump right back sideways King
                if (firstRow >= 2 && firstCol <= 3 && currentGame.CheckerBoard[firstRow - 1][firstCol + 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol + 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol + 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol + 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow == secondRow && firstCol + 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol + 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol + 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol + 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }

                //diagonal double Jump left back sideways king
                if (firstRow >= 2 && firstCol >= 4 && currentGame.CheckerBoard[firstRow - 1][firstCol - 1] > 0 && currentGame.CheckerBoard[firstRow - 2][firstCol - 2] == 0 && currentGame.CheckerBoard[firstRow - 1][firstCol - 3] > 0 && currentGame.CheckerBoard[firstRow][firstCol - 4] == 0 && currentGame.CheckerBoard[firstRow][firstCol] == -2 && firstRow == secondRow && firstCol - 4 == secondCol)
                {
                    PossibleMove.turn = currentGame.turn + 1;
                    PossibleMove.gameID = currentGame.gameID;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 1] = 0;
                    PossibleMove.CheckerBoard[firstRow - 2][firstCol - 2] = 0;
                    PossibleMove.CheckerBoard[firstRow - 1][firstCol - 3] = 0;
                    PossibleMove.CheckerBoard[firstRow][firstCol - 4] = PossibleMove.CheckerBoard[firstRow][firstCol];
                    PossibleMove.CheckerBoard[firstRow][firstCol] = 0;
                }
            }
        

            currentGame = PossibleMove.ShallowCopy();
            for (int i = 0; i < 8; i++)
            {
                for(int ii = 0; ii < 8; ii++)
                {
                    currentGame.SelectedStatus[i][ii] = false;
                }
            }
           currentGame = FindKings(currentGame);
            
            LinkToGUI(currentGame);
        }

        public CheckerBoardArray FindKings(CheckerBoardArray possibleMove)
        {

                for (int i = 0; i < 8; i++)
                {
                    if (possibleMove.CheckerBoard[7][i] == 1)
                    {
                        possibleMove.CheckerBoard[7][i] = 2;
                    }
                    else if (possibleMove.CheckerBoard[0][i] == -1)
                    {
                        possibleMove.CheckerBoard[0][i] = -2;
                    }

                }

            return possibleMove;

            }



        public void LinkToGUI(CheckerBoardArray currentGame)
        {
            DisposeOldImages();
              
                switch (currentGame.CheckerBoard[0][0])
            {
                case -2:
                    Square1.BackgroundImage = Properties.Resources.kingblue;
                    break;
                case -1:
                    Square1.BackgroundImage = Properties.Resources.blue;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square1.BackgroundImage = Properties.Resources.white;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square1.BackgroundImage = Properties.Resources.red;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square1.BackgroundImage = Properties.Resources.kingred;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            

            switch (currentGame.CheckerBoard[0][2])
            {
                case -2:
                    Square3.BackgroundImage = Properties.Resources.kingblue;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square3.BackgroundImage = Properties.Resources.blue;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square3.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square3.BackgroundImage = Properties.Resources.red;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square3.BackgroundImage = Properties.Resources.kingred;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            

            switch (currentGame.CheckerBoard[0][4])
            {
                case -2:
                    Square5.BackgroundImage = Properties.Resources.kingblue;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square5.BackgroundImage = Properties.Resources.blue;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square5.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square5.BackgroundImage = Properties.Resources.red;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square5.BackgroundImage = Properties.Resources.kingred;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

           

            switch (currentGame.CheckerBoard[0][6])
            {  
                case -2:
                    Square7.BackgroundImage = Properties.Resources.kingblue;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square7.BackgroundImage = Properties.Resources.blue;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square7.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square7.BackgroundImage = Properties.Resources.red;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square7.BackgroundImage = Properties.Resources.kingred;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

          

            switch (currentGame.CheckerBoard[1][1])
            {
                case -2:
                    Square10.BackgroundImage = Properties.Resources.kingblue;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square10.BackgroundImage = Properties.Resources.blue;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square10.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square10.BackgroundImage = Properties.Resources.red;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square10.BackgroundImage = Properties.Resources.kingred;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

           
            switch (currentGame.CheckerBoard[1][3])
            {
                case -2:
                    Square12.BackgroundImage = Properties.Resources.kingblue;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square12.BackgroundImage = Properties.Resources.blue;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square12.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square12.BackgroundImage = Properties.Resources.red;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square12.BackgroundImage = Properties.Resources.kingred;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[1][5])
            {
                case -2:
                    Square14.BackgroundImage = Properties.Resources.kingblue;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square14.BackgroundImage = Properties.Resources.blue;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square14.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square14.BackgroundImage = Properties.Resources.red;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square14.BackgroundImage = Properties.Resources.kingred;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
           
            switch (currentGame.CheckerBoard[1][7])
            {
                case -2:
                    Square16.BackgroundImage = Properties.Resources.kingblue;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square16.BackgroundImage = Properties.Resources.blue;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square16.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square16.BackgroundImage = Properties.Resources.red;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square16.BackgroundImage = Properties.Resources.kingred;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.CheckerBoard[2][0])
            {
                case -2:
                    Square17.BackgroundImage = Properties.Resources.kingblue;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square17.BackgroundImage = Properties.Resources.blue;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square17.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square17.BackgroundImage = Properties.Resources.red;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square17.BackgroundImage = Properties.Resources.kingred;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;

            }
            
            switch (currentGame.CheckerBoard[2][2])
            {
                case -2:
                    Square19.BackgroundImage = Properties.Resources.kingblue;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square19.BackgroundImage = Properties.Resources.blue;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square19.BackgroundImage =Properties.Resources.white;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square19.BackgroundImage = Properties.Resources.red;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square19.BackgroundImage = Properties.Resources.kingred;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[2][4])
            {
                case -2:
                    Square21.BackgroundImage = Properties.Resources.kingblue;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square21.BackgroundImage = Properties.Resources.blue;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square21.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square21.BackgroundImage = Properties.Resources.red;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square21.BackgroundImage = Properties.Resources.kingred;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
           
            switch (currentGame.CheckerBoard[2][6])
            {
                case -2:
                    Square23.BackgroundImage = Properties.Resources.kingblue;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square23.BackgroundImage = Properties.Resources.blue;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square23.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square23.BackgroundImage = Properties.Resources.red;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
  
                    break;
                case 2:
                    Square23.BackgroundImage = Properties.Resources.kingred;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
           
            
            switch (currentGame.CheckerBoard[3][1])
            {
                case -2:
                    Square26.BackgroundImage = Properties.Resources.kingblue;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square26.BackgroundImage = Properties.Resources.blue;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square26.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square26.BackgroundImage = Properties.Resources.red;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square26.BackgroundImage = Properties.Resources.kingred;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.CheckerBoard[3][3])
            {
                case -2:
                    Square28.BackgroundImage = Properties.Resources.kingblue;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square28.BackgroundImage = Properties.Resources.blue;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square28.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square28.BackgroundImage = Properties.Resources.red;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square28.BackgroundImage = Properties.Resources.kingred;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[3][5])
            {
                case -2:
                    Square30.BackgroundImage = Properties.Resources.kingblue;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square30.BackgroundImage = Properties.Resources.blue;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square30.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square30.BackgroundImage = Properties.Resources.red;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square30.BackgroundImage = Properties.Resources.kingred;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[3][7])
            {
                case -2:
                    Square32.BackgroundImage = Properties.Resources.kingblue;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square32.BackgroundImage = Properties.Resources.blue;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square32.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square32.BackgroundImage = Properties.Resources.red;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square32.BackgroundImage = Properties.Resources.kingred;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.CheckerBoard[4][0])
            {
                case -2:
                    Square33.BackgroundImage = Properties.Resources.kingblue;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square33.BackgroundImage = Properties.Resources.blue;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square33.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square33.BackgroundImage = Properties.Resources.red;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square33.BackgroundImage = Properties.Resources.kingred;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[4][2])
            {
                case -2:
                    Square35.BackgroundImage = Properties.Resources.kingblue;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square35.BackgroundImage = Properties.Resources.blue;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square35.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square35.BackgroundImage = Properties.Resources.red;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square35.BackgroundImage = Properties.Resources.kingred;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[4][4])
            {
                case -2:
                    Square37.BackgroundImage = Properties.Resources.kingblue;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square37.BackgroundImage = Properties.Resources.blue;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square37.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square37.BackgroundImage = Properties.Resources.red;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square37.BackgroundImage = Properties.Resources.kingred;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[4][6])
            {
                case -2:
                    Square39.BackgroundImage = Properties.Resources.kingblue;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square39.BackgroundImage = Properties.Resources.blue;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square39.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square39.BackgroundImage = Properties.Resources.red;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square39.BackgroundImage = Properties.Resources.kingred;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
       
            switch (currentGame.CheckerBoard[5][1])
            {
                case -2:
                    Square42.BackgroundImage = Properties.Resources.kingblue;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square42.BackgroundImage = Properties.Resources.blue;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square42.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square42.BackgroundImage = Properties.Resources.red;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square42.BackgroundImage = Properties.Resources.kingred;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[5][3])
            {
                case -2:
                    Square44.BackgroundImage = Properties.Resources.kingblue;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square44.BackgroundImage = Properties.Resources.blue;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square44.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square44.BackgroundImage = Properties.Resources.red;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square44.BackgroundImage = Properties.Resources.kingred;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[5][5])
            {
                case -2:
                    Square46.BackgroundImage = Properties.Resources.kingblue;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square46.BackgroundImage = Properties.Resources.blue;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square46.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square46.BackgroundImage = Properties.Resources.red;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square46.BackgroundImage = Properties.Resources.kingred;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[5][7])
            {
                case -2:
                    Square48.BackgroundImage = Properties.Resources.kingblue;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square48.BackgroundImage = Properties.Resources.blue;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square48.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square48.BackgroundImage = Properties.Resources.red;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square48.BackgroundImage = Properties.Resources.kingred;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.CheckerBoard[6][0])
            {
                case -2:
                    Square49.BackgroundImage = Properties.Resources.kingblue;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square49.BackgroundImage = Properties.Resources.blue;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square49.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square49.BackgroundImage = Properties.Resources.red;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square49.BackgroundImage = Properties.Resources.kingred;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[6][2])
            {
                case -2:
                    Square51.BackgroundImage = Properties.Resources.kingblue;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square51.BackgroundImage = Properties.Resources.blue;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square51.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square51.BackgroundImage = Properties.Resources.red;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square51.BackgroundImage = Properties.Resources.kingred;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[6][4])
            {
                case -2:
                    Square53.BackgroundImage = Properties.Resources.kingblue;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square53.BackgroundImage = Properties.Resources.blue;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square53.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square53.BackgroundImage = Properties.Resources.red;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square53.BackgroundImage = Properties.Resources.kingred;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[6][6])
            {
                case -2:
                    Square55.BackgroundImage = Properties.Resources.kingblue;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square55.BackgroundImage = Properties.Resources.blue;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square55.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square55.BackgroundImage = Properties.Resources.red;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square55.BackgroundImage = Properties.Resources.kingred;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            
            switch (currentGame.CheckerBoard[7][1])
            {
                case -2:
                    Square58.BackgroundImage = Properties.Resources.kingblue;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square58.BackgroundImage = Properties.Resources.blue;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square58.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square58.BackgroundImage = Properties.Resources.red;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square58.BackgroundImage = Properties.Resources.kingred;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[7][3])
            {
                case -2:
                    Square60.BackgroundImage = Properties.Resources.kingblue;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square60.BackgroundImage = Properties.Resources.blue;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square60.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square60.BackgroundImage = Properties.Resources.red;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square60.BackgroundImage = Properties.Resources.kingred;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[7][5])
            {
                case -2:
                    Square62.BackgroundImage = Properties.Resources.kingblue;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square62.BackgroundImage = Properties.Resources.blue;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square62.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square62.BackgroundImage = Properties.Resources.red;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square62.BackgroundImage = Properties.Resources.kingred;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            
            switch (currentGame.CheckerBoard[7][7])
            {
                case -2:
                    Square64.BackgroundImage = Properties.Resources.kingblue;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square64.BackgroundImage = Properties.Resources.blue;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square64.BackgroundImage = Properties.Resources.white;
                    break;
                case 1:
                    Square64.BackgroundImage = Properties.Resources.red;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square64.BackgroundImage = Properties.Resources.kingred;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

           
        }

        private void Square1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);


        }

        private void Square3_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 2;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square5_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 4;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square7_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 6;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square10_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 1;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square12_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 3;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square14_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 5;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square16_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 7;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square17_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 0;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square19_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 2;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square21_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 4;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square23_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 6;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square26_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 1;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square28_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 3;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square30_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 5;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square32_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 7;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }
        private void Square33_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 0;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square35_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 2;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square37_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 4;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square39_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 6;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square42_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 1;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square44_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 3;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square46_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 5;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square48_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 7;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square49_Click(object sender, EventArgs e)
        {
            int row = 6;
            int col = 0;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square51_Click(object sender, EventArgs e)
        {
            int row = 6;
            int col = 2;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square53_Click(object sender, EventArgs e)
        {
            int row = 6;
            int col = 4;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square55_Click(object sender, EventArgs e)
        {
            int row = 6;
            int col = 6;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square58_Click(object sender, EventArgs e)
        {
            int row = 7;
            int col = 1;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square60_Click(object sender, EventArgs e)
        {
            int row = 7;
            int col = 3;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }


        private void Square62_Click(object sender, EventArgs e)
        {
            int row = 7;
            int col = 5;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }

        private void Square64_Click(object sender, EventArgs e)
        {
            int row = 7;
            int col = 7;

            currentGame.SelectedStatus[row][col] = true;
            HumanMoveInfo(row,col);
        }
        public void DisposeOldImages()
        {

         if (Square1.BackgroundImage != null)
            {
                Square1.BackgroundImage.Dispose();
            }
            if (Square3.BackgroundImage != null)
            {
                Square3.BackgroundImage.Dispose();
            }
            if (Square5.BackgroundImage != null)
            {
                Square5.BackgroundImage.Dispose();
            }
            if (Square7.BackgroundImage != null)
            {
                Square7.BackgroundImage.Dispose();
            }
            if (Square10.BackgroundImage != null)
            {
                Square10.BackgroundImage.Dispose();
            }
            if (Square12.BackgroundImage != null)
            {
                Square12.BackgroundImage.Dispose();
            }
            if (Square14.BackgroundImage != null)
            {
                Square14.BackgroundImage.Dispose();
            }
            if (Square16.BackgroundImage != null)
            {
                Square16.BackgroundImage.Dispose();
            }
            if (Square17.BackgroundImage != null)
            {
                Square17.BackgroundImage.Dispose();
            }
            if (Square19.BackgroundImage != null)
            {
                Square19.BackgroundImage.Dispose();
            }
            if (Square21.BackgroundImage != null)
            {
                Square21.BackgroundImage.Dispose();
            }
            if (Square23.BackgroundImage != null)
            {
                Square23.BackgroundImage.Dispose();
            }
            if (Square42.BackgroundImage != null)
            {
                Square42.BackgroundImage.Dispose();
            }
            if (Square44.BackgroundImage != null)
            {
                Square44.BackgroundImage.Dispose();
            }
            if (Square46.BackgroundImage != null)
            {
                Square46.BackgroundImage.Dispose();
            }
            if (Square48.BackgroundImage != null)
            {
                Square48.BackgroundImage.Dispose();
            }
            if (Square49.BackgroundImage != null)
            {
                Square49.BackgroundImage.Dispose();
            }
            if (Square51.BackgroundImage != null)
            {
                Square51.BackgroundImage.Dispose();
            }
            if (Square53.BackgroundImage != null)
            {
                Square53.BackgroundImage.Dispose();
            }
            if (Square55.BackgroundImage != null)
            {
                Square55.BackgroundImage.Dispose();
            }
            if (Square58.BackgroundImage != null)
            {
                Square58.BackgroundImage.Dispose();
            }
            if (Square60.BackgroundImage != null)
            {
                Square60.BackgroundImage.Dispose();
            }
            if (Square62.BackgroundImage != null)
            {
                Square62.BackgroundImage.Dispose();
            }
            if (Square64.BackgroundImage != null)
            {
                Square64.BackgroundImage.Dispose();
            }

        }
    }
}