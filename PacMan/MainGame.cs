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


namespace PacMan
{
    public partial class MainGame : Form
    {
        Graphics grs;
        GameManager manager;
       
        
        public MainGame()
        {
            InitializeComponent();
            manager = new GameManager();
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
    }
}
