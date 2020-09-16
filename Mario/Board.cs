using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    class Board
    {
        private char[,] board = new char[13, 80];
        private int marioX, marioY;

        public Board()
        {
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    this.board[i, j] = ' ';
                }
            }
        }

        public char[,] getBoard()
        {
            return this.board;
        }
        public void clear()
        {
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    this.board[i, j] = ' ';
                }
            }

        }



        public void Print()
        {
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    //if (j >= marioX && j < marioX + 2)
                       // Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.Write(board[i, j]);
                   // Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public void addToBoard(List<Obstacle> obstacles)
        {
            foreach(Obstacle obst in obstacles)
            {
                if (obst.isVisible())
                {
                    for (int yy = 0; yy <= obst.getObstacle().GetUpperBound(0); yy++)
                    {
                        for (int xx = 0; xx <= obst.getObstacle().GetUpperBound(1); xx++)
                        {
                            this.board[this.board.GetUpperBound(0) - obst.getObstacle().GetUpperBound(0) + yy - obst.getY(), xx + obst.getX()] = obst.getObstacle()[yy, xx];
                           

                        }
                    }
                }
            }
        }
        public void addToBoard(Sprite mario)
        {
            this.marioX = mario.getX();
            this.marioY = mario.getY();
            
            for (int yy = 0; yy <= mario.getSprite().GetUpperBound(0); yy++)
            {
                for (int xx = 0; xx <= mario.getSprite().GetUpperBound(1); xx++)
                {
                    this.board[this.board.GetUpperBound(0)-mario.getSprite().GetUpperBound(0)+yy- mario.getY(), xx + mario.getX()] = mario.getSprite()[yy , xx ];
                    
                    
                }
            }
        }

        public bool Collision(Sprite mario,List<Obstacle> obstacles)
        {

            foreach (Obstacle obstacle in obstacles)
            {

                if ((marioX + mario.getW() >= obstacle.getX()+2 ) && (marioY <= obstacle.getY() + obstacle.getH()) && (marioY+mario.getH()>=obstacle.getY()) && marioX < obstacle.getX() + obstacle.getW() )
                    return true;

            }

            return false;
            
        }

        public bool canObstacleVisible(Obstacle obstacle, List<Obstacle> obstacles, int level)
        {
            foreach(Obstacle obst in obstacles)
            {
                if(obst!=obstacle&& !obstacle.isVisible() )
                {
                    if (obst.getX()>board.GetUpperBound(1)-(35/(level+1)) && obst.isVisible() )
                        return false;
                }
                
            }
            return true;

        }

        

    }
}
