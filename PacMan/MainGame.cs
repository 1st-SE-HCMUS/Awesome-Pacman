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
        Manager manager = new Manager();
        List<Character> listCharacter = new List<Character>();
        
        public MainGame()
        {
            InitializeComponent();
            manager.ReadFileMap();

            
            Pacman pacman = new Pacman();
            EnemyBlue blue = new EnemyBlue(new Point(15, 14));
            EnemyRed red = new EnemyRed(new Point(18, 14));
            EnemyPink pink = new EnemyPink(new Point(21, 14));
            EnemyOrange orange = new EnemyOrange(new Point(5, 17));

            listCharacter.Add(blue);
            listCharacter.Add(red);
            listCharacter.Add(pink);
            listCharacter.Add(orange);
            listCharacter.Add(pacman);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            manager.RunInPaint(g, listCharacter);
        }

        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        private void timerRefresh(object sender, EventArgs e)
        {
            manager.CharacterBehavior(listCharacter);
            Invalidate();
        }

        private void timer_Sprite_Animation_Speed_Tick(object sender, EventArgs e)
        {
        }
    }
}
