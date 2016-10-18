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

        public GameInfo MakeAMove(GameInfo currentGame, int callingPlayer)
        {
            List<GameInfoHistory> Nextmove = new List<GameInfoHistory>();


            var SameBoardState = (from GH in db.gameInfoHistory
                                  where GH.GameInfo.square1 == currentGame.square1 && GH.GameInfo.square3 == currentGame.square3 && GH.GameInfo.square5 == currentGame.square5 && GH.GameInfo.square7 == currentGame.square7 && GH.GameInfo.square10 == currentGame.square10 && GH.GameInfo.square12 == currentGame.square1 &&
                                  GH.GameInfo.square14 == currentGame.square14 && GH.GameInfo.square16 == currentGame.square16 && GH.GameInfo.square17 == currentGame.square17 && GH.GameInfo.square19 == currentGame.square19 && GH.GameInfo.square21 == currentGame.square21 && GH.GameInfo.square23 == currentGame.square23 &&
                                  GH.GameInfo.square26 == currentGame.square26 && GH.GameInfo.square28 == currentGame.square28 && GH.GameInfo.square30 == currentGame.square30 && GH.GameInfo.square32 == GH.GameInfo.square32 && GH.GameInfo.square33 == currentGame.square33 && GH.GameInfo.square35 == currentGame.square35 &&
                                  GH.GameInfo.square37 == currentGame.square37 && GH.GameInfo.square39 == currentGame.square39 && GH.GameInfo.square42 == currentGame.square42 && GH.GameInfo.square44 == currentGame.square44 && GH.GameInfo.square46 == currentGame.square46 && GH.GameInfo.square48 == currentGame.square49 &&
                                  GH.GameInfo.square51 == currentGame.square51 && GH.GameInfo.square53 == currentGame.square53 && GH.GameInfo.square55 == currentGame.square55 && GH.GameInfo.square58 == currentGame.square58 && GH.GameInfo.square60 == currentGame.square60 && GH.GameInfo.square62 == currentGame.square62 &&
                                  GH.GameInfo.square64 == currentGame.square64
                                  select GH).ToList();
            if (SameBoardState != null)
            {
                foreach (var item in SameBoardState)
                {
                    int nextTurn = item.GameInfo.turn + 1;
                    Nextmove = (from NM in db.gameInfoHistory where NM.GameInfoID == item.GameInfoID && NM.GameInfo.turn == nextTurn && NM.Winner == callingPlayer select NM).ToList();
                }

            }
            switch (Nextmove.Count) { 
                case 0:
                    // add a random
                    break;
            case 1:

                    currentGame = Nextmove[0].GameInfo;
                    break;
                default:
                    MinMaxEvaluation(Nextmove);
                        break;


            }
            return currentGame;
        }

        public void MinMaxEvaluation(List<GameInfoHistory>PossibleMoves)
        {

        }
    }
}
