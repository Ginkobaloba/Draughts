using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
   public class AI
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
                    foreach (var item2 in possibleNextMoves)
                    {
                        possibleBoardStates.Add(currentCheckerBoard.serialization(item2));
                    }
                }

            }


            if (random.Next(0, 5) > 1)
            {
                switch (possibleNextMoves.Count) {
                    case 0:
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

            }

            return currentGame;
        }

        public void MinMaxEvaluation(List<GameInfo> PossibleMoves)
        {

        }
        public List<CheckerBoardArray> GetPossibleMoves(CheckerBoardArray CurrentGame, int CallingPlayer)
        {
            List<CheckerBoardArray> PossibleMoves = new List<CheckerBoardArray>();

            switch (CallingPlayer) {
                
                case 1:
                    for (int i = 0; i < 8; i++)
                    {
                        for (int ii = 0; ii < 8; ii++)
                       {
                            try
                            {
                                if (CurrentGame.CheckerBoard[i][ii] > 0)
                                {
                                    //diagonal right unpromoted or king
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] == 0 && i <= 6 && ii <= 6)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] == 0 && i <= 6 && ii >= 1)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal right back  king
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] == 0 && i >= 1 && ii <= 6 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal left back king 
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] == 0 && i >= 1 && ii >= 1 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal Jump right Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && i <= 5 && ii <= 5)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal jump left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && i >= 2 && ii >= 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal Jump right king back
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && i >= 2 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal jump left king back                                                       
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && i >= 2 && ii >= 2 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii + 3] < 0 && CurrentGame.CheckerBoard[i + 4][ii + 4] == 0 && i <= 3 && ii <= 3)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii - 3] < 0 && CurrentGame.CheckerBoard[i + 4][ii - 4] == 0 && i <= 3 && ii >= 4)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right then middle Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii <= 5)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left then middle Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii >= 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right back king
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii + 3] < 0 && CurrentGame.CheckerBoard[i - 4][ii + 4] == 0 && i >= 4 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i - 3][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i - 4][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left back king
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii - 3] < 0 && CurrentGame.CheckerBoard[i - 4][ii - 4] == 0 && i >= 4 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal double Jump right then middle back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left then middle back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right front sideways King
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 1][ii + 3] < 0 && CurrentGame.CheckerBoard[i][ii + 4] == 0 && i <= 5 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left right sideways king
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 1][ii - 3] < 0 && CurrentGame.CheckerBoard[i][ii - 4] == 0 && i <= 3 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }



                                    //diagonal double Jump right back sideways King
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i - 1][ii + 3] < 0 && CurrentGame.CheckerBoard[i][ii + 4] == 0 && i >= 2 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left back sideways king
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i - 1][ii - 3] < 0 && CurrentGame.CheckerBoard[i][ii - 4] == 0 && i >= 2 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                }

                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    break;

                case -1:
                    for (int i = 0; i < 8; i++)
                    {
                        for (int ii = 0; ii < 8; ii++)
                        {
                            try
                            {

                                if (CurrentGame.CheckerBoard[i][ii] < 0)
                                {

                                    //diagonal blue right unpromoted or king
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] == 0 && i >= 1 && ii <= 6)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal blue left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] == 0 && i >= 1 && ii >= 1)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal blue right back  king
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] == 0 && i >= 1 && ii <= 6 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal blue left back king 
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] == 0 && i >= 1 && ii >= 1 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal blue Jump right Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && i >= 2 && ii <= 5)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal jump left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && i >= 2 && ii >= 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal Jump right king back
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && i <= 5 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal jump left king back                                                       
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && i <= 5 && ii >= 2 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii + 3] < 0 && CurrentGame.CheckerBoard[i - 4][ii + 4] == 0 && i >= 4 && ii <= 3)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i - 3][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i - 4][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii - 3] < 0 && CurrentGame.CheckerBoard[i - 4][ii - 4] == 0 && i >= 4 && ii >= 4)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i - 3][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i - 4][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right then middle Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 4][ii] == 0 && i >= 4 && ii <= 5)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i - 3][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left then middle Unpromoted or promoted
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i - 3][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 4][ii] == 0 && i >= 4 && ii >= 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i - 3][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }


                                    //diagonal double Jump right back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii + 3] < 0 && CurrentGame.CheckerBoard[i + 4][ii + 4] == 0 && i <= 3 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii - 3] < 0 && CurrentGame.CheckerBoard[i + 4][ii - 4] == 0 && i <= 3 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                    //diagonal double Jump right then middle back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left then middle back king
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 3][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 4][ii] == 0 && i <= 3 && ii <= 5 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 3][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 4][ii] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump right front sideways King
                                    if (CurrentGame.CheckerBoard[i + 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i + 1][ii + 3] < 0 && CurrentGame.CheckerBoard[i][ii + 4] == 0 && i <= 5 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left right sideways king
                                    if (CurrentGame.CheckerBoard[i + 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i + 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i + 1][ii - 3] < 0 && CurrentGame.CheckerBoard[i][ii - 4] == 0 && i <= 3 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i + 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i + 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i + 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }



                                    //diagonal double Jump right back sideways King
                                    if (CurrentGame.CheckerBoard[i - 1][ii + 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii + 2] == 0 && CurrentGame.CheckerBoard[i - 1][ii + 3] < 0 && CurrentGame.CheckerBoard[i][ii + 4] == 0 && i >= 2 && ii <= 3 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii + 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii + 2] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii + 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii + 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }

                                    //diagonal double Jump left back sideways king
                                    if (CurrentGame.CheckerBoard[i - 1][ii - 1] < 0 && CurrentGame.CheckerBoard[i - 2][ii - 2] == 0 && CurrentGame.CheckerBoard[i - 1][ii - 3] < 0 && CurrentGame.CheckerBoard[i][ii - 4] == 0 && i >= 2 && ii >= 4 && CurrentGame.CheckerBoard[i][ii] == 2)
                                    {
                                        CheckerBoardArray PossibleMove = CurrentGame.ShallowCopy();                                        
                                        PossibleMove.turn = CurrentGame.turn + 1;
                                        PossibleMove.gameID = CurrentGame.gameID;
                                        PossibleMove.CheckerBoard[i - 1][ii - 1] = 0;
                                        PossibleMove.CheckerBoard[i - 2][ii - 2] = 0;
                                        PossibleMove.CheckerBoard[i - 1][ii - 3] = 0;
                                        PossibleMove.CheckerBoard[i][ii - 4] = PossibleMove.CheckerBoard[i][ii];
                                        PossibleMove.CheckerBoard[i][ii] = 0;
                                        PossibleMoves.Add(PossibleMove);
                                    }
                                }

                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    break;
                default:
                    break;
                    }

                PossibleMoves = FindKings(PossibleMoves);

                    return PossibleMoves;
            }
        public List<CheckerBoardArray> FindKings(List<CheckerBoardArray> PossibleMoves)
        {
            foreach(CheckerBoardArray possibleMove in PossibleMoves)
            {
                for (int i = 0; i<8; i++)
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



            }









            return PossibleMoves;
        }
        }
    }

