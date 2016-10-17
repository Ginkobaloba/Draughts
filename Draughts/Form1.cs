using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draughts
{
    public partial class Form1 : Form
    {
        private DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
            SetupArrangement();
        }

        public void SetupArrangement()
        {
            Red1.Location = Square1.Location;
            Red2.Location = Square3.Location;
            Red3.Location = Square5.Location;
            Red4.Location = Square7.Location;
            Red5.Location = Square10.Location;
            Red6.Location = Square12.Location;
            Red7.Location = Square14.Location;
            Red8.Location = Square16.Location;
            Red9.Location = Square17.Location;
            Red10.Location = Square19.Location;
            Red11.Location = Square21.Location;
            Red12.Location = Square23.Location;

            Blue1.Location = Square42.Location;
            Blue2.Location = Square44.Location;
            Blue3.Location = Square46.Location;
            Blue4.Location = Square48.Location;
            Blue5.Location = Square49.Location;
            Blue6.Location = Square51.Location;
            Blue7.Location = Square53.Location;
            Blue8.Location = Square55.Location;
            Blue9.Location = Square58.Location;
            Blue10.Location = Square60.Location;
            Blue11.Location = Square62.Location;
            Blue12.Location = Square64.Location;

        } 

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameInfo currentgame = new GameInfo();


            if (rdbtnAllAI.Checked == true)
            {   var currentgame = ( from cp in db.gameInfo where cp.gameInfo)
                var query = (from Q in db.gameInfoHistory where Q.gameinfo.gameInfo == );
            }
            else if (rdbtn2player.Checked == true)
            {

            }
            else
            {

            }
        }
    }
}
