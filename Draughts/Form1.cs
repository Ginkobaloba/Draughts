﻿using System;
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
            currentGame.turn = 0;
            currentGame.square1 = 1;
            currentGame.square3 = 1;
            currentGame.square5 = 1;
            currentGame.square7 = 1;
            currentGame.square10 = 1;
            currentGame.square12 = 1;
            currentGame.square14 = 1;
            currentGame.square16 = 1;
            currentGame.square17 = 1;
            currentGame.square19 = 1;
            currentGame.square21 = 1;
            currentGame.square23 = 1;
            currentGame.square42 = -1;
            currentGame.square44 = -1;
            currentGame.square46 = -1;
            currentGame.square48 = -1;
            currentGame.square49 = -1;
            currentGame.square51 = -1;
            currentGame.square53 = -1;
            currentGame.square55 = -1;
            currentGame.square58 = -1;
            currentGame.square60 = -1;
            currentGame.square62 = -1;
            currentGame.square64 = -1;



            return currentGame;
        }



        public void LinkToGUI(GameInfo currentGame)
        {

            switch (currentGame.square1)
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

            

            switch (currentGame.square3)
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

            

            switch (currentGame.square5)
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

           

            switch (currentGame.square7)
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

          

            switch (currentGame.square10)
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

           
            switch (currentGame.square12)
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
            
            switch (currentGame.square14)
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
           
            switch (currentGame.square16)
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
            switch (currentGame.square17)
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
            
            switch (currentGame.square19)
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
            
            switch (currentGame.square21)
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
           
            switch (currentGame.square23)
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
           
            
            switch (currentGame.square26)
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

            switch (currentGame.square28)
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
            
            switch (currentGame.square30)
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
            
            switch (currentGame.square32)
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
            switch (currentGame.square33)
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
            
            switch (currentGame.square35)
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
            
            switch (currentGame.square37)
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
            
            switch (currentGame.square39)
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
            
       
            switch (currentGame.square42)
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
            
            switch (currentGame.square44)
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
            
            switch (currentGame.square46)
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
            
            switch (currentGame.square48)
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
            switch (currentGame.square49)
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
            
            switch (currentGame.square51)
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
            
            switch (currentGame.square53)
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
            
            switch (currentGame.square55)
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
            
            
            switch (currentGame.square58)
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
            
            switch (currentGame.square60)
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
            
            switch (currentGame.square62)
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
            
            switch (currentGame.square64)
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