using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Resources;

namespace Draughts
{
    public partial class Form1 : Form
    {
        private DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
            GameInfo currentGame = new GameInfo();
            currentGame = SetupInital(currentGame);
            LinkToGUI(currentGame);
        }


        private void btnStart_Click(object sender, EventArgs e)
        {



            //foreach







            if (rdbtnAllAI.Checked == true)
            {   //var currentgame = (from cp in db.gameInfo where cp.gameInfo)
                //var query = (from Q in db.gameInfoHistory where Q.gameinfo.gameInfo == );
            }
            else if (rdbtn2player.Checked == true)
            {

            }
            else
            {

            }
        }
        public GameInfo SetupInital(GameInfo currentGame)
        {

            currentGame.checkerboard = new List<List<CheckerSquare>>();
            for (int i = 0; i < 8; i++)
            {
                List<CheckerSquare> checkersquares = new List<CheckerSquare>();
                currentGame.checkerboard.Add(new List<CheckerSquare>());

                for (int ii = 0; ii < 8; ii++)
                {
                    currentGame.checkerboard[i].Add(new CheckerSquare());
                }
            }

            currentGame.turn = 0;
            currentGame.checkerboard[0][0].status = 1;
            var what = currentGame.checkerboard[0][0].status;
            currentGame.checkerboard[0][2].status = 1;
            currentGame.checkerboard[0][4].status = 1;
            currentGame.checkerboard[0][6].status = 1;
            currentGame.checkerboard[1][1].status = 1;
            currentGame.checkerboard[1][3].status = 1;
            currentGame.checkerboard[1][5].status = 1;
            currentGame.checkerboard[1][7].status = 1;
            currentGame.checkerboard[2][0].status = 1;
            currentGame.checkerboard[2][2].status = 1;
            currentGame.checkerboard[2][4].status = 1;
            currentGame.checkerboard[2][6].status = 1;
            currentGame.checkerboard[7][7].status = -1;
            currentGame.checkerboard[7][5].status = -1;
            currentGame.checkerboard[7][3].status = -1;
            currentGame.checkerboard[7][1].status = -1;
            currentGame.checkerboard[6][6].status = -1;
            currentGame.checkerboard[6][4].status = -1;
            currentGame.checkerboard[6][2].status = -1;
            currentGame.checkerboard[6][0].status = -1;
            currentGame.checkerboard[5][7].status = -1;
            currentGame.checkerboard[5][5].status = -1;
            currentGame.checkerboard[5][3].status = -1;
            currentGame.checkerboard[5][1].status = -1;



            return currentGame;
        }



