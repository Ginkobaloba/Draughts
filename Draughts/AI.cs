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

        public GameInfo opening(GameInfo currentGame)
        {
            //var query = (from GH in db.gameInfoHistory where db.gameInfoHistory)




            return currentGame;
        }

        public void MinMaxEvaluation()
        {

        }
    }
}
