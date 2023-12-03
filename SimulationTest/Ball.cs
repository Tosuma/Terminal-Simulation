using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTest
{
    public class Ball
    {
        public (double x, double y) Pos;
        public (double x, double y) Vel;
        public (double x, double y) PrevPos;
        public double TimeStep;

        public Ball(double px, double py, double vx, double vy, double timeStep)
        {
            Pos.x = px;
            Pos.y = py;
            PrevPos.x = px;
            PrevPos.y = py;
            Vel.x = vx;
            Vel.y = vy;
            TimeStep = timeStep;
        }
    }
}
