using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    class AI
    {
        private DatabaseContext db = new DatabaseContext();
        public AI()
        { }

        public GameInfo MakeAMove(CheckerBoardArray currentCheckerBoard, int callingPlayer)
        {
            Random random = new Random();
            List<GameInfo> possibleNextMoves = new List<GameInfo>();
            GameInfo currentGame = new GameInfo();

            currentGame = currentGame.Serialization(currentCheckerBoard);


            var SameBoardState = (from GI in db.gameInfo
                                  where GI.square1 == currentGame.square1 && GI.square3 == currentGame.square3 && GI.square5 == currentGame.square5 && GI.square7 == currentGame.square7 && GI.square10 == currentGame.square10 && GI.square12 == currentGame.square1 &&
                                  GI.square14 == currentGame.square14 && GI.square16 == currentGame.square16 && GI.square17 == currentGame.square17 && GI.square19 == currentGame.square19 && GI.square21 == currentGame.square21 && GI.square23 == currentGame.square23 &&
                                  GI.square26 == currentGame.square26 && GI.square28 == currentGame.square28 && GI.square30 == currentGame.square30 && GI.square32 == currentGame.square32 && GI.square33 == currentGame.square33 && GI.square35 == currentGame.square35 &&
                                  GI.square37 == currentGame.square37 && GI.square39 == currentGame.square39 && GI.square42 == currentGame.square42 && GI.square44 == currentGame.square44 && GI.square46 == currentGame.square46 && GI.square48 == currentGame.square49 &&
                                  GI.square51 == currentGame.square51 && GI.square53 == currentGame.square53 && GI.square55 == currentGame.square55 && GI.square58 == currentGame.square58 && GI.square60 == currentGame.square60 && GI.square62 == currentGame.square62 &&
                                  GI.square64 == currentGame.square64
                                  select GI).ToList();

            if (SameBoardState != null)
            {
                List<CheckerBoardArray> possibleBoardStates = new List<CheckerBoardArray>();
                foreach (var item in SameBoardState)
                {
                    int nextTurn = item.turn + 1;
                    possibleNextMoves = (from PNM in db.gameInfo where PNM.gameNumber == item.gameNumber && PNM.turn == nextTurn && PNM.winner == callingPlayer select PNM).ToList();
                    foreach(var item2 in possibleNextMoves)
                    {
                        possibleBoardStates.Add(currentCheckerBoard.serialization(item2));
                    }
                }

            }


            if (random.Next(0, 5)> 1)
            {
                switch (possibleNextMoves.Count) {
                    case 0:
                        randomNextMove(currentCheckerBoard, callingPlayer);
                        break;
                    case 1:

                        currentGame = possibleNextMoves[0];
                        break;
                    default:
                        MinMaxEvaluation(possibleNextMoves);
                        break;


                }
            }
            else
            {
                randomNextMove(currentCheckerBoard, callingPlayer);
            }

            return currentGame;
        }

        public void MinMaxEvaluation(List<GameInfo>PossibleMoves)
        {

        }
        public GameInfo randomNextMove(CheckerBoardArray curentGame, int CallingPlayer)
        {
            GameInfo nextMove = new GameInfo();
            List<int> properties = new List<int>();
            foreach(var item in curentGame.GetType().GetProperties())
            {

            }

            return nextMove;
        }
        public List<GameInfo> GetPossibleMoves(CheckerBoardArray CurrentGame, int CallingPlayer)
        {
            List<GameInfo> PossibleMoves = new List<GameInfo>();

            switch (CallingPlayer) {
                case -1:
                    for (int i = 0; i < 8; i++)
                    { 
                     for (int ii = 0; ii < 8; ii++)
                    {
                            if (CurrentGame.CheckerBoard[i][ii] == -1)
                            {
                                if (CurrentGame.CheckerBoard[i + 1][ii + 1] == 0 && i )
                                {   //diagonal right
                                    CheckerBoardArray PossibleMove = new CheckerBoardArray();
                                    PossibleMove = CurrentGame;
                                    PossibleMove.turn = CurrentGame.turn + 1;
                                    PossibleMove.gameID = CurrentGame.gameID;
                                    PossibleMove.CheckerBoard[i][ii] = 0;
                                    PossibleMove.CheckerBoard[i][ii] = CallingPlayer;                                   
                                }
                                if 
                            }

                    }
                    }
                    break;
                case 1:
                    break;
                default:
                    break;
            }

            return PossibleMoves;
        }
    }
}
