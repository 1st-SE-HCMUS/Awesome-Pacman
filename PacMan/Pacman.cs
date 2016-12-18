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
            Character_Enemy_Blue blue = new Character_Enemy_Blue(new Point(15, 14));
            Character_Enemy_Red red = new Character_Enemy_Red(new Point(18, 14));
            Character_Enemy_Pink pink = new Character_Enemy_Pink(new Point(21, 14));
            Character_Enemy_Orange orange = new Character_Enemy_Orange(new Point(5, 17));

            listCharacter.Add(blue);
            listCharacter.Add(red);
            listCharacter.Add(pink);
            listCharacter.Add(orange);
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