        public void LinkToGUI(GameInfo currentGame)
        {

            switch (currentGame.checkerboard[0][0].status)
            {
                case -2:
                    Square1.BackgroundImage = Properties.Resources.kingblue;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square1.BackgroundImage = Properties.Resources.blue;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square1.BackgroundImage = Properties.Resources.white;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square1.BackgroundImage = Properties.Resources.red;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square1.BackgroundImage = Properties.Resources.kingred;
                    Square1.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][1].status)
            {
                case -2:
                    Square2.BackgroundImage = Properties.Resources.kingblue;
                    Square2.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square2.BackgroundImage = Properties.Resources.blue;
                    Square2.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square2.BackgroundImage = Properties.Resources.black;
                    Square2.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square2.BackgroundImage = Properties.Resources.red;
                    Square2.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square2.BackgroundImage = Properties.Resources.kingred;
                    Square2.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][2].status)
            {
                case -2:
                    Square3.BackgroundImage = Properties.Resources.kingblue;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square3.BackgroundImage = Properties.Resources.blue;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square3.BackgroundImage = Properties.Resources.white;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square3.BackgroundImage = Properties.Resources.red;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square3.BackgroundImage = Properties.Resources.kingred;
                    Square3.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][3].status)
            {
                case -2:
                    Square4.BackgroundImage = Properties.Resources.kingblue;
                    Square4.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square4.BackgroundImage = Properties.Resources.blue;
                    Square4.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square4.BackgroundImage = Properties.Resources.black;
                    Square4.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square4.BackgroundImage = Properties.Resources.red;
                    Square4.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square4.BackgroundImage = Properties.Resources.kingred;
                    Square4.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][4].status)
            {
                case -2:
                    Square5.BackgroundImage = Properties.Resources.kingblue;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square5.BackgroundImage = Properties.Resources.blue;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square5.BackgroundImage = Properties.Resources.white;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square5.BackgroundImage = Properties.Resources.red;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square5.BackgroundImage = Properties.Resources.kingred;
                    Square5.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][5].status)
            {
                case -2:
                    Square6.BackgroundImage = Properties.Resources.kingblue;
                    Square6.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square6.BackgroundImage = Properties.Resources.blue;
                    Square6.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square6.BackgroundImage = Properties.Resources.black;
                    Square6.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square6.BackgroundImage = Properties.Resources.red;
                    Square6.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square6.BackgroundImage = Properties.Resources.kingred;
                    Square6.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][6].status)
            {
                case -2:
                    Square7.BackgroundImage = Properties.Resources.kingblue;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square7.BackgroundImage = Properties.Resources.blue;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square7.BackgroundImage = Properties.Resources.white;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square7.BackgroundImage = Properties.Resources.red;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square7.BackgroundImage = Properties.Resources.kingred;
                    Square7.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[0][7].status)
            {
                case -2:
                    Square8.BackgroundImage = Properties.Resources.kingblue;
                    Square8.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square8.BackgroundImage = Properties.Resources.blue;
                    Square8.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square8.BackgroundImage = Properties.Resources.black;
                    Square8.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square8.BackgroundImage = Properties.Resources.red;
                    Square8.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square8.BackgroundImage = Properties.Resources.kingred;
                    Square8.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[1][0].status)
            {
                case -2:
                    Square9.BackgroundImage = Properties.Resources.kingblue;
                    Square9.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square9.BackgroundImage = Properties.Resources.blue;
                    Square9.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square9.BackgroundImage = Properties.Resources.black;
                    Square9.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square9.BackgroundImage = Properties.Resources.red;
                    Square9.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square9.BackgroundImage = Properties.Resources.kingred;
                    Square9.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[1][1].status)
            {
                case -2:
                    Square10.BackgroundImage = Properties.Resources.kingblue;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square10.BackgroundImage = Properties.Resources.blue;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square10.BackgroundImage = Properties.Resources.white;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square10.BackgroundImage = Properties.Resources.red;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square10.BackgroundImage = Properties.Resources.kingred;
                    Square10.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

            switch (currentGame.checkerboard[1][2].status)
            {
                case -2:
                    Square11.BackgroundImage = Properties.Resources.kingblue;
                    Square11.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square11.BackgroundImage = Properties.Resources.blue;
                    Square11.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square11.BackgroundImage = Properties.Resources.black;
                    Square11.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square11.BackgroundImage = Properties.Resources.red;
                    Square11.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square11.BackgroundImage = Properties.Resources.kingred;
                    Square11.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[1][3].status)
            {
                case -2:
                    Square12.BackgroundImage = Properties.Resources.kingblue;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square12.BackgroundImage = Properties.Resources.blue;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square12.BackgroundImage = Properties.Resources.white;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square12.BackgroundImage = Properties.Resources.red;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square12.BackgroundImage = Properties.Resources.kingred;
                    Square12.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[1][4].status)
            {
                case -2:
                    Square13.BackgroundImage = Properties.Resources.kingblue;
                    Square13.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square13.BackgroundImage = Properties.Resources.blue;
                    Square13.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square13.BackgroundImage = Properties.Resources.black;
                    Square13.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square13.BackgroundImage = Properties.Resources.red;
                    Square13.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square13.BackgroundImage = Properties.Resources.kingred;
                    Square13.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[1][5].status)
            {
                case -2:
                    Square14.BackgroundImage = Properties.Resources.kingblue;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square14.BackgroundImage = Properties.Resources.blue;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square14.BackgroundImage = Properties.Resources.white;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square14.BackgroundImage = Properties.Resources.red;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square14.BackgroundImage = Properties.Resources.kingred;
                    Square14.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[1][6].status)
            {
                case -2:
                    Square15.BackgroundImage = Properties.Resources.kingblue;
                    Square15.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square15.BackgroundImage = Properties.Resources.blue;
                    Square15.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square15.BackgroundImage = Properties.Resources.black;
                    Square15.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square15.BackgroundImage = Properties.Resources.red;
                    Square15.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square15.BackgroundImage = Properties.Resources.kingred;
                    Square15.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[1][7].status)
            {
                case -2:
                    Square16.BackgroundImage = Properties.Resources.kingblue;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square16.BackgroundImage = Properties.Resources.blue;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square16.BackgroundImage = Properties.Resources.white;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square16.BackgroundImage = Properties.Resources.red;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square16.BackgroundImage = Properties.Resources.kingred;
                    Square16.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][0].status)
            {
                case -2:
                    Square17.BackgroundImage = Properties.Resources.kingblue;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square17.BackgroundImage = Properties.Resources.blue;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square17.BackgroundImage = Properties.Resources.white;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square17.BackgroundImage = Properties.Resources.red;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square17.BackgroundImage = Properties.Resources.kingred;
                    Square17.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][1].status)
            {
                case -2:
                    Square18.BackgroundImage = Properties.Resources.kingblue;
                    Square18.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square18.BackgroundImage = Properties.Resources.blue;
                    Square18.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square18.BackgroundImage = Properties.Resources.black;
                    Square18.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square18.BackgroundImage = Properties.Resources.red;
                    Square18.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square18.BackgroundImage = Properties.Resources.kingred;
                    Square18.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][2].status)
            {
                case -2:
                    Square19.BackgroundImage = Properties.Resources.kingblue;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square19.BackgroundImage = Properties.Resources.blue;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square19.BackgroundImage = Properties.Resources.white;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square19.BackgroundImage = Properties.Resources.red;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square19.BackgroundImage = Properties.Resources.kingred;
                    Square19.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][3].status)
            {
                case -2:
                    Square20.BackgroundImage = Properties.Resources.kingblue;
                    Square20.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square20.BackgroundImage = Properties.Resources.blue;
                    Square20.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square20.BackgroundImage = Properties.Resources.black;
                    Square20.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square20.BackgroundImage = Properties.Resources.red;
                    Square20.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square20.BackgroundImage = Properties.Resources.kingred;
                    Square20.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][4].status)
            {
                case -2:
                    Square21.BackgroundImage = Properties.Resources.kingblue;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square21.BackgroundImage = Properties.Resources.blue;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square21.BackgroundImage = Properties.Resources.white;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square21.BackgroundImage = Properties.Resources.red;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square21.BackgroundImage = Properties.Resources.kingred;
                    Square21.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][5].status)
            {
                case -2:
                    Square22.BackgroundImage = Properties.Resources.kingblue;
                    Square22.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square22.BackgroundImage = Properties.Resources.blue;
                    Square22.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square22.BackgroundImage = Properties.Resources.black;
                    Square22.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square22.BackgroundImage = Properties.Resources.red;
                    Square22.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square22.BackgroundImage = Properties.Resources.kingred;
                    Square22.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][6].status)
            {
                case -2:
                    Square23.BackgroundImage = Properties.Resources.kingblue;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square23.BackgroundImage = Properties.Resources.blue;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square23.BackgroundImage = Properties.Resources.white;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square23.BackgroundImage = Properties.Resources.red;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square23.BackgroundImage = Properties.Resources.kingred;
                    Square23.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[2][7].status)
            {
                case -2:
                    Square24.BackgroundImage = Properties.Resources.kingblue;
                    Square24.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square24.BackgroundImage = Properties.Resources.blue;
                    Square24.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square24.BackgroundImage = Properties.Resources.black;
                    Square24.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square24.BackgroundImage = Properties.Resources.red;
                    Square24.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square24.BackgroundImage = Properties.Resources.kingred;
                    Square24.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][0].status)
            {
                case -2:
                    Square25.BackgroundImage = Properties.Resources.kingblue;
                    Square25.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square25.BackgroundImage = Properties.Resources.blue;
                    Square25.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square25.BackgroundImage = Properties.Resources.black;
                    Square25.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square25.BackgroundImage = Properties.Resources.red;
                    Square25.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square25.BackgroundImage = Properties.Resources.kingred;
                    Square25.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][1].status)
            {
                case -2:
                    Square26.BackgroundImage = Properties.Resources.kingblue;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square26.BackgroundImage = Properties.Resources.blue;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square26.BackgroundImage = Properties.Resources.white;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square26.BackgroundImage = Properties.Resources.red;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square26.BackgroundImage = Properties.Resources.kingred;
                    Square26.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][2].status)
            {
                case -2:
                    Square27.BackgroundImage = Properties.Resources.kingblue;
                    Square27.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square27.BackgroundImage = Properties.Resources.blue;
                    Square27.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square27.BackgroundImage = Properties.Resources.black;
                    Square27.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square27.BackgroundImage = Properties.Resources.red;
                    Square27.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square27.BackgroundImage = Properties.Resources.kingred;
                    Square27.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][3].status)
            {
                case -2:
                    Square28.BackgroundImage = Properties.Resources.kingblue;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square28.BackgroundImage = Properties.Resources.blue;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square28.BackgroundImage = Properties.Resources.white;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square28.BackgroundImage = Properties.Resources.red;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square28.BackgroundImage = Properties.Resources.kingred;
                    Square28.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][4].status)
            {
                case -2:
                    Square29.BackgroundImage = Properties.Resources.kingblue;
                    Square29.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square29.BackgroundImage = Properties.Resources.blue;
                    Square29.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square29.BackgroundImage = Properties.Resources.black;
                    Square29.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square29.BackgroundImage = Properties.Resources.red;
                    Square29.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square29.BackgroundImage = Properties.Resources.kingred;
                    Square29.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][5].status)
            {
                case -2:
                    Square30.BackgroundImage = Properties.Resources.kingblue;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square30.BackgroundImage = Properties.Resources.blue;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square30.BackgroundImage = Properties.Resources.white;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square30.BackgroundImage = Properties.Resources.red;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square30.BackgroundImage = Properties.Resources.kingred;
                    Square30.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][6].status)
            {
                case -2:
                    Square31.BackgroundImage = Properties.Resources.kingblue;
                    Square31.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square31.BackgroundImage = Properties.Resources.blue;
                    Square31.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square31.BackgroundImage = Properties.Resources.black;
                    Square31.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square31.BackgroundImage = Properties.Resources.red;
                    Square31.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square31.BackgroundImage = Properties.Resources.kingred;
                    Square31.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[3][7].status)
            {
                case -2:
                    Square32.BackgroundImage = Properties.Resources.kingblue;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square32.BackgroundImage = Properties.Resources.blue;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square32.BackgroundImage = Properties.Resources.white;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square32.BackgroundImage = Properties.Resources.red;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square32.BackgroundImage = Properties.Resources.kingred;
                    Square32.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][0].status)
            {
                case -2:
                    Square33.BackgroundImage = Properties.Resources.kingblue;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square33.BackgroundImage = Properties.Resources.blue;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square33.BackgroundImage = Properties.Resources.white;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square33.BackgroundImage = Properties.Resources.red;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square33.BackgroundImage = Properties.Resources.kingred;
                    Square33.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][1].status)
            {
                case -2:
                    Square34.BackgroundImage = Properties.Resources.kingblue;
                    Square34.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square34.BackgroundImage = Properties.Resources.blue;
                    Square34.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square34.BackgroundImage = Properties.Resources.black;
                    Square34.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square34.BackgroundImage = Properties.Resources.red;
                    Square34.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square34.BackgroundImage = Properties.Resources.kingred;
                    Square34.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][2].status)
            {
                case -2:
                    Square35.BackgroundImage = Properties.Resources.kingblue;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square35.BackgroundImage = Properties.Resources.blue;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square35.BackgroundImage = Properties.Resources.white;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square35.BackgroundImage = Properties.Resources.red;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square35.BackgroundImage = Properties.Resources.kingred;
                    Square35.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][3].status)
            {
                case -2:
                    Square36.BackgroundImage = Properties.Resources.kingblue;
                    Square36.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square36.BackgroundImage = Properties.Resources.blue;
                    Square36.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square36.BackgroundImage = Properties.Resources.black;
                    Square36.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square36.BackgroundImage = Properties.Resources.red;
                    Square36.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square36.BackgroundImage = Properties.Resources.kingred;
                    Square36.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][4].status)
            {
                case -2:
                    Square37.BackgroundImage = Properties.Resources.kingblue;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square37.BackgroundImage = Properties.Resources.blue;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square37.BackgroundImage = Properties.Resources.white;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square37.BackgroundImage = Properties.Resources.red;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square37.BackgroundImage = Properties.Resources.kingred;
                    Square37.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][5].status)
            {
                case -2:
                    Square38.BackgroundImage = Properties.Resources.kingblue;
                    Square38.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square38.BackgroundImage = Properties.Resources.blue;
                    Square38.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square38.BackgroundImage = Properties.Resources.black;
                    Square38.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square38.BackgroundImage = Properties.Resources.red;
                    Square38.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square38.BackgroundImage = Properties.Resources.kingred;
                    Square38.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][6].status)
            {
                case -2:
                    Square39.BackgroundImage = Properties.Resources.kingblue;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square39.BackgroundImage = Properties.Resources.blue;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square39.BackgroundImage = Properties.Resources.white;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square39.BackgroundImage = Properties.Resources.red;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square39.BackgroundImage = Properties.Resources.kingred;
                    Square39.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[4][7].status)
            {
                case -2:
                    Square40.BackgroundImage = Properties.Resources.kingblue;
                    Square40.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square40.BackgroundImage = Properties.Resources.blue;
                    Square40.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square40.BackgroundImage = Properties.Resources.black;
                    Square40.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square40.BackgroundImage = Properties.Resources.red;
                    Square40.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square40.BackgroundImage = Properties.Resources.kingred;
                    Square40.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][0].status)
            {
                case -2:
                    Square41.BackgroundImage = Properties.Resources.kingblue;
                    Square41.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square41.BackgroundImage = Properties.Resources.blue;
                    Square41.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square41.BackgroundImage = Properties.Resources.black;
                    Square41.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square41.BackgroundImage = Properties.Resources.red;
                    Square41.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square41.BackgroundImage = Properties.Resources.kingred;
                    Square41.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][1].status)
            {
                case -2:
                    Square42.BackgroundImage = Properties.Resources.kingblue;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square42.BackgroundImage = Properties.Resources.blue;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square42.BackgroundImage = Properties.Resources.white;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square42.BackgroundImage = Properties.Resources.red;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square42.BackgroundImage = Properties.Resources.kingred;
                    Square42.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][2].status)
            {
                case -2:
                    Square43.BackgroundImage = Properties.Resources.kingblue;
                    Square43.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square43.BackgroundImage = Properties.Resources.blue;
                    Square43.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square43.BackgroundImage = Properties.Resources.black;
                    Square43.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square43.BackgroundImage = Properties.Resources.red;
                    Square43.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square43.BackgroundImage = Properties.Resources.kingred;
                    Square43.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][3].status)
            {
                case -2:
                    Square44.BackgroundImage = Properties.Resources.kingblue;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square44.BackgroundImage = Properties.Resources.blue;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square44.BackgroundImage = Properties.Resources.white;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square44.BackgroundImage = Properties.Resources.red;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square44.BackgroundImage = Properties.Resources.kingred;
                    Square44.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][4].status)
            {
                case -2:
                    Square45.BackgroundImage = Properties.Resources.kingblue;
                    Square45.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square45.BackgroundImage = Properties.Resources.blue;
                    Square45.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square45.BackgroundImage = Properties.Resources.black;
                    Square45.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square45.BackgroundImage = Properties.Resources.red;
                    Square45.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square45.BackgroundImage = Properties.Resources.kingred;
                    Square45.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][5].status)
            {
                case -2:
                    Square46.BackgroundImage = Properties.Resources.kingblue;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square46.BackgroundImage = Properties.Resources.blue;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square46.BackgroundImage = Properties.Resources.white;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square46.BackgroundImage = Properties.Resources.red;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square46.BackgroundImage = Properties.Resources.kingred;
                    Square46.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][6].status)
            {
                case -2:
                    Square47.BackgroundImage = Properties.Resources.kingblue;
                    Square47.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square47.BackgroundImage = Properties.Resources.blue;
                    Square47.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square47.BackgroundImage = Properties.Resources.black;
                    Square47.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square47.BackgroundImage = Properties.Resources.red;
                    Square47.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square47.BackgroundImage = Properties.Resources.kingred;
                    Square47.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[5][7].status)
            {
                case -2:
                    Square48.BackgroundImage = Properties.Resources.kingblue;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square48.BackgroundImage = Properties.Resources.blue;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square48.BackgroundImage = Properties.Resources.white;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square48.BackgroundImage = Properties.Resources.red;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square48.BackgroundImage = Properties.Resources.kingred;
                    Square48.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][0].status)
            {
                case -2:
                    Square49.BackgroundImage = Properties.Resources.kingblue;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square49.BackgroundImage = Properties.Resources.blue;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square49.BackgroundImage = Properties.Resources.white;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square49.BackgroundImage = Properties.Resources.red;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square49.BackgroundImage = Properties.Resources.kingred;
                    Square49.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][1].status)
            {
                case -2:
                    Square50.BackgroundImage = Properties.Resources.kingblue;
                    Square50.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square50.BackgroundImage = Properties.Resources.blue;
                    Square50.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square50.BackgroundImage = Properties.Resources.black;
                    Square50.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square50.BackgroundImage = Properties.Resources.red;
                    Square50.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square50.BackgroundImage = Properties.Resources.kingred;
                    Square50.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][2].status)
            {
                case -2:
                    Square51.BackgroundImage = Properties.Resources.kingblue;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square51.BackgroundImage = Properties.Resources.blue;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square51.BackgroundImage = Properties.Resources.white;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square51.BackgroundImage = Properties.Resources.red;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square51.BackgroundImage = Properties.Resources.kingred;
                    Square51.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][3].status)
            {
                case -2:
                    Square52.BackgroundImage = Properties.Resources.kingblue;
                    Square52.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square52.BackgroundImage = Properties.Resources.blue;
                    Square52.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square52.BackgroundImage = Properties.Resources.black;
                    Square52.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square52.BackgroundImage = Properties.Resources.red;
                    Square52.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square52.BackgroundImage = Properties.Resources.kingred;
                    Square52.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][4].status)
            {
                case -2:
                    Square53.BackgroundImage = Properties.Resources.kingblue;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square53.BackgroundImage = Properties.Resources.blue;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square53.BackgroundImage = Properties.Resources.white;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square53.BackgroundImage = Properties.Resources.red;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square53.BackgroundImage = Properties.Resources.kingred;
                    Square53.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][5].status)
            {
                case -2:
                    Square54.BackgroundImage = Properties.Resources.kingblue;
                    Square54.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square54.BackgroundImage = Properties.Resources.blue;
                    Square54.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square54.BackgroundImage = Properties.Resources.black;
                    Square54.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square54.BackgroundImage = Properties.Resources.red;
                    Square54.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square54.BackgroundImage = Properties.Resources.kingred;
                    Square54.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][6].status)
            {
                case -2:
                    Square55.BackgroundImage = Properties.Resources.kingblue;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square55.BackgroundImage = Properties.Resources.blue;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square55.BackgroundImage = Properties.Resources.white;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square55.BackgroundImage = Properties.Resources.red;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square55.BackgroundImage = Properties.Resources.kingred;
                    Square55.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[6][7].status)
            {
                case -2:
                    Square56.BackgroundImage = Properties.Resources.kingblue;
                    Square56.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square56.BackgroundImage = Properties.Resources.blue;
                    Square56.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square56.BackgroundImage = Properties.Resources.black;
                    Square56.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square56.BackgroundImage = Properties.Resources.red;
                    Square56.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square56.BackgroundImage = Properties.Resources.kingred;
                    Square56.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][0].status)
            {
                case -2:
                    Square57.BackgroundImage = Properties.Resources.kingblue;
                    Square57.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square57.BackgroundImage = Properties.Resources.blue;
                    Square57.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square57.BackgroundImage = Properties.Resources.black;
                    Square57.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square57.BackgroundImage = Properties.Resources.red;
                    Square57.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square57.BackgroundImage = Properties.Resources.kingred;
                    Square57.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][1].status)
            {
                case -2:
                    Square58.BackgroundImage = Properties.Resources.kingblue;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square58.BackgroundImage = Properties.Resources.blue;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square58.BackgroundImage = Properties.Resources.white;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square58.BackgroundImage = Properties.Resources.red;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square58.BackgroundImage = Properties.Resources.kingred;
                    Square58.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][2].status)
            {
                case -2:
                    Square59.BackgroundImage = Properties.Resources.kingblue;
                    Square59.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square59.BackgroundImage = Properties.Resources.blue;
                    Square59.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square59.BackgroundImage = Properties.Resources.black;
                    Square59.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square59.BackgroundImage = Properties.Resources.red;
                    Square59.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square59.BackgroundImage = Properties.Resources.kingred;
                    Square59.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][3].status)
            {
                case -2:
                    Square60.BackgroundImage = Properties.Resources.kingblue;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square60.BackgroundImage = Properties.Resources.blue;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square60.BackgroundImage = Properties.Resources.white;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square60.BackgroundImage = Properties.Resources.red;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square60.BackgroundImage = Properties.Resources.kingred;
                    Square60.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][4].status)
            {
                case -2:
                    Square61.BackgroundImage = Properties.Resources.kingblue;
                    Square61.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square61.BackgroundImage = Properties.Resources.blue;
                    Square61.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square61.BackgroundImage = Properties.Resources.black;
                    Square61.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square61.BackgroundImage = Properties.Resources.red;
                    Square61.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square61.BackgroundImage = Properties.Resources.kingred;
                    Square61.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][5].status)
            {
                case -2:
                    Square62.BackgroundImage = Properties.Resources.kingblue;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square62.BackgroundImage = Properties.Resources.blue;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square62.BackgroundImage = Properties.Resources.white;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square62.BackgroundImage = Properties.Resources.red;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square62.BackgroundImage = Properties.Resources.kingred;
                    Square62.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][6].status)
            {
                case -2:
                    Square63.BackgroundImage = Properties.Resources.kingblue;
                    Square63.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square63.BackgroundImage = Properties.Resources.blue;
                    Square63.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square63.BackgroundImage = Properties.Resources.black;
                    Square63.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square63.BackgroundImage = Properties.Resources.red;
                    Square63.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square63.BackgroundImage = Properties.Resources.kingred;
                    Square63.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
            switch (currentGame.checkerboard[7][7].status)
            {
                case -2:
                    Square64.BackgroundImage = Properties.Resources.kingblue;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case -1:
                    Square64.BackgroundImage = Properties.Resources.blue;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 0:
                    Square64.BackgroundImage = Properties.Resources.white;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 1:
                    Square64.BackgroundImage = Properties.Resources.red;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    Square64.BackgroundImage = Properties.Resources.kingred;
                    Square64.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }

        }

        private void Square1_Click(object sender, EventArgs e)
        {
          
        }
    }
}