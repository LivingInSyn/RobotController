using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.helpers;

namespace RobotController.robots
{
    public interface IRobot
    {
        Point GetLocation();
        List<Point> GetPath();
        void Move(char direction);
    }
}
