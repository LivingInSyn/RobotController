using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.obstacles
{
    public class Rock : IObstacle
    {
        public bool CanNavigate { get { return false; } }        
    }
}
