using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.obstacles
{
    public interface IObstacle
    {
        bool CanNavigate { get; }
    }
}
