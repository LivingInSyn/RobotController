using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.helpers
{
    public class ParserReturn
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public ObstacleHolder ObstacleHolder { get; set; }
        public char[] Steps { get; set; }
    }
}
