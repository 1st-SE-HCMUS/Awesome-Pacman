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
        //Graphics grs;
        GameManager manager;
        int gameTickCount = 0;
       
        
        public MainGame()
        {
            InitializeComponent();
           
            InitNewGame();
        }

        public void InitNewGame()
        {
            
            manager = GameManager.GetInstance();
            manager.Reset();
            manager = GameManager.GetInstance();

            timer_game.Start();
            timer_Afraid.Interval = manager.AfraidTime;
            timer_Afraid.Stop();
            timer_Blink.Stop();
            manager.TimerAfraid = timer_Afraid;
            labelGameOver.Visible = false;
            labelRestart.Visible = false;
            labelStart.Visible = true;
            labelGameTitle.Visible = true;
            labelScore.Visible = false;
            timer_Blink.Interval = manager.AfraidTime / 3;
            manager.TimerBlink = timer_Blink;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(manager.CurrentStage == GameManager.GameStage.Playing)
            {
                manager.OnPlaying(e.Graphics);
                manager.ShowScore(labelScore);
            }
            if(manager.CurrentStage == GameManager.GameStage.Win)
            {
                manager.MngSound.Stop(Controller.SoundManager.SOUND.Siren);
                labelGameOver.Text = "YOU WIN!";
                labelGameOver.Visible = true;
                labelRestart.Visible = true;
            }
            if (manager.CurrentStage == GameManager.GameStage.GameOver)
            {
                labelGameOver.Text = "GAME OVER!";
                labelGameOver.Visible = true;
                labelRestart.Visible = true;
            }
            if(manager.CurrentStage == GameManager.GameStage.Menu)
            { 

                labelStart.Visible = true;
                labelGameTitle.Visible = true;
            }

        }
        

        private void timerRefresh(object sender, EventArgs e)
        {
            if (manager != null)
            {
                manager.CharacterBehavior();
            }
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

        private void timer_Afraid_Tick(object sender, EventArgs e)
        {
            if (manager != null)
            {
                for (int i = 0; i < manager.ListEnemy.Count; i++)
                {
                    manager.ListEnemy[i].State = Character.CharacterState.Blinking;
                }
                timer_Blink.Start();
            }
        }

        private void timer_Blink_Tick(object sender, EventArgs e)
        {
            if (manager != null)
            {
                for (int i = 0; i < manager.ListEnemy.Count; i++)
                {
                    manager.ListEnemy[i].State = Character.CharacterState.Alive;
                }
                timer_Blink.Stop();
                timer_Afraid.Stop();
            }
        }

        private void label_Restart_Click(object sender, EventArgs e)
        {
            InitNewGame();
            manager.MngSound.Play(Controller.SoundManager.SOUND.Siren, true);
            manager.CurrentStage = GameManager.GameStage.Playing;
            labelScore.Visible = true;
            labelGameTitle.Visible = false;
            labelStart.Visible = false;
            labelScore.Visible = true;
            labelGameTitle.Visible = false;
            labelStart.Visible = false;
        }

        private void labelStart_Click(object sender, EventArgs e)
        {
            manager.MngSound.Play(Controller.SoundManager.SOUND.Siren, true);
            manager.CurrentStage = GameManager.GameStage.Playing;
            labelScore.Visible = true;
            labelGameTitle.Visible = false;
            labelStart.Visible = false;
        }
    }
}
