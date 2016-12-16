using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.obstacles
{
    public class Hole : IObstacle
    {
        /// <summary>
        /// Build a Hole obstacle
        /// </summary>
        /// <param name="x">x location to teleport to</param>
        /// <param name="y">y location to teleport to</param>
        public Hole(int x, int y)
        {
            NewX = x;
            NewY = y;
        }

        public bool CanNavigate { get { return true; } }
        public int NewX { get; set; }
        public int NewY { get; set; }
    }
}
