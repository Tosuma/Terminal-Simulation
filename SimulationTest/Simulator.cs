using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTest
{
    public class Simulator
    {
        public int Width;
        public int Height;
        public double TimeStep = (1.0 / 60.0);
        public (double x, double y) Gravity = (0, -10);

        public char[,] ballLocation = { { LowerLeft, LowerRight }, { UpperLeft, UpperRight } };
        public static char LowerLeft = '\u2596';
        public static char LowerRight = '\u2597';
        public static char UpperLeft = '\u2598';
        public static char UpperRight = '\u259D';

        public void StartSim()
        {
            Initialize(150, 40);

            Ball ball = new Ball(0, 0, 15, 20, TimeStep);
            while (true)
            {
                Simulate(ball);
                Draw(ball);
                Thread.Sleep(1);
            }
        }

        public void Initialize(int width, int height)
        {
            Width = width;
            Height = height;

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width + 10, Height + 10);
            Console.Clear();
            string line = DrawLine();
            Console.WriteLine(line);
        }
        
        
        private void Draw(Ball ball)
        {
            Console.SetCursorPosition((int)Math.Round(ball.PrevPos.x), (int)Math.Round(ball.PrevPos.y));
            Console.Write(' ');
            Console.SetCursorPosition((int)Math.Round(ball.Pos.x), (int)Math.Round(ball.Pos.y));
            Console.WriteLine(ChooseCharToDraw(ball));
        }

        private char ChooseCharToDraw(Ball ball)
        {
            double x = ball.Pos.x % 1;
            double y = ball.Pos.y % 1;

            int horizontalLocation;
            int verticalLocation;

            if (x < 0.5) horizontalLocation = 0; else horizontalLocation = 1;
            if (y < 0.5) verticalLocation = 0; else verticalLocation = 1;

            return ballLocation[verticalLocation, horizontalLocation];
        }



        private string DrawLine()
        {
            return '+' + new string('-', Width) + '+';
        }

        public void Simulate(Ball ball)
        {
            ball.PrevPos.x = (int)Math.Round(ball.Pos.x);
            ball.PrevPos.y = (int)Math.Round(ball.Pos.y);
            ball.Vel.x += Gravity.x * TimeStep;
            ball.Vel.y += Gravity.y * TimeStep;
            ball.Pos.x += ball.Vel.x * TimeStep;
            ball.Pos.y += ball.Vel.y * TimeStep;

            if (ball.Pos.x < 1.0) // if ball is out of left bound
            {
                ball.Pos.x = 1.0;
                ball.Vel.x = -ball.Vel.x;
            }
            if (ball.Pos.x > Width) // if ball is out of right bound
            {
                ball.Pos.x = Width;
                ball.Vel.x = -ball.Vel.x;
            }
            if (ball.Pos.y < 1.0) // if ball is out of bottom bound
            {
                ball.Pos.y = 1.0;
                ball.Vel.y = -ball.Vel.y;
            }
            if (ball.Pos.y > Height) // if ball is out of top bound
            {
                ball.Pos.y = Height;
                ball.Vel.y = -ball.Vel.y;
            }
        }
    }
}
