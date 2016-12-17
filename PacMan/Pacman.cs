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

    public partial class Pacman : Form
    {
        Manager manager = new Manager();
        PacmanControl pacman = new PacmanControl();

        public Pacman()
        {
            InitializeComponent();
            manager.readFileMap();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            manager.drawMap(g);
            pacman.updatePos(g);
        }

        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        private void timerRefresh(object sender, EventArgs e)
        {
            pacman.behave();
            Invalidate();
        }

        
    }
}
