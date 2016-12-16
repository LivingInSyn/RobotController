using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.obstacles;

namespace RobotController.helpers
{
    public class ObstacleHolder
    {
        private IObstacle[,] _obstacleArray;
        /// <summary>
        /// Builds an ObstacleHolder
        /// </summary>
        /// <param name="xSize">Should be set the same size as the grid in the X direction</param>
        /// <param name="ySize">Should be set the same size as the grid in the Y direction</param>
        public ObstacleHolder(int xSize, int ySize)
        {
            _obstacleArray = new IObstacle[xSize, ySize];
        }

        /// <summary>
        /// Sets an obstacle at (x,y)
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="y">y location</param>
        /// <param name="obstacle">Obstacle to set</param>
        public void SetObstacle(int x, int y, IObstacle obstacle)
        {
            _obstacleArray[y, x] = obstacle;
        }

        /// <summary>
        /// Sets an obstacle at the given point
        /// </summary>
        /// <param name="point">Point to put the obstacle at</param>
        /// <param name="obstacle">Obstacle to place there</param>
        public void SetObstacle(Point point, IObstacle obstacle)
        {
            SetObstacle(point.XPoint, point.YPoint, obstacle);
        }

        /// <summary>
        /// Gets an obstacle at (x,y)
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <returns>Obstacle at x,y or NULL</returns>
        public IObstacle GetObstacle(int x, int y)
        {
            return _obstacleArray[y, x];
        }

        /// <summary>
        /// gets an obstacle at 'point'
        /// </summary>
        /// <param name="point">Point to query for an obstacle</param>
        /// <returns>Obstacle at the point or NULL</returns>
        public IObstacle GetObstacle(Point point)
        {
            return GetObstacle(point.XPoint, point.YPoint);
        }
    }
}
