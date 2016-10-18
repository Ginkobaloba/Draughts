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
        public GameInfo()
        {
        }
        public virtual List<GameInfo> gameInfo { get; set; }
    }
}
 