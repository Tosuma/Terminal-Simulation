using SimulationTest;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SimulationTest
{
    class Program
    {
        public static void Main()
        {
            Simulator simulator = new Simulator();
            simulator.StartSim();
        }
    }
}
