using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.helpers
{
    public class Point
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }

        public Point(int x, int y)
        {
            XPoint = x;
            YPoint = y;
        }

        public Point()
        {
        }
        
    }
}
