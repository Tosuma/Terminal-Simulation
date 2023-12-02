using SimulationTest;
using System.Text;


class Program
{
    public int Width = 150;
    public int Height = 40;
    public Ball Ball = new Ball();
    public (int x, int y) prevPos = (0,1);
    public (double x, double y) Gravity = (0, -10);
    public double TimeStep = (1.0 / 60.0);

    public static void Main()
    {
        Program sim = new Program();
        string line = sim.DrawLine();
        Console.WriteLine(line);

        while (true)
        {
            sim.Simulate();
            sim.Draw();
            Thread.Sleep(1);
        }
    }

    // Old way of rendering the ball
    //private void Draw()
    //{
    //    StringBuilder sb = new StringBuilder();
    //    sb.AppendLine(DrawLine());
    //    for (int i = 0; i < Height; i++)
    //    {
    //        for (int j = 0; j < Width; j++)
    //        {
    //            if(Math.Floor(Ball.Pos.y) == i && Math.Floor(Ball.Pos.x) == j)
    //            {
    //                sb.Append('o');
    //                i = Height;
    //                j = Width;
    //            }
    //            else
    //            {
    //                sb.Append(' ');
    //            }
    //        }
    //        sb.Append('\n');
    //    }
    //    Console.Clear();
    //    Console.WriteLine(sb.ToString());
    //}

    private void Draw()
    {
        Console.SetCursorPosition(prevPos.x, prevPos.y);
        Console.Write(' ');
        Console.SetCursorPosition((int) Ball.Pos.x, (int) Ball.Pos.y);
        Console.Write('o');
        Console.CursorVisible = false;
    }

    private void Simulate()
    {
        prevPos.x = (int) Ball.Pos.x;
        prevPos.y = (int) Ball.Pos.y;
        Ball.Vel.x += Gravity.x * TimeStep;
        Ball.Vel.y += Gravity.y * TimeStep;
        Ball.Pos.x += Ball.Vel.x * TimeStep;
        Ball.Pos.y += Ball.Vel.y * TimeStep;
        
        if (Ball.Pos.x < 1.0) // if ball is out of left bound
        {
            Ball.Pos.x = 1.0;
            Ball.Vel.x = -Ball.Vel.x;
        }
        if (Ball.Pos.x > Width) // if ball is out of right bound
        {
            Ball.Pos.x = Width;
            Ball.Vel.x = -Ball.Vel.x;
        }
        if (Ball.Pos.y < 1.0) // if ball is out of bottom bound
        {
            Ball.Pos.y = 1.0;
            Ball.Vel.y = -Ball.Vel.y;
        }
        if (Ball.Pos.y > Height) // if ball is out of top bound
        {
            Ball.Pos.y = Height;
            Ball.Vel.y = -Ball.Vel.y;
        }
    }

    private string DrawLine()
    {
        return '+' + new string('-', Width) + '+';
    }
}