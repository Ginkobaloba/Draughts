using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    public class CheckerBoardArray : ICloneable
    {
        public int gameID { get; set; }
        public int turn { get; set; }                                       
        public List<List<int>> CheckerBoard = new List<List<int>>();

        public CheckerBoardArray()
        {
            for (int i = 0; i < 8; i++)
            {
                List<int> row = new List<int>();
                for (int ii = 0; ii < 8; ii++)
                {
                    row.Add(0);
                }
                this.CheckerBoard.Add(row);
            }
        }
        public CheckerBoardArray serialization(GameInfo Gameinfo)
        {
            this.gameID = Gameinfo.gameInfoId;

            this.turn = Gameinfo.turn;
            this.CheckerBoard[0][0] = Gameinfo.square1;
            this.CheckerBoard[0][2] = Gameinfo.square3;
            this.CheckerBoard[0][4] = Gameinfo.square5;
            this.CheckerBoard[0][6] = Gameinfo.square7;
            this.CheckerBoard[1][1] = Gameinfo.square10;
            this.CheckerBoard[1][3] = Gameinfo.square12;
            this.CheckerBoard[1][5] = Gameinfo.square14;
            this.CheckerBoard[1][7] = Gameinfo.square16;
            this.CheckerBoard[2][0] = Gameinfo.square17;
            this.CheckerBoard[2][2] = Gameinfo.square19;
            this.CheckerBoard[2][4] = Gameinfo.square21;
            this.CheckerBoard[2][6] = Gameinfo.square23;
            this.CheckerBoard[3][1] = Gameinfo.square26;
            this.CheckerBoard[3][3] = Gameinfo.square28;
            this.CheckerBoard[3][5] = Gameinfo.square30;
            this.CheckerBoard[3][7] = Gameinfo.square32;
            this.CheckerBoard[4][0] = Gameinfo.square33;
            this.CheckerBoard[4][2] = Gameinfo.square35;
            this.CheckerBoard[4][4] = Gameinfo.square37;
            this.CheckerBoard[4][6] = Gameinfo.square39;
            this.CheckerBoard[5][1] = Gameinfo.square42;
            this.CheckerBoard[5][3] = Gameinfo.square44;
            this.CheckerBoard[5][5] = Gameinfo.square46;
            this.CheckerBoard[5][7] = Gameinfo.square48;
            this.CheckerBoard[6][0] = Gameinfo.square49;
            this.CheckerBoard[6][2] = Gameinfo.square51;
            this.CheckerBoard[6][4] = Gameinfo.square53;
            this.CheckerBoard[6][6] = Gameinfo.square55;
            this.CheckerBoard[7][1] = Gameinfo.square58;
            this.CheckerBoard[7][3] = Gameinfo.square60;
            this.CheckerBoard[7][5] = Gameinfo.square62;
            this.CheckerBoard[7][7] = Gameinfo.square64;

            return this;
        }
        public CheckerBoardArray ShallowCopy()
        {
            CheckerBoardArray copy = new CheckerBoardArray();

            copy.gameID = this.gameID;
            copy.turn = this.turn;
 
            for (int i = 0; i < 8; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    copy.CheckerBoard[i][ii] = this.CheckerBoard[i][ii];
                }
            }
            
            return copy;

        }
        public CheckerBoardArray Clone() { return (CheckerBoardArray)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }
    }
}

