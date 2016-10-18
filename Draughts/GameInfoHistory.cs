using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    public class GameInfoHistory
    {
            [Key]
            public int GameHistoryID { get; set; }
            public int Winner { get; set; }
            [ForeignKey("GameInfo")]
            public int GameInfoID { get; set; }         
            public GameInfo GameInfo { get; set; }    
            public virtual List<GameInfoHistory> gameInfoHistory { get; set; }
        }
}
