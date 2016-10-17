using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    class CheckerSquare
    {
        // -2 is black promoted,-1 is black, 0 is empty, +1 is white, +2 is white promoted
        public int status { get; set; }
        public string location { get; set; }
        public bool hasBeenClicked { get; set; }
    }
}
