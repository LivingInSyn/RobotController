using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.obstacles;

namespace RobotController.helpers
{
    public class JsonFileFormat
    {
        public JsonFileFormat()
        {
            ObstacleObjects = new List<ObstacleSetupObj>();
        }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string Steps { get; set; }
        public List<ObstacleSetupObj> ObstacleObjects { get; set; }
    }
}
