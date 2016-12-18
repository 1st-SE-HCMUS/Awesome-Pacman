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
        List<Character> listCharacter = new List<Character>();
        
        public Pacman()
        {
            InitializeComponent();
            manager.readFileMap();

            
            Character_Pacman pacman = new Character_Pacman();
            listCharacter.Add(pacman);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            manager.runInPaint(g, listCharacter);
        }

        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        private void timerRefresh(object sender, EventArgs e)
        {
            manager.characterBehavior(listCharacter);
            Invalidate();
        }

        private void timer_Sprite_Animation_Speed_Tick(object sender, EventArgs e)
        {
        }

        
    }
}
