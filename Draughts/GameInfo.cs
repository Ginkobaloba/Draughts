using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Draughts
{
    public class GameInfo
    {
        [Key]
        public int gameInfoId { get; set; }
        public int gameNumber { get; set; }
        public int turn { get; set; }
        public int square1 { get; set; }
        public int square3 { get; set; }
        public int square5 { get; set; }
        public int square7 { get; set; }
        public int square10 { get; set; }
        public int square12 { get; set; }
        public int square14 { get; set; }
        public int square16 { get; set; }
        public int square17 { get; set; }
        public int square19 { get; set; }
        public int square21 { get; set; }
        public int square23 { get; set; }
        public int square26 { get; set; }
        public int square28 { get; set; }
        public int square30 { get; set; }
        public int square32 { get; set; }
        public int square33 { get; set; }
        public int square35 { get; set; }
        public int square37 { get; set; }
        public int square39 { get; set; }
        public int square42 { get; set; }
        public int square44 { get; set; }
        public int square46 { get; set; }
        public int square48 { get; set; }
        public int square49 { get; set; }
        public int square51 { get; set; }
        public int square53 { get; set; }
        public int square55 { get; set; }
        public int square58 { get; set; }
        public int square60 { get; set; }
        public int square62 { get; set; }
        public int square64 { get; set; }

        public virtual List<GameInfo> gameInfo { get; set; }
        public GameInfo()
        {
        }
        public GameInfo Serialization(CheckerBoardArray checkerBoard)
        {

            this.turn = checkerBoard.turn;
            this.gameNumber = checkerBoard.gameID;
            this.square1 = checkerBoard.CheckerBoard[0][0];
            this.square3 = checkerBoard.CheckerBoard[0][2];
            this.square5 = checkerBoard.CheckerBoard[0][4];
            this.square7 = checkerBoard.CheckerBoard[0][6];
            this.square10 = checkerBoard.CheckerBoard[1][1];
            this.square12 = checkerBoard.CheckerBoard[1][3];
            this.square14 = checkerBoard.CheckerBoard[1][5];
            this.square16 = checkerBoard.CheckerBoard[1][7];
            this.square17 = checkerBoard.CheckerBoard[2][0];
            this.square19 = checkerBoard.CheckerBoard[2][2];
            this.square21 = checkerBoard.CheckerBoard[2][4];
            this.square23 = checkerBoard.CheckerBoard[2][6];
            this.square26 = checkerBoard.CheckerBoard[3][1];
            this.square28 = checkerBoard.CheckerBoard[3][3];
            this.square30 = checkerBoard.CheckerBoard[3][5];
            this.square32 = checkerBoard.CheckerBoard[3][7];
            this.square33 = checkerBoard.CheckerBoard[4][0];
            this.square35 = checkerBoard.CheckerBoard[4][2];
            this.square37 = checkerBoard.CheckerBoard[4][4];
            this.square39 = checkerBoard.CheckerBoard[5][1];
            this.square42 = checkerBoard.CheckerBoard[5][3];
            this.square44 = checkerBoard.CheckerBoard[5][5];
            this.square46 = checkerBoard.CheckerBoard[5][7];
            this.square48 = checkerBoard.CheckerBoard[6][0];
            this.square49 = checkerBoard.CheckerBoard[6][2];
            this.square51 = checkerBoard.CheckerBoard[6][4];
            this.square53 = checkerBoard.CheckerBoard[6][6];
            this.square55 = checkerBoard.CheckerBoard[7][1];
            this.square58 = checkerBoard.CheckerBoard[7][1];
            this.square60 = checkerBoard.CheckerBoard[7][3];
            this.square62 = checkerBoard.CheckerBoard[7][5];
            this.square64 = checkerBoard.CheckerBoard[7][7];

            return this;

        }

    }

}
 