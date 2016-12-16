using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.obstacles
{
    public class Spinner : IObstacle
    {
        /// <summary>
        /// Builds a spinner
        /// </summary>
        /// <param name="direction">True for Clockwise, False for CCW</param>
        /// <param name="turns">Number of 90 degree turns in 'direction'</param>
        public Spinner(bool direction, int turns)
        {
            Direction = direction;
            Turns = turns;
        }

        public bool CanNavigate { get { return true; } }
        /// <summary>
        /// indicates the direction to turn in, CCW or CW. True is CW, False is CCW
        /// </summary>
        public bool Direction { get; set; }
        /// <summary>
        /// indicates the number of turns to make in the Direction specified. 1 = 90 degrees, 2=180, etc.
        /// </summary>
        public int Turns { get; set; }
    }
}
