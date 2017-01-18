namespace PacMan
{
    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer_Refresh_Graphic = new System.Windows.Forms.Timer(this.components);
            this.timer_Sprite_Animation_Speed = new System.Windows.Forms.Timer(this.components);
            this.timer_game = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.timer_Afraid = new System.Windows.Forms.Timer(this.components);
            this.timer_Blink = new System.Windows.Forms.Timer(this.components);
            this.labelRestart = new System.Windows.Forms.Label();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelGameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_Refresh_Graphic
            // 
            this.timer_Refresh_Graphic.Enabled = true;
            this.timer_Refresh_Graphic.Interval = 50;
            this.timer_Refresh_Graphic.Tick += new System.EventHandler(this.timerRefresh);
            // 
            // timer_game
            // 
            this.timer_game.Interval = 1000;
            this.timer_game.Tick += new System.EventHandler(this.timer_game_Tick);
            // 
            // labelScore
            // 
            this.labelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.Crimson;
            this.labelScore.Location = new System.Drawing.Point(12, 23);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(209, 33);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "SCORE: 1000";
            // 
            // timer_Afraid
            // 
            this.timer_Afraid.Enabled = true;
            this.timer_Afraid.Interval = 400;
            this.timer_Afraid.Tick += new System.EventHandler(this.timer_Afraid_Tick);
            // 
            // timer_Blink
            // 
            this.timer_Blink.Tick += new System.EventHandler(this.timer_Blink_Tick);
            // 
            // labelRestart
            // 
            this.labelRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRestart.AutoSize = true;
            this.labelRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestart.ForeColor = System.Drawing.Color.Yellow;
            this.labelRestart.Location = new System.Drawing.Point(230, 370);
            this.labelRestart.Name = "labelRestart";
            this.labelRestart.Size = new System.Drawing.Size(133, 33);
            this.labelRestart.TabIndex = 1;
            this.labelRestart.Text = "Restart?";
            this.labelRestart.Click += new System.EventHandler(this.label_Restart_Click);
            // 
            // labelGameOver
            // 
            this.labelGameOver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.ForeColor = System.Drawing.Color.Cyan;
            this.labelGameOver.Location = new System.Drawing.Point(93, 276);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(418, 58);
            this.labelGameOver.TabIndex = 2;
            this.labelGameOver.Text = "GAME OVER";
            this.labelGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGameOver.Visible = false;
            // 
            // labelStart
            // 
            this.labelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.Cyan;
            this.labelStart.Location = new System.Drawing.Point(199, 334);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(194, 58);
            this.labelStart.TabIndex = 3;
            this.labelStart.Text = "START";
            this.labelStart.Click += new System.EventHandler(this.labelStart_Click);
            // 
            // labelGameTitle
            // 
            this.labelGameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGameTitle.AutoSize = true;
            this.labelGameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameTitle.ForeColor = System.Drawing.Color.DarkOrchid;
            this.labelGameTitle.Location = new System.Drawing.Point(42, 208);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(493, 54);
            this.labelGameTitle.TabIndex = 4;
            this.labelGameTitle.Text = "AWESOME PACMAN";
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(594, 760);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.labelGameTitle);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelRestart);
            this.Controls.Add(this.labelScore);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainGame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_Refresh_Graphic;

        private System.Windows.Forms.Timer timer_Sprite_Animation_Speed;
        private System.Windows.Forms.Timer timer_game;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer timer_Afraid;
        private System.Windows.Forms.Timer timer_Blink;
        private System.Windows.Forms.Label labelRestart;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelGameTitle;
    }
}

