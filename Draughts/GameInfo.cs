using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    public class GameInfo
    {
        [Key]
        public int gameInfoId { get; set; }
        public int gameNumber { get; set; }
        public int turn { get; set; }
        public List<List<CheckerSquare>> checkerboard { get; set; }
        public virtual List<GameInfo> gameInfo { get; set; }
    }
}
 