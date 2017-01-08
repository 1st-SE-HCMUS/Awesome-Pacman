using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace PacMan
{
    public partial class MainGame : Form
    {
        Graphics grs;
        GameManager manager;
        int gameTickCount = 0;
       
        
        public MainGame()
        {
            InitializeComponent();
            manager = GameManager.GetInstance();
            timer_game.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            manager.OnPaint(e.Graphics);
        }

        

        

        private void timerRefresh(object sender, EventArgs e)
        {
            manager.CharacterBehavior();
            Invalidate();
        }

        private void timer_game_Tick(object sender, EventArgs e)
        {
            gameTickCount++;

            if(gameTickCount >= manager.GetGameModeTime())
            {
                manager.ChangeGhostMode();
                gameTickCount = 0;
            }

            Debug.WriteLine("Game tick count: " + gameTickCount.ToString());
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            if (manager == null)
                manager = GameManager.GetInstance();
        }
    }
}
