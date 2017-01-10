using PacMan.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Enemy : Character
    {
        protected EnemyMode Mode;
        /// <summary>
        /// Character's last performed move. Auxiliary variable to help scene drwiwng process.
        /// </summary>
        public Direction lastMove { get; set; }

        public EnemyMode GetMode()
        {
            return Mode;
        }
        public enum EnemyMode { Scatter, Chase, Pissed}
        protected Pathfinder pathfinder;
        private Stack<Direction> pathToPac;
        public int Score = 1500;
        protected bool reachedCorner;
        protected GameMap.Pos turnPoint;


        public Enemy()
        {
            MapPosition = new GameMap.Pos(14, 15);
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
            Mode = EnemyMode.Scatter;
            Speed = 3f;
            reachedCorner = false;
            pathfinder = new Pathfinder();
        }

        public void Chase()
        {
            Mode = EnemyMode.Chase;
        }

        public void Scatter()
        {
            Mode = EnemyMode.Scatter;
        }

        protected int ChooseWayToGo(GameMap map, GameMap.Pos pacmanPosition)
        {
            // Got that bastard!!!
            if (reachedPacman(map, pacmanPosition))
            {
                // set on future respawn position
                //System.Windows.Forms.MessageBox.Show("Gotcha");
            }
            else if(getPathToPac() != null)
            {
                Stack<Direction> stack = getPathToPac();
                Direction dir = getPathToPac().Pop();
               
                lastMove = dir;

                if(dir == Direction.Left)
                {
                    ChangeDirection(Direction.Left);
                    Debug.WriteLine("Left");
                }
                else if(dir == Direction.Right)
                {
                    ChangeDirection(Direction.Right);
                    Debug.WriteLine("Right");
                }
                else if(dir == Direction.Up)
                {
                    ChangeDirection(Direction.Up);
                    Debug.WriteLine("Up");
                }
                else if(dir == Direction.Down)
                {
                    ChangeDirection(Direction.Down);
                    Debug.WriteLine("Down");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error");
                }

                /*
                switch (dir)
                {
                    case Direction.Left:
                        ChangeDirection(Direction.Left);
                        Debug.WriteLine("Left");
                        //System.Windows.Forms.MessageBox.Show("Left");
                        break;

                    case Direction.Right:
                        ChangeDirection(Direction.Right);
                        Debug.WriteLine("Right");
                        //System.Windows.Forms.MessageBox.Show("Right");
                        break;

                    case Direction.Up:
                        ChangeDirection(Direction.Up);
                        Debug.WriteLine("Up");
                        //System.Windows.Forms.MessageBox.Show("Up");
                        break;

                    case Direction.Down:
                        ChangeDirection(Direction.Down);
                        Debug.WriteLine("Down");
                        //System.Windows.Forms.MessageBox.Show("Down");
                        break;

                    default:
                        System.Windows.Forms.MessageBox.Show("Error");
                        break;
                }
                 */ 

                return 1;
            }

            return 0;
        }

        private bool reachedPacman(GameMap map, GameMap.Pos pacmanPos)
        {
            if ((MapPosition.X == pacmanPos.X) &&
                (MapPosition.Y == pacmanPos.Y))
                return true;

            return calcPathToPac(map, pacmanPos);
        }

        /*********************************************************************/
        /* Class Methods */
        /*********************************************************************/
        /// <summary>
        /// Calculates and returns, if possible, best route for ghost to reach pacman.
        /// </summary>
        /// <param name="map">Map used in search algorithm.</param>
        /// <param name="pacpos">Pacman's position in map.</param>
        public bool calcPathToPac(GameMap map, GameMap.Pos pacpos)
        {
            pathToPac = pathfinder.findBestPath(map, this.MapPosition, pacpos);

            if ((pathToPac != null) && (pathToPac.Count != 0))
                return false;
            return true;
        }

        /// <summary>
        /// Returns Direction stack that represents the best path to reach pacman.
        /// </summary>
        public Stack<Direction> getPathToPac()
        {
            return pathToPac;
        }

        public Direction GetLeftDirection(Direction dir)
        {
            switch(dir)
            {
                case Direction.Down:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Down;
            }

            return Direction.Left;
        }

        public Direction GetRightDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    return Direction.Left;
                case Direction.Right:
                    return Direction.Down;
                case Direction.Up:
                    return Direction.Right;
                case Direction.Left:
                    return Direction.Up;
            }

            return Direction.Left;
        }

        public bool CheckAvailableWay(Direction dir)
        {
            switch(dir)
            {
                case Direction.Down:
                    if (GameManager.GetInstance().GetMap().getSpaceType(MapPosition + GameMap.UnitY) == GameMap.SpaceType.Empty)
                        return true;
                    break;
                case Direction.Right:
                    if (GameManager.GetInstance().GetMap().getSpaceType(MapPosition + GameMap.UnitX) == GameMap.SpaceType.Empty)
                        return true;
                    break;
                case Direction.Up:
                    if (GameManager.GetInstance().GetMap().getSpaceType(MapPosition - GameMap.UnitY) == GameMap.SpaceType.Empty)
                        return true;
                    break;
                case Direction.Left:
                    if (GameManager.GetInstance().GetMap().getSpaceType(MapPosition - GameMap.UnitX) == GameMap.SpaceType.Empty)
                        return true;
                    break;
            }

            return false;
        }
    }
}
